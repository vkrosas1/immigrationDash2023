using Azure.Storage;
using Azure.Storage.Blobs;
using Immigration_Dashboard_Server.Services.Constants;
using Immigration_Dashboard_Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Immigration_Dashboard_Server.Services.src
{
    public class AzureBlobStorageService : IAzureBlobStorageService
    {
        public async Task<string> UploadFileToStorage(string fileName, IFormFile fileStream)
        {
            // Create a URI to the blob
            Uri blobUri = new Uri("https://" +
                                  AzureBlobStorageConstants.AccountName +
                                  ".blob.core.windows.net/" +
                                  AzureBlobStorageConstants.ContainerName +
                                  "/" + fileName);

            // Create StorageSharedKeyCredentials object by reading
            // the values from the configuration (appsettings.json)
            StorageSharedKeyCredential storageCredentials =
                new StorageSharedKeyCredential(AzureBlobStorageConstants.AccountName, AzureBlobStorageConstants.AccountKey);

            // Create the blob client.
            BlobClient blobClient = new BlobClient(blobUri, storageCredentials);

            // Upload the file
            bool overwrite = true;
            await blobClient.UploadAsync(fileStream.OpenReadStream(), overwrite);
            return blobUri.ToString();
        }
    }
}
