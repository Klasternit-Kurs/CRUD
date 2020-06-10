using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUD
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ObservableCollection<Artikal> listaArt = new ObservableCollection<Artikal>();

		public MainWindow()
		{
			InitializeComponent();

			dg.ItemsSource = listaArt;

		}

		private void Dodavanje(object sender, RoutedEventArgs e)
		{
			Editor ee = new Editor();
			ee.Owner = this;

			if (ee.ShowDialog() == true) 
			{
				listaArt.Add(ee.DataContext as Artikal);
			}
		}
	}
}
