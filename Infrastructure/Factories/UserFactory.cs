

using Infrastructure.Entities;
using Infrastructure.Models;
using System.Diagnostics;

namespace Infrastructure.Factories;

public class UserFactory
{
    public static UserEntity Create()
    {
        try
        {
            var date = DateTime.Now;
            return new UserEntity()

            {
                Id = Guid.NewGuid().ToString(),
                Created = date,
                Modified = date
            };
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public static UserEntity Create(SignUpModel model)
    {
        try
        {
            var date = DateTime.Now;
            

            return new UserEntity
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PasswordHash = model.Password,                
                Created = date,
                Modified = date
            };
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }
}
