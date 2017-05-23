using System;
namespace Flotta.ClientSide.Interface
{
	public interface IScadenzaListItem
	{
		string Name { get; }
		DateTime? Date { set; }
		string DateDescription { get; }
	}

	class ScadenzaListItem : IScadenzaListItem
	{
		private string _name;
		private DateTime? _date;

		internal ScadenzaListItem(string name, DateTime? date)
		{
			_name = name;
			_date = date;
		}

		public string Name
		{
			get => _name;
		}

		public DateTime? Date
		{
			set => _date = value;
		}

		public string DateDescription
		{
			get => _date.HasValue ? _date.ToString() : "Non impostata";
		}
	}
}
