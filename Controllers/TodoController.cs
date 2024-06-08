using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetTodos()
        {
            return Todo.Todos;  // This will include the dummy todos
        }

        [HttpGet("{id}")]
        public ActionResult<Todo> GetTodo(int id)
        {
            var todo = Todo.Todos.Find(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            return todo;
        }

        [HttpPost]
        public ActionResult<Todo> CreateTodo(Todo todo)
        {
            todo.IsComplete = false;
            Todo.Todos.Add(todo);
            return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTodo(int id, Todo todo)
        {
            if (id != todo.Id)
            {
                return BadRequest();
            }

            var existingTodo = Todo.Todos.Find(t => t.Id == id);
            if (existingTodo == null)
            {
                return NotFound();
            }

            existingTodo.Title = todo.Title;
            existingTodo.IsComplete = todo.IsComplete;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTodo(int id)
        {
            var todo = Todo.Todos.Find(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            Todo.Todos.Remove(todo);
            return NoContent();
        }
    }
}