using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sharity
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private async void Donate_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Important!!!", "App Development is progress.", "Ok");
        }

        private async void Recive_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Important!!!", "App Development is progress.", "Ok");
        }
    }
}
