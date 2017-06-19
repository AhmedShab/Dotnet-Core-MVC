using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetSimpleMVC.ViewModels
{
	public class ContactViewModel
	{

		[Required]
		public string Name { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		[StringLength(4096, MinimumLength =10)]
		public string Message { get; set; }
	}
}
