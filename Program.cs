async static void Loading(int time)
{
    for (int i = 0; i < time; i++)
    {
        await Task.Delay(300);
        Console.Write(".");
    }
}

Console.ForegroundColor = ConsoleColor.Black;
Console.BackgroundColor= ConsoleColor.Green;
Console.Write("Loading");
Loading(5);
await Task.Delay(2000);
Console.WriteLine();
bool continueRunning = true;

while (continueRunning)
{








    Console.Write("Continue? Y/N: ");
    if (Console.ReadLine() == "n") continueRunning = false;
}