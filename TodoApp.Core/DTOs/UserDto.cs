using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Core.DTOs;

public record class UserInfo
(
    [Required]
    [EmailAddress]
    string UserName,

    [Required]
    [PasswordPropertyText]
    string Password
);
