using System;
using System.Collections.Generic;
using System.Linq;

namespace MegaPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter value: ");
            int input = Convert.ToInt32(Console.ReadLine());

            MegaPrimesWriter writer = new MegaPrimesWriter();

            // we firstly identify the primes
            List<int> primes = writer.WorkoutConstituentPrimes(input);

            // we then identify the megaprimes
            List<int> megaPrimes = writer.WorkoutMegaprimes(primes);

            // finally we display the megaprimes to the console if any
            writer.DisplayMegaprimes(megaPrimes);
        }       
    }
    
    public class MegaPrimesWriter
    {
        internal List<int> WorkoutConstituentPrimes(int input)
        {
            List<int> primes = new List<int>();

            for (int i = 1; i <= input; i++)
            {
                int counter = 0;

                for (int j = 2; j <= i / 2; j++)
                {
                    if (i % j == 0)
                    {
                        counter++;
                        break;
                    }
                }

                if (counter == 0 && i != 1)
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        internal List<int> WorkoutMegaprimes(List<int> primes)
        {
            List<int> megaPrimes = new List<int>();

            for (int i = 0; i < primes.Count; i++)
            {
                string prime = primes[i].ToString();
                List<int> primeValueDigits = prime.Select(digit => int.Parse(digit.ToString())).ToList();

                bool isPrime = false;

                for (int j = 0; j < primeValueDigits.Count(); j++)
                {
                    // check if each digit of each value is a prime number
                    if (IsDigitPrime(primeValueDigits[j]))
                    {
                        isPrime = true;
                    }
                    else
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    megaPrimes.Add(primes[i]);
                }
            }

            return megaPrimes;
        }

        private bool IsDigitPrime(int num)
        {
            int counter = 0;

            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    counter++;
                }
            }

            if (counter == 2)
            {
                return true;
            }

            return false;
        }

        internal void DisplayMegaprimes(List<int> megaPrimes)
        {
            string output = megaPrimes.Count > 0 ? $"There are {megaPrimes.Count} Megaprimes: " : "No Megaprimes found";

            foreach (int megaPrime in megaPrimes)
            {
                output += String.Format("{0}, ", megaPrime);
            }

            Console.WriteLine(output.Trim().TrimEnd(','));
        }
    }
}
