using System;
using System.Collections.Generic;

namespace AddonCraft.CommandLineInterface.Handlers
{
    public class RemoveHandler
    {
        public void Remove(IEnumerable<String> packageNames, String gameFlavor)
        {
            Console.WriteLine($"Game Flavor: {gameFlavor}");
            foreach (var packageName in packageNames)
            {
                Console.WriteLine($"Removing {packageName}");
            }
        }
    }
}