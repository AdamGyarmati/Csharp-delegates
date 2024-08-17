namespace delegates;

class Program
{
    static void Main(string[] args)
    {
        ConnectToDatabase(PrintToFile);
    }

    // static void Print(string text)
    // {
    //     System.Console.WriteLine(text);
    // }

    static void ConnectToDatabase(PrintDelegate log)
    {
        // Do insertion
        log("Insertin data to database.");
        // Insertion done
        log("The record got inserted into the database.");
    }

    static PrintDelegate PrintConsole = (string text) =>
    {
        Console.WriteLine(text);
    };

    static PrintDelegate PrintToFile = (string text) =>
    {
        File.AppendAllText("./logs.txt", text);
    };

    delegate void PrintDelegate(string text);
}
