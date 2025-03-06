namespace RegisterAndLoginApp.Models
{
    public class GroupViewModel
    {
        public bool isSelected { get; set; }
        public string groupName { get; set; }
    }

    public class RegisterViewModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public List<GroupViewModel> groups { get; set;}

        public RegisterViewModel() 
        {
            username = "";
            password= "";
            groups = new List<GroupViewModel>
            {
                new GroupViewModel { groupName = "Admin", isSelected = false },
                new GroupViewModel { groupName = "Users", isSelected = false },
                new GroupViewModel { groupName = "Student", isSelected = false },
            };
        }
    }
}
