using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ClientSide.Interface
{
	public interface IManutenzioneListItem
	{
		string Date { get; set; }
		string Note { get; set; }
		string Tipo { get; set; }
		float Costo { get; set; }
		string AllegatoPath { get; set; }
		string Officina { get; set; }
	}

	internal class ManutenzioneListItem : IManutenzioneListItem
	{
		private string _date;
		private string _note;
		private string _tipo;
		private float _costo;
		private string _allegatoPath;
		private string _officina;

		public ManutenzioneListItem(string date, string note, string tipo, float costo, string allegatoPath, string officina)
		{
			if (note == null)
				throw new ArgumentNullException("No note specified");

			if (tipo == null)
				throw new ArgumentNullException("No tipo specified");

			if (officina == null)
				throw new ArgumentNullException("No officina specified");

			_date = date;
			_note = note;
			_tipo = tipo;
			_costo = costo;
			_allegatoPath = allegatoPath;
			_officina = officina;
		}

		public string Date
		{
			get => _date;
			set => _date = value;
		}

		public string Note
		{
			get => _note;
			set => _note = value;
		}

		public string Tipo
		{
			get => _tipo;
			set => _tipo = value;
		}

		public float Costo
		{
			get => _costo;
			set => _costo = value;
		}

		public string AllegatoPath
		{
			get => _allegatoPath ?? "Non presente";
			set => _allegatoPath = value;
		}

		public string Officina
		{
			get => _officina;
			set => _officina = value;
		}
	}
}
