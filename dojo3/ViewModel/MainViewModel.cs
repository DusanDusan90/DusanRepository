using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using System.Windows.Controls;
using Stanojevic_dojo3.View;

namespace Stanojevic_dojo3.ViewModel
{
    public class MainViewModel : BaseViewModel
    {

        public Array Currencies
        {
            get { return Enum.GetValues(typeof(CodingDojo4DataLib.Converter.Currencies)); }
        }

        public Currencies SelectedCurrency
        {
            get { return selectedCurrency; }
            set
            {
                selectedCurrency = value;
                OnChange("SelectedCurrency");
                this.DoCalculation();
            }
        }

        private void DoCalculation()
        {
            foreach (var item in Items)
            {
                item.CalculateSalesPriceFromEuro(SelectedCurrency);
            }
        }



        //viewmodel!
        private ObservableCollection<StockEntryViewModel> items = new ObservableCollection<StockEntryViewModel>();
        private CodingDojo4DataLib.Converter.Currencies selectedCurrency;

        //viewModel!
        public ObservableCollection<StockEntryViewModel> Items
        {
            get { return items; }
            set { items = value; }
        }


        public MainViewModel()
        {
            SampleManager manager = new SampleManager(); //Model stuff !

            foreach (var item in manager.CurrentStock.OnStock)
            {
                Items.Add(new StockEntryViewModel(item)); //viewmodel stuff!
            }
        }
        

    }
}
