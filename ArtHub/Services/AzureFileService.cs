using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Services
{
    public class AzureFileService : IFileService
    {
        public const string AccountName_Key = "EcommerceAzureStorageAccountName";
        private readonly CloudBlobClient cloudBlobClient;

        public AzureFileService(IConfiguration configuration)
        {
            var accountName = configuration[AccountName_Key] ?? throw new InvalidOperationException("Missing AzureStorageAccountName");
            var blobKey = configuration["AzureBlobKey"] ?? throw new InvalidOperationException("Missing AzureBlobKey");

            var storageCredentials = new StorageCredentials(accountName, blobKey);
            var storageAccount = new CloudStorageAccount(storageCredentials, true);

            cloudBlobClient = storageAccount.CreateCloudBlobClient();
        }

        public async Task<string> Create(IFormFile artFile)
        {
            // Access to a storage Container
            var container = cloudBlobClient.GetContainerReference("art");
            await container.CreateIfNotExistsAsync();
            await container.SetPermissionsAsync(new BlobContainerPermissions
            {
                // Allow anonymous access to individual files *if you have the link*
                PublicAccess = BlobContainerPublicAccessType.Blob,
            });

            // Actually do the upload
            var blobFile = container.GetBlockBlobReference(artFile.FileName);


            using var imageStream = artFile.OpenReadStream();
            await blobFile.UploadFromStreamAsync(imageStream);
            return blobFile.Uri.ToString();
        }


        public async Task<string> Update(IFormFile artFile)
        {
            // Access to a storage Container
            var container = cloudBlobClient.GetContainerReference("art");
            await container.CreateIfNotExistsAsync();
            await container.SetPermissionsAsync(new BlobContainerPermissions
            {
                // Allow anonymous access to individual files *if you have the link*
                PublicAccess = BlobContainerPublicAccessType.Blob,
            });

            // Actually do the upload
            var blobFile = container.GetBlockBlobReference(artFile.FileName);


            using var imageStream = artFile.OpenReadStream();
            await blobFile.UploadFromStreamAsync(imageStream);
            return blobFile.Uri.ToString();
        }
    }
}

