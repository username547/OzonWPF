using Ozon.Data;
using Ozon.Model;

namespace Ozon.DataManage
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
            int? roleId = GetRoleId("User");

            if (tempUser != null || roleId == null) return false;

            UserModel newUser = new UserModel
            {
                UserName = userName,
                UserSurname = userSurname,
                UserEmail = userEmail,
                UserPassword = userPassword,
                RoleId = (int)roleId
            };

            context.Add(newUser);
            context.SaveChanges();

            return true;
        }

        public static bool UpdateUser(int userId, string userName, string userSurname, string userEmail, string userPassword)
        {
            using ApplicationDbContext context = new();
            var user = context.Users.FirstOrDefault(x => x.UserId == userId);

            if (user == null) return false;

            user.UserName = userName;
            user.UserSurname = userSurname;
            user.UserEmail = userEmail;
            user.UserPassword = userPassword;

            context.SaveChanges();

            return true;
        }

        public static bool DeleteUser(int userId)
        {
            using ApplicationDbContext context = new();
            var user = context.Users.FirstOrDefault(x => x.UserId == userId);
            if (user == null) return false;

            context.Users.Remove(user);
            context.SaveChanges();

            return true;
        }

        public static int? GetRoleId(string roleName)
        {
            using ApplicationDbContext context = new();
            var role = context.Roles.FirstOrDefault(x => x.RoleName == roleName);
            if (role == null) return null;
            return role.RoleId;
        }

        public static string? GetRoleName(int roleId)
        {
            using ApplicationDbContext context = new();
            var role = context.Roles.FirstOrDefault(x => x.RoleId == roleId);
            if (role == null) return null;
            return role.RoleName;
        }

        public static bool ComparePassword(string userEmail, string userPassword)
        {
            using ApplicationDbContext context = new();
            var user = context.Users.FirstOrDefault(x =>x.UserEmail == userEmail);
            if (user == null) return false;
            if (!string.Equals(user.UserPassword, userPassword)) return false;
            return true;
        }
    }
}
