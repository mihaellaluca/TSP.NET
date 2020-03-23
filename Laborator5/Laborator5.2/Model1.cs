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
	public class Model1 : DbContext
	{
		public Model1()
			: base("name=Model1")
		{
		}
		public virtual DbSet<SelfReference> SelfReferences { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<SelfReference>()
			.HasMany(m => m.References)
			.WithOptional(m => m.ParentSelfReference);
		}

	}
	public class SelfReference
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int SelfReferenceId { get; private set; }
		public string Name { get; set; }
		public int? ParentSelfReferenceId { get; private set; }

		[ForeignKey("ParentSelfReferenceId")]
		public SelfReference ParentSelfReference { get; set; }
		public virtual ICollection<SelfReference> References { get; set; }
		public SelfReference()
		{
			References = new HashSet<SelfReference>();
		}
	}
}
