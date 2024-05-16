using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class User
{
    [Key, Column("USER_ID")]
    public Guid UserId { get; private set; }

    [Column("USER_NAME")]
    [MaxLength(50)]
    public string UserName { get; private set; } = string.Empty;

    [Column("USER_EMAIL")]
    [MaxLength(50)]
    public string UserEmail { get; private set; } = string.Empty;

    [Column("PASSWORD_HASH")]
    public byte[] PasswordHash { get; private set; } = Array.Empty<byte>();

    [Column("PASSWORD_SALT")]
    public byte[] PasswordSalt { get; private set; } = Array.Empty<byte>();

    [Column("USER_IMAGE")]
    public byte[]? UserImage { get; private set; }

    public static User Create(Guid userId, string userName, string userEmail, byte[] passwordHash, byte[] passwordSalt, byte[]? userImage = null)
    {
        return new User
        {
            UserId = userId,
            UserName = userName,
            UserEmail = userEmail,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            UserImage = userImage
        };
    }
}