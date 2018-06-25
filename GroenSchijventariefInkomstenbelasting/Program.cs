using System;

// Opdrachtenreeks groen Schijventarief Inkomstenbelasting

namespace GroenSchijventariefInkomstenbelasting
{
    class Program
    {
        static int VraagBelastbaarInkomen()
        {
            Console.WriteLine("Geef het belastbare inkomen op van de belastingplichtige in gehele euro's.");
            Console.WriteLine("Afronden in uw voordeel is toegestaan.");
            Console.Write("Belastbaar inkomen: ");
            return (int.Parse(Console.ReadLine()));
        }

        static int VraagTariefGroep()
        {
            Console.WriteLine("Geef de tariefgroep op waarin de belastingplichtige valt.");
            Console.WriteLine("Tariefgroep 1 (belastingvrije som: 419 euro)");
            Console.WriteLine("Tariefgroep 2 (belastingvrije som: 8799 euro)");
            Console.WriteLine("Tariefgroep 3 (belastingvrije som: 17179 euro)");
            Console.WriteLine("Tariefgroep 4 (belastingvrije som: 15503 euro)");
            Console.WriteLine("Tariefgroep 5 (belastingvrije som: 15503 euro + 12% belastbaar inkomen (max 6704))");
            Console.Write("Geef tariefgroep op (1, 2, 3, 4 of 5): ");
            return (int.Parse(Console.ReadLine()));
        }

        static void Main(string[] args)
        {
            int tariefgroep = 0;
            int belastbaarinkomen = 0;

            Console.WriteLine("Inkomstenbelasting berekenen.");
            belastbaarinkomen = VraagBelastbaarInkomen();
            tariefgroep = VraagTariefGroep();
            Console.WriteLine("Belastbaar inkomen is: {0}", belastbaarinkomen);
            Console.WriteLine("Tariefgroep is: {0}", tg);
        }
    }
}
