using Ceramics.Models;
using System;
using System.Linq;

namespace Ceramics.Models
{
    public static class DbInitializer
    {
        public static void Initialize(CeramicsContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Customer.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new Customer[]
            {
            new Customer{FirstMidName="Sodom",LastName="Lee",OrderDate=DateTime.Parse("2020-12-11")},
            new Customer{FirstMidName="Rachel",LastName="Buse",OrderDate=DateTime.Parse("2020-12-01")},
            new Customer{FirstMidName="Heather",LastName="Whittlesey",OrderDate=DateTime.Parse("2020-11-01")},
            new Customer{FirstMidName="Alexis",LastName="Dwyer",OrderDate=DateTime.Parse("2020-12-11")},
            new Customer{FirstMidName="Jeff",LastName="Miller",OrderDate=DateTime.Parse("2020-12-01")},
            new Customer{FirstMidName="Lyndsay",LastName="Nissen",OrderDate=DateTime.Parse("2020-11-01")},
            new Customer{FirstMidName="Edgar",LastName="Camacho",OrderDate=DateTime.Parse("2020-12-01")},
            new Customer{FirstMidName="Cody",LastName="Ryan",OrderDate=DateTime.Parse("2020-09-01")}
            };



            foreach (Customer cu in customers)
            {
                context.Customer.Add(cu);
            }
            context.SaveChanges();





            var colors = new Color[]
            {
            new Color{ColorID=6002,ColorName="Rose Pink",Price=25.55},
            new Color{ColorID=6121,ColorName="Saturn Orange",Price=14.18},
            new Color{ColorID=6404,ColorName="Vanadium",Price=32.27},
            new Color{ColorID=6166,ColorName="Camel Beige",Price=14.00},
            new Color{ColorID=6006,ColorName="Deep Crimson",Price=25.00},
            new Color{ColorID=6020,ColorName="Alumina Pink",Price=14.45},
            new Color{ColorID=6126,ColorName="Hazelnut",Price=17.27}
            };


            foreach (Color co in colors)
            {
                context.Color.Add(co);
            }
            context.SaveChanges();



            var orders = new Order[]
     {


            new Order{ColorID=6002,CustomerID=0001,MembershipStat=MembershipStat.A},
            new Order{ColorID=6121,CustomerID=0002,MembershipStat=MembershipStat.C},
            new Order{ColorID=6404,CustomerID=0003,MembershipStat=MembershipStat.B},
            new Order{ColorID=6002,CustomerID=0004,MembershipStat=MembershipStat.A},
            new Order{ColorID=6166,CustomerID=0005,MembershipStat=MembershipStat.C},
            new Order{ColorID=6006,CustomerID=0006,MembershipStat=MembershipStat.B},
            new Order{ColorID=6166,CustomerID=0007,MembershipStat=MembershipStat.C},
            new Order{ColorID=6006,CustomerID=0008,MembershipStat=MembershipStat.B}

     };
            foreach (Order o in orders)
            {
                context.Order.Add(o);
            }
            context.SaveChanges();




            var chemistry = new Chemistry[]
           {
                new Chemistry { ID = 9001, ChemComp = "Chromium, Strontium",
                    ChemAbbrev= "CrSn", ColorID = 6002 },
                new Chemistry { ID = 9002, ChemComp = "Chromium, Iron, Zinc, Aluminum, Silicon",
                    ChemAbbrev= "CrFeZnAlSi", ColorID = 6121 },
                new Chemistry { ID = 9003, ChemComp = "Strontium, Vanadium",
                    ChemAbbrev= "SnV", ColorID = 6404 },
                new Chemistry { ID = 9004, ChemComp = "Chromium, Iron, Zinc, Aluminum, Cobalt, Manganese",
                    ChemAbbrev= "CrFeZnAlCoMn", ColorID = 6166 },
                new Chemistry { ID = 9005, ChemComp = "Manganese, Aluminum ",
                    ChemAbbrev= "MnAl", ColorID = 6020 },
                new Chemistry { ID = 9006, ChemComp = "Chromium, Iron, Zinc, Aluminum",
                    ChemAbbrev= "CrFeZnAl", ColorID = 6126 },
                new Chemistry { ID = 9007, ChemComp = "Chromium, Strontium",
                    ChemAbbrev= "CrSn", ColorID = 6006 }

           };

            foreach (Chemistry i in chemistry)
            {
                context.Chemistry.Add(i);
            }
            context.SaveChanges();





            var colorfamily = new ColorFamily[]
            {
                new ColorFamily { ColorFamID  = 1, ColorFam = "red", ColorName="Rose Pink", ColorID = 6002 },
                new ColorFamily { ColorFamID  = 2, ColorFam = "orange", ColorName="Saturn Orange", ColorID = 6121 },
                new ColorFamily { ColorFamID  = 3, ColorFam = "yellow", ColorName="Vanadium", ColorID = 6404 },
                new ColorFamily { ColorFamID  = 2, ColorFam = "orange", ColorName="Camel Beige", ColorID = 6166 },
                new ColorFamily { ColorFamID  = 1, ColorFam = "red", ColorName="Alumina Pink", ColorID = 6020 },
                new ColorFamily { ColorFamID  = 2, ColorFam = "orange", ColorName="Hazelnut", ColorID = 6126 },
                new ColorFamily { ColorFamID  = 1, ColorFam = "red", ColorName="Deep Crimson", ColorID = 6006 }

            };

            foreach (ColorFamily d in colorfamily)
            {
                context.ColorFamily.Add(d);
            }
            context.SaveChanges();


        }
    }
}