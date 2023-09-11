using Immigration_Dashboard_Server.Models;
using Immigration_Dashboard_Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Path = Immigration_Dashboard_Server.Models.Path;

namespace Immigration_Dashboard_Server.Controllers
{
    public class ImmigrationDashboardDataController : Controller
    {
        private readonly ICosmosDbService<User> userCosmosDbService;
        private readonly ICosmosDbService<Form> formCosmosDbService;
        private readonly ICosmosDbService<Document> documentCosmosDbService;
        private readonly ICosmosDbService<Path> pathCosmosDbService;
        private readonly IAzureBlobStorageService azureBlobStorageService;

        public ImmigrationDashboardDataController(ICosmosDbService<User> userCosmosDbService,
            ICosmosDbService<Form> formCosmosDbService,
            ICosmosDbService<Document> documentCosmosDbService,
            ICosmosDbService<Path> pathCosmosDbService,
            IAzureBlobStorageService azureBlobStorageService)
        {
            Requires.NotNull(userCosmosDbService, nameof(userCosmosDbService));
            Requires.NotNull(formCosmosDbService, nameof(formCosmosDbService));
            Requires.NotNull(documentCosmosDbService, nameof(documentCosmosDbService));
            Requires.NotNull(pathCosmosDbService, nameof(pathCosmosDbService));
            Requires.NotNull(azureBlobStorageService, nameof(azureBlobStorageService));

            this.userCosmosDbService = userCosmosDbService;
            this.formCosmosDbService = formCosmosDbService;
            this.documentCosmosDbService = documentCosmosDbService;
            this.pathCosmosDbService = pathCosmosDbService;
            this.azureBlobStorageService = azureBlobStorageService;
        }

        [HttpGet]
        [Route("/HelloWorld/Welcome/")]
        [ActionName("Get")]
        public async Task<string> GetAsync()
        {
            User user = await userCosmosDbService.GetItemAsync("78");
            Form form = await formCosmosDbService.GetItemAsync("23");
            Document document = await documentCosmosDbService.GetItemAsync("J1");
            Path template = await pathCosmosDbService.GetItemAsync("F1 Visa Path");


            return "Success";
        }

        [HttpGet]
        [Route("/HelloWorld/")]
        [ActionName("Create")]
        public async Task<string> CreateAsync()
        {
            string documentName = "SampleDocWithStream";
            string filePath = "C:/Users/anaypurohit/OneDrive - Microsoft/Desktop/Microsoft/License Express for Individuals.pdf";
            //string fileBlobUri = await azureBlobStorageService.UploadFileToStorage(documentName, filePath);

            User user = new User();
            user.Id = "test";
            user.Password = "tet2";

            Form form = new Form();
            form.Id = "234";
            form.Data = "i20";
            form.Info = "school id doc";

            Document document = new Document();
            document.UserId = "5678";
            document.FormId = "234";
            document.Status = "In Progress";

            Path template = new Path();
            template.Id = "2";

            await userCosmosDbService.AddItemAsync(user);
            await formCosmosDbService.AddItemAsync(form);
            await documentCosmosDbService.AddItemAsync(document);
            await pathCosmosDbService.AddItemAsync(template);

            return "Success";
        }

        [HttpGet]
        [Route("/ImmigrationDashboard/GetAllUserDocuments")]
        [ActionName("GetAllUserDocuments")]
        public async Task<List<Document>> GetAllUserDocuments(string userId)
        {
            var sqlQueryText = "SELECT * FROM c WHERE c.userId = \"" + userId + "\"";
            return await documentCosmosDbService.GetItemsAsync(sqlQueryText);
        }

        [HttpGet]
        [Route("/ImmigrationDashboard/GetUserDocument")]
        [ActionName("GetUserDocuments")]
        public async Task<List<Document>> GetUserDocument(string userId, string formId)
        {
            var sqlQueryText = "SELECT * FROM c WHERE c.userId = \"" + userId + "\"" + " AND c.formId = \"" + formId + "\"";
            return await documentCosmosDbService.GetItemsAsync(sqlQueryText);
        }

        [HttpPost]
        [Route("/ImmigrationDashboard/CreateUserDocument")]
        [ActionName("CreateUserDocument")]
        public async Task CreateUserDocument([FromBody] Document userDocument)
        {
            await documentCosmosDbService.AddItemAsync(userDocument);
        }

