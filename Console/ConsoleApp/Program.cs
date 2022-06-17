using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        public static List<int> GetRank(List<int> ranked, List<int> player)
        {
            var result = new List<int>();

            ranked = ranked.OrderByDescending(i => i).ToList();
            player.Sort();
            Dictionary<int, int> rankedIndexes = new Dictionary<int, int>();
            int k = 1;
            for (int i = 0; i < ranked.Count; i++)
            {
                if (!rankedIndexes.ContainsValue(ranked[i]))
                {
                    rankedIndexes.Add(k, ranked[i]);
                    k++;
                }
            }
            int j = 0;
            foreach (int p in player)
            {
                result.Add(j);
                //rankedIndexes.Where(r=> r.Value >= p && r.Value <p)
                foreach (KeyValuePair<int, int> rankedIndex in rankedIndexes)
                {
                    if (p >= ranked.Max())
                    {
                        result[j] = 1;
                    }
                    else
                    {
                        if (!rankedIndexes.ContainsValue(p))
                        {
                            if (rankedIndex.Value < p)
                            {
                                result[j] = rankedIndex.Key == 1 ? 1 : rankedIndex.Key - 1;
                            }
                            else if (rankedIndex.Value > p)
                            {
                                result[j] = rankedIndex.Key + 1;
                            }
                            else
                            {
                                result[j] = rankedIndex.Key;
                            }
                        }
                    }
                }
                j++;
            }

            return result;
        }
        static void Main(string[] args)
        {
            //TODO: Change this input file path before start
            var filePath = "D:\\FaqInterview\\InterviewSourceCode\\Console\\ConsoleApp\\Input.txt";

            var lines = System.IO.File.ReadLines(filePath).ToList();

            int rankedCount = Convert.ToInt32(lines[0].Trim());

            List<int> ranked = lines[1].TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

            int playerCount = Convert.ToInt32(lines[2].Trim());

            List<int> player = lines[3].TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

            List<int> result = GetRank(ranked, player);

            Console.WriteLine(String.Join("\n", result));

        }
    }
}
