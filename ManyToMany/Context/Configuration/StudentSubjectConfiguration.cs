using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManyToMany.Entities;

namespace ManyToMany.Context.Configuration
{
	public class StudentSubjectConfiguration : EntityTypeConfiguration<StudentSubject>
	{
		public StudentSubjectConfiguration ()
		{
			HasKey (studentSubject => new { studentSubject.StudentId, studentSubject.SubjectId });
		}
	}
}
