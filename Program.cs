using ConsoleIO;

main();

void main()
{
    bool isWork = true;

    ConsoleIOHandler consIO = new ConsoleIOHandler();

    while (isWork)
    {
        consIO.PrintMainMenu();

        int taskNo = consIO.ReadInt("a task number", 0, 3, consIO.msgNoSuchOption);

        switch (taskNo)
        {
            case 1: Task64NaturalNumbers(); break;
            case 2: Task66SumOfNaturalElements(); break;
            case 3: Task68AckermannFunction(); break;
            case 0: isWork = false; break;
            default: System.Console.WriteLine(consIO.msgNoSuchOption); break;
        }

        if (isWork)
            consIO.WaitForAnyKey();
    }
}

#region Task64 Natural numbers
// Задача 64: Задайте значение N. Напишите программу, которая выведет все натуральные числа в промежутке от N до 1.
// Выполнить с помощью рекурсии.
// N = 5 -> "5, 4, 3, 2, 1"
// N = 8 -> "8, 7, 6, 5, 4, 3, 2, 1"
void Task64NaturalNumbers()
{
    ConsoleIOHandler consIO = new ConsoleIOHandler();

    Console.Clear();

    System.Console.WriteLine("Natural numbers from N to 1");

    System.Console.WriteLine(NaturalNumbersToString(consIO.ReadInt("N")));
}

string NaturalNumbersToString(int N)
{
    if (N > 1)
        return N.ToString() + ", " + NaturalNumbersToString(N - 1);
    else return "1" + Environment.NewLine;
}
#endregion

#region Task66 Sum Of Natural Elements
// Задача 66: Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.
// M = 1; N = 15 -> 120
// M = 4; N = 8. -> 30
void Task66SumOfNaturalElements()
{
    ConsoleIOHandler consIO = new ConsoleIOHandler();

    Console.Clear();

    System.Console.WriteLine("Sum of natural numbers from M to N");
    int m = consIO.ReadInt("M", 1, int.MaxValue, "Input error. Please enter a natural nmber up to {1}");
    int n = consIO.ReadInt("N", 1, int.MaxValue, "Input error. Please enter a natural nmber up to {1}");

    if (m > n)
    {
        int temp = n;
        n = m;
        m = temp;
    }

    System.Console.WriteLine($"Sum of natural numbers from {m} to {n} is {SumOfNaturalNumbers(m, n)}");

}

int SumOfNaturalNumbers(int fromVal, int toVal)
{
    if (fromVal < toVal)
        return fromVal + SumOfNaturalNumbers(fromVal + 1, toVal);
    else
        return toVal;
}
#endregion

#region Task68 Ackermann Function
// Задача 68: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
// m = 2, n = 3 -> A(m,n) = 9
// m = 3, n = 2 -> A(m,n) = 29
void Task68AckermannFunction()
{
    ConsoleIOHandler consIO = new ConsoleIOHandler();

    Console.Clear();

    System.Console.WriteLine("Ackermann function A(m, n)");

    int m = consIO.ReadInt("m", 0, 5, "It is impossible to show the result for m > {1}");
    int n = 0;

    if (m <= 3)
        n = consIO.ReadInt("n", 0, int.MaxValue, "It is impossible to show the result for entered m and n > {1}");
    else if (m == 4)
        n = consIO.ReadInt("n", 0, 1, "It is impossible to show the result for entered m and n > {1}");
    else System.Console.WriteLine("For m = 5 it is only possible to show the result for n = 0");
    
    System.Console.WriteLine($"A({m}, {n}) = {Ack(m, n)}");
}


int Ack (int m, int n)
{
    if (m == 0)
        return n + 1;
    else if (n == 0)
        return Ack(m - 1, 1);
    else
        return Ack(m - 1, Ack(m, n - 1));

}

#endregion
