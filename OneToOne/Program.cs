using System;
using System.Linq;
using System.Data.Entity;
using OneToOne.Entities;

namespace OneToOne
{
	class Program
	{

		static void Main (string[] args)
		{
			using (var dbContext = new Context.OneToOneDbContext (EntityFrameworkDbRelationships.Bootstrap.DbConfiguration.ConnectionString)) {
				dbContext.Students.Add (new Person
				{
					PersonName = "Student No Address"
				}
				);
				dbContext.SaveChanges ();

				var stud2 = new Person
				{
					PersonName = "Student With Address",
					
				};
				dbContext.Students.Add (stud2);
				dbContext.SaveChanges ();

				
				var address2 = new PersonAddress
				{
					Address = "Address1",
					PersonId = stud2.Id
				};

				stud2.Address = address2;
				dbContext.StudentAddresses.Add (address2);

				dbContext.SaveChanges ();
			}

			using (var dbContext = new Context.OneToOneDbContext (EntityFrameworkDbRelationships.Bootstrap.DbConfiguration.ConnectionString)) {
				var studList = dbContext.Students.Include (a => a.Address).ToList ();
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