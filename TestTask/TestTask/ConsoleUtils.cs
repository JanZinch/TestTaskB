using TestTask.Shapes;

namespace TestTask
{
    public static class ConsoleUtils
    {
        private const string IncorrectInputMessage = "Некорректный ввод";

        public static Matrix ReadMatrix(string inputDimensionsMsg, string inputStringsMsg, string incorrectInputMsg = IncorrectInputMessage)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"\n{inputDimensionsMsg}");
                    
                    int[] dimensions = Console.ReadLine().Split('x', ' ').Select(int.Parse).ToArray();

                    float[,] sourceArray = new float[dimensions[0], dimensions[1]];

                    Console.WriteLine(inputStringsMsg);
            
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
                    Console.WriteLine(incorrectInputMsg);
                }
            }
            
        }

        public static Tuple<string, string> ReadContact(string inputFullNameMsg, string inputNumberMsg, string incorrectInputMsg = IncorrectInputMessage)
        {
            try
            {
                string fullName = ReadFullName(inputFullNameMsg, incorrectInputMsg);
                
                Console.WriteLine(inputNumberMsg);
                string? phoneNumber = Console.ReadLine();

                Console.WriteLine();
                return new Tuple<string, string>(fullName, phoneNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(incorrectInputMsg);
            }

            return null;
        }

        public static string ReadFullName(string inputFullNameMsg, string incorrectInputMsg = IncorrectInputMessage)
        {
            try
            {
                Console.WriteLine(inputFullNameMsg);
                return Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(incorrectInputMsg);
            }

            return null;
        }

        public static Rectangle ReadRectangle(string inputWidthMsg, string inputHeightMsg, string incorrectInputMsg = IncorrectInputMessage)
        {
            try
            {
                Console.WriteLine($"\n{inputWidthMsg}");
                float sideA = float.Parse(Console.ReadLine());

                Console.WriteLine(inputHeightMsg);
                float sideB = float.Parse(Console.ReadLine());
                Console.WriteLine();
                
                return new Rectangle(sideA, sideB);
            }
            catch (Exception ex)
            {
                Console.WriteLine(incorrectInputMsg);
            }

            return null;
        }

        public static Square ReadSquare(string inputSideMsg, string incorrectInputMsg = IncorrectInputMessage)
        {
            try
            {
                Console.WriteLine($"\n{inputSideMsg}");
                float side = float.Parse(Console.ReadLine());
                return new Square(side);
            }
            catch (Exception ex)
            {
                Console.WriteLine(incorrectInputMsg);
            }

            return null;
        }
        
        public static Circle ReadCircle(string inputRadiusMsg, string incorrectInputMsg = IncorrectInputMessage)
        {
            try
            {
                Console.WriteLine($"\n{inputRadiusMsg}");
                float radius = float.Parse(Console.ReadLine());
                return new Circle(radius);
            }
            catch (Exception ex)
            {
                Console.WriteLine(incorrectInputMsg);
            }

            return null;
        }
        
        public static Rhombus ReadRhombus(string inputSideMsg, string inputHeightMsg, string incorrectInputMsg = IncorrectInputMessage)
        {
            try
            {
                Console.WriteLine($"\n{inputSideMsg}");
                float side = float.Parse(Console.ReadLine());
                
                Console.WriteLine(inputHeightMsg);
                float height = float.Parse(Console.ReadLine());
                
                return new Rhombus(side, height);
            }
            catch (Exception ex)
            {
                Console.WriteLine(incorrectInputMsg);
            }

            return null;
        }
    }
}