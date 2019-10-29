using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTodoAPI.Models;

namespace TestTodoAPI.Contollers
{
    [Route("api/todo")]
    public class TodoController : Controller
    {
        private DataContext dbContext = new DataContext();
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //To Get All Todos
        [Produces("application/json")]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var todos = dbContext.Todo.ToList();
                return Ok(todos);
            }
            catch
            {
                return BadRequest();
            }
        }

        //To Create New Todo From data in Request Body
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Todo todo)
        {
            try
            {
                dbContext.Todo.Add(todo);
                dbContext.SaveChanges();
                return Ok(todo);
            }
            catch
            {
                return BadRequest();
            }
        }

        //To Update Todo Data From data in Request Body
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("update/{todoId}}")]
        public async Task<IActionResult> update(int todoId,[FromBody] Todo todo)
        {
            try
            {
                Todo oldTodo = dbContext.Todo.Where(x => x.TodoId == todoId).FirstOrDefault();
                oldTodo.Detail = todo.Detail;
                oldTodo.ExpiryDate = todo.ExpiryDate;
                oldTodo.PrecentageProgress = todo.PrecentageProgress;
                oldTodo.Title = todo.Title;

                dbContext.SaveChanges();
                return Ok(todo);
            }
            catch
            {
                return BadRequest();
            }
        }

        //To Get Specific todo by Id
        [Produces("application/json")]
        [HttpGet("gettodobyid/{id}")]
        public async Task<IActionResult> GetTodoById(int todoId)
        {
            try
            {
                var todo = dbContext.Todo.Where(x => x.TodoId == todoId).FirstOrDefault();
                return Ok(todo);
            }
            catch
            {
                return BadRequest();
            }
        }

        //To Get Specific Todo by Title
        [Produces("application/json")]
        [HttpGet("gettodobytitle/{title}")]
        public async Task<IActionResult> GetTodoByTitle(string title)
        {
            try
            {
                var todo = dbContext.Todo.Where(x => x.Title == title).FirstOrDefault();
                return Ok(todo);
            }
            catch
            {
                return BadRequest();
            }
        }

        //To Get Incoming Todo
        [Produces("application/json")]
        [HttpGet("gettodobyexpirydate/{datatype}")]
        public async Task<IActionResult> GetTodoByExpiryDate(string datatype)
        {
            try
            {
                var dateParam = new DateTime();
                var dateParamStart = new DateTime();
                if (datatype == "Today")
                {
                    dateParam = DateTime.Now;
                }
                else if (datatype == "Tommorrow")
                {
                    dateParam = DateTime.Now.AddDays(1);
                }
                else if (datatype == "ThisWeek")
                {
                    dateParamStart = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
                    dateParam = dateParamStart.AddDays(6);
                }
                Todo todo = new Todo();
                if (datatype != "ThisWeek")
                {
                    todo = dbContext.Todo.Where(x => x.ExpiryDate == dateParam).FirstOrDefault();
                }
                else
                {
                    todo = dbContext.Todo.Where(x => x.ExpiryDate >= dateParamStart && x.ExpiryDate <= dateParam).FirstOrDefault();
                }
                return Ok(todo);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("settodopercentcomplete/{todoId}")]
        public async Task<IActionResult> SetTodoPercentComplete(int todoId)
        {
            try
            {
                Todo todo = dbContext.Todo.Where(x => x.TodoId == todoId).FirstOrDefault();
                todo.PrecentageProgress = 100;

                dbContext.SaveChanges();
                return Ok("Todo Percent Successfully Updated");
            }
            catch
            {
                return BadRequest();
            }
        }

        //To Remove Specific Todo
        [Produces("application/json")]
        [HttpGet("removetodo/{todoId}")]
        public async Task<IActionResult> RemoveTodo(int todoId)
        {
            try
            {
                Todo todo = dbContext.Todo.Where(x => x.TodoId == todoId).FirstOrDefault();
                dbContext.Remove(todo);
                dbContext.SaveChanges();
                return Ok("Todo Percent Successfully Updated");
            }
            catch
            {
                return BadRequest();
            }
        }

        //To Mark Todo As Done
        [Produces("application/json")]
        [HttpGet("markasdone/{todoId}")]
        public async Task<IActionResult> MarkAsDone(int todoId)
        {
            try
            {
                Todo todo = dbContext.Todo.Where(x => x.TodoId == todoId).FirstOrDefault();
                todo.IsDone = true;

                dbContext.SaveChanges();
                return Ok("Todo is marked as done");
            }
            catch
            {
                return BadRequest();
            }
        }
    }

    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}