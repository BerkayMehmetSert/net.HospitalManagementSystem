using Application.Contacts.Repositories;
using Application.Contacts.Requests.Users;
using Application.Contacts.Responses.Users;
using Application.Contacts.Services;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Exceptions.Types;
using Infrastructure.Notifications;
using Infrastructure.Utilities.Security;
using static Application.Contacts.Messages.Auth.BusinessMessages;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly INotificationService _notificationService;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper, INotificationService notificationService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _notificationService = notificationService;
    }

    public void Register(RegisterUserRequest request)
    {
        HashingHelper.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);

        var user = _mapper.Map<User>(request);
        user.Role = "User";
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        _unitOfWork.UserRepository.Create(user);
        _unitOfWork.SaveChanges();

        _notificationService.SendNotification($"Welcome {user.FirstName} {user.LastName} to our hospital!");
    }

    public void DeleteUser(Guid id)
    {
        var user = GetUser(id);

        _unitOfWork.UserRepository.Delete(user);
        _unitOfWork.SaveChanges();
    }

    public UserResponse GetUserById(Guid id)
    {
        var user = GetUser(id);

        return _mapper.Map<UserResponse>(user);
    }

    public List<UserResponse> GetAllUsers()
    {
        var users = _unitOfWork.UserRepository.GetAll();

        return users is not null
            ? _mapper.Map<List<UserResponse>>(users)
            : throw new NotFoundException(UserListIsEmpty);
    }

    private User GetUser(Guid id)
    {
        var user = _unitOfWork.UserRepository.Get(x => x.Id.Equals(id));

        return user ?? throw new NotFoundException(UserNotFound);
    }
}