using System.ComponentModel.DataAnnotations;

namespace TodoApp.Core.DTOs;

public record class CreateTodoDto(
    [Required]
    [StringLength(50)]
    string Title,

    string? Description
);

public record class UpdateTodoDto(
    [Required]
    int Id,

    [Required]
    [StringLength(50)]
    string Title,

    [StringLength(1000)]
    string Description,

    bool Status
);