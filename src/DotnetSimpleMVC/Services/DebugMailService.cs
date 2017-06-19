using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetSimpleMVC.Services
{
	public class DebugMailService : IMailService
	{
		public void SendMail(string to, string @from, string subject, string body)
		{
			Debug.WriteLine($"Sending Mail: to: {to} From {from} Subject {subject}");
		}
	}
}
