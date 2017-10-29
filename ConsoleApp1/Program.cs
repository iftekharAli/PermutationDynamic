using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] intInput = { "0", "1", "2", "3","4" };

            var arraytoList = intInput.ToList();

            for (int i = intInput.Length - 1; i > 1; i--)
            {
                IEnumerable<IEnumerable<string>> permutationsWithRept = GetPermutations<string>(arraytoList, i);
                PermutationToResultSet(permutationsWithRept, arraytoList);
                Console.WriteLine("________________________");
            }



            Console.ReadKey();
        }

        private static void PermutationToResultSet(IEnumerable<IEnumerable<string>> permutationsWithRept, List<string> arraytoList)
        {
            List<string> tempList = new List<string>();


            string result = string.Empty;
            string exceptString = string.Empty;
            foreach (IEnumerable<string> enumerable in permutationsWithRept)
            {
                tempList = new List<string>();
                foreach (var i in enumerable)
                {
                    tempList.Add(i);
                }
                var except = arraytoList.Except(tempList);

                result = tempList.Aggregate<string>((i, j) => i + "," + j);
                exceptString = except.Aggregate((i, j) => i + "," + j);
                Console.WriteLine(result + "=>" + exceptString);

            }

            if (arraytoList.Count-1 == tempList.Count)
            {


                foreach (IEnumerable<string> enumerable in permutationsWithRept)
                {
                    tempList = new List<string>();
                    foreach (var i in enumerable)
                    {
                        tempList.Add(i);
                    }
                    var except = arraytoList.Except(tempList);

                    result = tempList.Aggregate<string>((i, j) => i + "," + j);
                    exceptString = except.Aggregate((i, j) => i + "," + j);
                    Console.WriteLine(exceptString + "=>" + result);

                }
            }



        }

        // Print out the permutations of the input 
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int count)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (count == 1)
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetPermutations(items.Skip(i + 1), count - 1))
                        yield return new T[] { item }.Concat(result);
                }

                ++i;
            }
        }
    }
}
