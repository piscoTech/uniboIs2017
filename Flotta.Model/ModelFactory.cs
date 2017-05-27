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
		public static IMezzo NewMezzo()
		{
			return new Mezzo();
		}

		private static IEnumerable<LinkedTypeDescriptor> _linkedTypeCache = null;
		public static IEnumerable<LinkedTypeDescriptor> GetAllLinkedTypes()
		{
			if (_linkedTypeCache == null)
			{
				Assembly assembly = Assembly.GetExecutingAssembly();

				var rawTypes = from t in assembly.GetTypes()
							   let attr = t.GetCustomAttributes(typeof(LinkedTypeAttribute), true)?.ElementAtOrDefault(0)
							   where attr != null && t.IsSubclassOf(typeof(LinkedType))
							   select new { Type = t, Description = (attr as LinkedTypeAttribute).Name };
				_linkedTypeCache = from ab in rawTypes
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

			return _linkedTypeCache;
		}

		public static T NewLinkedType<T>() where T : LinkedType
		{
			Type concreteType = (from types in GetAllLinkedTypes() where types.Type == typeof(T) select types.ConcreteType).ElementAtOrDefault(0);
			if (concreteType == null)
				throw new NotImplementedException("Passed Type is not correctly implemented");

			return Activator.CreateInstance(concreteType, true) as T;
		}

		public static ITessera NewTessera(ITesseraType type)
		{
			return new Tessera(type);
		}

		public static IDispositivo NewDispositivo(IDispositivoType type)
		{
			return new Dispositivo(type);
		}

		public static IPermesso NewPermesso(IPermessoType type)
		{
			return new Permesso(type);
		}

		public static IManutenzione NewManutenzione(IMezzo mezzo)
		{
			return new Manutenzione(mezzo);
		}
	
	public static IOfficina NewOfficina(string nome, string telefono, string via, string cap, string citta, string provincia, string nazione)
		{
			return new Officina(nome, telefono, via, cap, citta, provincia, nazione);
		}
	}
}
