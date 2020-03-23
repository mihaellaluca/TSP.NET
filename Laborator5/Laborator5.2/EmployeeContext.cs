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
	public class EmployeeContext : DbContext
	{
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Employee>()
			.Map<FullTimeEmployee>(m => m.Requires("EmployeeType")
			.HasValue(1))
			.Map<HourlyEmployee>(m => m.Requires("EmployeeType")
			.HasValue(2));
		}

		public DbSet<Employee> Employees { get; set; }

	}
	public abstract class Employee
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int EmployeeId { get; protected set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
	public class FullTimeEmployee : Employee
	{
		public decimal? Salary { get; set; }
	}
	public class HourlyEmployee : Employee
	{
		public decimal? Wage { get; set; }
	}
}
