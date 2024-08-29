using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUnitOfwork.Core;

namespace RepositoryPatternWithUnitOfwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitofwork unitofwork;

        public AuthorsController(IUnitofwork unitofwork)
        {
            this.unitofwork = unitofwork;
        }
        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            return Ok(await unitofwork.Authors.GetByIdAsync(Id));
        }

    }
}
