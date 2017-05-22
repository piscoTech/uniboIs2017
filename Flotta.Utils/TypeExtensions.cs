using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Utils
{
    public static class TypeExtensions
    {
		public static Delegate DelegateForParameterlessConstructor(this Type type)
		{
			var ctor = type.GetConstructor(Type.EmptyTypes);
			if (ctor != null)
			{
				DynamicMethod dynamic = new DynamicMethod(string.Empty, type, Type.EmptyTypes, type);
				ILGenerator il = dynamic.GetILGenerator();

				il.DeclareLocal(type);
				il.Emit(OpCodes.Newobj, ctor);
				il.Emit(OpCodes.Stloc_0);
				il.Emit(OpCodes.Ldloc_0);
				il.Emit(OpCodes.Ret);

				return dynamic.CreateDelegate(typeof(Func<>).MakeGenericType(type));
			}

			return null;
		}
    }
}
