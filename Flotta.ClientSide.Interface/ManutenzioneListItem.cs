using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ClientSide.Interface
{
	public interface IManutenzioneListItem
	{
		DateTime Date { get; set; }
		string Note { get; set; }
		string Tipo { get; set; }
		float Costo { get; set; }
	}

	internal class ManutenzioneListItem : IManutenzioneListItem
	{
		private DateTime _date;
		private string _note;
		private string _tipo;
		private float _costo;

		public ManutenzioneListItem(DateTime date, string note, string tipo, float costo)
		{
			_date = date;
			_note = note;
			_tipo = tipo;
			_costo = costo;
		}

		public DateTime Date
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

	}
}
