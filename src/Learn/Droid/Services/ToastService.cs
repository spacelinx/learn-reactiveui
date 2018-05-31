using System;
using Android.App;
using Android.Widget;
using Learn.Core.Services.NativeInterfaces;

namespace Learn.Droid.Services
{
    public class ToastService : IToastService
    {
        public void DisplayText(string text, CommonToastLength toastLength)
        {
            var context = Application.Context;

            Enum.TryParse(toastLength.ToString(), out ToastLength androidToastLength);
            Toast.MakeText(context, text, androidToastLength).Show();
        }
    }
}