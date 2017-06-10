using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Flotta.Model;
using Flotta.ServerSide.Interface;

namespace Flotta.ServerSide
{
	public interface IServer
	{
		void ClientDisconnected(IUser user);
		void ClientConnected();
		event Action<IDBObject> ObjectChanged;
		event Action<IDBObject> ObjectRemoved;

		IEnumerable<IUser> Utenti { get; }
		IUser ValidateUser(string username, string password);
		IEnumerable<string> ChangeUserPassword(IUser user, string password, string oldPassword);

		IEnumerable<IMezzo> Mezzi { get; }

		IEnumerable<T> GetLinkedTypes<T>() where T : LinkedType;
		IEnumerable<IOfficina> Officine { get; }

		IEnumerable<string> UpdateMezzo(IMezzo mezzo, IImmagine foto, string modello, string targa, uint numero,
										string numCartaCircolazione, IPDF cartaCircolazione,
										string numeroTelaio, uint annoImmatricolazione, float portata,
										float altezza, float lunghezza, float profondita,
										float volumeCarico, IEnumerable<ITessera> tessere,
										IEnumerable<IDispositivo> dispositivi, IEnumerable<IPermesso> permessi);
		bool DeleteMezzo(IMezzo mezzo);

		void UpdateScadenza(IScadenzaAdapter scadOwner, Scadenza scad);

		IEnumerable<string> UpdateManutenzione(IManutenzione manutenzione, DateTime data, string note, IManutenzioneType tipo, float costo, IPDF allegato, IOfficina officina);
		void DeleteManutenzione(IManutenzione m);

		IEnumerable<string> UpdateLinkedType<T>(T tessera, string name) where T : LinkedType;
		bool DeleteLinkedType<T>(T obj) where T : LinkedType;

		IEnumerable<string> UpdateOfficina(IOfficina officina, string nome, string telefono, string via, string cap, string citta, string provincia, string nazione);
		bool DeleteOfficina(IOfficina off);

	}

	public class Server : IServer
	{
		private IServerWindow _window;

		private List<IUser> _utenti = new List<IUser>();
		private HashSet<IUser> _loggedUser = new HashSet<IUser>();

		private List<IMezzo> _mezzi = new List<IMezzo>();
		private Dictionary<Type, object> _linkedTypesList = new Dictionary<Type, object>();
		private List<IOfficina> _officine = new List<IOfficina>();

		internal Server(IServerWindow window)
		{
			_window = window;

			_window.CreateClient += OnCreateClient;
			_window.CanTerminate = true;

			FillDatabase();
		}

