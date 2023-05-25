using System;

namespace TestTask.Shapes
{
    public class Circle : Shape
    {
        public readonly float Radius;

        public override float Perimeter => 2 * (float) Math.PI * Radius;
        public override float Area => (float) (Math.PI * Math.Pow(Radius, 2));

        public Circle(float radius)
        {
            Radius = radius;
        }

        public override bool Verify()
        {
            return Radius > 0.0f;
        }
    }
}