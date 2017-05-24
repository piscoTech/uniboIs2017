using System;
using Flotta.ServerSide;
using Flotta.ClientSide.Interface;
using Flotta.Model;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Flotta.ClientSide
{
	internal class UpdateScadenzaPresenter : IClosablePresenter
	{
		private IUpdateScadenzaDialog _view;

		private List<ScadenzaTypeDescriptor> _scadTypes;

		private Scadenza _scad;

		internal UpdateScadenzaPresenter(IUpdateScadenzaDialog view, IScadenzaAdapter scadOwner)
		{
			_view = view;

			_scadTypes = ModelFactory.GetAllScadenzaTypes().ToList();

			if (scadOwner.Scadenza == null)
			{
				_scad = _scadTypes.ElementAt(0).NewInstance;
				if (_scad.HasDate)
					_scad.Date = DateTime.Now;
				// Setup other fields
			}
			else
				_scad = scadOwner.Scadenza;

			_view.ScadenzaName = scadOwner.ScadenzaName;
			_view.Types = (from t in _scadTypes select t.Name).ToList();
			_view.SelectedType = _scadTypes.FindIndex((ScadenzaTypeDescriptor desc) => desc.IsType(_scad));
			UpdateUI();

			_view.TypeChanged += OnTypeChanged;
		}

		internal Scadenza Scadenza => _scad;

		private void OnTypeChanged()
		{
			ScadenzaTypeDescriptor type = _scadTypes.ElementAt(_view.SelectedType);
			if (type.IsType(_scad))
				return;

			Scadenza newScad = type.NewInstance;
			if (newScad.HasDate)
			{
				newScad.Date = _scad.HasDate ? _scad.Date : DateTime.Now;
			}
			// do the same for format and recurrent

			_scad = newScad;
			UpdateUI();
		}

		private void UpdateUI()
		{
			_view.DateFieldsVisible = _scad.HasDate;
			if (_scad.HasDate)
			{
				_view.Date = _scad.Date;
				_view.SelectedFormat = 0;
			}
			_view.RecurFieldVisible = _scad.HasRecurrentPeriod;
			if (_scad.HasRecurrentPeriod)
			{
				_view.RecurCount = 1;
				_view.RecurSelectedType = 0;
			}
		}

		public void Close()
		{
			_view.Close();
			_view.Dispose();
		}
	}
}
