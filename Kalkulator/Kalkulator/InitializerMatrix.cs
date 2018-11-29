using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator
{
    

    internal class InitializerMatrix
    {
        static int row;
        static int column;
        static Matrix matrixOne;
        static Matrix matrixTwo;

        private static void InitializerVariables()
        {
            column = SetVariableSize("колонок");
            row = SetVariableSize("строк");
        }
        
        public static int SetVariableSize(string variableName)
        {
            int variable = 0;
            Console.Write($"Введите количество {variableName}: ");
            variable = int.Parse(Console.ReadLine());
            return variable;
        }

        private static Matrix CreateMatrix()
        {
            return new Matrix(column, row);
        }

        public static Matrix AddMatrix()
        {
            InitializerVariables();
            Matrix matrix = CreateMatrix();
            Console.WriteLine("Задайте значения матрицы:");           
            for(int i = 0; i < matrix.Value.Length; i++)
            {                
                for(int j = 0; j < matrix.Value[i].Length; j++)
                {
                    Console.Write("Число: ");                    
                    matrix.Value[i][j] = decimal.Parse(Console.ReadLine());
                }
            }                                              
            return matrix;
        }
        
        public static void AdditionTwoMatrix()
        {
            matrixOne = AddMatrix();
            Console.WriteLine("Матрица 1: ");
            Matrix.ShowMatrix(matrixOne);
            matrixTwo = AddMatrix();
            Console.WriteLine("Матрица 2: ");
            Matrix.ShowMatrix(matrixTwo);
        }



        public static void Choice()
        {
            Console.Write("Введите действие: ");
            string selection = Console.ReadLine();
            switch (selection)
            {                
                case "+":
                    AdditionTwoMatrix();
                    Matrix matrixSum = matrixOne + matrixTwo;
                    Console.WriteLine("Сумма первой и второй матрицы: ");
                    Matrix.ShowMatrix(matrixSum);
                    break;

                case "*":
                    AdditionTwoMatrix();
                    Matrix matrixMult = matrixOne * matrixTwo;
                    Console.WriteLine("Умножение первой и второй матрицы равно: ");
                    Matrix.ShowMatrix(matrixMult);
                    break;

                case "-":
                    AdditionTwoMatrix();
                    Matrix matrixDifference = matrixOne - matrixTwo;
                    Console.WriteLine("Разность первой и второй матрицы: ");
                    Matrix.ShowMatrix(matrixDifference);
                    break;

                case "/":
                    AdditionTwoMatrix();
                    Matrix matrixShare = matrixOne / matrixTwo;
                    Console.WriteLine("Деление первой и второй матрицы: ");
                    Matrix.ShowMatrix(matrixShare);
                    break;

                case "T":
                    matrixOne = AddMatrix();
                    Console.WriteLine("Матрица: ");
                    Matrix.ShowMatrix(matrixOne);
                    Console.WriteLine("Транспорированая матрица");
                    Matrix matrixTrans = matrixOne.Transport();
                    Matrix.ShowMatrix(matrixTrans);
                    break;
                default:
                    Console.WriteLine("Не корректный ввод");
                    break;


            }
        }


    }
}
