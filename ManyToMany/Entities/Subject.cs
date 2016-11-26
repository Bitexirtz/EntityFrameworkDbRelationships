using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany.Entities
{
	public class Subject
	{
		public Subject ()
		{
			this.StudentSubjects = new HashSet<StudentSubject> ();
		}

		public int SubjectId { get; set; }
		public string SubjectName { get; set; }
		public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
	}
}