        [HttpPut]
        [Route("/ImmigrationDashboard/UpdateUserDocument")]
        [ActionName("UpdateUserDocument")]
        public async Task UpdateUserDocument([FromBody] Document userDocument)
        {
            await documentCosmosDbService.UpdateItemAsync(userDocument.Id, userDocument);
        }

        [HttpPost]
        [Route("/ImmigrationDashboard/UploadUserDocument")]
        [ActionName("UploadUserDocument")]
        public async Task UploadUserDocument()
        {
            var files = Request.Form.Files;

            foreach (var file in files)
            {
                string filename = Request.Form["filename"];
                // to do save
                string fileBlobUri = await azureBlobStorageService.UploadFileToStorage(filename, file);
                Document userDocument = new Document();
                userDocument.UserId = Request.Form["userId"];
                userDocument.FormId = Request.Form["formId"];
                userDocument.Status = Request.Form["status"];
                userDocument.Url = fileBlobUri;
                userDocument.Id = Request.Form["formId"] + "_" + Request.Form["userId"];
                userDocument.FileName = filename;
                await documentCosmosDbService.UpdateItemAsync(userDocument.Id, userDocument);
            }
        }

        [HttpGet]
        [Route("/ImmigrationDashboard/GetForm")]
        [ActionName("GetForm")]
        public async Task<Form> GetForm(string formId)
        {
            return await formCosmosDbService.GetItemAsync(formId);
        }

        [HttpGet]
        [Route("/ImmigrationDashboard/GetAllForms")]
        [ActionName("GetForm")]
        public async Task<List<Form>> GetAllForms()
        {
            var sqlQueryText = "SELECT * FROM c";
            return await formCosmosDbService.GetItemsAsync(sqlQueryText);
        }

        [HttpGet]
        [Route("/ImmigrationDashboard/GetAllUserDocumentForms")]
        [ActionName("GetAllUserDocumentForms")]
        public async Task<List<Form>> GetAllUserDocumentForms(string userId)
        {
            var docsSqlQueryText = "SELECT * FROM c WHERE c.userId = \"" + userId + "\"";
            List<Document> userDocs = await documentCosmosDbService.GetItemsAsync(docsSqlQueryText);

            var formsSqlQueryText = "SELECT * FROM c";
            List<Form> allForms = await formCosmosDbService.GetItemsAsync(formsSqlQueryText);

            foreach (Document document in userDocs)
            {
                foreach (Form form in allForms)
                {
                    if (document.FormId == form.Id)
                    {
                        form.DocumentUrl = document.Url;
                        form.Status = document.Status;
                    }
                }
            }
            return allForms;
        }

        [HttpGet]
        [Route("/ImmigrationDashboard/GetUser")]
        [ActionName("GetUser")]
        public async Task<User> GetUser(string userId)
        {
            return await userCosmosDbService.GetItemAsync(userId);
        }

        [HttpGet]
        [Route("/ImmigrationDashboard/GetUserSettings")]
        [ActionName("GetUserSettings")]
        public async Task<UserSettings> GetUserSettings(string userId)
        {
            User user = await userCosmosDbService.GetItemAsync(userId);
            UserSettings userSettings = user.UserSettings;
            return userSettings;
        }

        [HttpGet]
        [Route("/ImmigrationDashboard/GetPath")]
        [ActionName("GetPath")]
        public async Task<Path> GetPath(string pathId)
        {
            return await pathCosmosDbService.GetItemAsync(pathId);
        }



        //[HttpPost]
        //[ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditAsync([Bind("Id,Name,Description,Completed")] Item item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _cosmosDbService.UpdateItemAsync(item.Id, item);
        //        return RedirectToAction("Index");
        //    }

        //    return View(item);
        //}

        //[ActionName("Edit")]
        //public async Task<ActionResult> EditAsync(string id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }

        //    Item item = await _cosmosDbService.GetItemAsync(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(item);
        //}

        //[ActionName("Delete")]
        //public async Task<ActionResult> DeleteAsync(string id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }

        //    Item item = await _cosmosDbService.GetItemAsync(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(item);
        //}

        //[HttpPost]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmedAsync([Bind("Id")] string id)
        //{
        //    await _cosmosDbService.DeleteItemAsync(id);
        //    return RedirectToAction("Index");
        //}

        //[ActionName("Details")]
        //public async Task<ActionResult> DetailsAsync(string id)
        //{
        //    return View(await _cosmosDbService.GetItemAsync(id));
        //}
    }
}