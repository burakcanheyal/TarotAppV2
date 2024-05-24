using Business.Models;
using DataAccess.Results;
using DataAccess.Results.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Business.Services.Bases;

namespace Business;

/// <summary>
/// Performs user CRUD operations.
/// </summary>
public interface IUserService
{
    // method definitions: method definitions must be created here in order to be used in the related controller

    /// <summary>
    /// Queries the records in the Users table.
    /// </summary>
    /// <returns></returns>
    IQueryable<UserModel> Query();

    Result Add(UserModel model);
    Result Update(UserModel model);

    Result DeleteUser(int id);
}

public class UserService : ServiceBase, IUserService // UserService is a IUserService (UserService implements IUserService)
{
    #region Db Constructor Injection


    public UserService(Db db) : base(db)
    {
    }
    #endregion



    public IQueryable<UserModel> Query()
    {
        return _db.Users.Include(e => e.Role).OrderByDescending(e => e.IsActive)
            .ThenBy(e => e.UserName)
            .Select(e => new UserModel()
            {
                
                Id = e.Id,
                IsActive = e.IsActive,
                Password = e.Password,
                RoleId = e.RoleId,
                Status = e.Status,
                UserName = e.UserName,

               
                IsActiveOutput = e.IsActive ? "Yes" : "No",
                RoleNameOutput = e.Role.Name,
                PasswordOutput = new string('*', e.Password.Length)
            });
    }

    public Result Add(UserModel model)
    {
        List<User> existingUsers = _db.Users.ToList();
        if (existingUsers.Any(u => u.UserName.Equals(model.UserName.Trim(), StringComparison.OrdinalIgnoreCase)))
            return new ErrorResult("User with the same user name already exists!");

        User userEntity = new User()
        {
            IsActive = model.IsActive,
            UserName = model.UserName.Trim(),
            Password = model.Password.Trim(),
            RoleId = model.RoleId ?? 0,

            Status = model.Status
        };

        _db.Users.Add(userEntity);

        _db.SaveChanges();

        return new SuccessResult("User added successfully.");
    }

    public Result Update(UserModel model)
    {
        var existingUsers = _db.Users.Where(u => u.Id != model.Id).ToList();
        if (existingUsers.Any(u => u.UserName.Equals(model.UserName.Trim(), StringComparison.OrdinalIgnoreCase)))
            return new ErrorResult("User with the same user name already exists!");

        var userEntity = _db.Users.SingleOrDefault(u => u.Id == model.Id);

        if (userEntity is null)
            return new ErrorResult("User not found!");

        userEntity.IsActive = model.IsActive;
        userEntity.UserName = model.UserName.Trim();
        userEntity.Password = model.Password.Trim();
        userEntity.RoleId = model.RoleId ?? 0;
        userEntity.Status = model.Status;

        _db.Users.Update(userEntity);

        _db.SaveChanges();

        return new SuccessResult("User updated successfully.");
    }


    public Result DeleteUser(int id)
    {
        var userEntity = _db.Users.Include(u => u.UserReadings).SingleOrDefault(u => u.Id == id);
        if (userEntity is null)
            return new ErrorResult("User not found!");

        _db.UserReading.RemoveRange(userEntity.UserReadings);

        _db.Users.Remove(userEntity);

        _db.SaveChanges();

        return new SuccessResult("User deleted successfully.");
    }
}