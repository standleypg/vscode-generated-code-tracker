using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserRecord
{
    [Key]
    [Column("USER_ID")]
    public Guid UserId { get; set; }

    [Key]
    [Column("SOLUTION_ID")]
    [StringLength(50)]
    public string SolutionId { get; set; } = "";

    [Key]
    [Column("SEQ_NO")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SeqNo { get; set; }

    [Column("RECORD_DATE")]
    public DateTime RecordDate { get; set; }

    [Column("NOOF_AUTO_GEN_LINES")]
    public decimal NoOfAutoGenLines { get; set; }
}
