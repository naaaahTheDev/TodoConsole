using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Handler
{
    public partial class TodoHandler
    { 
    
        public void SaveTodoList(List<string> todoList, string fileName)
        {
           try
           {
                // Write the todo list items to the file
                using (var writer = new System.IO.StreamWriter(fileName))
                {
                    foreach (string task in todoList)
                    {
                        writer.WriteLine(task);
                    }
                }
           } 
           catch (Exception e)
           {
                Console.WriteLine("Error saving the todo list: " + e.Message);
           }
        }
    }
}
