using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace KnowAboutMedicine.Droid
{
    [Activity(Label = "KnowAboutMedicine", Icon = "@mipmap/icon1", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            FileAccessHelper.GetLocalFilePath();
            LoadApplication(new App());
        }

    }

    public class FileAccessHelper
    {
        public static void GetLocalFilePath()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            if(!System.IO.File.Exists(path + "/Config.xml"))
            {
                using (var br = new System.IO.BinaryReader(Application.Context.Assets.Open("Config.xml")))
                {
                    using (var bw = new System.IO.BinaryWriter(new System.IO.FileStream(path + "/Config.xml", System.IO.FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, length);
                        }
                    }
                }
            }
            string dbPath = System.IO.Path.Combine(path, "Data");
            if (!System.IO.Directory.Exists(dbPath))
            {
                System.IO.Directory.CreateDirectory(dbPath);
                string[] arr = Application.Context.Assets.List("Data");
                for (int i = 0; i < arr.Length; i++)
                {
                    using (var br = new System.IO.BinaryReader(Application.Context.Assets.Open("Data/" + arr[i])))
                    {
                        using (var bw = new System.IO.BinaryWriter(new System.IO.FileStream(dbPath + "/" + arr[i], System.IO.FileMode.Create)))
                        {
                            byte[] buffer = new byte[2048];
                            int length = 0;
                            while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                bw.Write(buffer, 0, length);
                            }
                        }
                    }
                }
            }
        }
    }

}