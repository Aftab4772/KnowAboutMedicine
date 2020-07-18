using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KnowAboutMedicine
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            appLogo.Source = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("MainIcon230.png")
                : ImageSource.FromFile("Images/MainIcon230.png");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var backingFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Config.xml");
            List <System.Xml.Linq.XElement> xEleList = System.Xml.Linq.XElement.Load(backingFile).Descendants("Settings").ToList();
            if (Convert.ToBoolean(xEleList[0].Element("DoNotShowAgain").Value))
                Application.Current.MainPage = new NavigationPage(new MainSearchWindow());
            else
                Application.Current.MainPage = new NavigationPage(new ImpInstructions());
        }


    }
}
