using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDesignFirst_L1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test Model Designer First");
    /*        TestPerson();
            TesTOneToMany();*/
            TestManyToMany();
            Console.ReadKey();
        }
        static void TestPerson()
        {
            using (ModelContainer context = new ModelContainer())
            {
                Person p = new Person()
                {
                    FirstName = "Julie",
                    LastName = "Andrew",
                    MidleName = "T",
                    TelephonNumber = "1234567890"
                };
                context.People.Add(p);
                context.SaveChanges();
                var items = context.People;
                foreach (var x in items)
                    Console.WriteLine("{0} {1}", x.Id, x.FirstName);
            }
        }

        static void TesTOneToMany()
        {
            Console.WriteLine("One to many association");

            
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();
            Console.Write("Enter customer city: ");
            string city = Console.ReadLine();


            using (ModelOneToManyContainer context =
           new ModelOneToManyContainer())
            {
                Customer c = new Customer()
                {
                    Name = name,
                    City = city
                };
                Order o1 = new Order()
                {
                    TotalValue = 200,
                    Date = DateTime.Now,
                    Customer = c
                };
                Order o2 = new Order()
                {
                    TotalValue = 300,
                    Date = DateTime.Now,
                    Customer = c
                };
                context.Customers.Add(c);
                context.Orders.Add(o1);
                context.Orders.Add(o2);
                context.SaveChanges();
                var items = context.Customers;
                foreach (var x in items)
                {
                    Console.WriteLine("Customer : {0}, {1}, {2}",
                   x.CustomerId, x.Name, x.City);
                    foreach (var ox in x.Orders)
                        Console.WriteLine("\tOrders: {0}, {1}, {2}",
                       ox.OrderId, ox.Date, ox.TotalValue);
                }
            }
        }

        static void TestManyToMany()
        {
                using (ModelManyToManyContainer context =
               new ModelManyToManyContainer())
                {
                    Artist artist = new Artist()
                    {
                        FirstName = "John2",
                        LastName = "Doe2"
                    };
                    Album album = new Album()
                    {
                        AlbumName = "First Album2"
                    };

                    context.Artists.Add(artist);
                    artist.Albums.Add(album);
                    context.Albums.Add(album);

                    context.SaveChanges();
                
                    var allAlbums = context.Albums;
                    foreach(var a in allAlbums)
                    {
                        Console.WriteLine(a + " ");
                     
                    }
                
            }
        }
    }
}
