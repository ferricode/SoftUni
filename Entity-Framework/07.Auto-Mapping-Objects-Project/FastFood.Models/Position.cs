namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Position
	{
		public int Id { get; set; }

		[Required]
		[StringLength(30, MinimumLength = 3, ErrorMessage="Position name must be between 3 and 30 characters long")]
		public string Name { get; set; }

		public ICollection<Employee> Employees { get; set; }
	}
}