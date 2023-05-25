namespace TestTask.Shapes
{
    public class Rhombus : Shape
    {
        public readonly float Side;
        public readonly float Height;
        
        public override float Perimeter => 4 * Side;
        public override float Area => Side * Height;

        public Rhombus(float side, float height)
        {
            Side = side;
            Height = height;
        }

        public override bool Verify()
        {
            return Side > 0.0f && Height > 0.0f && Height < Side;
        }
    }
}