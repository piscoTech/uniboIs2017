﻿using System;
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
	class LinkedTypeManagerPresenter<T> : IWindowPresenter where T : LinkedType
	{
		private IServer _server;
		private ILinkedTypeManagerWindow _window;

		private List<T> _typeList;
		private string _typeName;

		private UpdateLinkedTypePresenter<T> _updatePresenter;

		internal LinkedTypeManagerPresenter(IServer server, string typeName)
		{
			_server = server;
			_server.ObjectChanged += OnObjectChangedRemoved;
			_server.ObjectRemoved += OnObjectChangedRemoved;

			_typeName = typeName;
		}

		public void Show()
		{
			_window = ClientSideInterfaceFactory.NewLinkedTypeManagerWindow();
			_window.FormClosed += (object s, FormClosedEventArgs e) => Close();

			_window.CreateNewType += OnCreateNewType;
			_window.EditType += OnEditType;
			_window.DeleteType += OnDeleteType;
			_window.TypeName = _typeName;

			UpdateTypeList();

			_window.Show();
		}

		private void OnObjectChangedRemoved(IDBObject obj)
		{
			if (obj is T)
			{
				UpdateTypeList();
			}
		}

		private void UpdateTypeList()
		{
			if (_window == null)
				return;

			_typeList = (from t in _server.GetLinkedTypes<T>() orderby t.IsDisabled, t.Name select t).ToList();
			_window.TypeList = from t in _typeList select ClientSideInterfaceFactory.NewLinkedTypeListItem(t.Name, t.IsDisabled);
		}

		private void OnCreateNewType()
		{
			DoEdit(ModelFactory.NewLinkedType<T>());
		}

		private void OnEditType(int index)
		{
			DoEdit(_typeList[index]);
		}

		private void DoEdit(T activeType)
		{
			_updatePresenter = new UpdateLinkedTypePresenter<T>(_server, activeType, _typeName);
			_updatePresenter.PresenterClosed += () => _updatePresenter = null;
			_updatePresenter.ShowDialog();
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
			var win = _window;
			_window = null;

			_updatePresenter?.Close();
			win?.Close();
			win?.Dispose();
			PresenterClosed?.Invoke();
		}
	}
}
