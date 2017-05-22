using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public interface IOfficina : IDBObject
	{
		string Nome { get; set; }
		string Telefono { get; set; }
		string Via { get; set; }
		string Cap { get; set; }
		string Citta { get; set; }
		string Provincia { get; set; }
		string Nazione { get; set; }
	}

	internal class Officina : IOfficina
	{
		private string _nome;
		private string _telefono;
		private string _via;
		private string _cap;
		private string _citta;
		private string _provincia;
		private string _nazione;


		public string Nome
		{
			get { return _nome; }
			set { _nome = value; }
		}

		public string Telefono
		{
			get { return _telefono; }
			set { _telefono = value; }
		}
		public string Via
		{
			get { return _via; }
			set { _via = value; }
		}
		public string Cap
		{
			get { return _cap; }
			set { _cap = value; }
		}
		public string Citta
		{
			get { return _citta; }
			set { _citta = value; }
		}
		public string Provincia
		{
			get { return _provincia; }
			set { _provincia = value; }
		}

		public string Nazione
		{
			get { return _nazione; }
			set { _nazione = value; }
		}
	}
}
