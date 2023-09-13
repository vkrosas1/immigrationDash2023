using AutoMapper;
using ImmigrationHack.Services.src;
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
            /*User user = new User();
            user.Email = username;
            user.Password = password;
            user.CitizenCountry = country;
            user.Name = firstName + " " + lastName;*/
            return _service.CreateUser(user).Result;

        }

    }
}