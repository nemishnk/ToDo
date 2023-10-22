using ToDoAPI.Models;

namespace ToDoAPI.Interfaces
{
    public interface IToDo
    {
        public List<TodoModel> GetAllTasks();
        public void UpdateTask(TodoModel todo);
        public void DeleteTask(int TaskID);
        public void AddTask(TodoModel todo);
    }
}
