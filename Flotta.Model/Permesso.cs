using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public interface IPermesso : ICloneable, ILinkedObjectWithPDF<IPermessoType>, IScadenzaOwner
	{
		bool IsValid { get; }
	}

	internal class Permesso : IPermesso
	{
		private readonly IMezzo _mezzo;
		private readonly IPermessoType _type;
		private IPDF _allegato;
		private Scadenza _scadenza;

		internal Permesso(IMezzo mezzo, IPermessoType type)
		{
			if (mezzo == null)
				throw new ArgumentNullException("Mezzo not specified");
			if (type == null)
				throw new ArgumentNullException("Type not specified");

			_mezzo = mezzo;
			_type = type;
		}

		private Permesso(IMezzo mezzo, IPermessoType type, IPDF allegato)
		{
			_mezzo = mezzo;
			_type = type;
			_allegato = allegato;
		}

		public IMezzo Mezzo => _mezzo;
		public IPermessoType Type => _type;
		public IPDF Allegato => _allegato;

		public Scadenza Scadenza
		{
			get => _scadenza;
			set
			{
				if (value == null)
					throw new ArgumentNullException("No new scadenza specified");

				_scadenza = value;
			}
		}
		public string ScadenzaName => "Permesso: " + _type.Name;

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
			return new Permesso(_mezzo, _type, _allegato) { Scadenza = _scadenza };
		}
	}
}