		private void FillDatabase()
		{
			IUser u = ModelFactory.NewUtente();
			u.Update("admin", true);
			u.ChangePassword("password", null);
			_utenti.Add(u);

			u = ModelFactory.NewUtente();
			u.Update("user", false);
			u.ChangePassword("user", null);
			_utenti.Add(u);

			var tess = GetLinkedTypesList<ITesseraType>();
			ITesseraType tt = ModelFactory.NewLinkedType<ITesseraType>();
			tt.Update("Tessera 1");
			tess.Add(tt);
			tt = ModelFactory.NewLinkedType<ITesseraType>();
			tt.Update("Tessera 2");
			tt.Disable();
			tess.Add(tt);

			var disp = GetLinkedTypesList<IDispositivoType>();
			IDispositivoType dt = ModelFactory.NewLinkedType<IDispositivoType>();
			dt.Update("Dispositivo 1");
			dt.Disable();
			disp.Add(dt);
			dt = ModelFactory.NewLinkedType<IDispositivoType>();
			dt.Update("Dispositivo 2");
			disp.Add(dt);

			var perm = GetLinkedTypesList<IPermessoType>();
			IPermessoType pt = ModelFactory.NewLinkedType<IPermessoType>();
			pt.Update("Permesso 1");
			perm.Add(pt);
			pt = ModelFactory.NewLinkedType<IPermessoType>();
			pt.Update("Permesso 2");
			pt.Disable();
			perm.Add(pt);

			var manut = GetLinkedTypesList<IManutenzioneType>();
			IManutenzioneType mt = ModelFactory.NewLinkedType<IManutenzioneType>();
			mt.Update("Manutenzione 1");
			mt.Disable();
			manut.Add(mt);
			mt = ModelFactory.NewLinkedType<IManutenzioneType>();
			mt.Update("Manutenzione 2");
			manut.Add(mt);

			IMezzo m = ModelFactory.NewMezzo();
			ITessera t = ModelFactory.NewTessera(m, tess.ElementAt(1));
			t.Update("123", "7654");
			IDispositivo d = ModelFactory.NewDispositivo(m, disp.ElementAt(0));
			d.Update(null);
			IPermesso p1, p2;
			p1 = ModelFactory.NewPermesso(m, perm.ElementAt(0));
			p1.Update(null);
			p2 = ModelFactory.NewPermesso(m, perm.ElementAt(1));
			p1.Update(null);
			m.Update(null, "Mezzo 1", "aa000aa", 100, "CRTCIRC123", null, "ABC12345", 2017, 1, 5.4F, 9, 10, 5, new ITessera[] { t }, new IDispositivo[] { d }, new IPermesso[] { p1, p2 });
			_mezzi.Add(m);

			var scad = ModelFactory.GetAllScadenzaTypes();
			var scadFormat = ModelFactory.GetAllScadenzaFormats();
			var scadRecur = ModelFactory.GetAllScadenzaRecurrencyTypes();

			Scadenza ts = scad.ElementAt(0).NewInstance;
			ts.Date = DateTime.Now;
			ts.Formatter = scadFormat.ElementAt(0).Formatter;
			t.Scadenza = ts;

			Scadenza ds = scad.ElementAt(1).NewInstance;
			ds.Date = new DateTime(2017, 8, 1);
			ds.Formatter = scadFormat.ElementAt(1).Formatter;
			ds.RecurrencyInterval = 4;
			ds.RecurrencyType = scadRecur.ElementAt(1).RecurrencyType;
			d.Scadenza = ds;

			Scadenza ps = scad.ElementAt(2).NewInstance;
			p1.Scadenza = ps;

			Scadenza ccircs = scad.ElementAt(1).NewInstance;
			ccircs.Date = new DateTime(2018, 8, 1);
			ccircs.Formatter = scadFormat.ElementAt(1).Formatter;
			ccircs.RecurrencyInterval = 2;
			ccircs.RecurrencyType = scadRecur.ElementAt(2).RecurrencyType;
			m.ScadenzaCartaCircolazione = ccircs;

			IOfficina off = ModelFactory.NewOfficina();
			off.Update("Officina 1", "051123456", "Via Prova 1", "01234", "Bologna", "Bo", "Italia");
			_officine.Add(off);

			IManutenzione man = ModelFactory.NewManutenzione(m);
			man.Update(DateTime.Now, manut.ElementAt(0), "Note", 10, null, off);
			m.AddManutenzione(man);
		}

		private Action _createClient;
		internal Action ClientCreator
		{
			set
			{
				_createClient = value;
			}
		}

		private int _activeConnections = 0;
		private bool CanTerminate
		{
			get => _activeConnections == 0;
		}

		public event Action<IDBObject> ObjectChanged;
		public event Action<IDBObject> ObjectRemoved;

		public void ClientConnected()
		{
			_window.UpdateCounter(++_activeConnections);
			_window.CanTerminate = CanTerminate;

			Log("Un client si è connesso");
		}

		public void ClientDisconnected(IUser user)
		{
			_loggedUser.Remove(user);

			_window.UpdateCounter(--_activeConnections);
			_window.CanTerminate = CanTerminate;

			Log("Un client si è disconnesso");
		}

		private void OnCreateClient()
		{
			_createClient?.Invoke();
		}

		private void Log(string line)
		{
			_window.Log(line);
		}

		public IEnumerable<IUser> Utenti => from u in _utenti orderby u.Username select u;

		public IUser ValidateUser(string username, string password)
		{
			IUser user = _utenti.FirstOrDefault((IUser u) => u.Match(username, password));
			if (user != null)
				_loggedUser.Add(user);

			return user;
		}

