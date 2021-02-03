using Ceramics.Models;
using Ceramics.Pages.Models;
using System;
using System.Linq;

namespace Ceramics.Models
{
    public static class DbInitializer
    {
        public static void Initialize(CeramicsContext context)
        {
           // context.Database.EnsureCreated();

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
            new Color{ColorID=6002,ColorName="Rose Pink",Price=25.55, ColorFamID=1, ColorFamName= "Red" },
            new Color{ColorID=6121,ColorName="Saturn Orange",Price=14.18, ColorFamID=2, ColorFamName= "Orange"},
            new Color{ColorID=6404,ColorName="Vanadium",Price=32.27, ColorFamID=3, ColorFamName= "Yellow"},
            new Color{ColorID=6166,ColorName="Camel Beige",Price=14.00, ColorFamID=2, ColorFamName= "Orange"},
            new Color{ColorID=6006,ColorName="Deep Crimson",Price=25.00, ColorFamID=1, ColorFamName= "Red"},
            new Color{ColorID=6020,ColorName="Alumina Pink",Price=14.45, ColorFamID=1, ColorFamName= "Red"},
            new Color{ColorID=6126,ColorName="Hazelnut",Price=17.27, ColorFamID=2, ColorFamName= "Orange"}
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



            var chemistry = new Chem[]
     {


            new Chem{ChemComp="Chromium, Strontium", ChemAbbrev= "CrSn", ColorID = 6002, WarehouseLocationID = 1},
            new Chem{ChemComp="Chromium, Iron, Zinc, Aluminum, Silicon", ChemAbbrev= "CrFeZnAlSi", ColorID = 6404, WarehouseLocationID = 2},
            new Chem{ChemComp="Strontium, Vanadium",ChemAbbrev= "SnV", ColorID = 6404, WarehouseLocationID = 2},
            new Chem{ChemComp="Chromium, Iron, Zinc, Aluminum, Cobalt, Manganese", ChemAbbrev= "CrFeZnAlCoMn", ColorID = 6166, WarehouseLocationID = 3},
            new Chem{ChemComp="Manganese, Aluminum",ChemAbbrev= "MnAl", ColorID = 6020, WarehouseLocationID = 1},
            new Chem{ChemComp="Chromium, Iron, Zinc, Aluminum", ChemAbbrev= "CrFeZnAl", ColorID = 6126, WarehouseLocationID = 3},
            new Chem{ChemComp="Chromium, Strontium", ChemAbbrev= "CrSn", ColorID = 6006, WarehouseLocationID = 2}


     }; 
            foreach (Chem i in chemistry)
            {
                context.Chemistry.Add(i);
            }
            context.SaveChanges();



            /*    var chemistry = new Chem[]
               {
                    new Chem{ChemComp = "Chromium, Strontium", ChemAbbrev= "CrSn", ColorID = 6002, WarehouseLocationID = 1},
                    new Chem{ChemComp = "Chromium, Iron, Zinc, Aluminum, Silicon", ChemAbbrev= "CrFeZnAlSi", ColorID = 6121, WarehouseLocationID = 2 },
                    new Chem{ChemComp = "Strontium, Vanadium", ChemAbbrev= "SnV", ColorID = 6404, WarehouseLocationID = 2 },
                    new Chem{ChemComp = "Chromium, Iron, Zinc, Aluminum, Cobalt, Manganese", ChemAbbrev= "CrFeZnAlCoMn", ColorID = 6166, WarehouseLocationID = 3 },
                    new Chem{ChemComp = "Manganese, Aluminum ", ChemAbbrev= "MnAl", ColorID = 6020, WarehouseLocationID = 1 },
                    new Chem{ChemComp = "Chromium, Iron, Zinc, Aluminum", ChemAbbrev= "CrFeZnAl", ColorID = 6126, WarehouseLocationID = 3 },
                    new Chem{ChemComp = "Chromium, Strontium", ChemAbbrev= "CrSn", ColorID = 6006, WarehouseLocationID = 2 }

               };

                foreach (Chem i in chemistry)
                {
                    context.Chemistry.Add(i);
                }
                context.SaveChanges();

                */



            /*    var colorfamily = new ColorFamily[]
              {
                  new ColorFamily { ColorFamilyID  = 1, ColorFam = "red", ColorName="Rose Pink", ColorID = 6002, },
                  new ColorFamily { ColorFamilyID  = 2, ColorFam = "orange", ColorName="Saturn Orange", ColorID = 6121 },
                  new ColorFamily { ColorFamilyID  = 3, ColorFam = "yellow", ColorName="Vanadium", ColorID = 6404 },
                  new ColorFamily { ColorFamilyID  = 2, ColorFam = "orange", ColorName="Camel Beige", ColorID = 6166 },
                  new ColorFamily { ColorFamilyID  = 1, ColorFam = "red", ColorName="Alumina Pink", ColorID = 6020 },
                  new ColorFamily { ColorFamilyID  = 2, ColorFam = "orange", ColorName="Hazelnut", ColorID = 6126 },
                  new ColorFamily { ColorFamilyID  = 1, ColorFam = "red", ColorName="Deep Crimson", ColorID = 6006 }

              };

              foreach (ColorFamily d in colorfamily)
              {
                  context.ColorFamily.Add(d);
              }
              context.SaveChanges();


                var colorAssignments = new ColorAssignment[]
                 {
                      new ColorAssignment { ChemID = 001 , ColorID = 6002 },
                       new ColorAssignment { ChemID = 121 , ColorID = 6121 },
                        new ColorAssignment { ChemID = 404 , ColorID = 6404 },
                         new ColorAssignment { ChemID = 166 , ColorID = 6166 },
                          new ColorAssignment { ChemID = 020 , ColorID = 6020 },
                           new ColorAssignment { ChemID = 126 , ColorID = 6126 },
                            new ColorAssignment { ChemID = 006 , ColorID = 6006 }



                 };

                  foreach (ColorAssignment ca in colorAssignments)
                  {
                      context.ColorAssignments.Add(ca);
                  }
                  context.SaveChanges();
            */




            /*   var colorAssignment = new ColorAssignment[]
                 {
                     new ColorAssignment {
                         ColorID = colors.Single(co => co.ColorFamName == "red" ).ColorID,
                         ChemID = chemistry.Single(i => i.ChemAbbrev == "CrSn").ChemID
                         },
                        new ColorAssignment {
                         ColorID = colors.Single(co => co.ColorFamName == "orange" ).ColorID,
                         ChemID = chemistry.Single(i => i.ChemAbbrev == "CrFeZnAl").ChemID
                         },
                           new ColorAssignment {
                         ColorID = colors.Single(co => co.ColorFamName == "yellow" ).ColorID,
                         ChemID = chemistry.Single(i => i.ChemAbbrev == "SnV").ChemID
                         },
                              new ColorAssignment {
                         ColorID = colors.Single(co => co.ColorName == "yellow" ).ColorID,
                         ChemID = chemistry.Single(i => i.ChemAbbrev == "ZrV").ChemID
                         },
                                 new ColorAssignment {
                         ColorID = colors.Single(co => co.ColorName == "yellow" ).ColorID,
                         ChemID = chemistry.Single(i => i.ChemAbbrev == "CrTiSb").ChemID
                         },



             };


                 context.ColorAssignments.AddRange(colorAssignment);
                 context.SaveChanges();





               var warehouseLocation = new WarehouseLocation[]
                 {
                     new WarehouseLocation {
                         ChemID = chemistry.Single( i => i.ChemAbbrev == "CrSn").ChemID,
                         Location = "Minneapolis, MN", WarehouseLocationID = 1 },
                     new WarehouseLocation {
                         ChemID = chemistry.Single( i => i.ChemAbbrev == "MnAl").ChemID,
                         Location = "Minneapolis, MN", WarehouseLocationID = 1 },
                     new WarehouseLocation {
                         ChemID = chemistry.Single( i => i.ChemAbbrev == "SnV").ChemID,
                         Location = "Chicago, IL", WarehouseLocationID = 2 },
                      new WarehouseLocation {
                         ChemID = chemistry.Single( i => i.ChemAbbrev == "CrFeZnAl").ChemID,
                         Location = "Minneapolis, MN" },
                     new WarehouseLocation {
                         ChemID = chemistry.Single( i => i.ChemAbbrev == "ZrV").ChemID,
                         Location = "Chicago, IL", WarehouseLocationID = 2 },
                 };

                 context.WarehouseLocation.AddRange(warehouseLocation);
                 context.SaveChanges();






                 var orders = new Order[]
                {
                     new Order {
                         CustomerID = customers.Single(cu => cu.LastName == "Lee").ID,
                         ColorID = colors.Single(co => co.ColorName == "Rose Pink" ).ColorID,
                         MembershipStat = MembershipStat.A
                     },
                            new Order {
                         CustomerID = customers.Single(cu => cu.LastName == "Buse").ID,
                         ColorID = colors.Single(co => co.ColorName == "Saturn Orange" ).ColorID,
                         MembershipStat = MembershipStat.C
                     },
                           new Order {
                         CustomerID = customers.Single(cu => cu.LastName == "Whittlesey").ID,
                         ColorID = colors.Single(co => co.ColorName == "Vanadium" ).ColorID,
                         MembershipStat = MembershipStat.B
                     },
                           new Order {
                         CustomerID = customers.Single(cu => cu.LastName == "Dwyer").ID,
                         ColorID = colors.Single(co => co.ColorName == "Rose Pink" ).ColorID,
                         MembershipStat = MembershipStat.A
                     },

                           new Order {
                         CustomerID = customers.Single(cu => cu.LastName == "Miller").ID,
                         ColorID = colors.Single(co => co.ColorName == "Camel Beige" ).ColorID,
                         MembershipStat = MembershipStat.C
                     },
                           new Order {
                         CustomerID = customers.Single(cu => cu.LastName == "Nissen").ID,
                         ColorID = colors.Single(co => co.ColorName == "Deep Crimson" ).ColorID,
                         MembershipStat = MembershipStat.B
                     },
                           new Order {
                         CustomerID = customers.Single(cu => cu.LastName == "Camacho").ID,
                         ColorID = colors.Single(co => co.ColorName == "Camel Beige" ).ColorID,
                         MembershipStat = MembershipStat.C
                     },
                             new Order {
                         CustomerID = customers.Single(cu => cu.LastName == "Ryan").ID,
                         ColorID = colors.Single(co => co.ColorName == "Deep Crimson" ).ColorID,
                         MembershipStat = MembershipStat.B
                     }
                             };

                 foreach (Order o in orders)
                 {
                     var orderInDataBase = context.Order.Where(
                         cu =>
                                 cu.Customer.ID == o.CustomerID &&
                                 cu.Color.ColorID == o.ColorID).SingleOrDefault();
                     if (orderInDataBase == null)
                     {
                         context.Order.Add(o);
                     }
                 }
                 context.SaveChanges();
          */













        }
    }
}