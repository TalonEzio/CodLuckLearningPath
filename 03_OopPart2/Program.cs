namespace _03_OopPart2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Bird:");
            var bird = new Bird(50) { Weight = 100 }; // 100
            bird.Feed();
            Console.WriteLine($"Weight: {bird.Weight}");
            bird.Fly();

            Console.WriteLine("".PadLeft(40, '-'));
            Console.WriteLine("Parrot:");
            var parrot = new Parrot(200);
            parrot.Feed();
            Console.WriteLine($"Weight: {parrot.Weight}");
            parrot.Fly();
            parrot.Speak();

            Console.WriteLine("".PadLeft(40, '-'));
            Console.WriteLine("Cockatoo:");
            var cockatoo = new Cockatoo { Weight = 300 };
            cockatoo.Feed();
            Console.WriteLine($"Weight: {cockatoo.Weight}");
            cockatoo.Fly();
            cockatoo.Speak();
            cockatoo.Dance();


            Console.WriteLine("".PadLeft(40, '-'));
            Bird parrotBird = new Parrot();
            Parrot cockatooParrot = new Cockatoo();

            parrotBird.Fly();//Bird is flying

            (parrotBird as Parrot)?.Fly();//Parrot is flying



            Console.WriteLine("".PadLeft(40, '-'));

            Chicken chicken = new Chicken();
            chicken.Fly();//Chicken can't fly 

            (chicken as Bird)?.Fly();//Bird is flying

            chicken.FlyVirtual();//Chicken can't fly 
            chicken.FlyVirtual();//Chicken can't fly 



            Console.WriteLine("".PadLeft(40, '-'));

            IPet pet = new Dog();
            var petLover = new PetLover(pet);
            petLover.Play();

            petLover = new PetLover(new ParrotFromInterface());
            petLover.Play();

            var birdLover = new BirdLover(new ParrotFromInterface());
            birdLover.Play();

            var cat = new Cat();
            cat.Feed(); cat.Sound();

            IPet cat2 = new Cat();
            cat2.Feed(); cat2.Sound();

            ParrotFromInterface parrotFromInterface = new ParrotFromInterface();
            parrotFromInterface.Feed(); parrotFromInterface.Fly();

            IBird parrot2 = new ParrotFromInterface();
            parrot2.Feed(); parrot2.Fly(); 
            
            (parrot2 as IPet)?.Sound();// I can speak!
            parrot2.Sound();// I can sing, too!
            

            IPet dog = new Dog();
            dog.Feed(); dog.Sound();

            Console.ReadLine();
        }
    }
}
