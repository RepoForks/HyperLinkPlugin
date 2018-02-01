﻿using System.Linq;
using HyperLink.FormsPlugin.Droid;
using HyperLink.FormsPlugin.Abstractions;
using Android.Text.Util;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Android.Util;

[assembly: ExportRenderer(typeof(HyperLinkControl), typeof(HyperLinkRenderer))]

namespace HyperLink.FormsPlugin.Droid
{
    public class HyperLinkRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var view = (HyperLinkControl)Element;
            if (view == null) return;

            TextView textView = new TextView(Forms.Context);
            textView.LayoutParameters = new LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
            textView.SetTextColor(view.TextColor.ToAndroid());
            textView.AutoLinkMask = MatchOptions.All;
            textView.Text = view.Text;
            textView.SetTextSize(ComplexUnitType.Dip, (float)view.FontSize);
            
            SetNativeControl(textView);

        }
    }
}