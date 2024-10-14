namespace _03_OopPart2
{
    public partial class Student
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public partial void ChangeName(string firstName, string lastName);
    }



    public partial class Student
    {
        public override string ToString()
        {
            return $"{FirstName} {LastName} ({DateOfBirth.ToShortDateString()})";
        }
        public partial void ChangeName(string firstName, string lastName)
        { 
            FirstName = firstName;
            LastName = lastName;

            Console.WriteLine($"new name: {FirstName} {LastName}");
        }

    }

}