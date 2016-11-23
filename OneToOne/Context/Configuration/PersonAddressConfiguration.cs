using System.Data.Entity.ModelConfiguration;
using OneToOne.Entities;

namespace OneToOne.Context.Configuration
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
