using System;
using Flotta.ServerSide;
using Flotta.ClientSide.Interface;
using Flotta.Model;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Flotta.ClientSide
{
	internal class UpdateScadenzaPresenter : IPresenter
	{
		private IUpdateScadenzaDialog _view;

		private List<ScadenzaTypeDescriptor> _scadTypes;
		private List<ScadenzaFormatDescriptor> _scadFormats;
		private List<ScadenzaRecurrencyTypeDescriptor> _scadRecurrency;

		private Scadenza _scad;

		internal UpdateScadenzaPresenter(IUpdateScadenzaDialog view, IScadenzaAdapter scadOwner)
		{
			_view = view;

			_scadTypes = ModelFactory.GetAllScadenzaTypes().ToList();
			_scadFormats = ModelFactory.GetAllScadenzaFormats().ToList();
			_scadRecurrency = ModelFactory.GetAllScadenzaRecurrencyTypes().ToList();

			if (scadOwner.Scadenza == null)
			{
				_scad = _scadTypes[0].NewInstance;
				if (_scad.HasDate)
				{
					_scad.Date = DateTime.Now;
					_scad.Formatter = _scadFormats[0].Formatter;
				}
				if (_scad.HasRecurrencyPeriod)
				{
					_scad.RecurrencyInterval = 1;
					_scad.RecurrencyType = _scadRecurrency[0].RecurrencyType;
				}
			}
			else
				_scad = scadOwner.Scadenza.Clone() as Scadenza;

			_view.ScadenzaName = scadOwner.ScadenzaName;

			_view.Types = (from t in _scadTypes select t.Name).ToList();
			_view.Formats = (from f in _scadFormats select f.Name).ToList();
			_view.RecurTypes = (from rt in _scadRecurrency select rt.Name).ToList();
			_view.SelectedType = _scadTypes.FindIndex((ScadenzaTypeDescriptor desc) => desc.IsType(_scad));

			UpdateUI();

			_view.TypeChanged += OnTypeChanged;
			_view.Validation = () =>
			{
				try
				{
					if (_scad.HasDate)
					{
						_scad.Date = _view.Date;
						_scad.Formatter = _scadFormats[_view.SelectedFormat].Formatter;
					}
					if (_scad.HasRecurrencyPeriod)
					{
						_scad.RecurrencyInterval = _view.RecurCount;
						_scad.RecurrencyType = _scadRecurrency[_view.SelectedRecurType].RecurrencyType;
					}

					return true;
				}
				catch (Exception e)
				{
					MessageBox.Show(e.Message, "Errore");
					return false;
				}

			};
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
				newScad.Formatter = _scad.HasDate ? _scad.Formatter : _scadFormats[0].Formatter;
			}
			if (newScad.HasRecurrencyPeriod)
			{
				newScad.RecurrencyInterval = _scad.HasRecurrencyPeriod ? _scad.RecurrencyInterval : 1;
				newScad.RecurrencyType = _scad.HasRecurrencyPeriod ? _scad.RecurrencyType : _scadRecurrency[0].RecurrencyType;
			}

			_scad = newScad;
			UpdateUI();
		}

		private void UpdateUI()
		{
			_view.DateFieldsVisible = _scad.HasDate;
			if (_scad.HasDate)
			{
				_view.Date = _scad.Date;
				_view.SelectedFormat = _scadFormats.FindIndex((ScadenzaFormatDescriptor desc) => desc.IsFormat(_scad));
			}
			_view.RecurFieldVisible = _scad.HasRecurrencyPeriod;
			if (_scad.HasRecurrencyPeriod)
			{
				_view.RecurCount = _scad.RecurrencyInterval;
				_view.SelectedRecurType = _scadRecurrency.FindIndex((ScadenzaRecurrencyTypeDescriptor desc) => desc.IsRecurrencyType(_scad));
			}
		}

		public event Action PresenterClosed;
		public void Close()
		{
			_view.Close();
			_view.Dispose();
		}
	}
}
