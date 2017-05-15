using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flotta.ClientSide.Interface;
using Flotta.Model;

namespace Flotta.ClientSide
{
	internal class TabGeneralePresenter : ITabPresenter
	{

		private MezzoTabPresenter _tabs;
		private ITabViewGenerale _view;

		private IMezzo Mezzo
		{
			get => _tabs.Mezzo;
		}

		private bool _editMode;
		private bool EditMode
		{
			get => _editMode;
			set
			{
				_editMode = value;
				Reload();
			}
		}

		internal TabGeneralePresenter(MezzoTabPresenter tabs, ITabViewGenerale view)
		{
			_tabs = tabs;
			_view = view;

			EditMode = false;

			_view.CancelEdit += OnCancelEdit;
			_view.EnterEdit += OnEnterEdit;
			_view.SaveEdit += OnSaveEdit;
		}

		public void Reload()
		{
			if (_tabs.Mezzo == null)
				return;

			_view.Modello = Mezzo.Modello;
			_view.Targa = Mezzo.Targa;
			_view.EditMode = _editMode;
		}

		private void OnEnterEdit()
		{
			if (EditMode)
				return;

			EditMode = true;
			Console.WriteLine("Generale Enter Edit");
		}

		public void OnCancelEdit()
		{
			if (!EditMode)
				return;

			EditMode = false;
			Console.WriteLine("Generale Cancel Edit");
		}

		private void OnSaveEdit()
		{
			if (!EditMode)
				return;

			// Save all data

			EditMode = false;
			Console.WriteLine("Generale Save Edit");
		}
	}
}
