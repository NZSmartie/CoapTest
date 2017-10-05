﻿using Android.App;
using Android.Content.PM;
using Android.Widget;
using Android.OS;

namespace OICExplorer.Droid
{
    [Activity(Label = "OIC Explorer", Icon = "@drawable/icon", Theme = "@style/AppTheme")]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new OICExplorer.App());
        }
    }
}

