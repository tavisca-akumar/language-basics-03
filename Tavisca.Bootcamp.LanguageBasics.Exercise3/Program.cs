using System;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int[] calories = new int[protein.Length];
            for (int i = 0; i < carbs.Length; i++)
            {
                calories[i] = 5 * (carbs[i] + protein[i])+ 9 * fat[i];
            }

          
            int[] results = new int[dietPlans.Length];

            for (int i = 0; i < dietPlans.Length; i++)
            {
                string str = dietPlans[i];
                ArrayList ans = new ArrayList();
                if (str.Length > 1)
                {
                    for (int j = 0; j < str.Length; j++)
                    {
                        ArrayList ans1 = res(str[j].ToString(), protein, carbs, fat, calories, ans);

                      
                        if (ans1.Count == 1)
                        {
                            results[i] = (int)ans1[0];
                            break;
                        }

                       
                        else
                        {
                            ans = ans1;
                        }
                        results[i] = (int)ans1[0];
                    }
                }

               
                else if (str.Length == 1)
                {
                    results[i] = (int)res(str, protein, carbs, fat, calories)[0];
                }
            }

            return results;

            throw new NotImplementedException();
        }
        
        public static ArrayList Max(int[] arr, ArrayList Index)
        {

            int max = int.MinValue;
            ArrayList result = new ArrayList();

            if (Index != null && Index.Count != 0)
            {
                foreach (object o in Index)
                {
                    if (arr[(int)o] > max)
                    {
                        max = arr[(int)o];
                        result = new ArrayList();
                        result.Add((int)o);
                    }
                    else if (arr[(int)o] == max)
                    {
                        result.Add((int)o);
                    }
                }

            }
            else
            {

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > max)
                    {
                        max = arr[i];
                        result = new ArrayList();
                        result.Add(i);
                    }
                    else if (arr[i] == max)
                    {
                        result.Add(i);
                    }
                }
            }

            return result;
        }

        public static ArrayList Min(int[] arr, ArrayList Index)
        {
            int min = int.MaxValue;
            ArrayList ind = new ArrayList();
            if (Index != null && Index.Count > 0)
            {

                foreach (object o in Index)
                {
                    if (arr[(int)o] < min)
                    {
                        min = arr[(int)o];
                        ind = new ArrayList();
                        ind.Add((int)o);
                    }
                    else if (arr[(int)o] == min)
                    {
                        ind.Add((int)o);
                    }
                }
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] < min)
                    {
                        min = arr[i];
                        ind = new ArrayList();
                        ind.Add(i);
                    }
                    else if (arr[i] == min)
                    {
                        ind.Add(i);
                    }
                }
            }

            return ind;
        }
        public static ArrayList res(string str, int[] protein, int[] carbs, int[] fat, int[] calories, ArrayList Index=null)
        {
            ArrayList result= new ArrayList();

             if (str.Equals("p"))
            {
                result = Min(protein, Index);
            }
            else if (str.Equals("P"))
            {
                result = Max(protein, Index);
            }
            else if (str.Equals("c"))
            {
                result = Min(carbs, Index);
            }
            else if (str.Equals("C"))
            {
                result = Max(carbs, Index);
            }
            else if (str.Equals("f"))
            {
                result = Min(fat, Index);
            }
            else if (str.Equals("F"))
            {
                result = Max(fat, Index);
            }
            else if (str.Equals("t"))
            {
                result = Min(calories, Index);
            }
            else if (str.Equals("T"))
            { 
                result = Max(calories, Index);
            }


            return result;
        
        }
    }
}
