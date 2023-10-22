using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using ToDoAPI.Helper;
using ToDoAPI.Interfaces;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoAPIController : ControllerBase
    {
        
        private readonly ILogger<ToDoAPIController> _logger;
        private readonly IToDo _toDo;
        public ToDoAPIController(IConfiguration configuration, ILogger<ToDoAPIController> logger,IToDo toDo)
        {
             _toDo= toDo;
             _logger = logger;
        }

        [HttpPost("InsertTask")]
        public IActionResult InsertItem(TodoModel todo)
        {
            try
            {
                 _toDo.AddTask(todo);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        [HttpGet]
        public IActionResult GetAllItems()
        {
            List<TodoModel> res = new List<TodoModel>();
            try
            {
                res = _toDo.GetAllTasks();
                return Ok(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("UpdateTask")]
        public IActionResult UpdateItem(TodoModel todo)
        {
            var connectionString = "mongodb+srv://admin:admin123@todocluster.tcer2lv.mongodb.net/";
            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("ToDo");
            
            return Ok();
        }

        [HttpPost("DeleteTask")]
        public IActionResult DeleteItem(int TaskID)
        {
            var connectionString = "mongodb+srv://admin:admin123@todocluster.tcer2lv.mongodb.net/";
            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("ToDo");
           
            return Ok();
        }

        [HttpGet("TestMethod")]
        public IActionResult Testmethod(string settingsValue)
        {

            string value = AppSettingsHelper.GetValue("MongoDB:ConnectionURI");
            _logger.LogInformation(value);
            return Ok();
        }


    }
}
