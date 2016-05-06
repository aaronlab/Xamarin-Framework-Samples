using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinReference.Lib.Interface;
using Cirrious.CrossCore;

namespace XamarinReference.Droid.Activities.Base
{
    public abstract class BaseActivity : Activity
    {
		//used to look up logging based on how the app has logging setup 
		protected readonly ILoggingService _logging = Mvx.Resolve<ILoggingService>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }
    }
}