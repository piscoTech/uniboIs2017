using System;
namespace Flotta.ClientSide.Interface
{
	public interface IScadenzaListItem
	{
		string Name { get; }
		bool IsValid { set; }
		DateTime? Date { set; }
		string DateDescription { get; }
	}

	class ScadenzaListItem : IScadenzaListItem
	{
		private string _name;
		private bool _isValid;
		private DateTime? _date;

		internal ScadenzaListItem(string name, bool isValid, DateTime? date)
		{
			_name = name;
			_isValid = isValid;
			_date = date;
		}

		public string Name
		{
			get => _name;
		}

		public bool IsValid
		{
			set => _isValid = value;
		}

		public DateTime? Date
		{
			set => _date = value;
		}

		public string DateDescription
		{
			get => _isValid ? (_date.HasValue ? _date.ToString() : "Illimitata") : "Non impostata";
		}
	}
}
