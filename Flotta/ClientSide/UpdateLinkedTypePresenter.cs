using System;
using Flotta.ClientSide.View;
using Flotta.ServerSide;
using Flotta.Model;
using System.Linq;
using System.Windows.Forms;

namespace Flotta.ClientSide
{
	internal class UpdateLinkedTypePresenter<T> : IDialogPresenter where T : LinkedType
	{
		private readonly IServer _server;
		private IUpdateLinkedTypeDialog _window;
		private readonly T _type;

		private readonly string _typeName;

		internal UpdateLinkedTypePresenter(IServer server, T type, string typeName)
		{
			if (server == null)
				throw new ArgumentNullException("No server specified");

			if (type == null)
				throw new ArgumentNullException("No type specified");

			if (typeName == null)
				throw new ArgumentNullException("No type name specified");

			_server = server;
			_type = type;

			_typeName = typeName;
		}

		public void ShowDialog()
		{
			using (_window = ClientSideInterfaceFactory.NewUpdateLinkedTypeDialog())
			{
				_server.ObjectRemoved += OnObjectRemoved;

				_window.NameText = _type.Name ?? "";
				_window.TypeName = _typeName;
				_window.Validation = () =>
				{
					var errors = _server.UpdateLinkedType(_type, _window.NameText);
					if (errors.Count() > 0)
					{
						MessageBox.Show(String.Join("\r\n", errors), "Errore");
						return false;
					}
					else
						return true;
				};

				_window.ShowDialog();
			}
			Close();
		}

		private void OnObjectRemoved(IDBObject obj)
		{
			if (obj is T t && t == _type)
				Close();
		}

		public event Action PresenterClosed;
		public void Close()
		{
			_server.ObjectRemoved -= OnObjectRemoved;

			var win = _window;
			_window = null;

			win?.Close();
			win.Dispose();
			PresenterClosed?.Invoke();
		}
	}
}
