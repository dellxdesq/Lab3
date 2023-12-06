namespace Lab3
{
    public class QueuesOperations
    {
        public static void DoQueuesOperations()
        {
            for (int size = 1; size <= 100; size++)
            {
                Console.WriteLine($"Номер прохода: {size}:");

                Generator.GenerateInputFile(size);

                ModifiedQueue<string> queue = new ModifiedQueue<string>();

                try
                {
                    string[] operations = File.ReadAllText("input.txt").Split(' ');

                    for (int i = 0; i < operations.Length - 1; i++)
                    {
                        int op = int.Parse(operations[i]);
                        ProcessQueueOperation(op, i, operations, queue);
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Файл queue_input.txt не найден.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка выполнения операций: {ex.Message}");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
            TasksChoice.ReturnToMainMenu("Queue");
        }

        private static void ProcessQueueOperation(int op, int i, string[] operations, ModifiedQueue<string> queue)
        {
            switch (op)
            {
                case 1:
                    if (i + 1 < operations.Length)
                    {
                        string element = operations[i + 1];
                        queue.Enqueue(element);
                        Console.WriteLine($"Enqueue: {element}");
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("Enqueue: Недостаточно аргументов для операции.");
                    }
                    break;
                case 2:
                    try
                    {
                        string dequeuedItem = queue.Dequeue();
                        Console.WriteLine($"Dequeue: {dequeuedItem}");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"Dequeue: {ex.Message}");
                    }
                    break;
                case 3:
                    try
                    {
                        string peekedItem = queue.Peek();
                        Console.WriteLine($"Peek: {peekedItem}");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"Peek: {ex.Message}");
                    }
                    break;
                case 4:
                    Console.WriteLine($"IsEmpty: {queue.IsEmpty()}");
                    break;
                case 5:
                    if (queue.IsEmpty())
                    {
                        Console.WriteLine("Print: Queue is Empty.");
                        break;
                    }
                    queue.Print();
                    break;
                default:
                    Console.WriteLine("Неверная операция");
                    break;
            }
        }

        public static void DoQueueOperationsWithSameLenghtFile() 
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outputFilePath = Path.Combine(desktopPath, "CustomQueueSameLength.xlsx");
            string chartName = "CustomQueue_SameLength";
            int isSameLenght = 1;

            List<Tuple<int, double>> results = new List<Tuple<int, double>>();
            ExecuteQueueOperations(results, "inputQueueDifferent.txt", isSameLenght);

            ResultsCollectorToExcel.WriteToExcel(results, outputFilePath, chartName);

            Console.WriteLine();
            TasksChoice.ReturnToMainMenu("Queue");
        }
        public static void DoDifferentQueueOperationWithFile()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outputFilePath = Path.Combine(desktopPath, "CustomQueue.xlsx");
            string chartName = "CustomQueue";
            int isChoose = 2;

            List<Tuple<int, double>> resultsDifferent = new List<Tuple<int, double>>();
            ExecuteQueueOperations(resultsDifferent, "inputQueue.txt", isChoose);

            ResultsCollectorToExcel.WriteToExcel(resultsDifferent, outputFilePath, chartName);

            Console.WriteLine();
            TasksChoice.ReturnToMainMenu("Queue");
        }

        private static void ExecuteQueueOperations(List<Tuple<int, double>> results, string fileName, int chooseFile)
        {
            bool isExcel = true;

            for (int size = 10; size <= 10000; size += 10)
            {
                Console.WriteLine($"Номер прохода: {size}:");

                try
                {
                    if (chooseFile == 1)
                    {
                        Generator.GenerateInputQueueSametFile();
                    }
                    else if (chooseFile == 2)
                    {
                        Generator.GenerateInputQueueFile(size);
                    }

                    ModifiedQueue<string> queue = new ModifiedQueue<string>();
                    TimeMeter timer = new TimeMeter();
                    timer.Start();

                    ProcessQueueOperations(queue, fileName, isExcel);

                    TimeSpan elapsedTotal = timer.Stop();
                    results.Add(new Tuple<int, double>(size, elapsedTotal.TotalMilliseconds));
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"Файл {fileName} не найден.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка выполнения операций: {ex.Message}");
                }
            }
        }

        private static void ProcessQueueOperations(ModifiedQueue<string> queue, string fileName, bool isExcel)
        {
            string[] operations = File.ReadAllText(fileName).Split(' ');

            for (int i = 0; i < operations.Length - 1; i++)
            {
                int op = int.Parse(operations[i]);

                switch (op)
                {
                    case 1:
                        if (i + 1 < operations.Length)
                        {
                            string element = operations[i + 1];
                            queue.Enqueue(element);
                            i++;
                        }
                        break;
                    case 2:   
                        try
                        {
                            string dequeuedItem = queue.Dequeue();
                        }
                        catch (InvalidOperationException) { }
                        break;
                    case 3:
                        try
                        {
                            string peekedItem = queue.Peek();
                        }
                        catch (InvalidOperationException) { }
                        break;
                    case 4:
                        bool isEmpty = queue.IsEmpty();
                        break;
                    case 5:
                        queue.Print(isExcel);
                        break;
                    default:
                        Console.WriteLine("Неверная операция");
                        break;
                }
            }
        }
        public static void DoStandartQueueOperation() 
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outputFilePath = Path.Combine(desktopPath, "Queue - График выполнения операций.xlsx");
            string chartName = "Queue - График выполнения операций";

            List<Tuple<int, double>> results = new List<Tuple<int, double>>();

            for (int size = 10; size <= 10000; size += 10)
            {
                Console.WriteLine($"Номер прохода: {size}");

                try
                {
                    Generator.GenerateInputQueueFile(size);

                    Queue<object> queue = new Queue<object>();
                    TimeMeter timer = new TimeMeter();
                    timer.Start();

                    ProcessQueueOperationsWithQueue(queue);

                    TimeSpan elapsedTotal = timer.Stop();
                    results.Add(new Tuple<int, double>(size, elapsedTotal.TotalMilliseconds));
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Файл inputQueue.txt не найден.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка выполнения операций: {ex.Message}");
                }
            }

            ResultsCollectorToExcel.WriteToExcel(results, outputFilePath, chartName);
            TasksChoice.ReturnToMainMenu("Queue");
        }

        private static void ProcessQueueOperationsWithQueue(Queue<object> queue)
        {
            string[] operations = File.ReadAllText("inputQueue.txt").Split(' ');

            for (int i = 0; i < operations.Length - 1; i++)
            {
                int op = int.Parse(operations[i]);

                switch (op)
                {
                    case 1:
                        if (i + 1 < operations.Length)
                        {
                            i++;
                            object element = operations[i];
                            queue.Enqueue(element);
                        }
                        break;
                    case 2:
                        if (queue.Count > 0)
                        {
                            object dequeuedItem = queue.Dequeue();
                        }
                        break;
                    case 3:
                        if (queue.Count > 0)
                        {
                            object peekedItem = queue.Peek();
                        }
                        break;
                    case 4:
                        if (queue.Count == 0)
                        {
                            bool isEmpty = true;
                        }
                        break;
                    case 5:
                        foreach (var item in queue) { }
                        break;
                    default:
                        Console.WriteLine("Неверная операция");
                        break;
                }
            }
        }

    }

}
