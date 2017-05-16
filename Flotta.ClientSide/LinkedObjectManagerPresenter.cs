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
	class LinkedObjectManagerPresenter<T> where T : class, ILinkedObject
	{

		internal delegate IEnumerable<T> GetListHandler();
		internal delegate IEnumerable<string> UpdateTypeHandler(T type, string name);
		internal delegate bool DeleteTypeHandler(T type);
		internal delegate T GetNewType();

		private IServer _server;
		private ILinkedObjectManagerWindow _window;

		private GetListHandler _getList;
		private UpdateTypeHandler _updateType;
		private DeleteTypeHandler _deleteType;
		private GetNewType _newType;

		private List<T> _typeList;

		internal LinkedObjectManagerPresenter(IServer server, ILinkedObjectManagerWindow window, GetListHandler getList, UpdateTypeHandler updateType, DeleteTypeHandler deleteType, GetNewType newType)
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
			if(obj is T)
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
					_updateDialog?.Close();
			}
		}

		private void UpdateTypeList()
		{
			_typeList = _getList().ToList();
			_window.TypeList = from t in _typeList select ClientSideInterfaceFactory.NewLinkedObjectListItem(t.Name, t.IsDisabled);
		}

		private T _activeType = null;
		private IUpdateLinkedObjectDialog _updateDialog;

		private void OnCreateNewType()
		{
			if (_activeType != null)
				return;

			_updateDialog = ClientSideInterfaceFactory.NewUpdateLinkedObjectDialog();
			_updateDialog.FormClosed += (object sender, FormClosedEventArgs e) => _activeType = null;
			_updateDialog.SaveType += OnSaveType;

			_updateDialog.ShowDialog();
		}

		private void OnEditType(int index)
		{
			if (_activeType != null)
				return;

			_activeType = _typeList[index];
			_updateDialog = ClientSideInterfaceFactory.NewUpdateLinkedObjectDialog();
			_updateDialog.FormClosed += (object sender, FormClosedEventArgs e) => _activeType = null;
			_updateDialog.SaveType += OnSaveType;
			_updateDialog.TypeName = _activeType.Name;

			_updateDialog.ShowDialog();
		}

		private void OnDeleteType(int index)
		{
			if(MessageBox.Show("Sei sicuro di voler eliminare " + _typeList[index].Name + "?", "Elimina", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (!_deleteType(_typeList[index]))
					MessageBox.Show("Errore durante l'eliminazione");
			}
		}

		private void OnSaveType(string name)
		{
			T type = _activeType == null ? _newType() : _activeType;
			var errors = _updateType(type, name);
			if (errors.Count() > 0) MessageBox.Show(String.Join("\r\n", errors), "Errore");
			else
			{
				_updateDialog.Close();
				_updateDialog = null;
			}
		}
	}
}
