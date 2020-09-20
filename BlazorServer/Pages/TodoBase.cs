using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServer.Models;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorServer.Pages
{
    public class TodoBase : ComponentBase
    {
        public int FakeId { get; set; } = 0;
        public TodoList todo { get; set; } = new TodoList();

        public List<TodoList> todoLists { get; set; } = new List<TodoList>();

        protected void AddTodo()
        {
            TodoList todoP = new TodoList
            {
                Id = FakeId++,
                TodoItem = todo.TodoItem
            };

            todoLists.Add(todoP);
            todo.TodoItem = string.Empty;
        }

        protected void DeleteTodo(int todoId)
        {
            var deletedTodo = todoLists.Find(e => e.Id == todoId);

            todoLists.Remove(deletedTodo);
        }

        protected void EditTodo(int todoId)
        {
            var editedTodo = todoLists.Find(e => e.Id == todoId);

            if (!string.IsNullOrEmpty(todo.TodoItem))
            {
                editedTodo.TodoItem = todo.TodoItem;
                todo.TodoItem = string.Empty;
            }
        }
    }
}
