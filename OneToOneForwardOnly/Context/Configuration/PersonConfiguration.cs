using System.Data.Entity.ModelConfiguration;
using OneToOneForwardOnly.Entities;

namespace OneToOneForwardOnly.Context.Configuration
{
	class PersonConfiguration : EntityTypeConfiguration<Person>
	{
		public PersonConfiguration ()
		{
			HasKey (person => person.Id);

			HasOptional (person => person.Address).WithMany ()
				.HasForeignKey (person => person.AddressId);
		}
	}
}
