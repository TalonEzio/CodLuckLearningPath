namespace _02_Oop
{

    class Vector
    {
        private readonly double[] _components;
        public Vector(int dimension)
        {
            _components = new double[dimension];
        }
        public Vector(params double[] components)
        {
            _components = components;
        }
        public override string ToString()
        {
            return $"({string.Join(", ", _components)})";
        }

        public double this[int index]
        {
            get => (index < _components.Length) ? _components[index] : double.NaN;
            set { if (index < _components.Length) _components[index] = value; }
        }

        public int Length => _components.Length;
    }
}