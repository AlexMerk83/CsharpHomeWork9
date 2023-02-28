namespace ConsoleIO
{
    #region Input and Output methods
    internal class ConsoleIOHandler
    {
        #region Output Support Methods

        public string msgAnyKeyRequest = "Press any key to continue...";
        public string msgNoSuchOption = "There is no such option. Try again.";


        public void PrintMainMenu()
        {
            Console.Clear();

            System.Console.WriteLine("Homework 9 tasks:");
            System.Console.WriteLine("1 - Task64: Natural numbers from N to 1");
            System.Console.WriteLine("2 - Task66: Sum of natural numbers from M to N");
            System.Console.WriteLine("3 - Task68: Ackermann function");
            System.Console.WriteLine("0 - Exit");
        }

        public void WaitForAnyKey()
        {
            System.Console.WriteLine();
            System.Console.WriteLine(msgAnyKeyRequest);
            Console.ReadKey();
        }

        public void ClearLine(int lineShift = 0, bool keepCursor = true)
        {
            int currentTop = Console.CursorTop,
                currentLeft = Console.CursorLeft;

            Console.SetCursorPosition(0, currentTop + lineShift);
            Console.Write(new string(' ', Console.WindowWidth));

            if (keepCursor)
                Console.SetCursorPosition(currentLeft, currentTop);
            else
                Console.SetCursorPosition(0, currentTop + lineShift);
        }

        #endregion

        #region Input Support Methods

        public const string defaultIntErrorMessage = "Input error. Please enter an integer number.";
        private const string defaultRangeErrorMessage = "Input error. Please enter an integer number from the range {0}..{1}.";
        public const string defaultDoubleErrorMessage = "Input error. Please enter a real number.";

        public int ReadInt(string argument)
        {
            int parsedNum = 0,
                inputFieldX = 0,
                inputFieldY = 0;

            System.Console.Write($"Enter {argument}: ");
            inputFieldX = Console.CursorLeft;
            inputFieldY = Console.CursorTop;
            while (!int.TryParse(Console.ReadLine(), out parsedNum))
            {
                Console.SetCursorPosition(0, inputFieldY);
                ClearLine();
                System.Console.WriteLine($"Enter {argument}: ");
                System.Console.WriteLine(defaultIntErrorMessage);
                Console.SetCursorPosition(inputFieldX, inputFieldY);
            }

            ClearLine();

            return parsedNum;
        }

        public int ReadInt(string argument, int minValue, int maxValue, string errorMessage = defaultRangeErrorMessage)
        {
            int parsedNum = 0,
                inputFieldX = 0,
                inputFieldY = 0;

            System.Console.Write($"Enter {argument}: ");
            inputFieldX = Console.CursorLeft;
            inputFieldY = Console.CursorTop;
            while (!int.TryParse(Console.ReadLine(), out parsedNum) || parsedNum < minValue || parsedNum > maxValue)
            {
                Console.SetCursorPosition(0, inputFieldY);
                ClearLine();
                System.Console.WriteLine($"Enter {argument}: ");
                System.Console.WriteLine(errorMessage, minValue, maxValue);
                Console.SetCursorPosition(inputFieldX, inputFieldY);
            }

            ClearLine();

            return parsedNum;
        }

        public double ReadDouble(string argument)
        {
            double parsedNum = 0.0;
            int inputFieldX = 0,
                inputFieldY = 0;

            System.Console.Write($"Enter {argument}: ");
            inputFieldX = Console.CursorLeft;
            inputFieldY = Console.CursorTop;
            while (!double.TryParse(Console.ReadLine(), out parsedNum))
            {
                Console.SetCursorPosition(0, inputFieldY);
                ClearLine();
                System.Console.WriteLine($"Enter {argument}: ");
                System.Console.WriteLine(defaultDoubleErrorMessage);
                Console.SetCursorPosition(inputFieldX, inputFieldY);
            }

            ClearLine();

            return parsedNum;
        }
        #endregion
    }
    #endregion
}