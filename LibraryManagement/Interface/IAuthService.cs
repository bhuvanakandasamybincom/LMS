using LibraryManagement.Model;

namespace LibraryManagement.Interface
{
    public interface IAuthService
    {
        Task<(int, string)> Registeration(RegistrationUser model, string role);
        Task<(int, string)> Login(Login model);
    }
}
