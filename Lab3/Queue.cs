namespace Lab3;
public class ModifiedQueue<T>
{
    private LinkedList<T> elements;

    public ModifiedQueue()
    {
        elements = new LinkedList<T>();
    }

    public void Enqueue(T item)
    {
        elements.AddLast(item);
    }

    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Очередь пуста");
        }

        T value = elements.First.Value;
        elements.RemoveFirst();
        return value;
    }

    public bool IsEmpty() => elements.Count == 0;

    public void Print()
    {
        foreach (T item in elements)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Очередь пуста");
        }

        return elements.First.Value;
    }

    public void Print(bool isExcel)
    {
        
    }
}
