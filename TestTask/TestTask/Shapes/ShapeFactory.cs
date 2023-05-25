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
                    createdShape = ConsoleUtils.ReadRectangle("Введите ширину прямоуголника: ", "Введите высоту прямоуголника: ");
                    break;
                
                case ShapeType.Square:
                    createdShape = ConsoleUtils.ReadSquare("Введите длину стороны квадрата: ");
                    break;
                
                case ShapeType.Circle:
                    createdShape = ConsoleUtils.ReadCircle("Введите радиус круга: ");
                    break;
                
                case ShapeType.Rhombus:
                    createdShape = ConsoleUtils.ReadRhombus("Введите длину стороны ромба: ", "Введите высоту ромба: ");
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