using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public interface IDispositivo : ICloneable, ILinkedObjectWithPDF<IDispositivoType>
	{
		bool IsValid { get; }
	}

	internal class Dispositivo : IDispositivo
	{
		private IDispositivoType _type;
		private IPDF _allegato;

		internal Dispositivo(IDispositivoType type)
		{
			_type = type;
		}

		private Dispositivo(IDispositivoType type, IPDF allegato)
		{
			_type = type;
			_allegato = allegato;
		}

		public IDispositivoType Type => _type;
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
			return new Dispositivo(_type, _allegato);
		}
	}
}
