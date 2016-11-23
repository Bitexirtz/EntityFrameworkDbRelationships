using System;
using System.Linq;
using System.Data.Entity;
using OneToOneForwardOnly.Entities;

namespace OneToOneForwardOnly
{
	class Program
	{

		static void Main (string[] args)
		{
			using (var dbContext = new Context.OneToOneDbContext (EntityFrameworkDbRelationships.Bootstrap.DbConfiguration.ConnectionString)) {
				dbContext.Students.Add (new Person {
						PersonName = "Student No Address"
					}
				);
				dbContext.SaveChanges ( );

				dbContext.Students.Add(new Person {
					PersonName = "Student With Address",
					Address = new PersonAddress {
						Address = "This is student address."
					}
				});
				dbContext.SaveChanges ( );
			}

			using (var dbContext = new Context.OneToOneDbContext (EntityFrameworkDbRelationships.Bootstrap.DbConfiguration.ConnectionString)) {
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