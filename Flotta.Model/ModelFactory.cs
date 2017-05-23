using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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

		private static IEnumerable<LinkedTypeDescriptor> _linkedTypesCache = null;
		public static IEnumerable<LinkedTypeDescriptor> GetAllLinkedTypes()
		{
			if (_linkedTypesCache == null)
			{
				Assembly assembly = Assembly.GetExecutingAssembly();

				var rawTypes = from t in assembly.GetTypes()
							   let attr = t.GetCustomAttributes(typeof(LinkedTypeAttribute), true)?.ElementAtOrDefault(0)
							   where attr != null && typeof(LinkedType).IsAssignableFrom(t)
							   select new { Type = t, Description = (attr as LinkedTypeAttribute).Name };
				_linkedTypesCache = from ab in rawTypes
									let t = (from type in rawTypes
											 where !type.Type.IsAbstract && ab.Type.IsAssignableFrom(type.Type)
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

		private static IEnumerable<ScadenzaTypeDescriptor> _scadenzaTypesCache = null;
		public static IEnumerable<ScadenzaTypeDescriptor> GetAllScadenzaTypes()
		{
			if (_scadenzaTypesCache == null)
			{
				Assembly assembly = Assembly.GetExecutingAssembly();

				_scadenzaTypesCache = from t in assembly.GetTypes()
									  where typeof(Scadenza).IsAssignableFrom(t) && !t.IsAbstract
									  select new ScadenzaTypeDescriptor(t);
			}

			return _scadenzaTypesCache;
		}
	}
}
