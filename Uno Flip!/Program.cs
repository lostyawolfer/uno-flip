class Program
{
    static void Main()
    {

    }

    static float GetFloat(string question)
    {
        float result;
        string input;

        do
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(question);
            Console.ForegroundColor = ConsoleColor.White;
            input = Console.ReadLine();
        } while (!float.TryParse(input, out result));

        return result;
    }
}