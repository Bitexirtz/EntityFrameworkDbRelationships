using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManyToMany.Entities;

namespace ManyToMany.Context.Configuration
{
	public class SubjectConfiguration : EntityTypeConfiguration<Subject>
	{
		public SubjectConfiguration ()
		{
			HasKey (subject => subject.SubjectId);

			HasMany (subject => subject.StudentSubjects)
				.WithRequired (studentSubject => studentSubject.Subject)
				.HasForeignKey (studentSubject => studentSubject.SubjectId);
		}
	}
}
