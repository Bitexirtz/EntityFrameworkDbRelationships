using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany.Entities
{
	public class Student
	{
		public Student ()
		{
			this.StudentSubjects = new HashSet<StudentSubject> ();
		}

		public int StudentId { get; set; }
		public string PersonName { get; set; }

		public int? AddressId { get; set; }
		public virtual StudentAddress Address { get; set; }

		public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
	}
}
