using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Core.Entities;

public class Todo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Title { get; set; } = default!;
    [StringLength(1000)]
    public string? Description { get; set; }
    public bool Status { get; set; } = false;
    [Required]
    public string OwnerId { get; set; } = default!;
}
