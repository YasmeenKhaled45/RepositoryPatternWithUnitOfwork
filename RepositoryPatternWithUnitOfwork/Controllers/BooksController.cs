using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUnitOfwork.Core.Constant;
using RepositoryPatternWithUnitOfwork.Core.Models;
using RepositoryPatternWithUnitOfwork.Core;

namespace RepositoryPatternWithUnitOfwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitofwork _unitOfWork;

        public BooksController(IUnitofwork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById()
        {
            return Ok(_unitOfWork.Books.GetByIdAsync(1));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Books.GetAll());
        }

        [HttpGet("GetOrdered")]
        public async Task<IActionResult> GetOrdered()
        {
            return Ok(_unitOfWork.Books.FindAllAsync(b => b.Title.Contains("New Book"), null, null, b => b.Id, OrderBy.Descending));
        }

        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            var book = _unitOfWork.Books.AddAsync(new Book { Title = "Test 4", AuthorId = 1 });
            _unitOfWork.SaveChanges();
            return Ok(book);
        }
    }
}
