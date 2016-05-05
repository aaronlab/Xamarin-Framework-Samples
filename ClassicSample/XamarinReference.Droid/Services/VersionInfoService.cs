using System;
using XamarinReference.Lib.Interface;
using Android.Content;
using System.Diagnostics;

namespace XamarinReference.Droid
{
	public class VersionInfoService : IVersionInfo
	{
		private DateTime _ApplicationBuildTime;

		public DateTime ApplicationBuildTime
		{
			get { return _ApplicationBuildTime; }
		}

		private string _ApplicationVersion;

		public string ApplicationVersion
		{
			get { return _ApplicationVersion; }
		}

		private string _OperatingSystemVersion;

		public string OperatingSystemVersion
		{
			get { return _OperatingSystemVersion; }
		}

		public VersionInfoService(Context applicationContext)
		{
			try
			{
				var  version = applicationContext.PackageManager.GetPackageInfo(applicationContext.PackageName, 0);
				var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
				_ApplicationBuildTime = epoch.AddMilliseconds(version.LastUpdateTime).ToLocalTime();

				_OperatingSystemVersion = Android.OS.Build.VERSION.Release;
				_ApplicationVersion = version.VersionName;
			}

			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}
		}
	}
}

