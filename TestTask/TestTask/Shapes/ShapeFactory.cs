using System;

namespace TestTask.Shapes
{
    public class ShapeFactory
    {
        public enum ShapeType
        {
            None = 0,
            Rectangle = 1,
            Square = 2,
            Circle = 3,
            Rhombus = 4,
        }

        public Shape CreateShape(ShapeType shapeType)
        {
            Shape createdShape;
            
            switch (shapeType)
            {
                case ShapeType.Rectangle:
                    createdShape = ConsoleUtils.ReadRectangle();
                    break;
                
                case ShapeType.Square:
                    createdShape = ConsoleUtils.ReadSquare();
                    break;
                
                case ShapeType.Circle:
                    createdShape = ConsoleUtils.ReadCircle();
                    break;
                
                case ShapeType.Rhombus:
                    createdShape = ConsoleUtils.ReadRhombus();
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(shapeType), shapeType, null);
            }

            if (createdShape.Verify())
            {
                return createdShape;
            }
            else
            {
                throw new Exception("Данной фигуры не существует");
            }
        }


    }
}