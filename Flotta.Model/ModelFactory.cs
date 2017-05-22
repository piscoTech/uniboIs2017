using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Flotta.Utils;

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

				var rawTypes = from t in assembly.GetTypes() let attr = t.GetCustomAttributes(typeof(LinkedTypeAttribute), true)?.ElementAtOrDefault(0) where attr != null && typeof(LinkedType).IsAssignableFrom(t) select new { Type = t, Description = (attr as LinkedTypeAttribute).Name };
				var types = from ab in rawTypes let t = (from type in rawTypes where !type.Type.IsAbstract && ab.Type.IsAssignableFrom(type.Type) select type.Type).ElementAtOrDefault(0) where ab.Type.IsAbstract && t != null select new { Type = ab.Type, Description = ab.Description, ConcreteType = t };
				var tmp = new List<LinkedTypeDescriptor>();
				foreach (var t in types)
				{
					var creator = t.ConcreteType.DelegateForParameterlessConstructor();
					if (creator != null)
					{
						tmp.Add((LinkedTypeDescriptor)Activator.CreateInstance(typeof(LinkedTypeDescriptor), BindingFlags.NonPublic | BindingFlags.Instance, null, new Object[] { t.Type, t.Description, creator }, null));
					}
				}

				_linkedTypeCache = tmp;
			}

			return _linkedTypeCache;
		}

		public static T NewLinkedType<T>() where T : LinkedType
		{
			return (from types in GetAllLinkedTypes() where types.Type == typeof(T) select types.Creator as Func<T>).ElementAtOrDefault(0)?.Invoke();
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
	}
}
