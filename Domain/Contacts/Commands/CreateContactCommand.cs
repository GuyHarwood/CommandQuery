using System.ComponentModel.DataAnnotations;
using Core;

namespace Domain.Contacts.Commands
{
	public class CreateContactCommand : Command
	{
		//use data annotations for simple validation
		[Required]
		[MinLength(2)]
		public string Name { get; set; }

		//use override for complex validation
		public override bool Validate()
		{
			return !Name.Equals("Bill Gates");
		}
	}
}