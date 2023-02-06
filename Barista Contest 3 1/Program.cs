using System;
using System.Collections.Generic;
using System.Linq;

namespace Barista_Contest_3_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffeeQuantities = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> milkQuantities = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> coffeeDrinksMenue = new Dictionary<string, int>()
            {
                {"Cortado", 50},
                {"Espresso", 75},
                {"Capuccino", 100},
                {"Americano", 150},
                {"Latte", 200}
            };

            Dictionary<string, int> coffeeMade = new Dictionary<string, int>();

            while (coffeeQuantities.Any() && milkQuantities.Any())
            {
                int totalQuantities = coffeeQuantities.Peek() + milkQuantities.Peek();
                if (coffeeDrinksMenue.ContainsValue(totalQuantities))
                {
                    string drinkName = coffeeDrinksMenue.First(c => c.Value == totalQuantities).Key;

                    if (!coffeeMade.ContainsKey(drinkName))
                    {
                        coffeeMade.Add(drinkName, 0);
                    }

                    coffeeMade[drinkName]++;

                    coffeeQuantities.Dequeue();
                    milkQuantities.Pop();
                }
                else
                {
                    coffeeQuantities.Dequeue();
                    milkQuantities.Push(milkQuantities.Pop() - 5);
                }
            }

            if (coffeeQuantities.Count == 0 && milkQuantities.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffeeQuantities.Count > 0)
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffeeQuantities)}");
            }
            else
            {
                Console.WriteLine("Coffee left: none");
            }

            if (milkQuantities.Count > 0)
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milkQuantities)}");
            }
            else
            {
                Console.WriteLine("Milk left: none");
            }

            foreach (var drink in coffeeMade.OrderBy(c => c.Value).ThenByDescending(c => c.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }
    }
}
