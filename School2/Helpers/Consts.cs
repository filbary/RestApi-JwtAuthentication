namespace School2.Helpers
{
    public static class Consts
    {
        public class MongoDb
        {
            public const string Users = "users";
            public const string Students = "students";
        }
        public class Rests
        {
            public const string Users = "users/";
            public const string UserByEmail = "/byemail";
            public const string Register = "register";
            public const string Login = "login";
        }
        public class Roles
        {
            public const string Admin = "Admin";
            public const string Student = "Student";
            public const string Teacher = "Teacher";
        }
        public class Messages
        {
            public const string WRONGNAMEORPASS = "Wrong username or password";
        }
    }
}
