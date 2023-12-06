namespace Lab3;

public class StackOperations
{
    public static void DoStackOperations()
    {
        for (int iteration = 1; iteration <= 100; iteration++)
        {
            Console.WriteLine($"Номер прохода: {iteration}:");
            Generator.GenerateInputFile(iteration);

            ModifiedStack<object> stack = new ModifiedStack<object>();

            try
            {
                string[] operations = File.ReadAllText("input.txt").Split(' ');

                for (int i = 0; i < operations.Length - 1; i++)
                {
                    int operationCode = int.Parse(operations[i]);
                    ProcessOperation(operationCode, stack, ref i, operations);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ошибка! Файл input.txt не найден.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка выполнения операций: {ex.Message}");
            }

            Console.WriteLine();
        }
        TasksChoice.ReturnToMainMenu("Stack");
    }

    private static void ProcessOperation<T>(int operationCode, ModifiedStack<T> stack, ref int currentIndex, string[] operations)
    {
        switch (operationCode)
        {
            case 1:
                T value = (T)Convert.ChangeType(operations[currentIndex + 1], typeof(T));
                stack.Push(value);
                currentIndex++; 
                break;
            case 2:
                stack.Pop();
                break;
            case 3:
                var topElement = stack.Top();
                Console.WriteLine($"Top element: {topElement}");
                break;
            case 4:
                bool isEmpty = stack.IsEmpty();
                Console.WriteLine($"Is Empty: {isEmpty}");
                break;
            case 5:
                stack.Print();
                break;
            default:
                Console.WriteLine($"Неизвестная операция: {operationCode}");
                break;
        }
    }
    public static void DoStackOperationsFromFile()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string outputFilePath = Path.Combine(desktopPath, "ModifiedStack.xlsx");
        string chartName = "ModifiedStack";

        List<Tuple<int, double>> results = new List<Tuple<int, double>>();

        for (int size = 10; size <= 30000; size += 10)
        {
            Console.WriteLine($"Размер стека: {size}");

            Generator.GenerateInputStackFile(size);

            ModifiedStack<object> stack = new ModifiedStack<object>();
            TimeMeter timer = new TimeMeter();

            try
            {
                timer.Start();
                ProcessStackOperations(size, stack, results);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл inputStack.txt не найден.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка выполнения операций: {ex.Message}");
            }
            TimeSpan elapsedTotal = timer.Stop();
            results.Add(new Tuple<int, double>(size, elapsedTotal.TotalMilliseconds));
        }

        ResultsCollectorToExcel.WriteToExcel(results, outputFilePath, chartName);
        TasksChoice.ReturnToMainMenu("Stack");
    }

    private static void ProcessStackOperations(int size, ModifiedStack<object> stack, List<Tuple<int, double>> results)
    {
        string[] operations = File.ReadAllText("inputStack.txt").Split(' ');

        for (int i = 0; i < operations.Length - 1; i++)
        {
            int op = int.Parse(operations[i]);
            PerformStackOperation(op, stack, ref i, operations);
        }
    }

    private static void PerformStackOperation(int op, ModifiedStack<object> stack, ref int i, string[] operations)
    {
        switch (op)
        {
            case 1:
                if (i + 1 < operations.Length)
                {
                    i++;
                    object element = operations[i];
                    stack.Push(element);
                }
                break;
            case 2:
                stack.Pop();
                break;

            case 3:
                stack.Top();
                break;
            case 4:
                stack.IsEmpty();
                break;
            case 5:
                stack.Print(false);
                break;
            default:
                Console.WriteLine("Неверная операция");
                break;
        }
    }

    public static void DoPostfixOperation()
    {
        Console.WriteLine("Задание 1.4 - Вычисление в постфиксной записи");
        Console.WriteLine("Введите выражение для вычисления:");

        string expression = Console.ReadLine();

        while (!IsPostfixExpressionValid(expression))
        {
            Console.WriteLine("Выражение введено неверно. Пожалуйста, повторите ввод:");
            expression = Console.ReadLine();
        }

        try
        {
            double result = Calculator.PostfixCalculate(expression);
            Console.WriteLine($"Выражение: {expression} = {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при вычислении выражения: {ex.Message}");
        }
        TasksChoice.ReturnToMainMenu("Stack");
    }

    private static bool IsPostfixExpressionValid(string expression)
    {
        expression = expression.Replace(" ", "");
        if (string.IsNullOrWhiteSpace(expression))
        {
            return false;
        }

        if (expression.Length < 3)
        {
            return false;
        }

        bool hasOperand = false;
        bool hasOperation = false;

        foreach (char ch in expression)
        {
            if (char.IsDigit(ch))
            {
                hasOperand = true;
            }
            else if (IsOperator(ch))
            {
                hasOperation = true;
            }

            if (hasOperand && hasOperation)
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsOperator(char ch)
    {
        return "+-*/^".Contains(ch);
    }

    public static void DoInfixToPostfixOperation()
    {
        Console.WriteLine("Задание 1.5 - Перевод из инфиксной в постфиксную запись");
        Console.WriteLine("Введите инфиксное выражение:");

        string infixExpression = Console.ReadLine();

        try
        {
            string postfixExpression = InfixToPostfixConverter.ConvertToPostfix(infixExpression);
            Console.WriteLine("");
            Console.WriteLine($"Постфиксное: {postfixExpression}");

            double result = Calculator.PostfixCalculate(postfixExpression);
            Console.WriteLine($"Результат: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        TasksChoice.ReturnToMainMenu("Stack");
    }

    public static void DoStandartStackOperation()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string outputFilePath = Path.Combine(desktopPath, "StandartStack.xlsx");
        string chartName = "StandartStack";

        List<Tuple<int, double>> results = new List<Tuple<int, double>>();

        for (int size = 10; size <= 30000; size += 10)
        {
            Console.WriteLine($"Размер стека: {size}");

            Generator.GenerateInputStackFile(size);
            Stack<object> stack = new Stack<object>();
            TimeMeter timer = new TimeMeter();
            timer.Start();

            try
            {
                ProcessStackOperations(size, stack, results);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл inputStack.txt не найден.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка выполнения операций: {ex.Message}");
            }
            TimeSpan elapsedTotal = timer.Stop();
            results.Add(new Tuple<int, double>(size, elapsedTotal.TotalMilliseconds));
        }

        ResultsCollectorToExcel.WriteToExcel(results, outputFilePath, chartName);
        TasksChoice.ReturnToMainMenu("Stack");
    }

    private static void ProcessStackOperations(int size, Stack<object> stack, List<Tuple<int, double>> results)
    {
        string[] operations = File.ReadAllText("inputStack.txt").Split(' ');

        for (int i = 0; i < operations.Length - 1; i++)
        {
            int op = int.Parse(operations[i]);
            PerformStackOperation(op, stack, ref i, operations);
        }
    }

    private static void PerformStackOperation(int op, Stack<object> stack, ref int currentIndex, string[] operations)
    {
        switch (op)
        {
            case 1:
                if (currentIndex + 1 < operations.Length)
                {
                    currentIndex++;
                    object element = operations[currentIndex];
                    stack.Push(element);
                }
                break;
            case 2:
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
                break;
            case 3:
                if (stack.Count > 0)
                {
                    stack.Peek();
                }
                break;
            case 4:
                if (stack.Count == 0)
                {
                    bool isEmpty = true;
                }
                break;
            case 5:
                foreach (var item in stack)
                {
                }
                break;
            default:
                Console.WriteLine("Неверная операция");
                break;
        }
    }



}

