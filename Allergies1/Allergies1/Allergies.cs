using System;
using System.Collections.Generic;
using System.Text;

namespace Allergies1
{
    class Allergies
    {
        private readonly Dictionary<string, int> allergiesPattern;
        private List<string> allergies;

        public int Score { get; set; }
        public string Name { get; set; }

        public bool IsAlergic
        {
            get
            {
                if (this.Score > 0)
                {
                    if (this.Score > 255)
                    {
                        Console.WriteLine($"{this.Name} is allergic person.\nNote:Warning!There are unidentified allergies due to out of this test scope.");
                        Console.ReadLine();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"{this.Name} is allergic person.");
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine($"{this.Name} is NOT allergic.");
                }
                return false;
            }
        }
        public bool IsAlergicAt(string alergen)
        {
            for (int i = 0; i < allergies.Count; i++)
            {
                if (alergen == allergies[i])
                {
                    Console.WriteLine($"{this.Name} is allergic at {alergen}.");
                    return true;
                }

            }
            Console.WriteLine($"{this.Name} is not allergic at {alergen}.");
            return false;
        }
        public void DisplayAllergyPattern()
        {
            Console.WriteLine($"Table of allergies score:");
            foreach (var pair in allergiesPattern)
            {
                Console.WriteLine($"{pair.Key}---->{pair.Value}");
            }
            Console.WriteLine("-------------------------------------------------------");
        }
        public Allergies(string name, int score)
        {
            Dictionary<string, int> allergiesPattern = new Dictionary<string, int>();

            allergiesPattern.Add("eggs", 1);
            allergiesPattern.Add("peanuts", 2);
            allergiesPattern.Add("shellfish", 4);
            allergiesPattern.Add("strawberries", 8);
            allergiesPattern.Add("tomatoes", 16);
            allergiesPattern.Add("chocolate", 32);
            allergiesPattern.Add("pollen", 64);
            allergiesPattern.Add("cats", 128);

            List<string> allergies = new List<string>();
            var marks = GetFullAllergyList(score);
            foreach (var allergyMark in allergiesPattern)
            {
                foreach (var item in marks)
                    if (allergyMark.Value == (int)item)
                    {
                        allergies.Add(allergyMark.Key);
                    }
            }
            this.allergies = allergies;
            Console.WriteLine($"\n{name} is allergic at:\n");
            if (score == 0)
            {
                Console.WriteLine($"The test result didn't match any test's alergen presence.");
            }
            foreach (var allergy in allergies)
            {
                Console.WriteLine($"{allergy.ToUpper()}");
            }
            Console.ReadKey();

            this.allergiesPattern = allergiesPattern;
            this.Name = name;
            this.Score = score;
            this.allergies = allergies;
        }
        private List<double> GetFullAllergyList(int score)
        {
            List<double> marksList = new List<double>();

            string result;
            result = "";

            while (score > 1)
            {
                int remainder = score % 2;
                result = " " + Convert.ToString(remainder) + result;
                score /= 2;
            }
            result = Convert.ToString(score) + result;
            //Console.WriteLine("{0} ", result);

            var markArray = result.Split(" ");
            for (int i = 0; i < markArray.Length; i++)
            {
                // Console.WriteLine(markArray[i]);
                if (markArray[i] == "1")
                {
                    marksList.Add(Math.Pow(2, markArray.Length - i - 1));
                }
            }
            //Console.WriteLine($"The identified allergy scores are:");
            //foreach (var ex in marksList)
            //{
            //    Console.Write($"{ex} ");
            //}
            //Console.WriteLine();

            return marksList;
        }
        public override string ToString()
        {
            if (IsAlergic)
            {
                return $"{this.Name} is a person with allergies.\n";
            }
            else
            {
                return $"{this.Name} is a person with no allergies.\n";
            }
        }
    }
}
