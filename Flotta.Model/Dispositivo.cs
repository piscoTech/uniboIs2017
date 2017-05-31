using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public interface IDispositivo : ICloneable, ILinkedObjectWithPDF<IDispositivoType>, IScadenzaOwner
	{
		bool IsValid { get; }
	}

	internal class Dispositivo : IDispositivo
	{
		private IMezzo _mezzo;
		private IDispositivoType _type;
		private IPDF _allegato;
		private Scadenza _scadenza;

		internal Dispositivo(IMezzo mezzo, IDispositivoType type)
		{
			_mezzo = mezzo;
			_type = type;
		}

		private Dispositivo(IMezzo mezzo, IDispositivoType type, IPDF allegato)
		{
			_mezzo = mezzo;
			_type = type;
			_allegato = allegato;
		}

		public IMezzo Mezzo => _mezzo;
		public IDispositivoType Type => _type;
		public IPDF Allegato => _allegato;

		public Scadenza Scadenza
		{
			get => _scadenza;
			set => _scadenza = value;
		}
		public string ScadenzaName => "Dispositivo: " + _type.Name;

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
			return new Dispositivo(_mezzo, _type, _allegato) { Scadenza = _scadenza };
		}
	}
}
