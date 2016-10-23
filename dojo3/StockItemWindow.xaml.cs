using CodingDojo4DataLib;
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
using System.Windows.Shapes;

namespace Stanojevic_dojo3
{
    /// <summary>
    /// Interaction logic for StockItem.xaml
    /// </summary>
    public partial class StockItemWindow : Window
    {
        public StockEntryViewModel ItemToEdit { get; set; }
        public List<Group> Groups { get; set; }

        private Group selectedGroup;

        public Group SelectedGroup {
            get
            {
                if (selectedGroup != null)
                {
                    return selectedGroup;
                }
                else
                {
                    if (ItemToEdit != null)
                    {
                        foreach (Group group in Groups)
                        {
                            if (group.Name.Equals(ItemToEdit.Category))
                            {
                                return group;
                            }
                        }
                    }
                    return null;
                }
            }
            set { this.selectedGroup = value; }
        }

        public StockItemWindow()
        {
            SampleManager manager = new SampleManager();
            Groups = manager.AvailableGroups;

            InitializeComponent();
            this.DataContext = this;
        }

        public void InitEditForm()
        {
            tbAmount.Text = ItemToEdit.OnStock.ToString();
            tbName.Text = ItemToEdit.Name;
            tbPurchasePrice.Text = ItemToEdit.PurchasePrice.ToString();
            tbSalesPrice.Text = ItemToEdit.SalesPrice.ToString();

            
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ItemToEdit == null)
            {
                //new element mode
                StockEntry item = new StockEntry();
                item.Amount = Convert.ToInt32(tbAmount.Text);

                Software package = new Software(tbName.Text);
                package.PurchasePrice = Convert.ToDouble(tbPurchasePrice.Text);
                package.SalesPrice = Convert.ToDouble(tbSalesPrice.Text);
                package.Category = (Group)cbGorup.SelectedItem;

                item.SoftwarePackage = package;

                StockEntryViewModel model = new StockEntryViewModel(item);

                ((MainWindow)Application.Current.MainWindow).viewModel.Items.Add(model);
            }
            else
            {
                //edit item mode
                ItemToEdit.OnStock = Convert.ToInt32(tbAmount.Text);
                ItemToEdit.Name = tbName.Text;
                ItemToEdit.PurchasePrice = Convert.ToDouble(tbPurchasePrice.Text);
                ItemToEdit.SalesPrice = Convert.ToDouble(tbSalesPrice.Text);
                ItemToEdit.Category = ((Group)cbGorup.SelectedItem).Name;
                ((MainWindow)Application.Current.MainWindow).myDataGrid.Items.Refresh();
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
