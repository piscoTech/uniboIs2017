using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.ServerSide;
using Flotta.ClientSide.Interface;
using Flotta.Model;
using System.Windows.Forms;

namespace Flotta.ClientSide
{
	class LinkedTypeManagerPresenter<T> : IPresenter where T : LinkedType
	{
		private IServer _server;
		private ILinkedTypeManagerWindow _window;

		private List<T> _typeList;
		private string _typeName;

		internal LinkedTypeManagerPresenter(IServer server, ILinkedTypeManagerWindow window, string typeName)
		{
			_server = server;
			_window = window;

			_server.ObjectChanged += OnObjectChanged;
			_server.ObjectRemoved += OnObjectRemoved;
			_window.CreateNewType += OnCreateNewType;
			_window.EditType += OnEditType;
			_window.DeleteType += OnDeleteType;

			_typeName = typeName;
			_window.TypeName = _typeName;

			UpdateTypeList();
		}

		private void OnObjectChanged(IDBObject obj)
		{
			if (obj is T)
			{
				UpdateTypeList();
			}
		}

		private void OnObjectRemoved(IDBObject obj)
		{
			if (obj is T)
			{
				UpdateTypeList();
				if ((obj as T) == _activeType)
				{
					_updateDialog?.Close();
					_updateDialog?.Dispose();
				}
			}
		}

		private void UpdateTypeList()
		{
			_typeList = (from t in _server.GetLinkedTypes<T>() orderby t.IsDisabled, t.Name select t).ToList();
			_window.TypeList = from t in _typeList select ClientSideInterfaceFactory.NewLinkedTypeListItem(t.Name, t.IsDisabled);
		}

		private T _activeType = null;
		private IUpdateLinkedTypeDialog _updateDialog;

		private void OnCreateNewType()
		{
			DoEdit(null);
		}

		private void OnEditType(int index)
		{
			DoEdit(_typeList[index]);
		}

		private void DoEdit(T activeType)
		{
			_activeType = activeType;

			using (_updateDialog = ClientSideInterfaceFactory.NewUpdateLinkedTypeDialog())
			{
				_updateDialog.NameText = activeType?.Name ?? "";
				_updateDialog.TypeName = _typeName;
				_updateDialog.Validation = () =>
				{
					T type = activeType ?? ModelFactory.NewLinkedType<T>();
					var errors = _server.UpdateLinkedType(type, _updateDialog.NameText);
					if (errors.Count() > 0)
					{
						MessageBox.Show(String.Join("\r\n", errors), "Errore");
						return false;
					}
					else
						return true;
				};

				_updateDialog.ShowDialog();
				_updateDialog = null;
			}
		}

		private void OnDeleteType(int index)
		{
			if (MessageBox.Show("Sei sicuro di voler eliminare " + _typeList[index].Name + "?", "Elimina", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (!_server.DeleteLinkedType(_typeList[index]))
					MessageBox.Show("Errore durante l'eliminazione");
			}
		}

		public event Action PresenterClosed;
		public void Close()
		{
			_updateDialog?.Close();
			_updateDialog?.Dispose();
			_window.Close();
		}
	}
}
