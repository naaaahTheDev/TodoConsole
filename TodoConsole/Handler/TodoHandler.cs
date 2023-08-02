using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Handler
{
    public partial class TodoHandler
    {
        public string fileName;

        public TodoHandler(string fileName)
        {
            this.fileName = fileName;
        }

        public void AddTodo(string newTask)
        {
            List<string> todoList = LoadTodoList(fileName);
            try
            {
				todoList.Add(newTask);
			}
            catch (Exception e)
            {
                Console.WriteLine("Error while adding todo: " + e.Message);
            }
            
        }
        
        public void DeleteTodo(int taskIndex)
        {
			List<string> todoList = LoadTodoList(fileName);
			try
			{
                if (taskIndex >= 0)
                {
					todoList.RemoveAt(taskIndex);
				}
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while deleting todo: " + e.Message);
            }
		}

        public void MarkDone(int taskIndex)
        {
			List<string> todoList = LoadTodoList(fileName);
            try
            {
                if (taskIndex >= 0)
                {
                    todoList.Add(todoList[taskIndex] + " (Completed)");
                    todoList.RemoveAt(taskIndex);
                }
            } catch (Exception e)
            {
                Console.WriteLine("Error whille marking todo as complete: " + e.Message);
            }
		}

        public List<string> GetTodoList()
        {	
				List<string> todoList = LoadTodoList(fileName);
				return todoList;
		}

        public void Exit()
        {
			List<string> todoList = LoadTodoList(fileName);
            SaveTodoList(todoList, fileName);
        }
	}
}
