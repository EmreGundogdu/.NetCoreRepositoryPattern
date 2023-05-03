using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketBook.Core.IConfiguration;
using PocketBook.Models;

namespace PocketBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> logger;
        private readonly IUnitOfWork unitOfWork;

        public UsersController(ILogger<UsersController> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                await unitOfWork.Users.Add(user);
                await unitOfWork.CompleteAsync();
                return CreatedAtAction("GetItem", new { user.Id }, user);
            }
            return new JsonResult("Something wen wrong") { StatusCode = StatusCodes.Status500InternalServerError };
        }
    }
}
