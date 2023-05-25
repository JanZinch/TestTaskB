using TestTask.Shapes;

namespace TestTask
{
    public static class ConsoleUtils
    {
        private const string IncorrectInputMessage = "Некорректный ввод";

        public static Matrix ReadMatrix()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\nВведите размеры матрицы: сначала строки, затем столбцы. Пример: 3x4");
                    
                    int[] dimensions = Console.ReadLine().Split('x', ' ').Select(int.Parse).ToArray();

                    float[,] sourceArray = new float[dimensions[0], dimensions[1]];

                    Console.WriteLine("Введите последовательно каждую строку матрицы. Пример строки: 1 -5 30 8");
            
                    for (int i = 0; i < sourceArray.GetLength(0); i++)
                    {
                        float[] inputRow = Console.ReadLine().Split(' ').Select(float.Parse).ToArray();
                
                        for (int j = 0; j < sourceArray.GetLength(1); j++)
                        {
                            sourceArray[i, j] = inputRow[j];
                        }
                    }

                    return new Matrix(sourceArray);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(IncorrectInputMessage);
                }
            }
            
        }

        public static FullName ReadFullName()
        {
            try
            {
                Console.WriteLine("\nВведите фамилию: ");
                string? surname = Console.ReadLine();

                Console.WriteLine("Введите имя: ");
                string? name = Console.ReadLine();
            
                Console.WriteLine("Введите отчество: ");
                string? patronymic = Console.ReadLine();
                
                return new FullName(surname, name, patronymic);
            }
            catch (Exception ex)
            {
                Console.WriteLine(IncorrectInputMessage);
            }
            
            return null;
        }
        
        public static KeyValuePair<FullName, string> ReadContact()
        {
            try
            {
                FullName fullName = ReadFullName();
                
                Console.WriteLine("Введите номер телефона: ");
                string? phoneNumber = Console.ReadLine();

                Console.WriteLine();
                return new KeyValuePair<FullName, string>(fullName, phoneNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(IncorrectInputMessage);
            }

            return default;
        }

        public static Rectangle ReadRectangle()
        {
            try
            {
                Console.WriteLine("\nВведите ширину прямоуголника: ");
                float sideA = float.Parse(Console.ReadLine());

                Console.WriteLine("Введите высоту прямоуголника: ");
                float sideB = float.Parse(Console.ReadLine());
                Console.WriteLine();
                
                return new Rectangle(sideA, sideB);
            }
            catch (Exception ex)
            {
                Console.WriteLine(IncorrectInputMessage);
            }

            return null;
        }

        public static Square ReadSquare()
        {
            try
            {
                Console.WriteLine("\nВведите длину стороны квадрата: ");
                float side = float.Parse(Console.ReadLine());
                return new Square(side);
            }
            catch (Exception ex)
            {
                Console.WriteLine(IncorrectInputMessage);
            }

            return null;
        }
        
        public static Circle ReadCircle()
        {
            try
            {
                Console.WriteLine("\nВведите радиус круга: ");
                float radius = float.Parse(Console.ReadLine());
                return new Circle(radius);
            }
            catch (Exception ex)
            {
                Console.WriteLine(IncorrectInputMessage);
            }

            return null;
        }
        
        public static Rhombus ReadRhombus()
        {
            try
            {
                Console.WriteLine("\nВведите длину стороны ромба: ");
                float side = float.Parse(Console.ReadLine());
                
                Console.WriteLine("Введите высоту ромба: ");
                float height = float.Parse(Console.ReadLine());
                
                return new Rhombus(side, height);
            }
            catch (Exception ex)
            {
                Console.WriteLine(IncorrectInputMessage);
            }

            return null;
        }
    }
}