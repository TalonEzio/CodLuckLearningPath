namespace _01_Overview
{
    internal class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public uint Age { get; set; }

        public override string ToString()
        {
            return $"My id is {Id}, my name is {Name} and i am {Age} years old";
        }
    }
}
