namespace _02_Oop
{
    public class Student
    {
        private static int _autoIncrementId = 1;
        
        static Student()
        {
            _autoIncrementId = Random.Shared.Next(10);
        }

        public static int AutoIncrementId
        {
            get => _autoIncrementId;
            private set => _autoIncrementId = value;
        }


        public int Id { get; }

        public string Name { get; set; }

        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                if (value is < 0 or > 100)
                {
                    throw new Exception("Invalid Age");
                }
                _age = value;
            }
        }

        public Student(string name)
        {
            Id = _autoIncrementId++;
            Name = name;
            Age = 1;
        }
        public Student(string name, int age) : this(name)
        {
            Age = age;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Id: {Id} - Name: {Name} - Age: {Age}");
        }

        public void ShowInfo(ConsoleColor fgColor)
        {
            Console.ForegroundColor = fgColor;
            ShowInfo();
            Console.ResetColor();
        }
    }
}
