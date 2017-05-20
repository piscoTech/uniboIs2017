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
	class LinkedTypeManagerPresenter<T> : IClosablePresenter where T : LinkedType
	{
		private IServer _server;
		private ILinkedTypeManagerWindow _window;

		private Func<IEnumerable<T>> _getList;
		private Func<T, string, IEnumerable<string>> _updateType;
		private Func<T, bool> _deleteType;
		private Func<T> _newType;

		private List<T> _typeList;
		private string _typeName;
		internal string TypeName
		{
			set
			{
				_typeName = value;
				_window.TypeName = value;
			}
		}

		internal LinkedTypeManagerPresenter(IServer server, ILinkedTypeManagerWindow window, Func<IEnumerable<T>> getList, Func<T, string, IEnumerable<string>> updateType, Func<T, bool> deleteType, Func<T> newType)
		{
			_server = server;
			_window = window;

			_server.ObjectChanged += OnObjectChanged;
			_server.ObjectRemoved += OnObjectRemoved;
			_window.CreateNewType += OnCreateNewType;
			_window.EditType += OnEditType;
			_window.DeleteType += OnDeleteType;

			_getList = getList;
			_updateType = updateType;
			_deleteType = deleteType;
			_newType = newType;

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
			_typeList = (from t in _getList() orderby t.IsDisabled, t.Name select t).ToList();
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
					T type = activeType ?? _newType();
					var errors = _updateType(type, _updateDialog.NameText);
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
				if (!_deleteType(_typeList[index]))
					MessageBox.Show("Errore durante l'eliminazione");
			}
		}

		public void Close()
		{
			_updateDialog?.Close();
			_updateDialog?.Dispose();
			_window.Close();
		}
	}
}
