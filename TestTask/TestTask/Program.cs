using System;
using TestTask.Shapes;

namespace TestTask
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Для выбора задачи нажмите соостветствующую клавишу:\n" +
                              "1. Матрицы.\n" +
                              "2. Рекурсивные алгоритмы.\n" +
                              "3. Хеширование данных.\n" +
                              "4. ООП.\n");
            
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    LaunchMatrixTask();
                    break;
                    
                case '2':
                    LaunchRecursiveTask();
                    break;
                
                case '3':
                    LaunchContactDirectory();
                    break;
                
                case '4':
                    LaunchShapeFactory();
                    break;
            }
        }

        private static void LaunchMatrixTask()
        {
            Matrix matrix = ConsoleUtils.ReadMatrix();
            Console.WriteLine("Сумма чисел главной диагонали: " + matrix.GetMainDiagonalSum());
            Console.WriteLine("Сумма чисел, кратных 3: " + matrix.GetSumOfMultiples(3));
        }

        private static void LaunchRecursiveTask()
        {
            try
            {
                Console.WriteLine("\nВведите индекс для метода Фибоначчи: ");
                int index = int.Parse(Console.ReadLine());
                Console.WriteLine("Число Фибоначчи: " + RecursiveMath.FibonacciNumber(index));
            
                Console.WriteLine("\nВведите число для возведения в степень: ");
                float number = float.Parse(Console.ReadLine());
            
                Console.WriteLine("Введите степень: ");
                int power = int.Parse(Console.ReadLine());
            
                Console.WriteLine("Результат возведения: " + RecursiveMath.Pow(number, power));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void LaunchContactDirectory()
        {
            ContactDirectory contactDirectory = new ContactDirectory();
            bool needToExit = false;
            string msgBuffer;
            
            while (!needToExit)
            {
                Console.WriteLine("\nНажмите соостветствующую клавишу:\n" +
                                  "1. Добавить контакт.\n" +
                                  "2. Удалить контакт.\n" +
                                  "3. Редактировать контакт.\n" +
                                  "4. Найти номер по ФИО.\n"+
                                  "0. Выйти");
            
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        
                        var newContact = ConsoleUtils.ReadContact();
                        msgBuffer = contactDirectory.AddContact(newContact.Key, newContact.Value)
                            ? "Контакт добавлен"
                            : "Данный контакт уже существует";
                        
                        Console.WriteLine(msgBuffer);
                        break;
                    
                    case '2':
                        
                        var removableFullName = ConsoleUtils.ReadFullName();
                        msgBuffer = contactDirectory.RemoveContact(removableFullName)
                            ? "\nКонтакт удалён"
                            : "\nДанного контакта не существует";
                        
                        Console.WriteLine(msgBuffer);
                        break;
                    
                    case '3':
                        
                        var editableFullName = ConsoleUtils.ReadFullName();
                        string oldPhoneNumber = contactDirectory.GetPhoneNumber(editableFullName);
                        
                        if (oldPhoneNumber != null)
                        {
                            Console.WriteLine("\nТекущий номер телефона: " + oldPhoneNumber + 
                                              "\nВведите новый номер или нажмите Enter для отмены");

                            string newPhoneNumber = Console.ReadLine();

                            if (!string.IsNullOrEmpty(newPhoneNumber))
                            {
                                contactDirectory.RewritePhoneNumber(editableFullName, newPhoneNumber);
                                Console.WriteLine("\nКонтакт отредактирован");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nДанного контакта не существует");
                        }
                        
                        break;
                
                    case '4': 
                    
                        var desiredFullName = ConsoleUtils.ReadFullName();
                        string phoneNumber = contactDirectory.GetPhoneNumber(desiredFullName);

                        msgBuffer = phoneNumber != null
                            ? "\nНомер телефона: " + phoneNumber
                            : "\nДанного контакта не существует";
                        
                        Console.WriteLine(msgBuffer);
                        break;
                    
                    case '0':
                        needToExit = true;
                        break;
                }
            }
        }

        private static void LaunchShapeFactory()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            
            while (true)
            {
                Console.WriteLine("\nЧтобы создать фигуру, нажмите соостветствующую клавишу:\n" +
                                  "1. Прямоугольник.\n" +
                                  "2. Квадрат.\n" +
                                  "3. Круг.\n" +
                                  "4. Ромб.\n"+
                                  "0. Выйти");

                string input = Console.ReadKey(true).KeyChar.ToString();

                if (input == "0") break;
                
                if (int.TryParse(input, out int inputNumber))
                {
                    try
                    {
                        bool needToExit = false;
                        Shape shape = shapeFactory.CreateShape((ShapeFactory.ShapeType) inputNumber);
                        
                        while (!needToExit)
                        {
                            Console.WriteLine("\nЧтобы просмотреть свойства фигуры, нажмите соостветствующую клавишу:\n" +
                                              "1. Периметр фигуры.\n" +
                                              "2. Площадь фигуры.\n" +
                                              "0. Выйти в меню");
                        
                            switch (Console.ReadKey(true).KeyChar)
                            {
                                case '1':
                                    Console.WriteLine("\nПериметр фигуры: " + shape.Perimeter);
                                    break;
                    
                                case '2':
                                    Console.WriteLine("\nПлощадь фигуры: " + shape.Area);
                                    break;
                            
                                case '0':
                                    needToExit = true;
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}