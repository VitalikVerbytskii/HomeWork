
class Program
{
    static void Main(string[] args)
    {
       
        Console.Write("Enter the path to the log file: ");
        string Constanta  = @"C:\Users\vital\Downloads\test.txt";

        try
        {
           
            if (File.Exists(Constanta))
            {
                Console.WriteLine("File found.");
            }
            else
            {
                Console.WriteLine("File no found.");
                return;
            }

           
            string[] lines = File.ReadAllLines(Constanta);

            
            int totalEntries = lines.Length;
            int errorCount = 0;
            int warningCount = 0;
            int infoCount = 0;

            foreach (string line in lines)
            {
                if (line.Contains("ERROR"))
                {
                    errorCount++;
                }
                else if (line.Contains("WARNING"))
                {
                    warningCount++;
                }
                else if (line.Contains("INFO"))
                {
                    infoCount++;
                }
            }

            
            string report = $"Total number of entries: {totalEntries}" +
                            $"Number of errors : {errorCount}" +
                            $"Number of warnings : {warningCount}" +
                            $"Number of information records : {infoCount}";

           
            Console.WriteLine("Report:");
            Console.WriteLine(report);

          
            string reportConstanta  = Path.Combine(Path.GetDirectoryName(Constanta), "log_report.txt");
            File.WriteAllText(reportConstanta , report);
            Console.WriteLine($"The report is saved in the file: {reportConstanta }");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
