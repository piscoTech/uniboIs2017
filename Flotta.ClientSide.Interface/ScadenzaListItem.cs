using System;
namespace Flotta.ClientSide.Interface
{
	public interface IScadenzaListItem
	{
		string Name { get; }
		string Date { set; }
		string DateDescription { get; }
		bool Expired { get; set; }
		bool CanRenew { get; set; }
	}

	class ScadenzaListItem : IScadenzaListItem
	{
		private string _name;
		private string _date;
		private bool _expired;
		private bool _canRenew;

		internal ScadenzaListItem(string name, string date, bool expired, bool canRenew)
		{
			if (name == null)
				throw new ArgumentNullException("No name specified");

			_name = name;
			_date = date;
			_expired = expired;
			_canRenew = canRenew;
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

		public bool CanRenew
		{
			get => _canRenew;
			set => _canRenew = value;
		}
	}
}
