using System.Threading.Tasks;

namespace Learn.Core.Views.Login
{
    public interface ILoginService
    {
        Task<bool> LoginAsync(string userName, string password);
    }
}