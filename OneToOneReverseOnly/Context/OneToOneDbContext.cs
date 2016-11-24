using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using OneToOneReverseOnly.Entities;

namespace OneToOneReverseOnly.Context
{
	public class OneToOneDbContext : DbContext
	{
		public OneToOneDbContext (string connectionString)
			:base(connectionString)
		{
			Configuration.LazyLoadingEnabled = false;

			//Database.SetInitializer<OneToOneDbContext> (new CreateDatabaseIfNotExists<OneToOneDbContext> ());
			//Database.SetInitializer<OneToOneDbContext> (new DropCreateDatabaseIfModelChanges<OneToOneDbContext> ());
			Database.SetInitializer<OneToOneDbContext> (new DropCreateDatabaseAlways<OneToOneDbContext> ());
		}

		#region DBSets
		public DbSet<Person> Students { get; set; }
		public DbSet<PersonAddress> StudentAddresses { get; set; }
		#endregion

		protected override void OnModelCreating (DbModelBuilder modelBuilder)
		{
			RemoveConventions (modelBuilder);
			AddAllEntityConfigurations (modelBuilder);

			base.OnModelCreating (modelBuilder);
		}


		private void AddAllEntityConfigurations (DbModelBuilder modelBuilder)
		{
			var configurationsToRegister = GetAllEntityConfigurationsToRegister ();

			RegisterEntityTypeConfigurations (modelBuilder, configurationsToRegister);
		}

		private static void RegisterEntityTypeConfigurations (DbModelBuilder modelBuilder, IEnumerable<Type> configurationsToRegister)
		{
			foreach (var type in configurationsToRegister) {
				dynamic configurationInstance = Activator.CreateInstance (type);
				modelBuilder.Configurations.Add (configurationInstance);
			}
		}

		private static IEnumerable<Type> GetAllEntityConfigurationsToRegister ()
		{
			var entityConfigurationsToRegister = Assembly.GetExecutingAssembly ().GetTypes ()
				.Where (type => !String.IsNullOrEmpty (type.Namespace))
				.Where (type => type.BaseType != null
								&& type.BaseType.IsGenericType
								&& type.BaseType.GetGenericTypeDefinition () == typeof (EntityTypeConfiguration<>));

			return entityConfigurationsToRegister;
		}

		private static void RemoveConventions (DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention> ();
		}
	}
}
