class Program
{
    static List<TaskItem> taskList = new List<TaskItem>(); // Замість List<string> використовуємо список об'єктів TaskItem

    static string dataFilePath = "tasks.txt"; // Файл для збереження завдань

    static void Main(string[] args)
    {
        LoadTasks(); // Завантаження завдань з файлу, якщо вони є

        while (true)
        {
            Console.WriteLine("ToDo List");
            Console.WriteLine("1. Show tasks");
            Console.WriteLine("2. Add a task");
            Console.WriteLine("3. Edit task");
            Console.WriteLine("4. Delete task");
            Console.WriteLine("5. Task search");
            Console.WriteLine("6. Delete all tasks");
            Console.WriteLine("0. Entrance");
            Console.Write("Select an option: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        ShowTasks();
                        break;
                    case 2:
                        AddTask();
                        break;
                    case 3:
                        EditTask();
                        break;
                    case 4:
                        DeleteTask();
                        break;
                    case 5:
                        SearchTask();
                        break;
                    case 6:
                        DeleteAllTasks();
                        break;
                    case 0:
                        SaveTasks(); // Збереження завдань в файл перед виходом
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

    // Відображення всіх завдань
    static void ShowTasks()
    {
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
    }

    // Додавання нового завдання
    static void AddTask()
    {
        Console.Write("Enter a task name: ");
        string title = Console.ReadLine();
        TaskItem newTask = new TaskItem(title);
        taskList.Add(newTask);
        Console.WriteLine("Task added.");
    }

    // Редагування існуючого завдання
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
    }

    // Видалення існуючого завдання
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
    }

    // Пошук завдання за назвою
    static void SearchTask()
    {
        Console.Write("Enter the name of the task to search for: ");
        string searchTitle = Console.ReadLine();

        var foundTasks = taskList
            .Select((task, index) => new { Task = task, Index = index + 1 })
            .Where(task => task.Task.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase))
            .ToList();

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
    }

    // Видалення всіх завдань
    static void DeleteAllTasks()
    {
        Console.Write("Are you sure you want to delete all tasks? (Yes/No): ");
        string confirmation = Console.ReadLine();
        if (confirmation.Equals("Yes", StringComparison.OrdinalIgnoreCase))
        {
            taskList.Clear();
            Console.WriteLine("All tasks have been deleted.");
        }
    }

    // Збереження завдань в файл
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

    // Завантаження завдань з файлу
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

    public void Edit(string newTitle)
    {
        history.Add($"Changed: {DateTime.Now}, New name: {newTitle}");
        Title = newTitle;
    }

    public void ShowHistory()
    {
        Console.WriteLine("History of changes:");
        foreach (string entry in history)
        {
            Console.WriteLine(entry);
        }
    }
}
