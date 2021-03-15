using System;

namespace AddonCraft.CommandLineInterface.Handlers
{
    public class ListHandler
    {
        public void List(String gameFlavor)
        {
            Console.WriteLine($"Listing for {gameFlavor}");
        }
    }
}