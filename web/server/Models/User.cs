using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key, Column("USER_ID")]
    public Guid UserId { get; set; }

    [Column("USER_NAME")]
    [MaxLength(50)]
    public string UserName { get; set; } = "";

    [Column("USER_EMAIL")]
    [MaxLength(50)]
    public string UserEmail { get; set; } = "";

    [Column("PASSWORD_HASH")]
    public byte[] PasswordHash { get; set; } = Array.Empty<byte>();

    [Column("PASSWORD_SALT")]
    public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();

    [Column("USER_IMAGE")]
    public byte[]? UserImage { get; set; } 
}