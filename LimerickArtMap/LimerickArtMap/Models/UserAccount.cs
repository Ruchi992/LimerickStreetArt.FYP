﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LimerickArtMap.Models
{
	class UserAccount
	{
		public int Id { get; set; }
		public String Username
		{
			get;
			set;
		}
		public String Email
		{
			get;
			set;
		}
		public String Password { get; set; }
		public bool Active
		{
			get;
			set;
		}
		public DateTime DateOfBirth
		{
			get;
			set;
		}
		public int AccessLevel
		{
			get;
			set;
		}
	}
}

