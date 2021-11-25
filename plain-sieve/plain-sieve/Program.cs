using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace plain_sieve
{
    class Program
    {
        static void Main(string[] args)
        {
            if ((args[0] == "--primes" || args[0] == "-p") && int.TryParse(args[1], out var result))
            {
                computePrimesUpToN(result);
            }
            else
            {
                Console.WriteLine("No maximum number provided. Aborting.");
          }
        }

        private static void computePrimesUpToN(int n)
        {
            var primes = Enumerable.Repeat(true, n).ToArray();
            primes[0] = primes[1] = false;

            var endpoint = Math.Sqrt(n);
            for (var i = 2; i < endpoint; i++)
            {
                for (var j = i * i; j < n; j += i)
                {
                    primes[j] = false;
                }
            }
            
            DisplayPrimes(primes);
        }

        private static void DisplayPrimes(bool[] primes)
        {
            var result = new List<string>();
            for (var i = 0; i < primes.Length; i++)
            {
                if (primes[i])
                {
                    result.Add(i.ToString());
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
