using System;

namespace Allergies1
{
    class Program
    {
        static void Main(string[] args)
        {
            Allergies tom = new Allergies("Tom", 2340);
            Console.WriteLine("-------------------------------------------------------");

            tom.IsAlergic.ToString();
            Console.WriteLine("-------------------------------------------------------");

            tom.IsAlergicAt("cats");
            Console.WriteLine("-------------------------------------------------------");

            tom.DisplayAllergyPattern();
            Console.WriteLine("-------------------------------------------------------");


        }
    }
}
