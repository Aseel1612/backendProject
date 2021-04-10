using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Models;

namespace TravelAgent.DataAccess
{
    public class DbInitializer
    {
        public static void Initialize(TravelAgentContext context)
        {
            // Look for any students.
            if (context.TodoItems.Any())
            {
                return;   // DB has been seeded
            }

            var todoItems = new TodoItem[]
            {
                new TodoItem{Name= "Hasan",IsComplete=true},
                new TodoItem{Name= "Maram",IsComplete=false},
                new TodoItem{Name= "Aseel",IsComplete=false}
            };

            context.TodoItems.AddRange(todoItems);
            context.SaveChanges();
        }
    }
}
