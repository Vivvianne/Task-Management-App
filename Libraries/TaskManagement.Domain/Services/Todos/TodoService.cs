using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Domain.Data.Infrastructure;
using TaskManagement.Domain.Models.Todos;

namespace TaskManagement.Domain.Services.Todos
{
    /// <summary>
    /// Represets a todo service
    /// </summary>
    public class TodoService : ITodoService
    {
        private readonly IRepository<Todo> todoRepository;

        public TodoService(IRepository<Todo> todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public Todo GetTodoById(int id)
        {
            return todoRepository.GetById(id);
        }

        public List<Todo> GetAllTodos()
        {
            return todoRepository.Table.ToList();
        }

        /// <summary>
        /// Inserts a todo
        /// </summary>
        /// <param name="todo">todo</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void InsertTodo(Todo todo)
        {
            if (todo is null)
                throw new ArgumentNullException(nameof(Todo));

            todoRepository.Insert(todo);
        }

        /// <summary>
        /// Update to do
        /// </summary>
        /// <param name="todo">Todo</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void UpdateTodo(Todo todo)
        {
            if (todo is null)
                throw new ArgumentNullException(nameof(Todo));

            todoRepository.Update(todo);
        }

        public List<Todo> GetTodos()
        {
            return todoRepository.Table.ToList();
        }
    }
}
