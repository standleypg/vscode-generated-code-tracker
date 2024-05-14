using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Project
{
    [Key, Column("PROJECT_ID")]
    [MaxLength(50)]
    public string ProjectId { get; set; } = "";

    [Column("PROJECT_NAME")]
    [MaxLength(50)]
    public string ProjectName { get; set; } = "";
}