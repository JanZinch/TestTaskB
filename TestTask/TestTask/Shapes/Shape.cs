namespace TestTask.Shapes
{
    public abstract class Shape
    {
        public abstract float Perimeter { get; }
        public abstract float Area { get; }
        
        public abstract bool Verify();
    }
}