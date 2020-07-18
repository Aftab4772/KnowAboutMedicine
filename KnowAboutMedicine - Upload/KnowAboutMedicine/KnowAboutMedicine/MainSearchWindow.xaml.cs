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
	public partial class MainSearchWindow : ContentPage
	{

        public MainSearchWindow ()
		{
			InitializeComponent ();
            LoadData();
        }

        private void LoadData()
        {
            var backingFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Data", "medicineList.xml");
            System.Xml.Linq.XElement xEle = System.Xml.Linq.XElement.Load(backingFile);
            string[] dataFetch = xEle.Descendants("Medicine").OrderBy(x => Convert.ToString(x.Element("Name").Value)).Select(x => Convert.ToString(x.Element("Name").Value)).ToArray();
            fillButton(dataFetch);
        }

        private void fillButton(string[] data)
        {
            scrlGrid.RowDefinitions.Clear();
            scrlGrid.Children.Clear();
            for (int i = 0; i < data.Count(); i++)
            {
                scrlGrid.RowDefinitions.Add(new RowDefinition
                {
                    Height = 60
                });

                Button btn = new Button
                {
                    Text = data[i],
                    FontAttributes = FontAttributes.Bold

                };
                btn.Clicked += Button_Clicked;
                scrlGrid.Children.Add(btn);

                Grid.SetRow(btn, i);
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MedicineDetails(((Button)sender).Text));
        }

        private void Enter_Medicine_TextChanged(object sender, TextChangedEventArgs e)
        {
            var backingFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Data", "medicineList.xml");
            System.Xml.Linq.XElement xEle = System.Xml.Linq.XElement.Load(backingFile);
            string[] dataFetch = xEle.Descendants("Medicine").Where(x => Convert.ToString(x.Element("Name").Value).ToLower().Contains(Enter_Medicine.Text.ToLower())).OrderBy(x => Convert.ToString(x.Element("Name").Value)).Select(x => Convert.ToString(x.Element("Name").Value)).ToArray();
            fillButton(dataFetch);
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new About());
        }
    }
}