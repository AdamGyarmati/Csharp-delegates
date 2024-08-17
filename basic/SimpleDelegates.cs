namespace delegates;

public class SimpleDelegates
{
    public delegate void PrintDelegate(string text);

    public void Print(string text)
    {
        System.Console.WriteLine(text);
    }

    public void ConnectToDatabase(PrintDelegate log)
    {
        // Do insertion
        log("Insertin data to database.");
        // Insertion done
        log("The record got inserted into the database.");
    }

    public PrintDelegate PrintConsole = (string text) =>
    {
        Console.WriteLine(text);
    };

    public PrintDelegate PrintToFile = (string text) =>
    {
        File.AppendAllText("./logs.txt", text);
    };
}
