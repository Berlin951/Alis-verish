using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp16.Command;
using WpfApp16.Model;

namespace WpfApp16.ViewModel
{

    public class ProductViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> buyedProducts;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Product> BuyedProducts { get => buyedProducts; set { buyedProducts = value; OnPropertyChanged(); } }
        public ICommand BuyCommand { get; set; }
        public ProductViewModel()
        {
            Products = new ObservableCollection<Product>
            {
            new Product{Photo="/iphone.png", Name="Iphone 11 PRO" , Price="2199 Azn"  },
            new Product{Photo="/ps.png",Name="Plasytation 4",Price="644 Azn"},
            new Product{Photo="/Msi.png",Name="Msi 230",Price="2600 Azn"},
            new Product{Photo="/mi8.png",Name="Xiaomi Mi8 Lite",Price="599 Azn"},
            new Product{Photo="/usb_.png",Name="Usb 3",Price="14.99 Azn"},
            new Product{Photo="/modem.png",Name="Modem",Price="55 Azn"},
            new Product{Photo="/flash.png",Name="FlashCard 2GB",Price="12 Azn"},
            new Product{Photo="/camera.png",Name="Nikon D300",Price="455 Azn"},
            new Product{Photo="/ssd.png",Name="SSD 128GB",Price="45 Azn"}
            };
            BuyedProducts = new ObservableCollection<Product>
            {
                 // new Product{Photo="/iphone.png", Name="Iphone 11 PRO" , Price="2199 Azn"  }
            };
            BuyCommand = new RelayCommand(BuyCommandExecute);
        }
        public void BuyCommandExecute(object param)
        {
            Product obj = param as Product;
            BuyedProducts.Add(obj);
        }

    }
}
