using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public interface IPermesso : ICloneable, ILinkedObjectWithPDF<IPermessoType>
	{
		bool IsValid { get; }
	}

	internal class Permesso : IPermesso
	{
		private IPermessoType _type;
		private IPDF _allegato;

		internal Permesso(IPermessoType type)
		{
			_type = type;
		}

		private Permesso(IPermessoType type, IPDF allegato)
		{
			_type = type;
			_allegato = allegato;
		}

		public IPermessoType Type => _type;
		public IPDF Allegato => _allegato;

		public IEnumerable<string> Update(IPDF allegato)
		{
			if (!(allegato?.IsValid ?? true))
				return new string[] { "Allegato non valido" };

			_allegato = allegato;
			return new string[0];
		}

		public bool IsValid => _allegato?.IsValid ?? true;

		public object Clone()
		{
			// Also copy the reference to scadenza
			return new Permesso(_type, _allegato);
		}
	}
}
