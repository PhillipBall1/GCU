using System.Data.SqlClient;

namespace RegisterAndLoginApp.Models
{
    public class UserCollection : IUserManager
    {
        private List<UserModel> _users;

        public UserCollection()
        { 
            _users = new List<UserModel>();
            GenerateUserData();
        }

        private void GenerateUserData()
        {
            UserModel user1 = new UserModel();
            user1.Username = "Phillip";
            user1.PasswordHash = "gcustudent";
            user1.Groups = "Admin";

            UserModel user2 = new UserModel();
            user1.Username = "Phillip2";
            user1.PasswordHash = "gcustudent2";
            user1.Groups = "User";

            AddUser(user1);
            AddUser(user2);
        }

        public int AddUser(UserModel user)
        {
            user.Id = _users.Count + 1;
            _users.Add(user);
            return user.Id;
        }

        public int CheckCredentials(string username, string password)
        {
            using(SqlConnection connection = new SqlConnection(username))
            {

            }
            return 0;
        }

        public void DeleteUser(UserModel user)
        {
            _users.Remove(user);
        }

        public List<UserModel> GetAllUsers()
        {
            return _users;
        }

        public UserModel GetUserById(int id)
        {
            foreach(UserModel user in _users)
            {
                if(user.Id == id) return user;
            }

            return null;
        }

        public void UpdateUser(UserModel user)
        {
            UserModel findUser = GetUserById(user.Id);

            if (findUser == null) return;

            int index = _users.IndexOf(findUser);
            _users[index] = user;
        }
    }
}
