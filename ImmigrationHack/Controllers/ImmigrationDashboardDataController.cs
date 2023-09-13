using AutoMapper;
using ImmigrationHack.Services.src;
using ImmigrationHack.Services.src.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using User = ImmigrationHack.Services.src.Data.Entities.User;

namespace Immigration_Dashboard_Server.Controllers
{
    [ApiController]
    public class ImmigrationDashboardDataController : ControllerBase
    {
        private readonly IImmigrationService _service;

        public ImmigrationDashboardDataController(
            IImmigrationService service
        )
        {
            _service = service;
        }

        [HttpPost]
        [Route("/ImmigrationDashboard/CreateUser")]
        [ActionName("CreateUserAccount")]
        [Consumes("application/json")]
        [Produces("application/json", "application/xml")]
        public User CreateUserAccount(User user)
        {
            return _service.CreateUser(user).Result;

        }

        [HttpPost]
        [Route("/ImmigrationDashboard/AuthenticateUser")]
        [ActionName("AuthenticateUser")]
        [Consumes("application/json")]
        [Produces("application/json", "application/xml")]
        public bool AuthenticateAccount(User user)
        {
            return _service.AuthenticateUser(user.Email, user.Password);

        }

        [HttpPost]
        [Route("/ImmigrationDashboard/UploadDocument")]
        [ActionName("UploadDocument")]
        [Consumes("application/json")]
        [Produces("application/json", "application/xml")]
        public UserDocument UploadDocument(UserDocument userDocument)
        {
            return _service.UploadDocument(userDocument).Result;

        }

    }
}