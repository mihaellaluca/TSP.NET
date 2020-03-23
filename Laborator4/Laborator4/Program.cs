using System;

namespace Laborator4
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			var personContext = new PersonContext();
			Person pers = new Person()
			{
				Id = "1",
				FirstName = "John",
				LastName = "Snow",
				TelephoneNumber = "12345789"
			};
			personContext.People.Add(pers);
			personContext.SaveChanges();
			TesTOneToMany();
			TestManyToMany();



		}
		static void TesTOneToMany()
		{
			Console.WriteLine("One to many association");
			using (PersonContext context =
		   new PersonContext())
			{
				Customer c = new Customer()
				{
					CustomerId = "cust4",
					Name = "Customer 1",
					City = "Iasi"
				};
				Order o1 = new Order()
				{
					OrderId = "ord35343",
					TotalValue = 200,
					date = DateTime.Now,
					customer = c
				};
				Order o2 = new Order()
				{
					OrderId="ord352534",
					TotalValue = 300,
					date = DateTime.Now,
					customer = c
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
					   ox.OrderId, ox.date, ox.TotalValue);
				}

			}
		}
		static void TestManyToMany()
		{
			using (PersonContext context =
		   new PersonContext())
			{
				Artist artist = new Artist()
				{
					ArtistId = "artist123",
					FirstName = "John2",
					LastName = "Doe2"
				};
				Album album = new Album()
				{
					AlbumId = "album123",
					AlbumName = "First Album2"
				};

				context.Artists.Add(artist);
				context.Albums.Add(album);
				ArtistAlbum artistAlbum = new ArtistAlbum()
				{
					Artist = artist,
					Album = album
				};
				context.ArtistAlbum.Add(artistAlbum);
				context.SaveChanges();

				var allAlbums = context.Albums;
				foreach (var a in allAlbums)
				{
					Console.WriteLine(a + " ");

				}

			}
		}


	}
}
