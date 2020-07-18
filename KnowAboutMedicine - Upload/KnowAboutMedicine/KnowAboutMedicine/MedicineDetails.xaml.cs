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
	public partial class MedicineDetails : ContentPage
	{
		public MedicineDetails (string medName)
		{
			InitializeComponent ();
            var backingFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Data", medName + ".xml");
            if (!System.IO.File.Exists(backingFile))
                return;
            List<System.Xml.Linq.XElement> xEleList = System.Xml.Linq.XElement.Load(backingFile).Descendants("Medicine").ToList();
            if (xEleList.Count == 0)
                return;
            lblMedName.Text = medName;
            imgMed.Source = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile(medName + ".jpg")
                : ImageSource.FromFile("Images/" + medName + ".jpg");
            lblMedDetails.Text = xEleList[0].Element("Details").Value;
            lblMedInfoHead.Text = xEleList[0].Element("InfoHeader").Value;
            lblMedInfo.Text = xEleList[0].Element("Info").Value;
            lblMedIntakeInfoHead.Text = xEleList[0].Element("IntakeInfoHeader").Value;
            lblMedIntakeInfo.Text = xEleList[0].Element("IntakeInfo").Value;
            lblMedWarningHead.Text = xEleList[0].Element("WarningHeader").Value;
            lblMedWarning.Text = xEleList[0].Element("Warning").Value;
        }
    }
}