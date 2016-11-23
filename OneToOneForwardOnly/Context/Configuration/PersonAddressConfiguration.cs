using System.Data.Entity.ModelConfiguration;
using OneToOneForwardOnly.Entities;

namespace OneToOneForwardOnly.Context.Configuration
{
	public class PersonAddressConfiguration : EntityTypeConfiguration<PersonAddress>
	{
		public PersonAddressConfiguration ()
		{
			HasKey (personAddress => personAddress.Id);
		}
	}
}
