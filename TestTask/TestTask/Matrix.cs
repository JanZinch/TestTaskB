using System;

namespace TestTask
{
    public struct Matrix
    {
        private readonly float[,] _baseArray;
        
        public Matrix(float[,] sourceArray)
        {
            _baseArray = new float[sourceArray.GetLength(0), sourceArray.GetLength(1)];
            Array.Copy(sourceArray, _baseArray, _baseArray.Length);
        }

        public override string ToString()
        {
            string result = string.Empty;
            
            for (int i = 0; i < _baseArray.GetLength(0); i++)
            {
                for (int j = 0; j < _baseArray.GetLength(1); j++)
                {
                    result += " " + _baseArray[i, j];
                }

                result += "\n";
            }

            return result;
        }

        public float GetMainDiagonalSum()
        {
            float sum = 0.0f;
            float diagonalSize = Math.Min(_baseArray.GetLength(0), _baseArray.GetLength(1));
            
            for (int i = 0; i < diagonalSize; i++)
            {
                sum += _baseArray[i, i];
            }

            return sum;
        }

        public float GetSumOfMultiples(float number)
        {
            float sum = 0.0f;
            
            for (int i = 0; i < _baseArray.GetLength(0); i++)
            {
                for (int j = 0; j < _baseArray.GetLength(1); j++)
                {
                    if (_baseArray[i, j] % number == 0)
                    {
                        sum += _baseArray[i, j];
                    }
                }
            }

            return sum;
        }
    }
}