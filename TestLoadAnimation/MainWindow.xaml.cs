using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestLoadAnimation
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		delegate void LogInHandler(bool flag);
		event LogInHandler logInNotify;


		public MainWindow()
		{
			InitializeComponent();
			DataContext = new ViewModel();
			logInNotify += logicalDialogClosing;
			BooleanAnimationUsingKeyFrames an = new BooleanAnimationUsingKeyFrames();
		}

		private void StartBtn_Click(object sender, RoutedEventArgs e)
		{
			((ViewModel)DataContext).IsLoading = true;
			ThreadStart threadStart = new ThreadStart(Count);
			/*threadStart += () =>
			{
				this.Dispatcher.Invoke(new Action(() => { this.DialogResult = true; }));
			};*/
			Thread myThread = new Thread(threadStart);
			myThread.Start();
			var x = myThread.ThreadState;
		}

		private void StopBtn_Click(object sender, RoutedEventArgs e)
		{
			((ViewModel)DataContext).IsLoading = false;
		}

		public void Count()
		{
			for (int i = 1; i < 99; i++)
			{				
				Thread.Sleep(1000);
			}
			this.Dispatcher.Invoke(logInNotify,true);
		}

		public void logicalDialogClosing(bool flag)
		{
			if (flag) DialogResult = true;
		}

		private bool Flag;

		public event PropertyChangedEventHandler PropertyChanged;

		public bool flag
		{
			get { return Flag; }
			set
			{
				Flag = value;
				arc1.SweepDirection = Flag ? SweepDirection.Clockwise : SweepDirection.Counterclockwise;
				arc2.SweepDirection = Flag ? SweepDirection.Clockwise : SweepDirection.Counterclockwise;
				OnPropertyChanged("flag");
			}
		}

		public void OnPropertyChanged(string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}

	}
}
