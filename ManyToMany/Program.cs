using System;
using System.Linq;
using System.Data.Entity;
using ManyToMany.Entities;
using System.Collections.Generic;

namespace ManyToMany
{
	class Program
	{
		static void Main (string[] args)
		{
			using (var dbContext = new Context.ManyToManyDbContext (EntityFrameworkDbRelationships.Bootstrap.DbConfiguration.ConnectionString)) {
				dbContext.Students.Add (new Student {
						PersonName = "Student No Address"
					}
				);
				dbContext.SaveChanges ( );

				var stud2 = new Student
				{
					PersonName = "Student With Address",
					Address = new StudentAddress
					{
						Address = "This is student address."
					}
				};
				dbContext.Students.Add(stud2);
				dbContext.SaveChanges ( );

				var subject1 = new Subject {
					SubjectName = "Mathematics"
				};

				dbContext.Subjects.Add (subject1);
				dbContext.SaveChanges ();

				dbContext.StudentCourses.Add (new StudentSubject {
					Subject = subject1,
					Student = stud2
				});
				dbContext.SaveChanges ();
			}

			using (var dbContext = new Context.ManyToManyDbContext (EntityFrameworkDbRelationships.Bootstrap.DbConfiguration.ConnectionString)) {
				var studList = dbContext.Students.Include (a => a.Address).ToList ( );
				foreach (var stud in studList) {
					Console.WriteLine ("Student: {0}", stud.PersonName);
					if (stud.Address != null) {
						Console.WriteLine ("   Address: {0}", stud.Address.Address);
					}
					else {
						Console.WriteLine ("   Address: (None)");
					}
				}
			}
		}
	}
}