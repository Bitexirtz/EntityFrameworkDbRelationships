using System.Data.Entity.ModelConfiguration;
using OneToOneReverseOnly.Entities;

namespace OneToOneReverseOnly.Context.Configuration
{
	public class PersonAddressConfiguration : EntityTypeConfiguration<PersonAddress>
	{
		public PersonAddressConfiguration ()
		{
			HasKey (personAddress => personAddress.Id);

			HasRequired (personAddress => personAddress.Person).WithMany ()
				.HasForeignKey (personAddress => personAddress.PersonId);
		}
	}
}
