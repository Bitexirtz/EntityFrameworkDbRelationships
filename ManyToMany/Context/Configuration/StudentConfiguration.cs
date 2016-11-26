using System.Data.Entity.ModelConfiguration;
using ManyToMany.Entities;

namespace ManyToMany.Context.Configuration
{
	class StudentConfiguration : EntityTypeConfiguration<Student>
	{
		public StudentConfiguration ()
		{
			HasKey (student => student.StudentId);

			HasOptional (student => student.Address).WithMany ()
				.HasForeignKey (student => student.AddressId);

			HasMany (student => student.StudentSubjects)
				.WithRequired (studentSubject => studentSubject.Student)
				.HasForeignKey (studentSubject => studentSubject.StudentId);
		}
	}
}
