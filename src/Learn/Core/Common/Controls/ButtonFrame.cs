using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Learn.Core.Common.Controls
{
    public class ButtonFrame : Frame
    {
        public ButtonFrame()
        {
            HasShadow = true;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ContentProperty.PropertyName)
            {
                ContentUpdated();
            }
        }

        private void ContentUpdated()
        {
            BackgroundColor = Content.BackgroundColor;
        }
    }
}
