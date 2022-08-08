using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace TestLoadAnimation
{
	public class ViewModel2 : INotifyPropertyChanged
	{
		private bool isLoading = false;
		public bool IsLoading
		{
			get { return isLoading; }
			set
			{
				isLoading = value;
				OnPropertyChanged("IsLoading");
			}
		}

		public ObservableCollection<String> list { get; set; }

		private RelayCommand loadListCommand;
		public RelayCommand LoadListCommand
		{
			get
			{
				return loadListCommand ??
				  (loadListCommand = new RelayCommand(obj =>
				  {
					  if (!IsLoading)
					  {
						  IsLoading = true;
						  list.Clear();
						  for (int i = 0; i < 300; i++)
						  {
							  list.Add(i.ToString());
						  }
						  IsLoading = false;
					  }
				  }));
			}
		}


		public ViewModel2() { list = new ObservableCollection<string>(); }
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}


        public class RelayCommand : ICommand
        {
            private Action<object> execute;
            private Func<object, bool> canExecute;

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
            {
                this.execute = execute;
                this.canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return this.canExecute == null || this.canExecute(parameter);
            }

            public void Execute(object parameter)
            {
                this.execute(parameter);
            }
        }
    }
}
