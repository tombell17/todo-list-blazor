using System.ComponentModel.DataAnnotations;

namespace ToDoListBlazor.Domain.Shared.UserAccount
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
