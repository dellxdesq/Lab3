using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3;
public class QueueThirdTask
{
    private Queue<string> customerQueue;

    public QueueThirdTask()
    {
        customerQueue = new Queue<string>();
    }

    public void EnqueueCustomer(string customerName)
    {
        customerQueue.Enqueue(customerName);
        Console.WriteLine($"{customerName} встал в очередь.");
    }

    public void ServeCustomers()
    {
        while (customerQueue.Count > 0)
        {
            string servedCustomer = customerQueue.Dequeue();
            Console.WriteLine($"{servedCustomer} обслужен.");
        }

        Console.WriteLine("Очередь пуста. Все клиенты обслужены.");
    }

    
    public static void BankServiceSimulation()
    {
        QueueThirdTask bankSimulation = new QueueThirdTask();
        bankSimulation.EnqueueCustomer("Иван");
        bankSimulation.EnqueueCustomer("Мария");
        bankSimulation.EnqueueCustomer("Петр");

        Console.WriteLine("Обслуживание клиентов:");
        bankSimulation.ServeCustomers();
    }
}
