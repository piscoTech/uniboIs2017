using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
	public static class ModelFactory
	{
		public static IMezzo NewMezzo ()
		{
			return new Mezzo();
		}

		public static ITesseraType NewTesseraType()
		{
			return new TesseraType();
		}

		public static IDispositivoType NewDispositivoType()
		{
			return new DispositivoType();
		}

		public static IPermessoType NewPermessoType()
		{
			return new PermessoType();
		}

		public static IManutenzioneType NewManutenzioneType()
		{
			return new ManutenzioneType();
		}

		public static IAssicurazioneType NewAssicurazioneType()
		{
			return new AssicurazioneType();
		}

		public static IManutenzione NewManutenzione(IMezzo mezzo)
		{
			return new Manutenzione(mezzo);
		}
	}
}
