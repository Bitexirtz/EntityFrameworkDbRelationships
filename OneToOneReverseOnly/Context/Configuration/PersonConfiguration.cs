using System.Data.Entity.ModelConfiguration;
using OneToOneReverseOnly.Entities;

namespace OneToOneReverseOnly.Context.Configuration
{
	class PersonConfiguration : EntityTypeConfiguration<Person>
	{
		public PersonConfiguration ()
		{
			HasKey (person => person.Id);
		}
	}
}
