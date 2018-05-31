namespace Learn.Core.Services.NativeInterfaces
{
    public interface IToastService
    {
        void DisplayText(string text, CommonToastLength toastLength);

    }

    public enum CommonToastLength
    {
        Short,
        Long
    }
}