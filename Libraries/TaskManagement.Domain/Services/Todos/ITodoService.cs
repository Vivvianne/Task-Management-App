using System.Collections.Generic;
using TaskManagement.Domain.Models.Todos;

namespace TaskManagement.Domain.Services.Todos
{
    /// <summary>
    /// Represents a todo service
    /// </summary>
    public interface ITodoService
    {
        /// <summary>
        /// Inserts a todo
        /// </summary>
        /// <param name="todo">Todo</param>
        void InsertTodo(Todo todo);

        /// <summary>
        /// Update a todo
        /// </summary>
        /// <param name="todo"></param>
        void UpdateTodo(Todo todo);

        /// <summary>
        /// Gets a todo by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Todo</returns>
        Todo GetTodoById(int id);
        
        /// <summary>
        /// Gets all todos
        /// </summary>
        /// <returns>Todos</returns>
        List<Todo> GetAllTodos();
    }
}
