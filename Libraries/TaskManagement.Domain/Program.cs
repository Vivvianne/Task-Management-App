using System;
using System.Linq;
using TaskManagement.Domain.Data;
using TaskManagement.Domain.Models.Todos;

namespace TaskManagement.Domain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TaskManagementContext())
            {
                // Create and save a new Task
                Console.Write("Enter a name for a new todo: ");
                var todoName = Console.ReadLine();

                var todo = new Todo 
                { 
                    Name = todoName
                };

                db.Todos.Add(todo);
                db.SaveChanges();

                // Display all Blogs from the database
                var query = from b in db.Todos
                            orderby b.Name
                            select b;

                Console.WriteLine("All Todos in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
