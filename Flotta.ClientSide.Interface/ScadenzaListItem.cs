using System;
namespace Flotta.ClientSide.Interface
{
	public interface IScadenzaListItem
	{
		string Name { get; }
		string Date { set; }
		string DateDescription { get; }
		bool Expired { get; set; }
	}

	class ScadenzaListItem : IScadenzaListItem
	{
		private string _name;
		private string _date;
		private bool _expired;

		internal ScadenzaListItem(string name, string date, bool expired)
		{
			_name = name;
			_date = date;
			_expired = expired;
		}

		public string Name
		{
			get => _name;
		}

		public string Date
		{
			set => _date = value;
		}

		public string DateDescription
		{
			get => _date ?? "Non impostata";
		}

		public bool Expired
		{
			get => _expired;
			set => _expired = value;
		}
	}
}
