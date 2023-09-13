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
        public Task<ActionResult<User>> CreateUserAccount(User user)
        {
            return _service.CreateUser(user);

        }

        [HttpPost]
        [Route("/ImmigrationDashboard/AuthenticateUser")]
        [ActionName("AuthenticateUser")]
        [Consumes("application/json")]
        [Produces("application/json", "application/xml")]
        public Task<ActionResult<bool>> AuthenticateAccount(User user)
        {
            return _service.AuthenticateUser(user.Email, user.Password);

        }

        [HttpGet]
        [Route("/ImmigrationDashboard/GetUserInfo")]
        [ActionName("GetUserInfo")]
        [Consumes("application/json")]
        [Produces("application/json", "application/xml")]
        public Task<ActionResult<User>> GetUserInfo(string emailId)
        {
            return _service.GetUserByEmail(emailId);

        }

        [HttpPost]
        [Route("/ImmigrationDashboard/UploadDocument")]
        [ActionName("UploadDocument")]
        [Consumes("application/json")]
        [Produces("application/json", "application/xml")]
        public Task<ActionResult<UserDocument>> UploadDocument(UserDocument userDocument)
        {
            return _service.UploadDocument(userDocument);

        }

        [HttpGet]
        [Route("/ImmigrationDashboard/GetAllDocuments")]
        [ActionName("GetAllDocuments")]
        [Consumes("application/json")]
        [Produces("application/json", "application/xml")]
        public Task<ActionResult<List<UserDocument>>> GetAllDocuments(Guid userId)
        {
            return _service.GetAllDocuments(userId);

        }

    }
}