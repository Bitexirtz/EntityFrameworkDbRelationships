namespace OneToOneReverseOnly.Entities
{
	public class PersonAddress
	{
		public int Id { get; set; }
		
		public string Address { get; set; }

		public int PersonId { get; set; }
		public virtual Person Person { get; set; }
	}
}