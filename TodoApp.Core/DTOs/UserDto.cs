using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Core.DTOs;

public record class UserInfo
(
    [Required]
    string UserName,

    [Required]
    [PasswordPropertyText]
    string Password
);
