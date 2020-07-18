﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KnowAboutMedicine
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class About : ContentPage
	{
		public About ()
		{
			InitializeComponent ();
            appLogo.Source = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("MainIcon230.png")
                : ImageSource.FromFile("Images/MainIcon230.png");

        }
	}
}