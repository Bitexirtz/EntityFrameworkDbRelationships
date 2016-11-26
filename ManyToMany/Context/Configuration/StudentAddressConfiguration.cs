using System.Data.Entity.ModelConfiguration;
using ManyToMany.Entities;

namespace ManyToMany.Context.Configuration
{
	public class StudentAddressConfiguration : EntityTypeConfiguration<StudentAddress>
	{
		public StudentAddressConfiguration ()
		{
			HasKey (studentAddress => studentAddress.StudentAddressId);
		}
	}
}
