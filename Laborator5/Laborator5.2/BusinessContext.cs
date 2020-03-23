﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator5._2
{
	public class BusinessContext : DbContext
	{
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Business>()
			.ToTable("Business", "BazaDeDate");
		}

		public DbSet<Business> Businesses { get; set; }
	}

	[Table("Business", Schema = "BazaDeDate")]
	public class Business
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int BusinessId { get; protected set; }
		public string Name { get; set; }
		public string LicenseNumber { get; set; }
	}

	[Table("eCommerce", Schema = "BazaDeDate")]
	public class eCommerce : Business
	{
		public string URL { get; set; }
	}

	[Table("Retail", Schema = "BazaDeDate")]
	public class Retail : Business
	{
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZIPCode { get; set; }
	}


}
