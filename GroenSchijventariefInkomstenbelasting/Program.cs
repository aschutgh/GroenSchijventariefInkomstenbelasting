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

        static Double BerekenBelasting(int belastbaresom)
        {
            //FIXME Controleren!!!!!!!!!!!!!!!
            int belastinggebied = 1;
            Double belasting = 0.0;
            int bsom = belastbaresom;
            var doorgaan = true;

            while (doorgaan == true)
            {
                switch (belastinggebied)
                {
                    case 1:
                        Console.WriteLine("Belastinggebied 1");
                        if (bsom - 8000 <= 0)
                        {
                            doorgaan = false;
                            belasting = bsom * 0.3575;
                            Console.WriteLine("belastbare som {0} ; belasting {1}", bsom, belasting);
                        }
                        else if (bsom - 8000 > 0)
                        {
                            bsom = bsom - 8000;
                            belasting = 8000 * 0.3575;
                            belastinggebied += 1;
                            doorgaan = true;
                            Console.WriteLine("belastbare som {0} ; belasting {1}", bsom, belasting);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Belastinggebied 2");
                        if (bsom - 17000 <= 0)
                        {
                            doorgaan = false;
                            belasting = belasting + bsom * 0.3705;
                            Console.WriteLine("belastbare som {0} ; belasting {1}", bsom, belasting);
                        }
                        else if (bsom - 17000 > 0)
                        {
                            bsom = bsom - 17000;
                            belasting = belasting + 17000 * 0.3705;
                            belastinggebied += 1;
                            doorgaan = true;
                            Console.WriteLine("belastbare som {0} ; belasting {1}", bsom, belasting);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Belastinggebied 3");
                        if (bsom - 29000 <= 0)
                        {
                            doorgaan = false;
                            belasting = belasting + bsom * 0.50;
                            Console.WriteLine("belastbare som {0} ; belasting {1}", bsom, belasting);
                        }
                        else if (bsom - 29000 > 0)
                        {
                            bsom = bsom - 29000;
                            belasting = belasting + 29000 * 0.50;
                            belastinggebied += 1;
                            doorgaan = true;
                            Console.WriteLine("belastbare som {0} ; belasting {1}", bsom, belasting);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Belastinggebied 4");
                        doorgaan = false;
                        belasting = belasting + bsom * 0.60;
                        Console.WriteLine("belastbare som {0} ; belasting {1}", bsom, belasting);
                        break;
                }
            }
            return belasting;
        }

        static void Main(string[] args)
        {
            int invtariefgroep = 1;
            int belastbaarinkomen = 0;
            int belastbaresom = 0;
            int belastingvrijesom = 0;

            belastbaarinkomen = VraagBelastbaarInkomen();
            invtariefgroep = VraagTariefGroep();
            Dictionary<int, int> tariefgroep = new Dictionary<int, int>();
            tariefgroep.Add(1, 419);
            tariefgroep.Add(2, 8799);
            tariefgroep.Add(3, 17179);
            tariefgroep.Add(4, 15503);
            tariefgroep.Add(5, berekentargrp5(belastbaarinkomen));
            belastingvrijesom = tariefgroep[invtariefgroep];
            belastbaresom = belastbaarinkomen - belastingvrijesom;

            if (belastbaresom <= belastingvrijesom)
            {
                Console.WriteLine("Belastbare som is: {0}", belastbaresom);
                Console.WriteLine("Belastingvrije som is: {0}", belastingvrijesom);
                Console.WriteLine("U hoeft geen belasting te betalen.");
                Environment.Exit(0);
            }

            Console.WriteLine("Inkomstenbelasting berekenen.");
            
            Console.WriteLine("Belastbaar inkomen is: {0}", belastbaarinkomen);
            Console.WriteLine("Tariefgroep is: {0}", invtariefgroep);
            Console.WriteLine("Uw belastingvrije som is: {0}", tariefgroep[invtariefgroep]);
            Console.WriteLine("Uw belastbare som is: {0}", belastbaresom);

            var belasting = BerekenBelasting(belastbaresom);
            Console.WriteLine("U moet het volgende bedrag aan belasting betalen: {0}", belasting);
        }
    }
}
