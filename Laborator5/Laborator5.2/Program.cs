using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator5._2
{
	class Program
	{
		static void Main(string[] args)
		{
			//Scenariul 1
			using (var db = new Model1())
			{

				var blog = new SelfReference { Name = "Numeeee" };
				db.SelfReferences.Add(blog);
				db.SaveChanges();
				var someReferences = db.SelfReferences.ToList();
				foreach(SelfReference reference in someReferences)
				{
					Console.WriteLine(reference);
				}


			}

			// Scenariul 2
			using (var context = new ProductContext())
			{
				var product = new Product
				{
					SKU = 147,
					Description = "Expandable Hydration Pack",
					Price = 19.97M,
					ImageURL = "/pack147.jpg"
				};
				context.Products.Add(product);
				product = new Product
				{
					SKU = 178,
					Description = "Rugged Ranger Duffel Bag",
					Price = 39.97M,
					ImageURL = "/pack178.jpg"
				};
				context.Products.Add(product);
				product = new Product
				{
					SKU = 186,
					Description = "Range Field Pack",
					Price = 98.97M,
					ImageURL = "/noimage.jp"
				};
				context.Products.Add(product);
				product = new Product
				{
					SKU = 202,
					Description = "Small Deployment Back Pack",
					Price = 29.97M,
					ImageURL = "/pack202.jpg"
				};
				context.Products.Add(product);
				context.SaveChanges();
			}
			using (var context = new ProductContext())
			{
				foreach (var p in context.Products)
				{
					Console.WriteLine("{0} {1} {2} {3}", p.SKU, p.Description,
					p.Price.ToString("C"), p.ImageURL);
				}
			}

			//Scenariul 3
			byte[] thumbBits = new byte[100];
			byte[] fullBits = new byte[2000];
			using (var context = new PhotographContext())
			{
				var photo = new Photograph
				{
					Title = "My Dog",
					ThumbnailBits = thumbBits
				};
				var fullImage = new PhotographFullImage
				{
					HighResolutionBits =
				fullBits
				};
				photo.PhotographFullImage = fullImage;
				context.Photographs.Add(photo);
				context.SaveChanges();
			}

			//Scenariul 4

			using (var context = new BusinessContext())
			{
				var business = new Business
				{
					Name = "Corner Dry Cleaning",
					LicenseNumber = "100x1"
				};
				context.Businesses.Add(business);
				var retail = new Retail
				{
					Name = "Shop and Save",
					LicenseNumber =
				"200C",
					Address = "101 Main",
					City = "Anytown",
					State = "TX",
					ZIPCode = "76106"
				};
				context.Businesses.Add(retail);
				var web = new eCommerce
				{
					Name = "BuyNow.com",
					LicenseNumber =
				"300AB",
					URL = "www.buynow.com"
				};
				context.Businesses.Add(web);
				context.SaveChanges();
			}

			//Scenariul 5
			using (var context = new EmployeeContext())
{
				var fte = new FullTimeEmployee
				{
					FirstName = "Jane",
					LastName =
				"Doe",
					Salary = 71500M
				};
				context.Employees.Add(fte);
				fte = new FullTimeEmployee
				{
					FirstName = "John",
					LastName = "Smith",
					Salary = 62500M
				};
				context.Employees.Add(fte);
				var hourly = new HourlyEmployee
				{
					FirstName = "Tom",
					LastName =
				"Jones",
					Wage = 8.75M
				};
				context.Employees.Add(hourly);
				context.SaveChanges();
			}


		}
	}
	
}
