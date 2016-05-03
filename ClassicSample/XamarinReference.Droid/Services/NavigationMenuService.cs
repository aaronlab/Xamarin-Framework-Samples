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

using Cirrious.CrossCore;

using XamarinReference.Lib.Interface;
using XamarinReference.Lib.Model;
using XamarinReference.Droid.Activities;
using XamarinReference.Droid.Fragments;


namespace XamarinReference.Droid.Services
{
    public class NavigationMenuService : INavigationMenuService<Fragment>
    {
        private readonly IStringLookupService _localizedStrings = Mvx.Resolve<IStringLookupService>();

        public IList<NavigationMenuItem<Fragment>> MenuItems { get; set; }

        public NavigationMenuService ()
        {
            this.MenuItems = new List<NavigationMenuItem<Fragment>>
            {
				new NavigationMenuItem<Fragment>
				{
					IsEnabled =  true,
					Manager = new BusinessCardFragment(),
					Title = _localizedStrings.GetLocalizedString("BusinessCardTitle")
				},
				new NavigationMenuItem<Fragment>
				{
					IsEnabled =  true,
					Manager = new TabNavFragment(),
					Title = _localizedStrings.GetLocalizedString("TabNavigationTitle")
				},
				new NavigationMenuItem<Fragment>
				{
					IsEnabled =  true,
					Manager = new StickyHeaderFragment(),
					Title = _localizedStrings.GetLocalizedString("StickyHeaderTitle")
				},
				new NavigationMenuItem<Fragment>
				{
					IsEnabled =  true,
					Manager = new CameraFragment(),
					Title = _localizedStrings.GetLocalizedString("Camera")
				},
				new NavigationMenuItem<Fragment>
				{
					IsEnabled =  true,
					Manager = new GeolocationFragment(),
					Title = _localizedStrings.GetLocalizedString("Geolocation")
				},
				new NavigationMenuItem<Fragment>
				{
					IsEnabled =  true,
					Manager = new NetworkConnectivityFragment(),
					Title = _localizedStrings.GetLocalizedString("NetworkConnectivityTitle")
				},
				new NavigationMenuItem<Fragment>
				{
					IsEnabled =  true,
					Manager = new PdfStitchingFragment(),
					Title = _localizedStrings.GetLocalizedString("PdfStitching")
				},
				new NavigationMenuItem<Fragment>
				{
					IsEnabled =  true,
					Manager = new PingFragment(),
					Title = _localizedStrings.GetLocalizedString("Ping")
				},

				new NavigationMenuItem<Fragment>
				{
					IsEnabled =  true,
					Manager = new AboutFragment(), 
					Title = _localizedStrings.GetLocalizedString("About") 
				},
				new NavigationMenuItem<Fragment>
				{
					IsEnabled =  true,
					Manager = new ThemeColorFragment(), 
					Title = _localizedStrings.GetLocalizedString("ThemeColors") 
				},
				new NavigationMenuItem<Fragment>
				{
					IsEnabled =  true,
					Manager = new ThemeFontFragment(), 
					Title = _localizedStrings.GetLocalizedString("ThemeFonts") 
				},
				new NavigationMenuItem<Fragment>
				{
					IsEnabled =  true,
					Manager = new FontFragment(),
					Title = _localizedStrings.GetLocalizedString("FontsLoaded") 
				},
            };
        }

        public IList<NavigationMenuItem<Fragment>> GetMenuItemsEnabled()
        {
            return MenuItems.Where(x => x.IsEnabled).ToList();
        }
    }
}