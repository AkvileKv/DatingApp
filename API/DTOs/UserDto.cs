namespace API.DTOs
{
    public class UserDto
    { //object we gonne to return when user to logs in or registers
        public string Username { get; set; }
        public string Token { get; set; }
        public string PhotoUrl { get; set; }

        public string KnownAs { get; set; }

        public string Gender { get; set; }
    }
}