using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReLearn2019
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<HashSet<string>> vertexes= new List<HashSet<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
			{
                String[] inputSplited = Console.ReadLine().Split();
                addToList(inputSplited, vertexes);
            };

            foreach (var hashVertex in vertexes)
            {
                Console.WriteLine(string.Join(",", hashVertex));
                
            }
            var minVertexCount = vertexes.Min(x => x.Count);
            var gaphCount = vertexes.Count;
            Console.WriteLine("Graphs count:" + gaphCount);
            Console.WriteLine("Min:" + minVertexCount);

		}

        private static List<HashSet<string>> addToList(String[] inputSplited, List<HashSet<string>> vertexes)
        {
            string a = inputSplited[0];
            string b = inputSplited[1];

            foreach (var hashVertex in vertexes) {
                    if(hashVertex.Contains(a) || hashVertex.Contains(b))
                    {
                        hashVertex.Add(a);
                        hashVertex.Add(b);
                        return vertexes;
                    }
            }
            HashSet<string> newHash = new HashSet<string>();
            newHash.Add(a);
            newHash.Add(b);
            vertexes.Add(newHash);
            return vertexes;
        }
     }
 }
/*
8
1 2
2 4
4 1
3 6
3 5
3 7
6 7 
16 5 
*/
