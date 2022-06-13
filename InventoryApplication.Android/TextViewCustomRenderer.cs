using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using InventoryApplication.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(TextViewCustomRenderer))]
namespace InventoryApplication.Droid
{
    [Obsolete]
    public class TextViewCustomRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = Android.App.Application.Context.GetDrawable(Resource.Drawable.RoundCornerbutton);
                Control.Gravity = GravityFlags.CenterVertical;
                Control.SetPadding(50, 0, 20, 0);
            }
        }
    }
}