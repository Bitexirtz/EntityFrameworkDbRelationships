using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDbRelationships.Bootstrap
{
	public static class DbConfiguration
	{
		public static string ConnectionString {
			get {
				return "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=EntityFrameworkDbRelationships;Integrated Security=True";
			}
		}
	}
}
