using MongoDB.Driver;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using ToDoAPI.Helper;
using ToDoAPI.Interfaces;
using ToDoAPI.Models;

namespace ToDoAPI.DataLayer
{
    public class ToDoData: IToDo
    {
        private IMongoDatabase db;
        public ToDoData() {

            var connectionString = AppSettingsHelper.GetValue("MongoDB:ConnectionURI");
            var client = new MongoClient(connectionString);
            db = client.GetDatabase("ToDo");
        }
        public List<TodoModel> GetAllTasks()
        {
            List <TodoModel> tasks = new List <TodoModel>();
            try
            {
                var collection = db.GetCollection<TodoModel>("ToDoCollection");
                tasks = collection.AsQueryable().ToList();
                return tasks; 
            }
            catch ( Exception ex)
            {

                throw;
            }
        }
        public void UpdateTask(TodoModel todo)
        {
            try
            {
                var collection = db.GetCollection<TodoModel>("ToDoCollection");
                var count = collection.ReplaceOneAsync(b => b.TaskID == todo.TaskID, todo);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void DeleteTask(int TaskID) 
        {
            try
            {
                var collection = db.GetCollection<TodoModel>("ToDoCollection");
                var count = collection.DeleteOne(b => b.TaskID == TaskID);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void AddTask(TodoModel todo) 
        {
            try
            {
                var collection = db.GetCollection<TodoModel>("ToDoCollection");
                collection.InsertOne(todo);
            }
            catch (Exception Ex)
            {

                throw;
            }
            

        }

    }
}
