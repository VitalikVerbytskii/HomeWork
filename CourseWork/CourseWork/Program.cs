using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    private static readonly List<TaskItem> taskList = new List<TaskItem>();
    private static readonly string dataFilePath = "tasks.txt";

    static void Main(string[] args)
    {
        LoadTasks(); // Download tasks from the file, if there are any

        while (true)
        {
            Console.Clear();
            Console.WriteLine("ToDo List");
            Console.WriteLine("1. Show tasks");
            Console.WriteLine("2. Add a task");
            Console.WriteLine("3. Edit task");
            Console.WriteLine("4. Delete task");
            Console.WriteLine("5. Task search");
            Console.WriteLine("6. Delete all tasks");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        ShowTasks(); // Show a list of tasks
                        break;
                    case 2:
                        AddTask(); // Add a new task
                        break;
                    case 3:
                        EditTask(); // Editing an existing task
                        break;
                    case 4:
                        DeleteTask(); // Delete the task
                        break;
                    case 5:
                        SearchTask(); // Looking for a task by name
                        break;
                    case 6:
                        DeleteAllTasks(); // Delete all tasks
                        break;
                    case 0:
                        SaveTasks(); // Save the task to a file before exiting
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Incorrect option selection.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Incorrect input.");
            }
        }
    }

    // Shows a list of all tasks
    static void ShowTasks()
    {
        Console.Clear();
        if (taskList.Any())
        {
            Console.WriteLine("List of tasks:");
            for (int i = 0; i < taskList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {taskList[i].Title}");
                taskList[i].ShowHistory();
            }
        }
        else
        {
            Console.WriteLine("There are no tasks.");
        }
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    // Adds a new task
    static void AddTask()
    {
        Console.Write("Enter a task name: ");
        string title = Console.ReadLine();
        TaskItem newTask = new TaskItem(title);
        taskList.Add(newTask);
        Console.WriteLine("Task added.");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    // Edits an existing task
    static void EditTask()
    {
        ShowTasks();
        Console.Write("Enter the number of the task you want to edit: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 1 && taskNumber <= taskList.Count)
        {
            Console.Write("Enter a new task name: ");
            string newTitle = Console.ReadLine();
            taskList[taskNumber - 1].Edit(newTitle);
            Console.WriteLine("The task has been edited.");
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    // Deletes an existing task
    static void DeleteTask()
    {
        ShowTasks();
        Console.Write("Enter the number of the task you want to delete: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 1 && taskNumber <= taskList.Count)
        {
            taskList.RemoveAt(taskNumber - 1);
            Console.WriteLine("The task has been deleted.");
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    // Searches for tasks by name
    static void SearchTask()
    {
        Console.Write("Enter the name of the task to search for: ");
        string searchTitle = Console.ReadLine();

        var foundTasks = taskList
            .Select((task, index) => new { Task = task, Index = index + 1 })
            .Where(task => task.Task.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase))
            .ToList();

        Console.Clear();
        if (foundTasks.Any())
        {
            Console.WriteLine("Tasks found:");
            foreach (var task in foundTasks)
            {
                Console.WriteLine($"{task.Index}. {task.Task.Title}");
                task.Task.ShowHistory();
            }
        }
        else
        {
            Console.WriteLine("No task found.");
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    // Deletes all tasks
    static void DeleteAllTasks()
    {
        Console.Write("Are you sure you want to delete all tasks? (Yes/No): ");
        string confirmation = Console.ReadLine();
        if (confirmation.Equals("Yes", StringComparison.OrdinalIgnoreCase))
        {
            taskList.Clear();
            Console.WriteLine("All tasks have been deleted.");
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    // Saves the task to a file
    static void SaveTasks()
    {
        using (StreamWriter writer = new StreamWriter(dataFilePath))
        {
            foreach (TaskItem task in taskList)
            {
                writer.WriteLine($"{task.Title}");
            }
        }
    }

    // Loads a task from a file
    static void LoadTasks()
    {
        if (File.Exists(dataFilePath))
        {
            taskList.Clear();
            using (StreamReader reader = new StreamReader(dataFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    taskList.Add(new TaskItem(line));
                }
            }
        }
    }
}

class TaskItem
{
    public string Title { get; private set; }
    private List<string> history;

    public TaskItem(string title)
    {
        Title = title;
        history = new List<string>();
        history.Add($"Created: {DateTime.Now}");
    }
    // Edits the task name and adds a record of the change to the history.
    public void Edit(string newTitle)
    {
        history.Add($"Changed: {DateTime.Now}, New name: {newTitle}");
        Title = newTitle;
    }
    // Outputs the history of changes in the task to the console.
    public void ShowHistory()
    {
        Console.WriteLine("History of changes:");
        foreach (string entry in history)
        {
            Console.WriteLine(entry);
        }
    }
}
