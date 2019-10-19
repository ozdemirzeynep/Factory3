using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Factory3.Factories;
using Factory3.Models;
using Factory3.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Factory3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        DataContextFactory<BookService> dataContextFactory = new DataContextFactory<BookService>();
        public IActionResult GetBooks()
        {

            dataContextFactory.Instance.Insert(new Models.Book()
            {
                CreateDate = DateTime.UtcNow,
                Name = "zzz"
            });

            IEnumerable<Models.Book> books = dataContextFactory.Instance.List().ToList();

            return new JsonResult(books);
        }


        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {

            var book = dataContextFactory.Instance.Get(id);

            return new JsonResult(book);
        }

        [HttpPost]
        public IActionResult PostBook(Models.Book book)
        {
            dataContextFactory.Instance.Insert(book);
            return new JsonResult(book);
        }


        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book book)
        {
           // Book book= dataContextFactory.Instance.Get(id);
            if(id==book.Id)
            {
                dataContextFactory.Instance.Update(book);
                
            }
            
            return new JsonResult(book);
        }

        public void DeleteBook(int id)
        {
           dataContextFactory.Instance.Delete(id);
        }
    }
}