using CustomerFunctionApp.Data;
using CustomerFunctionApp.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

public class CustomerFunction
{
    private readonly AppDbContext _context;

    public CustomerFunction(AppDbContext context)
    {
        _context = context;
    }

    [Function("CreateCustomer")]
    [OpenApiOperation(operationId: "CreateCustomer", tags: new[] { "Customer" })]
    [OpenApiRequestBody("application/json", typeof(Customer))]
    [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Customer))]
    public async Task<HttpResponseData> CreateCustomer(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "customer")] HttpRequestData req)
    {
        var body = await new StreamReader(req.Body).ReadToEndAsync();
        var customer = JsonConvert.DeserializeObject<Customer>(body);

        customer.Id = Guid.NewGuid();

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(customer);
        return response;
    }

    [Function("GetCustomers")]
    [OpenApiOperation(operationId: "GetCustomers", tags: new[] { "Customer" })]
    [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(List<Customer>))]
    public async Task<HttpResponseData> GetCustomers(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "customer")] HttpRequestData req)
    {
        var customers = await _context.Customers.ToListAsync();

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(customers);
        return response;
    }

    [Function("GetCustomerById")]
    [OpenApiOperation(operationId: "GetCustomerById", tags: new[] { "Customer" })]
    [OpenApiParameter(name: "id", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
    [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Customer))]
    public async Task<HttpResponseData> GetCustomerById(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "customer/{id}")] HttpRequestData req,
        string id)
    {
        var customer = await _context.Customers.FindAsync(Guid.Parse(id));

        if (customer == null)
        {
            var notFound = req.CreateResponse(HttpStatusCode.NotFound);
            return notFound;
        }

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(customer);
        return response;
    }

    // 🔹 UPDATE
    [Function("UpdateCustomer")]
    [OpenApiOperation(operationId: "UpdateCustomer", tags: new[] { "Customer" })]
    [OpenApiParameter(name: "id", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
    [OpenApiRequestBody("application/json", typeof(Customer))]
    public async Task<HttpResponseData> UpdateCustomer(
        [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "customer/{id}")] HttpRequestData req,
        string id)
    {
        var body = await new StreamReader(req.Body).ReadToEndAsync();
        var updated = JsonConvert.DeserializeObject<Customer>(body);

        var customer = await _context.Customers.FindAsync(Guid.Parse(id));

        if (customer == null)
        {
            var notFound = req.CreateResponse(HttpStatusCode.NotFound);
            return notFound;
        }

        customer.Name = updated.Name;
        customer.Email = updated.Email;

        await _context.SaveChangesAsync();

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(customer);
        return response;
    }

    // 🔹 DELETE
    [Function("DeleteCustomer")]
    [OpenApiOperation(operationId: "DeleteCustomer", tags: new[] { "Customer" })]
    [OpenApiParameter(name: "id", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
    public async Task<HttpResponseData> DeleteCustomer(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "customer/{id}")] HttpRequestData req,
        string id)
    {
        var customer = await _context.Customers.FindAsync(Guid.Parse(id));

        if (customer == null)
        {
            var notFound = req.CreateResponse(HttpStatusCode.NotFound);
            return notFound;
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteStringAsync("Deleted successfully");
        return response;
    }
}
