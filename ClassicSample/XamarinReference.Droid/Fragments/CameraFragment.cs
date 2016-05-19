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

using XamarinReference.Droid.Fragments.Base;
using Java.IO;
using Android.Provider;
using Android.Content.PM;
using Android.Graphics;

namespace XamarinReference.Droid.Fragments
{
	public class CameraFragment : BaseFragment
	{
		File _dir, _file;
		Bitmap _bitmap;
		ImageView _picture;
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.CameraFragmentLayout, container, false);
			_picture = view.FindViewById<ImageView>(Resource.Id.imageViewPicture);
			SetHasOptionsMenu (true);
			return view;
		}

		public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
		{
			inflater.Inflate(Resource.Menu.CameraMenu, menu);
			menu.GetItem (0).SetShowAsAction (ShowAsAction.Always);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			//camera was clicked
			if (IsThereAnAppToTakePictures ()) {
				CreateDirectoryForPictures ();
				TakeAPicture ();
			} else {
				AlertDialog.Builder alert = new AlertDialog.Builder (this.Activity);
				alert.SetTitle (_localizeLookupService.GetLocalizedString("Confirm"));
				alert.SetMessage (_localizeLookupService.GetLocalizedString("DeleteFileMessage"));
				alert.SetNegativeButton ("OK", (senderAlert, args) => {});

				Dialog dialog = alert.Create();
				dialog.Show();
			}
			return true;
		}

		private void CreateDirectoryForPictures ()
		{
			_dir = new File (
				Android.OS.Environment.GetExternalStoragePublicDirectory (
					Android.OS.Environment.DirectoryPictures), "CameraAppDemo");
			if (!_dir.Exists ())
			{
				_dir.Mkdirs( );
			}
		}

		private bool IsThereAnAppToTakePictures ()
		{
			Intent intent = new Intent (MediaStore.ActionImageCapture);
			IList<ResolveInfo> availableActivities =
				Activity.PackageManager.QueryIntentActivities (intent, PackageInfoFlags.MatchDefaultOnly);
			return availableActivities != null && availableActivities.Count > 0;
		}
		private void TakeAPicture ()
		{
			Intent intent = new Intent (MediaStore.ActionImageCapture);
			_file = new File (_dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
			intent.PutExtra (MediaStore.ExtraOutput, Android.Net.Uri.FromFile (_file));
			StartActivityForResult (intent, 0);
		}
		public override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			// Make it available in the gallery

			Intent mediaScanIntent = new Intent (Intent.ActionMediaScannerScanFile);
			var contentUri = Android.Net.Uri.FromFile (_file);
			mediaScanIntent.SetData (contentUri);
			Activity.SendBroadcast (mediaScanIntent);

			// Display in ImageView. We will resize the bitmap to fit the display.
			// Loading the full sized image will consume to much memory
			// and cause the application to crash.

			int height = Resources.DisplayMetrics.HeightPixels;
			int width = _picture.Height ;
			var bitmap = LoadAndResizeBitmap (_file.Path,width, height);
			if (bitmap != null) {
				_picture.SetImageBitmap (bitmap);
				bitmap = null;
			}

			// Dispose of the Java side bitmap.
			GC.Collect();
		}

		private  Bitmap LoadAndResizeBitmap (string fileName, int width, int height)
		{
			// First we get the the dimensions of the file on disk
			BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
			BitmapFactory.DecodeFile (fileName, options);

			// Next we calculate the ratio that we need to resize the image by
			// in order to fit the requested dimensions.
			int outHeight = options.OutHeight;
			int outWidth = options.OutWidth;
			int inSampleSize = 1;

			if (outHeight > height || outWidth > width)
			{
				inSampleSize = outWidth > outHeight
					? outHeight / height
					: outWidth / width;
			}

			// Now we will load the image and have BitmapFactory resize it for us.
			options.InSampleSize = inSampleSize;
			options.InJustDecodeBounds = false;
			Bitmap resizedBitmap = BitmapFactory.DecodeFile (fileName, options);

			return resizedBitmap;
		}
	}
}