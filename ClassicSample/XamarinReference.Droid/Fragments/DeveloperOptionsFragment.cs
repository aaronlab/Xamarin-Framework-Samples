
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
using System.Threading;
using System.IO;
using Java.IO;

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
			//make sure the logging option supports deleting files
			if (_logging is ILoggingFile)
			{
				AlertDialog.Builder alert = new AlertDialog.Builder (this.Activity);
				alert.SetTitle (_localizeLookupService.GetLocalizedString("Confirm"));
				alert.SetMessage (_localizeLookupService.GetLocalizedString("DeleteFileMessage"));
				alert.SetPositiveButton (_localizeLookupService.GetLocalizedString("Delete"), (senderAlert, args) => {
					((ILoggingFile)_logging).DeleteLog();
				});

				alert.SetNegativeButton (_localizeLookupService.GetLocalizedString("Cancel"), (senderAlert, args) => {});

				Dialog dialog = alert.Create();
				dialog.Show();

			}
		}

		void ShareButtonClicked (object sender, EventArgs e)
		{
			if (_logging is ILoggingFile) {
				//get the file path of the log file to share
				var path = ((ILoggingFile)_logging).LoggingPath;
				var file = new Java.IO.File (path);
				var uri =  Android.Net.Uri.FromFile (file);

				var shareIntent = new Intent (Intent.ActionSend);
				shareIntent.SetType ("text/plain");
				shareIntent.PutExtra (Intent.ExtraStream, uri);
				StartActivity (Intent.CreateChooser (shareIntent, "Share page to..."));
			}
		}

		void ViewButtonClicked (object sender, EventArgs e)
		{
			//TODO:  show modal popup with the log file contents
		}
	}
}

