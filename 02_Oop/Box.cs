namespace _02_Oop
{

    internal class Box
    {
        private static readonly double ComparisonValue = 10e-9;

        public double Length { get; set; }
        public double Breadth { get; set; }
        public double Height { get; set; }

        public Box() { }
        public Box(double length, double breadth, double height)
        {
            Length = length;
            Breadth = breadth;
            Height = height;
        }

        public static Box operator +(Box b, Box c)
        {
            var box = new Box
            {
                Length = b.Length + c.Length,
                Breadth = b.Breadth + c.Breadth,
                Height = b.Height + c.Height
            };
            return box;
        }
        public static bool operator ==(Box lhs, Box rhs)
        {
            var status = Math.Abs(lhs.Length - rhs.Length) < ComparisonValue && Math.Abs(lhs.Height - rhs.Height) < ComparisonValue
                                                                             && Math.Abs(lhs.Breadth - rhs.Breadth) < ComparisonValue;
            return status;
        }
        public static bool operator !=(Box lhs, Box rhs)
        {
            var status = Math.Abs(lhs.Length - rhs.Length) > ComparisonValue || Math.Abs(lhs.Height - rhs.Height) > ComparisonValue ||
                         Math.Abs(lhs.Breadth - rhs.Breadth) > ComparisonValue;
            return status;
        }
        public static bool operator <(Box lhs, Box rhs)
        {
            var status = lhs.Length < rhs.Length && lhs.Height < rhs.Height
                                                 && lhs.Breadth < rhs.Breadth;
            return status;
        }
        public static bool operator >(Box lhs, Box rhs)
        {
            bool status = lhs.Length > rhs.Length && lhs.Height >
                rhs.Height && lhs.Breadth > rhs.Breadth;
            return status;
        }
        public override string ToString()
        {
            return $"({Length}, {Breadth}, {Height})";
        }
    }
}