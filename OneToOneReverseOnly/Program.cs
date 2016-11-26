using System;
using System.Linq;
using System.Data.Entity;
using OneToOneReverseOnly.Entities;

namespace OneToOneReverseOnly
{
	class Program
	{

		static void Main (string[] args)
		{
			using (var dbContext = new Context.OneToOneReverseOnlyDbContext (EntityFrameworkDbRelationships.Bootstrap.DbConfiguration.ConnectionString)) {
				dbContext.Students.Add (new Person
				{
					PersonName = "Student No Address"
				}
				);
				dbContext.SaveChanges ();

				var address = new PersonAddress
				{
					Address = "This is student address.",
					Person = new Person
					{
						PersonName = "Student With Address"
					}
				};

				dbContext.StudentAddresses.Add (address);
				dbContext.SaveChanges ();
			}

			using (var dbContext = new Context.OneToOneReverseOnlyDbContext (EntityFrameworkDbRelationships.Bootstrap.DbConfiguration.ConnectionString)) {
				var studAddressList = dbContext.StudentAddresses.Include (a => a.Person).ToList ();
				foreach (var address in studAddressList) {
					Console.WriteLine ("Student: {0}", address.Person.PersonName);
					Console.WriteLine ("   Address: {0}", address.Address);
				}
			}
		}
	}
}