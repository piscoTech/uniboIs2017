using System;
namespace Flotta.ClientSide.Interface
{
	public interface IScadenzaListItem
	{
		string Name { get; }
		string Date { set; }
		string DateDescription { get; }
	}

	class ScadenzaListItem : IScadenzaListItem
	{
		private string _name;
		private string _date;

		internal ScadenzaListItem(string name, string date)
		{
			_name = name;
			_date = date;
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
	}
}
