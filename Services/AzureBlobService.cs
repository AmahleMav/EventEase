using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

public class AzureBlobService
{
    private readonly string _connectionString;
    private readonly string _containerName;

    public AzureBlobService(IConfiguration config)
    {
        _connectionString = config["AzureStorage:ConnectionString"];
        _containerName = config["AzureStorage:ContainerName"];
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        var blobServiceClient = new BlobServiceClient(_connectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient(_containerName);
        await containerClient.CreateIfNotExistsAsync();

        var blobClient = containerClient.GetBlobClient(Guid.NewGuid() + Path.GetExtension(file.FileName));
        using (var stream = file.OpenReadStream())
        {
            await blobClient.UploadAsync(stream, true);
        }

        return blobClient.Uri.ToString();
    }
}
