using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KnowAboutMedicine
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImpInstructions : ContentPage
	{
		public ImpInstructions ()
		{
			InitializeComponent ();
		}

        private void SwtchIHaveRead_Toggled(object sender, ToggledEventArgs e)
        {
            if(swtchIHaveRead.IsToggled)
                btnNext.IsEnabled = true;
            else
                btnNext.IsEnabled = false;
        }

        private void BtnNext_Clicked(object sender, EventArgs e)
        {
            var backingFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Config.xml");
            System.Xml.Linq.XElement xEleList = System.Xml.Linq.XElement.Load(backingFile);
            if (swtchDoNotShowAgain.IsToggled)
            {
                xEleList.Descendants("DoNotShowAgain").First().Value = "true";
                xEleList.Save(backingFile);
            }
            Application.Current.MainPage = new NavigationPage(new MainSearchWindow());
        }
    }
}