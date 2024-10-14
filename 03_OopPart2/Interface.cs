namespace _03_OopPart2
{
    internal interface IPet
    {
        void Feed();
        void Sound();
    }
    internal interface IBird
    {
        void Fly();
        void Sound();
        void Feed();
    }
    internal class Cat : IPet
    {
        public Cat() => Console.WriteLine("I'm a cat. ");

        public void Feed() => Console.WriteLine("Fish, please!");
        public void Sound() => Console.WriteLine("Meow meow!");
    }
    internal class Dog : IPet // Dog thực thi IPet
    {
        public Dog() => Console.WriteLine("I'm a dog. ");

        void IPet.Feed() => Console.WriteLine("Bone, please!");
        void IPet.Sound() => Console.WriteLine("Woof woof!");
    }
    internal class ParrotFromInterface : IPet, IBird
    {
        public ParrotFromInterface() => Console.WriteLine("I'm a parrot. ");

        public void Feed() => Console.WriteLine("Nut, please!");
        public void Fly() => Console.WriteLine("Yeah, I can fly!");

        void IPet.Sound() => Console.WriteLine("I can speak!");
        void IBird.Sound() => Console.WriteLine("I can sing, too!");
    }
    internal class BirdLover(IBird bird)
    {
        public void Play()
        {
            Console.Write("Fly ...");
            bird.Fly();
            Console.Write("Say something ...");
            bird.Sound();
            Console.Write("What do you like to eat? ");
            bird.Feed();
        }
    }
    internal class PetLover(IPet pet)
    {
        public void Play()
        {
            Console.Write("What do you like to eat? ");
            pet.Feed();
            Console.Write("Now say something ... ");
            pet.Sound();
        }
    }

}