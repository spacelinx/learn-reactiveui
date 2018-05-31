using Xamarin.Forms;

namespace Learn.Core.Common.Helpers
{
    public class StatusBarHelper
    {
        private static readonly StatusBarHelper _instance = new StatusBarHelper();
        public const string TranslucentStatusChangeMessage = "TranslucentStatusChange";

        public static StatusBarHelper Instance => _instance;

        protected StatusBarHelper()
        {
        }

        public void MakeTranslucentStatusBar(bool translucent)
        {
            MessagingCenter.Send(this, TranslucentStatusChangeMessage, translucent);
        }
    }
}
