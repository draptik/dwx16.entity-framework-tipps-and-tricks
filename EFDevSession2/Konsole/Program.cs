using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Caching;
using EntityFramework.Caching;
using EntityFramework.Extensions;
using GO;

namespace Konsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Start...");

            //GetFlug();
            //GetFlugCaching();

            for (var i = 0; i < 10; i++)
            {
                var sw = new Stopwatch();
                sw.Start();
                //GetFluege();
                //GetFlug();
                //System.Threading.Thread.Sleep(500);
                //GetFluegeSecondLevelCache();
                GetFlugPerformance();
                sw.Stop();
                //Console.WriteLine("Dauer: " + sw.ElapsedMilliseconds + "ms");
            }

            Console.WriteLine("Ende!");
            Console.ReadLine();
        }

        private static void GetFlugPerformance()
        {
            using (var ctx = new Modell())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false; // change detection is not needed for 'Find'!!

                var flugSet = ctx.Flug.ToList();
                var sw = new Stopwatch();
                sw.Start();
                ctx.Flug.Find(101);
                //var flug = flugSet.SingleOrDefault(x => x.FlugNr == 101);
                sw.Stop();
                Console.WriteLine("Dauer: " + sw.ElapsedMilliseconds + "ms");
            }
        }

        private static void GetFluegeSecondLevelCache()
        {

            var cp = CachePolicy.WithDurationExpiration(new TimeSpan(0, 0, 5));
            using (var ctx = new Modell())
            {
                ctx.Database.Log = Console.WriteLine;
                var flugSet = ctx.Flug.FromCache(cp).ToList();
                Console.WriteLine("Geladene Fluege: " + flugSet.Count);
            }
        }


        private static List<Flug> GetFlugCaching()
        {
            var cache = MemoryCache.Default;
            if (cache["flugset"] == null)
            {
                using (var ctx = new Modell())
                {
                    cache.Set("flugset", ctx.Flug.ToList(), DateTime.Now.AddSeconds(5));
                }
            }

            return cache["flugset"] as List<Flug>;
        }

        private static void GetFlug()
        {
            using (var ctx = new Modell())
            {
                var flugSet = ctx.Flug.ToList();
                Console.WriteLine("Objekte im Cache: " + ctx.Flug.Local.Count);

                var oc = ((IObjectContextAdapter) ctx).ObjectContext;
                var oset = oc.CreateObjectSet<Flug>();
                oset.MergeOption = MergeOption.OverwriteChanges; // db always wins (see below: 'Find" cache looses)

                ctx.Database.Log = Console.WriteLine;

                Console.WriteLine("FirstOrDefault");
                //var flug2 = ctx.Flug.FirstOrDefault(f => f.FlugNr == 101); // always queries the db
                var flug2 = oset.FirstOrDefault(f => f.FlugNr == 101);
                flug2.FreiePlaetze--;
                Console.WriteLine("Freie Plaetze: " + flug2.FreiePlaetze);

                Console.WriteLine("Find");
                var flug1 = ctx.Flug.Find(101);// only queries db if not in cache; the cache always wins by default!
                Console.WriteLine("Freie Plaetze: " + flug1.FreiePlaetze);

                Console.WriteLine("SingleOrDefault");
                //var flug3 = ctx.Flug.SingleOrDefault(f => f.FlugNr == 101); // always queries the db
                var flug3 = oset.SingleOrDefault(f => f.FlugNr == 101);
                Console.WriteLine("Freie Plaetze: " + flug3.FreiePlaetze);

            }
        }

        private static void GetFluege()
        {
            using (var ctx = new Modell())
            {

                // Show raw sql output in console:
                //ctx.Database.Log = Console.WriteLine;

                var flugList = ctx.Flug.AsNoTracking().ToList(); // AsNoTracking: ideal fuer Read-Only Zeugs; Cache is not filled

                Console.WriteLine("Geladene Fluege: " + flugList.Count);

                var flug = flugList.First();
                ctx.Flug.Attach(flug); // manually attach 'flug' to activate change detection
                flug.FreiePlaetze--;

                var anz = ctx.SaveChanges();
                Console.WriteLine("Gespeicherte Aenderungen: " + anz);
            }
        }
    }
}