		public IEnumerable<string> ChangeUserPassword(IUser user, string password, string oldPassword)
		{
			var errors = user.ChangePassword(password, oldPassword);
			if (errors.Count() == 0)
				ObjectChanged(user);

			return errors;
		}

		public IEnumerable<IMezzo> Mezzi => from m in _mezzi orderby m.Numero select m;

		private List<T> GetLinkedTypesList<T>() where T : LinkedType
		{
			Type t = typeof(T);
			if (!t.IsAbstract)
				throw new ArgumentException("Type is not an abstract LinkedType");

			if (!_linkedTypesList.ContainsKey(t))
				_linkedTypesList.Add(t, new List<T>());

			return _linkedTypesList[t] as List<T>;
		}
		public IEnumerable<T> GetLinkedTypes<T>() where T : LinkedType
		{
			return from t in GetLinkedTypesList<T>() orderby t.Name select t;
		}

		public IEnumerable<IOfficina> Officine => from o in _officine orderby o.Nome select o;

		public IEnumerable<string> UpdateMezzo(IMezzo mezzo, IImmagine foto, string modello, string targa, uint numero,
												string numCartaCircolazione, IPDF cartaCircolazione,
												string numeroTelaio, uint annoImmatricolazione, float portata,
												float altezza, float lunghezza, float profondita,
												float volumeCarico, IEnumerable<ITessera> tessere,
												IEnumerable<IDispositivo> dispositivi, IEnumerable<IPermesso> permessi)
		{
			if (mezzo == null) throw new ArgumentNullException();
			List<String> errors = new List<string>();

			var numMatch = from m in _mezzi where m.Numero == numero && m != mezzo select m;
			if (numMatch.Count() > 0)
				errors.Add("Il numero è già utilizzato");

			targa = targa?.Trim()?.ToUpper();
			if (targa != null && (from m in _mezzi where m.Targa == targa && m != mezzo select m).Count() > 0)
				errors.Add("La targa è già utilizzata");

			if ((from t in tessere select t.Type).Any((ITesseraType t) => !GetLinkedTypes<ITesseraType>().Contains(t)))
				errors.Add("Uno o più tipi di tessere non esistono");
			if ((from d in dispositivi select d.Type).Any((IDispositivoType d) => !GetLinkedTypes<IDispositivoType>().Contains(d)))
				errors.Add("Uno o più tipi di dispositivi non esistono");
			if ((from p in permessi select p.Type).Any((IPermessoType p) => !GetLinkedTypes<IPermessoType>().Contains(p)))
				errors.Add("Uno o più tipi di permessi non esistono");

			if (errors.Count > 0)
				return errors;
			else
			{
				errors = mezzo.Update(foto, modello, targa, numero, numCartaCircolazione, cartaCircolazione,
									  numeroTelaio, annoImmatricolazione, portata, altezza, lunghezza,
									  profondita, volumeCarico, tessere, dispositivi, permessi).ToList();

				if (errors.Count == 0)
				{
					if (!_mezzi.Contains(mezzo))
					{
						_mezzi.Add(mezzo);
						Log("Mezzo " + mezzo.Numero + " è stato creato");
					}
					else
						Log("Mezzo " + mezzo.Numero + " è stato modificato");

					ObjectChanged(mezzo);
				}

				return errors;
			}
		}

		public bool DeleteMezzo(IMezzo mezzo)
		{
			if (mezzo == null) throw new ArgumentNullException();

			if (_mezzi.Contains(mezzo) && _mezzi.Remove(mezzo))
			{
				ObjectRemoved(mezzo);
				Log("Mezzo " + mezzo.Numero + " è stato eliminato");
				return true;
			}

			return false;
		}

		public IEnumerable<string> UpdateLinkedType<T>(T obj, string name) where T : LinkedType
		{
			if (obj == null)
				throw new ArgumentNullException();
			var list = GetLinkedTypesList<T>();

			List<string> errors = new List<string>();
			name = name?.Trim();
			if (String.IsNullOrEmpty(name))
				// Let the object give the error for missing name
				return obj.Update(null);

			var nameMatch = from l in list where l.Name == name && l != obj select l;
			if (nameMatch.Count() > 0)
			{
				errors.Add("Il nome è già utilizzato");
			}

			if (errors.Count > 0)
				return errors;
			else
			{
				errors = obj.Update(name).ToList();

				if (errors.Count == 0)
				{
					if (!list.Contains(obj))
					{
						list.Add(obj);
						Log("Il tipo (" + typeof(T).Name + ") '" + obj.Name + "' è stato creato");
					}
					else
						Log("Il tipo (" + typeof(T).Name + ") '" + obj.Name + "' è stato modificato");

					ObjectChanged(obj);
				}

				return errors;
			}
		}

