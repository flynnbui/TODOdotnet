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

/* This is a DTO class that will be used to transfer data between the API and the client
 that omit the ownerId field for security reason */
public record class TodoDto(
    int Id,
    string Title,
    string? Description,
    bool Status
);