using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{


    public class BooleanFunction
    {

        public List<bool[]> inputs = new List<bool[]>();
        public List<bool> result = new List<bool>();
        public string[] variables = new string[] { "x", "y", "z" };
        public BooleanFunction(bool[][] matrix, bool[] results)
        {
            for(int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
                inputs.Add(matrix[i]);

            result = results.ToList();
        }

        public bool IsConstantZero()
        {
            var row = inputs.First(r => r.All(input => input == false));
            int index = Array.IndexOf(inputs.ToArray(), row);
            return result[index] == false ? true : false;
        }

        public bool IsConstantOne()
        {
            var row = inputs.First(r => r.All(input => input == true));
            int index = Array.IndexOf(inputs.ToArray(), row);
            return result[index] == true ? true : false;
        }

        
        public string ConvertToPDNF()
        {
            var dnf = new StringBuilder();
            List<int> indexes = new List<int>();
            for(int i = 0; i < result.Count(); i++)
            {
                if (result[i] == true)
                    indexes.Add(i);
            }

            for (int k = 0; k < indexes.Count(); k++)
            {
                var res = String.Empty;
                for (int i = 0; i < 3; i++)
                {
                    if (inputs[indexes[k]][i] == true)
                    {
                        res += variables[i];
                    }
                    else
                    {
                        res += "-";
                        res += variables[i];
                    }

                    if (i != 2)
                        res += "*";

                }

                if (!res.Equals(String.Empty))
                    dnf.Append("(" + res + ")");
                if (k != indexes.Count() - 1)
                    dnf.Append("+");
            }

            return dnf.ToString();
        }

        /*public bool CheckSelfDuality()
        {
            var functionResults = new List<bool>();
            var results = new List<bool>();
            var pdnf = ConvertToPDNF();
            var expression = new PostfixNotationExpression();
            string[] postexp = expression.ConvertToPostfixNotation(pdnf);

            foreach (var row in rows)
            {
                bool[] array = row.inputs.ToArray();

                for (int i = 0; i < array.Length; i++) {
                    if (array[i] == true)
                        array[i] = false;
                    else
                        array[i] = true;
                }


                var functionResult = expression.Compute(row.inputs.ToArray(), postexp);
                var result = !expression.Compute(array, postexp);

                functionResults.Add(functionResult);
                results.Add(result);
            }

            for(int i = 0; i < functionResults.Count; i++)
            {
                if (functionResults[i] != results[i])
                    return false;
            }

            return true;

        }*/

        public string ConvertToPCNF()
        {
            var cnf = new StringBuilder();
            List<int> indexes = new List<int>();
            for (int i = 0; i < result.Count(); i++)
            {
                if (result[i] == false)
                    indexes.Add(i);
            }

            for (int k = 0; k < indexes.Count(); k++)
            {
                var res = String.Empty;
                for (int i = 0; i < 3; i++)
                {
                    if (inputs[indexes[k]][i] == false)
                    {
                        res += variables[i];
                    }
                    else
                    {
                        res += "-";
                        res += variables[i];
                    }

                    if (i != 2)
                        res += "+";

                }

                if (!res.Equals(String.Empty))
                    cnf.Append("(" + res + ")");
                if (k != indexes.Count() - 1)
                    cnf.Append("*");
            }

            return cnf.ToString();
        }

      

    } 

  

}
