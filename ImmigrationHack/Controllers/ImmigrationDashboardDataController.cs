using Immigration_Dashboard_Server.Models;
using Immigration_Dashboard_Server.Services.Interfaces;
using ImmigrationHack.Services.src.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using User = ImmigrationHack.Services.src.Data.Entities.User;

namespace Immigration_Dashboard_Server.Controllers
{
    [ApiController]
    public class ImmigrationDashboardDataController : ControllerBase
    {

        [HttpPost]
        [Route("/ImmigrationDashboard/CreateUser")]
        [ActionName("CreateUserAccount")]
        public bool CreateUserAccount(string username, string password)
        {
            User user = new User();
            user.Email = username;
            user.Password = password;
            //user.Name = Request?.Form["name"];
            return true;

        }

    }
}