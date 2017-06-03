using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount;
            Console.WriteLine("Please, enter the number of input variables:");
            bool res = Int32.TryParse(Console.ReadLine(), out amount);

            bool[] results = new bool[8];
            bool[][] matrix = new bool[8][] { new bool[] { false, false, false},
                                              new bool[] { false, false, true},
                                              new bool[] { false, true, false},
                                              new bool[] { false, true, true},
                                              new bool[] { true, false, false},
                                              new bool[] { true, false, true},
                                              new bool[] { true, true, false},
                                              new bool[] { true, true, true}
                                            };


            Console.WriteLine("Please, enter the results of boolean function:");
            for (int i = 0; i < Math.Pow(2, amount); i++)
            {
                for (int k = 0; k < amount; k++)
                    Console.Write((matrix[i][k] == true ? "1" : "0") + " ");
                
                Console.Write(": ");
                int result;
                res = Int32.TryParse(Console.ReadLine(), out result);
                bool finalResult = (result == 1 ? true : false);
                results[i] = finalResult;
            }

            var boolFunction = new BooleanFunction(matrix, results);

            bool isConstantZero = boolFunction.IsConstantZero();
            bool isConstantOne = boolFunction.IsConstantOne();
            Console.WriteLine("is constant zero = " + isConstantZero + ", is constant one = " + isConstantOne);

            var pdnf = boolFunction.ConvertToPDNF();
            Console.WriteLine("pdnf presentation : " + pdnf);

            var pcnf = boolFunction.ConvertToPCNF();
            Console.WriteLine("pcnf presentation : " + pcnf);

            /*bool results3 = boolFunction.CheckSelfDuality();
            Console.WriteLine("has self-duality = " + results3);

           */
           
            Console.ReadLine();

        }
    }
}
