using Azure.Storage.Blobs;

namespace ConsoleApp1
{
    internal class Program
    {

        static async Task Main()
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(str_connection);
            BlobContainerClient container_client =
            blobServiceClient.GetBlobContainerClient("data");
            BlobClient blob_client = container_client.GetBlobClient("ctsbackup2.txt");
            using FileStream uploadFileStream = File.OpenRead(@"D:\ctsbackup2.txt");
            await blob_client.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();
            Console.WriteLine("File uploaded");
            Console.WriteLine("Operation complete");
        }
    }
}
