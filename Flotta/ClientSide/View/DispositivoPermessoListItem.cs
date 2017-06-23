using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ClientSide.View
{
	public interface IDispositivoPermessoListItem
	{
		bool InUse { get; set; }
		string Type { get; }
		string AllegatoPath { get; set; }
	}

	class DispositivoPermessoListItem : IDispositivoPermessoListItem
	{
		private bool _inUse;
		private string _type;
		private string _allegatoPath;

		internal DispositivoPermessoListItem(bool inUse, string type, string allegatoPath)
		{
			if (type == null)
				throw new ArgumentNullException("No type specified");

			_inUse = inUse;
			_type = type;
			_allegatoPath = allegatoPath;
		}

		public bool InUse
		{
			get => _inUse;
			set => _inUse = value;
		}

		public string Type
		{
			get => _type;
		}

		public string AllegatoPath
		{
			get => _allegatoPath ?? (_inUse ? "Non presente" : "");
			set => _allegatoPath = value;
		}
	}
}
