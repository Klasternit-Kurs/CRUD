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
		//ObservableCollection<Artikal> listaArt = new ObservableCollection<Artikal>();
		EF baza = new EF();

		private string _pretraga;
		public string Pretraga 
		{ 
			get => _pretraga; 
			set
			{
				_pretraga = value;

				if (string.IsNullOrWhiteSpace(_pretraga))
				{
					dg.ItemsSource = baza.Artikals.ToList();
				}
				else
				{
					dg.ItemsSource =
						baza.Artikals.Where(a => a.Naziv.Contains(_pretraga.Trim())).ToList();
				}
			} 
		}

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
			dg.ItemsSource = baza.Artikals.ToList();
		}

		private void Dodavanje(object sender, RoutedEventArgs e)
		{
			Editor ee = new Editor();
			ee.Owner = this;

			if (ee.ShowDialog() == true) 
			{
				baza.Artikals.Add(ee.DataContext as Artikal);
				baza.SaveChanges();
				dg.ItemsSource = baza.Artikals.ToList(); 
			}
		}

		private void Izmena(object sender, RoutedEventArgs e)
		{
			//TODO Commanding 
			if (dg.SelectedItem != null)
			{
				Editor ed = new Editor();
				ed.Owner = this;
				ed.DataContext = dg.SelectedItem;
				ed.ShowDialog();
				baza.SaveChanges();
			}
		}

		private void Brisanje(object sender, RoutedEventArgs e)
		{
			if (dg.SelectedItem != null)
			{
				baza.Artikals.Remove(dg.SelectedItem as Artikal);
				baza.SaveChanges();
				dg.ItemsSource = baza.Artikals.ToList();
			}
		}
	}
}
