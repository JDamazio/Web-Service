﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Domain.Account
{
	public interface ISeedUserRoleInitial
	{
		void SeedUsers();
		void SeedRoles();
	}
}
