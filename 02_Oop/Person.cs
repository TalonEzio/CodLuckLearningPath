namespace _02_Oop
{
    public record PersonShort(string FirstName, string LastName);
    public record Person(string FirstName, string LastName)
    {
        public string FirstName { get; set; } = FirstName;
        public string LastName { get; set; } = LastName;

        public override string ToString() => $"{FirstName} {LastName}";
    }

}
