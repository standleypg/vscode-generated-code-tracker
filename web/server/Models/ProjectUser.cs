using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProjectUser
{
    [Key, Column("PROJECT_ID", Order = 0)]
    [MaxLength(50)]
    public string ProjectId { get; set; } = "";
    public Project Project { get; set; } = new Project();

    [Key, Column("USER_ID", Order = 1)]
    public Guid UserId { get; set; }
    public User? User { get; set; }
}
