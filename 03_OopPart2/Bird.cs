namespace _03_OopPart2
{
    internal class Bird
    {
        private int _weight;
        public int Weight
        {
            get => _weight;
            set
            {
                if (value > 0)
                    _weight = value;
            }
        }
        public void Feed() => _weight += 10;
        public Bird() => Console.WriteLine($"Bird created");
        public Bird(int weight)
        {
            _weight = weight;
            Console.WriteLine($"Bird created, {_weight} gr.");
        }
        public void Fly() => Console.WriteLine("Bird is flying");


        public virtual void FlyVirtual() => Console.WriteLine("Bird is flying");
    }
    internal class Parrot : Bird
    {
        public Parrot() => Console.WriteLine("Parrot created");
        public Parrot(int weight) : base(weight) { }

        public new void Fly() => Console.WriteLine("Parrot is flying");

        public void Speak() => Console.WriteLine("Parrot is speaking");


    }
    internal class Cockatoo : Parrot
    {
        public Cockatoo() => Console.WriteLine("Cockatoo created");
        public void Dance() => Console.WriteLine("Cockatoo is dancing");
    }

    class Chicken : Bird
    {
        public new void Fly() => Console.WriteLine("Chicken can't fly!");

        public override void FlyVirtual()
        {
            Console.WriteLine("Chicken can't fly!");
        }
    }
}