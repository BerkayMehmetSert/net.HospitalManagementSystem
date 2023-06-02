using Application.Contacts.Requests.Users;
using Application.Contacts.Responses.Users;

namespace Application.Contacts.Services;

public interface IUserService
{
    void Register(RegisterUserRequest request);
    void DeleteUser(Guid id);
    UserResponse GetUserById(Guid id);
    List<UserResponse> GetAllUsers();
}