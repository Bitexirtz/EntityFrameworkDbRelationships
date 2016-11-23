using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne.Entities
{
	public class Person
	{
		public Person () { }

		public int Id { get; set; }
		public string PersonName { get; set; }

		public int? AddressId { get; set; }
		public virtual PersonAddress Address { get; set; }
	}
}
