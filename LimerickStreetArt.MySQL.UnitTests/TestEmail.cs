using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace LimerickStreetArt.MySQL.UnitTests
{
	[TestClass]
	public class EmailTest
	{
		[TestMethod]
		[Ignore]
		void TestEmail()
		{
			SmtpClient client = new SmtpClient("mysmtpserver")
			{
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential("username", "password")
			};

			MailMessage mailMessage = new MailMessage
			{
				From = new MailAddress("whoever@me.com"),
				Body = "body",
				Subject = "subject"
			};
			mailMessage.To.Add("receiver@me.com");
			client.Send(mailMessage);
		}
	}
}
