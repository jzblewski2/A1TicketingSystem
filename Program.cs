namespace A1TicketingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.csv";
            string choice;
            do
            {
                Console.WriteLine(" (1) read ticketing system ");
                Console.WriteLine(" (2) add ticket ");
                Console.WriteLine("press any other key to exit ");

                choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        sr.ReadLine();
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("file doesn't exist ");
                    }
                }
                else if (choice == "2")
                {
                    StreamWriter sw = new StreamWriter(file, true);
                    char response;
                    do
                    {
                        Console.WriteLine("enter new ticket? (Y/N) ");
                        response = Convert.ToChar(Console.ReadLine().ToUpper());
                        if (response == 'N')
                            break;
                        Console.WriteLine("enter ticket id: ");
                        string id = Console.ReadLine();
                        Console.WriteLine("enter ticket summary: ");
                        string summary = Console.ReadLine();
                        Console.WriteLine("enter status (Open/Closed): ");
                        string status = Console.ReadLine();
                        Console.WriteLine("enter priority (Low/High): ");
                        string priority = Console.ReadLine();
                        Console.WriteLine("enter first and last name of submitter: ");
                        string submitter = Console.ReadLine();
                        Console.WriteLine("enter first and last name of assigned: ");
                        string assigned = Console.ReadLine();
                        char onWatch;
                        string personWatched;
                        List<string> watching = new List<string>();
                        do
                        {
                            Console.WriteLine("enter first and last name of person(s) watching? (Y/N) ");
                            onWatch = Convert.ToChar(Console.ReadLine().ToUpper());
                            if (onWatch == 'N')
                                break;
                            watching.Add(Console.ReadLine());
                        } while (onWatch == 'Y');
                        personWatched = string.Join(" | ", watching);
                        sw.WriteLine($"{id}, {summary}, {status}, {priority}, {submitter}, {assigned}, {personWatched}");
                    } while (response == 'Y');
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}