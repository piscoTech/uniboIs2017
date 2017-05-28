using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.ClientSide
{
	public interface IPresenter
	{
		void Close();

		event Action PresenterClosed;
	}

	interface IDialogPresenter : IPresenter
	{
		void ShowDialog();
	}

	public interface IWindowPresenter : IPresenter
	{
		void Show();
	}
}
