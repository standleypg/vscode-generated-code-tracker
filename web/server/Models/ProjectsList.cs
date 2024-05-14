using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProjectsList
{
    [Key]
    [StringLength(50)]
    [Column("PROJECT_ID")]
    public required string ProjectId { get; set; }

    [Required]
    [StringLength(50)]
    [Column("PROJECT_NAME")]
    public string ProjectName { get; set; } = "";
}
