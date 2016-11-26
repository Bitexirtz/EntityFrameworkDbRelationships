using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using ManyToMany.Entities;

namespace ManyToMany.Context
{
	public class ManyToManyDbContext : DbContext
	{
		public ManyToManyDbContext (string connectionString)
			:base(connectionString)
		{
			Configuration.LazyLoadingEnabled = false;

			//Database.SetInitializer<OneToOneDbContext> (new CreateDatabaseIfNotExists<OneToOneDbContext> ());
			//Database.SetInitializer<OneToOneDbContext> (new DropCreateDatabaseIfModelChanges<OneToOneDbContext> ());
			Database.SetInitializer<ManyToManyDbContext> (new DropCreateDatabaseAlways<ManyToManyDbContext> ());
		}

		#region DBSets
		public DbSet<Student> Students { get; set; }
		public DbSet<StudentAddress> StudentAddresses { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<StudentSubject> StudentCourses { get; set; }
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
