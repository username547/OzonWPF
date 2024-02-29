using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozon.Model.Data
{
    public class UserDataManager
    {
        public static List<UserModel> GetAllUsers()
        {
            using ApplicationDbContext context = new();
            return context.Users.ToList();
        }

        public static bool CreateUser(string userName, string userSurname, string userEmail, string userPassword)
        {
            using ApplicationDbContext context = new();
            var tempUser = context.Users.FirstOrDefault(x => x.UserEmail == userEmail);
            if (tempUser != null) return false;

            UserModel newUser = new UserModel
            {
                UserName = userName,
                UserSurname = userSurname,
                UserEmail = userEmail,
                UserPassword = userPassword,
                RoleId = 4
            };

            context.Add(newUser);
            context.SaveChanges();

            return true;
        }

        public static bool UpdateUser(UserModel user, string userName, string userSurname, string userEmail, string userPassword)
        {
            using ApplicationDbContext context = new();
            var tempUser = context.Users.FirstOrDefault(x => x.UserEmail == user.UserEmail);
            if (tempUser == null) return false;

            tempUser.UserName = userName;
            tempUser.UserSurname = userSurname;
            tempUser.UserEmail = userEmail;
            tempUser.UserPassword = userPassword;

            return true;
        }

        public static void DeleteUser(UserModel user)
        {
            using ApplicationDbContext context = new();
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
}
