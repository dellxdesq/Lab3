using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class TreeThirdTask
    {
        public int Value { get; set; }
        public List<TreeThirdTask> Children { get; set; }

        public TreeThirdTask(int value)
        {
            Value = value;
            Children = new List<TreeThirdTask>();
        }

        static int SumTreeValues(TreeThirdTask root)
        {
            if (root == null)
            {
                return 0;
            }

            int sum = root.Value;

            foreach (var child in root.Children)
            {
                sum += SumTreeValues(child);
            }

            return sum;
        }

        public static void DepthTree()
        {
            // Создаем дерево
            TreeThirdTask root = new TreeThirdTask(10);
            TreeThirdTask node1 = new TreeThirdTask(5);
            TreeThirdTask node2 = new TreeThirdTask(15);
            TreeThirdTask node3 = new TreeThirdTask(3);
            TreeThirdTask node4 = new TreeThirdTask(7);

            root.Children.Add(node1);
            root.Children.Add(node2);
            node1.Children.Add(node3);
            node1.Children.Add(node4);

            // Вызываем функцию для обхода дерева в глубину и подсчета суммы значений
            int sum = SumTreeValues(root);

            // Выводим результат
            Console.WriteLine(root);
            Console.WriteLine($"Сумма значений узлов дерева: {sum}");
        }
    }
}
