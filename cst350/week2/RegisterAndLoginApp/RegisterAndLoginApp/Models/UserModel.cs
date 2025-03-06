namespace RegisterAndLoginApp.Models
{
    public class UserModel
    {
        public int Id {  get; set; }
        public string Username {  get; set; }
        public string PasswordHash {  get; set; }
        public byte[] Salt {  get; set; }
        public string Groups {  get; set; }
    }
}
