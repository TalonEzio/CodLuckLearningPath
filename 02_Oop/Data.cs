namespace _02_Oop
{
    public class Data
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
    public static class ParameterPassingTest
    {
        public static void Change(Data data)
        {
            data.Id += 10; 
            data.Name += " Edited";

            data = new Data { Id = 100, Name = "Donald Trump" };

        }
        public static void ChangeWithRefKeyword(ref Data data)
        {
            data.Id += 10;
            data.Name += " Edited";

            data = new Data { Id = 100, Name = "Donald Trump" };
        }
    }

}