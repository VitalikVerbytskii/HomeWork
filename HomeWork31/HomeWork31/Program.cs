using System;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

class Program
{
    static void Main(string[] args)
    {
        
        Data data = GetDataFromUser();

        
        XMLManager xmlManager = new XMLManager(data);
        JSONManager jsonManager = new JSONManager(data);

       
        xmlManager.Save("data.xml");
        jsonManager.Save("data.json");

        Data loadedDataFromXml = xmlManager.Load("data.xml");
        Data loadedDataFromJson = jsonManager.Load("data.json");

        Console.WriteLine("Data XML:");
        Console.WriteLine(loadedDataFromXml);

        Console.WriteLine("Data JSON:");
        Console.WriteLine(loadedDataFromJson);
    }

    static Data GetDataFromUser()
    {
        Console.WriteLine("Enter the data:");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Email: ");
        string email = Console.ReadLine();

        return new Data { Name = name, Age = age, Email = email };
    }
}

[Serializable]
public class Data
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Email: {Email}";
    }
}

class XMLManager
{
    private Data data;

    public XMLManager(Data data)
    {
        this.data = data;
    }

    public void Save(string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Data));
        using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
        {
            serializer.Serialize(fileStream, data);
        }
    }

    public Data Load(string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Data));
        using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
        {
            return (Data)serializer.Deserialize(fileStream);
        }
    }
}

class JSONManager
{
    private Data data;

    public JSONManager(Data data)
    {
        this.data = data;
    }

    public void Save(string fileName)
    {
        string json = JsonSerializer.Serialize(data);
        File.WriteAllText(fileName, json);
    }

    public Data Load(string fileName)
    {
        string json = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<Data>(json);
    }
}
