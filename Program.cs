using System;
using System.Collections.Generic;

namespace Potions
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            Console.Write("N: "); 
            N = int.Parse(Console.ReadLine());

            List<int>[] _recipes = new List<int>[N-2];

            for (int i = 0; i < N - 2; i++)
            {
                _recipes[i] = new List<int>();

                Console.Write($"Рецепт {i + 3} зелья: ");
                string[] s = Console.ReadLine().Split(' ');
                int[] recipe = Array.ConvertAll(s, int.Parse);

                for (int j = 1; j < recipe.Length; j++)
                {
                    if (recipe[j] == 1 || recipe[j] == 2)
                    {
                        _recipes[i].Add(recipe[j]);
                    }
                    else
                    {
                        try
                        {
                            _recipes[i].AddRange(_recipes[recipe[j] - 3]);
                        }
                        catch (Exception)
                        {
                            _recipes[i].Add(recipe[j]);
                        }
                    }
                }

            }

            List<int>[] recipes = new List<int>[N - 2];
            for (int i = 0; i < _recipes.Length; i++)
            {
                recipes[i] = new List<int>();

                int[] recipe = _recipes[i].ToArray();
                for (int j = 0; j < recipe.Length; j++)
                {
                    if (recipe[j] == 1 || recipe[j] == 2)
                    {
                        recipes[i].Add(recipe[j]);
                    }
                    else
                    {
                        recipes[i].AddRange(_recipes[recipe[j] - 3]);
                    }
                }
            }

            int Q;
            Console.Write("Q:");
            Q = int.Parse(Console.ReadLine());

            List<int> answer = new List<int>();
            for (int i = 0; i < Q; i++)
            {
                Console.Write("X Y S: ");
                string[] s = Console.ReadLine().Split(' ');
                int[] question = Array.ConvertAll(s, int.Parse);
                int X = question[0];
                int Y = question[1];
                int S = question[2];

                bool skip = false;
                for (int j = 0; j < recipes[S - 3].Count && !skip; j++)
                {
                    if (recipes[S - 3][j] == 1)
                        X--;
                    else if (recipes[S - 3][j] == 2)
                        Y--;
                    else skip = true;
                }

                if (X >= 0 && Y >= 0 && !skip) 
                    answer.Add(1); 
                else 
                    answer.Add(0);
            }

            foreach (var item in answer)
            {
                Console.Write(item);
            }
        }
    }
}
