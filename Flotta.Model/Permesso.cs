﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	internal class Permesso : IPermesso
	{

		private PermessoType _type;

		public IPermessoType Type
		{
			get
			{
				return _type;
			}
		}

	}
}
