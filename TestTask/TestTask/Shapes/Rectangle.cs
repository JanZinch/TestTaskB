namespace TestTask.Shapes
{
    public class Rectangle : Shape
    {
        public readonly float SideA;
        public readonly float SideB;
        
        public override float Perimeter => 2 * (SideA + SideB);
        public override float Area => SideA * SideB;
        
        public Rectangle(float sideA, float sideB)
        {
            SideA = sideA;
            SideB = sideB;
        }
        
        public override bool Verify()
        {
            return SideA > 0.0f && SideB > 0.0f;
        }
        
    }
}