
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using XamarinReference.Lib.Interface;
using XamarinReference.Droid.Fragments.Base;

namespace XamarinReference.Droid
{
	public class DeveloperOptionsFragment : BaseFragment
	{

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.DeveloperOptionsFragmentLayout, container, false);

			var viewButton = view.FindViewById<Button>(Resource.Id.buttonViewLogFile);
			viewButton.Click += ViewButtonClicked;

			var shareButton = view.FindViewById<Button>(Resource.Id.buttonShareLogFile);
			shareButton.Click += ShareButtonClicked;

			var deleteButton = view.FindViewById<Button>(Resource.Id.buttonDeleteLogFile);
			deleteButton.Click += DeleteButtonClicked;
			return view;
		}

		void DeleteButtonClicked (object sender, EventArgs e)
		{
//			//make sure the logging option supports deleting files
//			if (_logging is ILoggingFile)
//			{
//				//confirm via UIAlert to delete
//				var isDelete = await Helper.Utility.ShowAlert(_localizeLookupService.GetLocalizedString("Confirm"), _localizeLookupService.GetLocalizedString("DeleteFileMessage"), _localizeLookupService.GetLocalizedString("Delete"), _localizeLookupService.GetLocalizedString("Cancel"));
//				if (isDelete)
//				{
//					//delete the file 
//					((ILoggingFile)_logging).DeleteLog();
//
//				}
//			}
		}

		void ShareButtonClicked (object sender, EventArgs e)
		{
		}

		void ViewButtonClicked (object sender, EventArgs e)
		{
			
		}
	}
}

