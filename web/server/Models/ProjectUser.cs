using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProjectUser
{
    [Key]
    [Column("PROJECT_ID")]
    [StringLength(50)]
    public required string ProjectId { get; set; }

    [Key]
    [Column("USER_ID")]
    public Guid UserId { get; set; }
}
