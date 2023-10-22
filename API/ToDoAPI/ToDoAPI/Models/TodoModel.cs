using MongoDB.Bson.Serialization.Attributes;

namespace ToDoAPI.Models
{
    [BsonIgnoreExtraElements]
    public class TodoModel
    {
        public int TaskID { get; set; }
        public  string TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public string TaskStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Effort { get; set;}
        public string StatusColor { get; set; }
    }
    }

