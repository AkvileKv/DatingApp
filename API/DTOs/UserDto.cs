namespace API.DTOs
{
    public class UserDto
    { //object we gonne to return when user to logs in or registers
        public string Username { get; set; }
        public string Token { get; set; }
    }
}