		public bool DeleteLinkedType<T>(T obj) where T : LinkedType
		{
			var list = GetLinkedTypesList<T>();

			if (obj.ShouldDisableInsteadOfDelete(_mezzi))
			{
				obj.Disable();
				ObjectChanged(obj);
				Log("Il tipo (" + typeof(T).Name + ") '" + obj.Name + "' è stato disabilitato");
				return true;
			}
			else
			{
				if (list.Contains(obj) && list.Remove(obj))
				{
					ObjectRemoved(obj);
					Log("Il tipo (" + typeof(T).Name + ") '" + obj.Name + "' è stato eliminato");
					return true;
				}

				return false;
			}
		}

		public void UpdateScadenza(IScadenzaAdapter scadOwner, Scadenza scad)
		{
			scadOwner.Scadenza = scad;
			ObjectChanged(scadOwner);
			Log("La scadenza " + scadOwner.ScadenzaName + " del mezzo " + scadOwner.Mezzo.Numero + " è stata modificata");
		}

		public IEnumerable<string> UpdateManutenzione(IManutenzione manutenzione, DateTime data, string note, IManutenzioneType tipo, float costo, IPDF allegato, IOfficina officina)
		{
			List<String> errors = new List<string>();

			if (tipo != null && !GetLinkedTypes<IManutenzioneType>().Contains(tipo))
				errors.Add("Il tipo di manutenzione non esiste");

			if (officina != null && !_officine.Contains(officina))
				errors.Add("L'officina non esiste");

			if (errors.Count() > 0)
				return errors;

			errors.AddRange(manutenzione.Update(data, tipo, note, costo, allegato, officina));

			if (errors.Count() > 0)
				return errors;

			manutenzione.Mezzo.AddManutenzione(manutenzione);

			ObjectChanged(manutenzione);
			Log("La manutenzione del " + data.ToString("dd/MM/yyyy") + " del mezzo " + manutenzione.Mezzo.Numero + " è stata modificata");

			return errors;
		}

		public void DeleteManutenzione(IManutenzione m)
		{
			m.Mezzo.RemoveManutenzione(m);
			ObjectRemoved(m);
			Log("La manutenzione del " + m.Data.ToString("dd/MM/yyyy") + " del mezzo " + m.Mezzo.Numero + " è stata eliminata");
		}

		public IEnumerable<string> UpdateOfficina(IOfficina officina, string nome, string telefono, string via, string cap, string citta, string provincia, string nazione)
		{
			List<string> errors = new List<string>();
			nome = nome?.Trim();
			if (nome != null && (from o in _officine where o.Nome == nome && o != officina select o).Count() > 0)
				errors.Add("Il nome è già utilizzato");

			if (errors.Count > 0)
				return errors;

			errors.AddRange(officina.Update(nome, telefono, via, cap, citta, provincia, nazione));
			if (errors.Count > 0)
				return errors;
			else
			{
				if (!_officine.Contains(officina))
				{
					_officine.Add(officina);
					Log("L'officina " + nome + " è stata creata");
				}
				else
					Log("L'officina " + nome + " è stata modificata");

				ObjectChanged(officina);
			}

			return errors;
		}

		public bool DeleteOfficina(IOfficina off)
		{
			if (off.ShouldDisableInsteadOfDelete(_mezzi))
			{
				off.Disable();
				ObjectChanged(off);
				Log("L'officina " + off.Nome + " è stata disabilitata");
				return true;
			}
			else
			{
				if (_officine.Contains(off) && _officine.Remove(off))
				{
					ObjectRemoved(off);
					Log("L'officina " + off.Nome + " è stata eliminata");
					return true;
				}

				return false;
			}
		}
	}
}
