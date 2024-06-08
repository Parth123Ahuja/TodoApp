using System.Collections.Generic;

namespace TodoApi.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }

        public static List<Todo> Todos { get; } = new List<Todo>();
        public static int NextId { get; set; } = 1;

        public Todo()
        {
            Id = NextId++;
        }

  
       
    }

     public class TodoUpdateModel
    {
        public string? Title { get; set; }
        public bool? IsComplete { get; set; }
    }
}