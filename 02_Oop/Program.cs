using System.Text;

namespace _02_Oop
{
    internal class Program
    {
        static void Main()
        {
            Console.InputEncoding = Console.OutputEncoding = Encoding.Unicode;

            Student student1 = new Student("Test");
            Student student2 = new Student("Test", 23);

            student1.ShowInfo();
            ConsoleHelper.WriteLine("Test static method", bgColor: ConsoleColor.Red, reset: true);

            student2.ShowInfo(ConsoleColor.Blue);

            Console.WriteLine($"Next id: {Student.AutoIncrementId}");

            Student student3 = new Student("Test");

            student3.ShowInfo();

            var box1 = new Box(6, 7, 5);
            var box2 = new Box(12, 13, 10);
            var box4 = new Box();


            var box3 = box1 + box2;
            Console.WriteLine("Box 3: {0}", box3);


            Console.WriteLine(box1 > box2 ? "Box1 lớn hơn Box2" : "Box1 không lớn hơn Box2");
            Console.WriteLine(box3 == box4 ? "Box3 bằng Box4" : "Box3 không bằng Box4");



            var vector = new Vector(1, 2);

            Console.WriteLine($"{vector[0]} - {vector[1]} - {vector[2]}");

            for (int i = 0; i < vector.Length; ++i)
            {
                Console.WriteLine(vector[i]);
            }


            var person1 = new Person("John", "Doe");
            var person2 = new Person("John", "Doe");

            Console.WriteLine(person1);
            Console.WriteLine(person1 == person2);


            var person4 = person1 with { FirstName = "Zed" };

            Console.WriteLine(person4);

            Console.WriteLine(person1 == person4);

            var data1 = new Data() { Id = 1, Name = "Data1" };
            var data2 = new Data() { Id = 2, Name = "Data2" };

            Console.WriteLine("Before change:");
            Console.WriteLine(data1);
            Console.WriteLine(data2);

            ParameterPassingTest.Change(data1);
            ParameterPassingTest.ChangeWithRefKeyword(ref data2);

            Console.WriteLine("After change:");
            Console.WriteLine(data1);
            Console.WriteLine(data2);
        }
    }
}
