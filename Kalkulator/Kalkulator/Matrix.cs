using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator
{
    internal class Matrix
    {
        public int CountOfColumn { get; }
        public int CountOfRow { get; }


        public decimal[][] Value;



        public Matrix(int countOfColumn, int countOfRow)
        {
            CountOfColumn = countOfColumn;
            CountOfRow = countOfRow;
            Value = new decimal[CountOfRow][];

            for (int i = 0; i < Value.Length; i++)
            {
                Value[i] = new decimal[CountOfColumn];
            }
        }

        public decimal[] GetRow(int rowNumber)
        {
            return Value[rowNumber];
        }

        public decimal[] GetColumn(int columnNumber)
        {
            var result = new decimal[CountOfRow];
            for (int i = 0; i < CountOfRow; i++)
            {
                result[i] = GetRow(i)[columnNumber];
            }
            return result;

        }
        
        public static Matrix operator *(Matrix value1, Matrix value2)
        {
            if (value1.CountOfRow == value2.CountOfColumn)
            {
                var result = new Matrix(value1.CountOfRow, value1.CountOfRow);

                for (int i = 0; i < value1.CountOfRow; i++)
                {
                    for (int j = 0; j < value1.CountOfRow; j++)
                    {
                        var column = value2.GetColumn(i);
                        var row = value1.GetRow(j);
                        result.Value[j][i] = MultVector(column, row);
                    }
                    
                }
                return result;
            }

            Console.WriteLine("Невозможно умножить матрицы");
            return null;

        }
        
        private static decimal MultVector(decimal[] value1, decimal[] value2)
        {
            decimal result = 0;
            string res = "";
            for (int i = 0; i < value1.Length; i++)
            {
                result += value1[i] * value2[i];
                res += value1[i] + "*" + value2[i] + "+";
            }

            res = res.Substring(0, res.Length - 1) + "=" + result;

            Console.WriteLine(res);

            return result;
        }

        public static Matrix operator +(Matrix value1, Matrix value2)
        {
            if (value1.CountOfRow == value2.CountOfColumn)
            {
                var result = new Matrix(value1.CountOfColumn, value2.CountOfRow);
                for (int i = 0; i < value1.CountOfColumn; i++)
                {
                    for (int j = 0; j < value1.CountOfRow; j++)
                    {
                        result.Value[i][j] = value1.Value[i][j] + value2.Value[i][j];
                    }
                }
                return result;
            }
            Console.WriteLine("Невозможно сложить матрицы");
            return null;            
        }

        public static Matrix operator -(Matrix value1, Matrix value2)
        {
            if (value1.CountOfRow == value2.CountOfColumn)
            {
                var result = new Matrix(value1.CountOfColumn, value2.CountOfRow);
                for (int i = 0; i < value1.CountOfColumn; i++)
                {
                    for (int j = 0; j < value1.CountOfRow; j++)
                    {
                        result.Value[i][j] = value1.Value[i][j] - value2.Value[i][j];
                    }
                }
                return result;
            }

            Console.WriteLine("Невызможно вычесть матрицы");
            return null;
        }

        public static Matrix operator /(Matrix value1, Matrix value2)
        {
            if(value1.CountOfRow == value2.CountOfColumn)
            {
                var result = new Matrix(value1.CountOfRow, value1.CountOfRow);

                for (int i = 0; i < value1.CountOfRow; i++)
                {
                    for (int j = 0; j < value1.CountOfRow; j++)
                    {
                        var column = value2.GetColumn(i);
                        var row = value1.GetRow(j);
                        result.Value[i][j] = ShareMatrix(column, row);
                    }
                }
                return result;
            }
            Console.WriteLine("Невозможно раздерить матрицы");
            return null;
        }

        private static decimal ShareMatrix(decimal[] value1, decimal[] value2)
        {
            decimal result = 0;
            string res = "";
            for (int i = 0; i < value1.Length; i++)
            {
                result += value1[i] / value2[i];
                res += value1[i] + "/" + value2[i] + "+";

            }
            res = res.Substring(0, res.Length - 1) + "=" + result;

            Console.WriteLine(res);
            return result;
        }

        public Matrix Transport()
        {
            var transMatrix = new Matrix(CountOfColumn, CountOfRow);
            for(int i = 0; i < CountOfRow; i++)
            {
                for(int j = 0; j < CountOfColumn; j++)
                {
                    transMatrix.Value[j][i] = Value[i][j];
                } 
            }
            return transMatrix;
        }


        

        public static void ShowMatrix(Matrix matrix)
        {
          for(int i =0; i < matrix.Value.Length; i++)
            {
                for(int j = 0; j < matrix.Value[i].Length; j++)
                {
                    Console.Write(String.Format("{0:F1}", matrix.Value[i][j]) + "\t");
                }
                Console.WriteLine();
            }   
        }
    }
}
