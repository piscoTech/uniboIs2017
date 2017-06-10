using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public static class ModelFactory
	{
		public static IUser NewUtente()
		{
			return new User();
		}

		public static IMezzo NewMezzo()
		{
			return new Mezzo();
		}

		private static IEnumerable<LinkedTypeDescriptor> _linkedTypesCache = null;
		public static IEnumerable<LinkedTypeDescriptor> GetAllLinkedTypes()
		{
			if (_linkedTypesCache == null)
			{
				Assembly assembly = Assembly.GetExecutingAssembly();

				var rawTypes = from t in assembly.GetTypes()
							   let attr = t.GetCustomAttributes(typeof(LinkedTypeAttribute), true)?.ElementAtOrDefault(0)
							   where attr != null && t.IsSubclassOf(typeof(LinkedType))
							   select new { Type = t, Description = (attr as LinkedTypeAttribute).Name };
				_linkedTypesCache = from ab in rawTypes
									let t = (from type in rawTypes
											 where !type.Type.IsAbstract && type.Type.IsSubclassOf(ab.Type)
											 select type.Type
											).ElementAtOrDefault(0)
									where ab.Type.IsAbstract && t != null
									orderby ab.Description
									select (LinkedTypeDescriptor)Activator.CreateInstance(typeof(LinkedTypeDescriptor),
																						  BindingFlags.NonPublic | BindingFlags.Instance,
																						  null,
																						  new Object[] { ab.Type, ab.Description, t }, null
																						 );
			}

			return _linkedTypesCache;
		}

		public static T NewLinkedType<T>() where T : LinkedType
		{
			Type concreteType = (from types in GetAllLinkedTypes() where types.Type == typeof(T) select types.ConcreteType).ElementAtOrDefault(0);
			if (concreteType == null)
				throw new NotImplementedException("Passed Type is not correctly implemented");

			return Activator.CreateInstance(concreteType, true) as T;
		}

		public static ITessera NewTessera(IMezzo mezzo, ITesseraType type)
		{
			return new Tessera(mezzo, type);
		}

		public static IDispositivo NewDispositivo(IMezzo mezzo, IDispositivoType type)
		{
			return new Dispositivo(mezzo, type);
		}

		public static IPermesso NewPermesso(IMezzo mezzo, IPermessoType type)
		{
			return new Permesso(mezzo, type);
		}

		private static IEnumerable<ScadenzaTypeDescriptor> _scadenzaTypesCache = null;
		public static IEnumerable<ScadenzaTypeDescriptor> GetAllScadenzaTypes()
		{
			if (_scadenzaTypesCache == null)
			{
				Assembly assembly = Assembly.GetExecutingAssembly();

				_scadenzaTypesCache = from t in assembly.GetTypes()
									  let attr = t.GetCustomAttributes(typeof(ScadenzaTypeAttribute), true)?.ElementAtOrDefault(0) as ScadenzaTypeAttribute
									  where t.IsSubclassOf(typeof(Scadenza)) && !t.IsAbstract && attr != null
									  orderby attr.Order
									  select new ScadenzaTypeDescriptor(t, attr);
			}

			return _scadenzaTypesCache;
		}

		private static IEnumerable<ScadenzaFormatDescriptor> _scadenzaFormatterCache = null;
		public static IEnumerable<ScadenzaFormatDescriptor> GetAllScadenzaFormats()
		{
			if (_scadenzaFormatterCache == null)
			{
				Assembly assembly = Assembly.GetExecutingAssembly();

				_scadenzaFormatterCache = from f in assembly.GetTypes()
										  let attr = f.GetCustomAttributes(typeof(ScadenzaFormatAttribute), true)?.ElementAtOrDefault(0) as ScadenzaFormatAttribute
										  where f.IsSubclassOf(typeof(ScadenzaFormat)) && !f.IsAbstract && attr != null
										  orderby attr.Order
										  select new ScadenzaFormatDescriptor(Activator.CreateInstance(f, true) as ScadenzaFormat, attr);
			}

			return _scadenzaFormatterCache;
		}

		private static IEnumerable<ScadenzaRecurrencyTypeDescriptor> _scadenzaRecurrencyTypesCache = null;
		public static IEnumerable<ScadenzaRecurrencyTypeDescriptor> GetAllScadenzaRecurrencyTypes()
		{
			if (_scadenzaRecurrencyTypesCache == null)
			{
				Assembly assembly = Assembly.GetExecutingAssembly();

				_scadenzaRecurrencyTypesCache = from rt in assembly.GetTypes()
												let attr = rt.GetCustomAttributes(typeof(ScadenzaRecurrencyTypeAttribute), true)?.ElementAtOrDefault(0) as ScadenzaRecurrencyTypeAttribute
												where rt.IsSubclassOf(typeof(ScadenzaRecurrencyType)) && !rt.IsAbstract && attr != null
												orderby attr.Order
												select new ScadenzaRecurrencyTypeDescriptor(Activator.CreateInstance(rt, true) as ScadenzaRecurrencyType, attr);
			}

			return _scadenzaRecurrencyTypesCache;
		}

		public static IEnumerable<IScadenzaOwner> GetAllScadenzeForMezzo(IMezzo mezzo)
		{
			var _scadenze = (from p in typeof(IMezzo).GetProperties()
							 let attr = p.GetCustomAttributes(typeof(MezzoScadenzaAttribute), true).ElementAtOrDefault(0) as MezzoScadenzaAttribute
							 where attr != null && typeof(Scadenza).IsAssignableFrom(p.PropertyType)
							 orderby attr.Order
							 select new MezzoScadenzaAdapter(mezzo, p, attr.Name) as IScadenzaOwner).ToList();

			_scadenze.AddRange(from t in mezzo.Tessere orderby t.Type.Name select t);
			_scadenze.AddRange(from d in mezzo.Dispositivi orderby d.Type.Name select d);
			_scadenze.AddRange(from p in mezzo.Permessi orderby p.Type.Name select p);

			return _scadenze;
		}

		public static IManutenzione NewManutenzione(IMezzo mezzo)
		{
			return new Manutenzione(mezzo);
		}

		public static IOfficina NewOfficina()
		{
			return new Officina();
		}

		public static IIncidente NewIncidente(IMezzo mezzo)
		{
			return new Incidente(mezzo);
		}

		public static IPDF NewPDF()
		{
			return new PDF();
		}

		public static IImmagine NewImmagine()
		{
			return new Immagine();
		}
	}
}
