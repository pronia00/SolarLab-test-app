using System;
using System.Collections.Generic;
using System.IO;

namespace Planner_app
{
    class Planner
    {
        private List<string> plans;   // contians task
        private const short MAX_TODO_LENGTH = 80; // max task length
        private const short MIN_TODO_LENGTH = 0;  // min task length 

        public Planner()
        {
            plans = new List<string>();
        }

        // saves list with tasks in txt file
        public void SaveFile()
        {
            Console.Clear();
            string file_path = GetPath();
            StreamWriter writer = File.CreateText(file_path);
            foreach (string todo in plans) 
            {
                writer.WriteLine(todo);
            }
            writer.Close();
            Console.WriteLine("File was saved in {0}", file_path);
            PressEnterToReturn();
        }

        //load tasks from txt file
        public void LoadFile()
        {
            Console.Clear();
            string file_path = GetPath();
            if (!File.Exists(file_path))
            {
                Console.WriteLine("Error, file {0} wasn't found!!!", file_path);
            }
            else
            {
                plans.Clear();
                StreamReader reader = File.OpenText(file_path);
                string temp = reader.ReadLine();

                while (temp != null)
                {
                    plans.Add(temp);
                    temp = reader.ReadLine();
                }
                PressEnterToReturn();
            }

        }

        // adds new task in list
        public void AddTodo() {
            Console.Clear();
            Console.WriteLine("Enter new todo, which you want to add in you plan :");

            string new_todo = Console.ReadLine();
            if (new_todo.Length == MIN_TODO_LENGTH)
            {
                Console.WriteLine("Sorry, todo is to short!");
            }
            else if (new_todo.Length > MAX_TODO_LENGTH)
            {
                Console.WriteLine("Sorry, todo is to long!");
            }
            else
            {
                plans.Add(new_todo);
                PressEnterToReturn();
            }
        }

        // deletes task from list
        public void DeleteTodo()
        {
            
            Console.Clear();
            Console.WriteLine("Enter todo's number, to delete:");
            string temp = Console.ReadLine();
            int num;
            bool isInt = Int32.TryParse(temp, out num);
            if (isInt && num <= plans.Count && num > 0)
            {
                plans.RemoveAt(num - 1);
                Console.WriteLine("To-do was removed");
            }
            else
            {
                Console.WriteLine("Incorrect number!");
            }
            PressEnterToReturn();
        }

        // gives an opportunity to edit chosen task
        public void EditTodo()
        {
            Console.Clear();
            Console.WriteLine("Enter num of todo, which you want to edit: ");

            string temp = Console.ReadLine();
            int num;
            bool isInt = Int32.TryParse(temp, out num);

            if (num <= plans.Count && num > 0) 
            {
                Console.WriteLine("Your todo : {0}", plans[num - 1]);
                Console.WriteLine("Enter new todo : ");
                string new_str = Console.ReadLine();

                if (new_str.Length == MIN_TODO_LENGTH || new_str.Length > MAX_TODO_LENGTH)
                {
                    Console.WriteLine("Incorrect todo length!");
                }
                else
                {
                    plans[num - 1] = new_str;
                    Console.WriteLine("Todo was edited!");
                }
            }
            else
            {
                Console.WriteLine("Incorrect number!");
                PressEnterToReturn();
            }

        }

        // Shows all tasks on the screen
        public void DisplayTodos()
        {
            Console.Clear();
            Console.WriteLine(" ┌────┬─────────────────────────────────────────────────────────────┐");
            Console.WriteLine(" │ No │                  Plans                                      │");
            Console.WriteLine(" ├────┼─────────────────────────────────────────────────────────────┤");

            int i = 1;
            foreach (string todo in plans)
            {
                Console.SetCursorPosition(0, i + 2);
                Console.WriteLine(" │    │                                                             │");
                Console.SetCursorPosition(3, i + 2);
                Console.Write(i);
                Console.SetCursorPosition(8, i + 2);
                Console.Write(plans[i - 1]);
                Console.SetCursorPosition(1, i + 2);
                ++i;
            }

            Console.SetCursorPosition(0, i + 2);
            Console.WriteLine(" └────┴─────────────────────────────────────────────────────────────┘");
            PressEnterToReturn();
        }

        // asks user to enter file's path
        private string GetPath() {
            Console.Clear();
            Console.WriteLine("Enter path to file: ");
            return Console.ReadLine();
        }

        // just waits for <enter>
        private void PressEnterToReturn() {
            Console.WriteLine("Press <Enter> to return...");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }
    }
}
