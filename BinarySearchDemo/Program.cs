using System.Diagnostics;

namespace BinarySearchDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            Random random = new Random();
            int n = 100000;
            int[] nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = random.Next(1000);
            }

            bool found;
            int foundCount = 0, iteration = 0;
            stopwatch.Start();
            for (int i = 0; i < 10; i++)// doing the search for 1 lakh time
            {
                 found = linearSearch(nums, random.Next(10000), out int iter);
                iteration += iter;
                if (found)
                    foundCount++;
            }
            stopwatch.Stop();
            Console.WriteLine($"LinearSearch : Elapsed time - {stopwatch.ElapsedMilliseconds / 1000} seconds, " +
                $"foundCount - {foundCount}, iteration = {iteration}");


            foundCount = 0;
            iteration = 0;
            Array.Sort(nums);
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < 10; i++)// doing the search for 1 lakh time
            {
                found = binarySearch(nums, random.Next(10000), out int iter);
                iteration += iter;
                if (found)
                    foundCount++;
            }
            stopwatch.Stop();
            Console.WriteLine($"BinarySearch : Elapsed time - {stopwatch.ElapsedMilliseconds / 1000} seconds," +
                $"foundCount - {foundCount}, iteration = {iteration}");
        }

        private static bool binarySearch(int[] nums, int v, out int iter)
        {
            int l = 0, r = nums.Length - 1;
            iter = 0;
            while(l<r)
            {
                iter++;
                int mid = (l+r)/2;
                if (nums[mid] == v)
                    return true;
                else if (nums[mid] < v)
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            return false;
        }

        private static bool linearSearch(int[] nums, int v, out int iteration)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == v)
                {
                    iteration = i;
                    return true;
                }
            }
            iteration = nums.Length;
            return false;
        }
    }
}