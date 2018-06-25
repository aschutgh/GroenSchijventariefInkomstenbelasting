using System;
using System.Collections.Generic;

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

        static int berekentargrp5(int belastbaarinkomen)
        {
            // twaalf procent van belastbaar inkomen
            int tpbi = 0;

            tpbi = (int)(belastbaarinkomen * 0.12);
            if (tpbi > 6704)
            {
                tpbi = 6704;
            }

            return (15503 + tpbi);
        }

        static void Main(string[] args)
        {
            int invtariefgroep = 0;
            int belastbaarinkomen = 0;

            belastbaarinkomen = VraagBelastbaarInkomen();
            invtariefgroep = VraagTariefGroep();
            Dictionary<int, int> tariefgroep = new Dictionary<int, int>();
            tariefgroep.Add(1, 419);
            tariefgroep.Add(2, 8799);
            tariefgroep.Add(3, 17179);
            tariefgroep.Add(4, 15503);
            tariefgroep.Add(5, berekentargrp5(belastbaarinkomen));


            Console.WriteLine("Inkomstenbelasting berekenen.");
            
            Console.WriteLine("Belastbaar inkomen is: {0}", belastbaarinkomen);
            Console.WriteLine("Tariefgroep is: {0}", invtariefgroep);
            Console.WriteLine("Uw belastingvrije som is: {0}", tariefgroep[invtariefgroep]);
        }
    }
}
