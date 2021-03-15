using System;
using System.Collections.Generic;

namespace AddonCraft.CommandLineInterface.Handlers
{
    public class UpgradeHandler
    {
        public void Upgrade(IEnumerable<String> packageNames, String release, String gameFlavor)
        {
            Console.WriteLine($"Release: {release} | Game Flavor: {gameFlavor}");
            foreach (var packageName in packageNames)
            {
                Console.WriteLine($"Upgrading {packageName}");
            }
        }
    }
}