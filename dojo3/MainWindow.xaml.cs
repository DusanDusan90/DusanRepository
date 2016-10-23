using Stanojevic_dojo3.ViewModel;
using System;
using System.Collections.Generic;
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

namespace Stanojevic_dojo3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Choose an item to delete", "Delete an item", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this item?", "Delete an item", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    viewModel.Items.Remove((StockEntryViewModel)myDataGrid.SelectedItem);
                }
            }

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            StockItemWindow w = new StockItemWindow();
            w.ShowDialog();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Choose an item to edit", "Edit an item", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                StockItemWindow w = new StockItemWindow();
                w.ItemToEdit = (StockEntryViewModel)myDataGrid.SelectedItem;
                w.InitEditForm();
                w.ShowDialog();
            }
        }
    }
}
