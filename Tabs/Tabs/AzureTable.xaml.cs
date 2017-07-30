using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabs.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AzureTable : ContentPage
    {
        Geocoder geoCoder;
        MobileServiceClient client = AzureManager.AzureManagerInstance.AzureClient;


        public AzureTable()
        {
            InitializeComponent();
            geoCoder = new Geocoder();
        }

        async void Handle_ClickedAsync(object sender, System.EventArgs e)
        {
            List<IsChickenModel> isChickenInformation = await AzureManager.AzureManagerInstance.GetChickenInformation();

            foreach (IsChickenModel model in isChickenInformation)
            {
                var position = new Position(model.Latitude, model.Longitude);
                var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                foreach (var address in possibleAddresses)
                    model.City = address;
            }

            ChickenList.ItemsSource = isChickenInformation;

        }
    }

}
