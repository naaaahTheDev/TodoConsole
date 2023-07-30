using System.Collections.Generic;
using System;


namespace TodoConsole
{
	internal class Program
	{
		enum UserChoice
		{
			Back = 0,
			AddTodo = 1,
			ViewTodo = 2,
			DeleteTodo = 3,
			Exit
		}
		static void Main(string[] args)
		{
			string fileName = "todolist.txt";
			List<string> todoList = LoadTodoList(fileName);
			while (true)
			{
				
				// Display the possible choices
				Console.WriteLine("[1] Add Todo");
				Console.WriteLine("[2] View Todo List");
				Console.WriteLine("[3] Delete Todo");
				Console.WriteLine("[4] Exit");
				Console.Write("Enter Option: ");
				// Get the choice
				try
				{
					int choice = int.Parse(Console.ReadLine());

					if (choice == (int)UserChoice.AddTodo)
					{
						Console.Write("Enter task: ");
						string task = Console.ReadLine();
						todoList.Add(task);
						Console.Clear();
						Console.WriteLine("Task added successfully!");
						Console.WriteLine("");
						Console.WriteLine("[0] Back To Menu");
						int back = int.Parse(Console.ReadLine());
						if (back == (int)UserChoice.Back)
						{
							Console.Clear();
						}
					}
					else if (choice == (int)UserChoice.DeleteTodo)
					{
						while (true)
						{
							Console.Clear();
							Console.WriteLine("Todo list: ");

							if (todoList.Count > 0)
							{
								for (int i = 0; i < todoList.Count; i++)
								{
									Console.WriteLine(i + 1 + ": " + todoList[i]);
									Console.WriteLine("");
								}
								Console.WriteLine("Enter the index of the todo task: ");
								int indexToDelete = int.Parse(Console.ReadLine());
								try
								{
									if (indexToDelete >= 0)
									{
										todoList.RemoveAt(indexToDelete - 1);
										Console.Clear();
										Console.WriteLine("Task deleted successfully!");
										Console.WriteLine("Back to Main Menu [0], Delete more items [1]");
										int option = int.Parse(Console.ReadLine());
										if (option == (int)UserChoice.Back)
										{
											Console.Clear();
											break;
										} 
										else
										{
											Console.Clear();
											continue;
										}
									}
									else
									{
										Console.WriteLine("Task not found in the todo list.");
										Console.Clear();
									}
								} catch (Exception)
								{
									Console.WriteLine("Looks like there was an issue while deleting that task, please try again. ");
									Console.Clear();
								}
						}
						}
						
						
					}
					else if (choice == (int)UserChoice.ViewTodo)
					{
						if (todoList.Count > 0)
						{
							Console.Clear();
							Console.WriteLine("Todo List: ");

							for (int i = 0; i < todoList.Count; i++)
							{
								Console.WriteLine("- " + todoList[i]);
								Console.WriteLine("");
							}
							Console.WriteLine("[0] Back To Menu");
							int back = int.Parse(Console.ReadLine());
							if (back == (int)UserChoice.Back)
							{
								Console.Clear();
							}
						}
						else
						{
							Console.Clear();
							Console.WriteLine("You currenty have no tasks in your todo list.");
							Console.WriteLine("[0] Back To Menu");
							int back = int.Parse(Console.ReadLine());
							if (back == (int)UserChoice.Back)
							{
								Console.Clear();
							}
						}
					}
					else if (choice == (int)UserChoice.Exit)
					{
						SaveTodoList(todoList, fileName);
						break;
					}
				}
				catch (Exception)
				{
					Console.WriteLine("Please try again, but enter a correct value for the task.");
				}
			}
			
			
		}

		private static void SaveTodoList(List<string> todoList, string fileName)
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
				Console.WriteLine("Todo list saved successfully!");
			}
			catch (Exception e)
			{
				Console.WriteLine("Error saving the todo list: " + e.Message);
			}
		}

		private static List<string> LoadTodoList(string fileName)
		{
			List<string> todoList = new List<string>();
			try
			{
				// Read the todo list items from thee file
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