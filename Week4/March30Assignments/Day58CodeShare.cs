
For azure refer below video links any how i had done in class what i have to teach 

    https://www.youtube.com/watch?v=5SC7D-RxNgo (important and easy one )

https://www.youtube.com/watch?v=cIStcPXjxKI

https://www.youtube.com/watch?v=8uKWbY0740A

Post Lunch class :
----------------

Now open the project which we were doing yesterday  and add packages from nugget manager 

step 1 :
-----------

Microsoft.AspNetCore.Identity.EntityFrameworkCore  of version 8.0.24

Microsoft.AspNetCore.Authentication.JwtBearer  of version 8.0.24

step 2 :
--------
after installing this once build the project once

step 3 :
---------
add one class in Models folder like this with annotations 
    
public class RegisterUser
{
[Required(ErrorMessage = "User Name is required")]
public string? Username { get; set; }
[EmailAddress]
[Required(ErrorMessage = "Email is required")]
public string? Email { get; set; }
[Required(ErrorMessage = "Password is required")]
public string? Password { get; set; }
} 


step 4 :
--------
now go to EmpContext chnage the code like this 
  
  using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApiInAsp.netcoreMvcDemo.Models
{
    public class EmpContext:IdentityDbContext<IdentityUser>
    {
        public EmpContext(DbContextOptions dbContextOptions) :
            base(dbContextOptions)
        {

        }

        public DbSet<Employee> employees { set; get; }

  

   protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            SeedRoles(modelBuilder);

        }
     private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
            (
            new IdentityRole()
            {
                Name = "Admin",
                ConcurrencyStamp = "1",
                NormalizedName = "Admin"
            },
            new IdentityRole()
            {
                Name = "User",
                ConcurrencyStamp = "2",
                NormalizedName = "User"
            },
            new IdentityRole()
            {
                Name = "HR",
                ConcurrencyStamp = "3",
                NormalizedName = "HR"
            }
            );
        }
    }
  
}

step 5 :
--------
    Now in program.cs do the following changes 

// For Entity Framework
var configuration = builder.Configuration;
    builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constring"))); //after this add it okay 
 // For Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
.AddEntityFrameworkStores<EmpContext>()
.AddDefaultTokenProviders();
// adding basic authentication
builder.Services.AddAuthentication(options =>
{
options.DefaultAuthenticateScheme =
JwtBearerDefaults.AuthenticationScheme;
options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});


step 6 
--------
    ---> Now run the migrations commands 

       add-migration InitialCreate
       update-database


--->Now go to dabatabse and analaize the tables once okay these tables will be empty only okay only roles table will be filled 


