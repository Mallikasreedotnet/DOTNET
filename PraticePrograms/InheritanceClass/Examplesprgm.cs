namespace InheritanceClass
{
    public class Examplesprgm
    {
        public void arraynumbers()
        {
            int num=Convert.ToInt32(Console.ReadLine());
            int[] numbers=new int[num];
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Enter data");
                int data = Convert.ToInt32(Console.ReadLine());
                numbers[i] = data;
            }
            Console.WriteLine("your data");
            foreach (int item in numbers)
            {
                //Console.WriteLine("Enter data");
                //int data = Convert.ToInt32(Console.ReadLine());
                //numbers[item] = data;
                //Console.WriteLine("your data");

                Console.WriteLine(item);
            }
        }
    }
}
