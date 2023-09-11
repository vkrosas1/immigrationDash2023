using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Immigration_Dashboard_Server.Services.Interfaces
{
    public interface IAzureBlobStorageService
    {
        Task<string> UploadFileToStorage(string fileName, IFormFile fileStream);
    }
}