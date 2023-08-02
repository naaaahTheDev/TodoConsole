using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Handler
{
	public partial class TodoHandler
	{
		public List<string> LoadTodoList(string fileName)
		{
			List<string> todoList = new List<string>();
			try
			{
				using (var reader = new System.IO.StreamReader(fileName))
				{
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						todoList.Add(line);
					}
				}
			} 
			catch (Exception e)
			{
				Console.WriteLine("Error loading the todo list: " + e.Message);
			}
			return todoList;
		}
	}
}
