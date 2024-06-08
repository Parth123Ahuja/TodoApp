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

        // Static constructor to add dummy todos
        static Todo()
        {
            Todos.Add(new Todo { Title = "Learn ASP.NET Core", IsComplete = false });
            Todos.Add(new Todo { Title = "Build a Web API", IsComplete = true });
            Todos.Add(new Todo { Title = "Test API with Postman", IsComplete = false });
            Todos.Add(new Todo { Title = "Deploy to Azure", IsComplete = false });
            Todos.Add(new Todo { Title = "Write API documentation", IsComplete = false });
        }
    }

     public class TodoUpdateModel
    {
        public string? Title { get; set; }
        public bool? IsComplete { get; set; }
    }
}