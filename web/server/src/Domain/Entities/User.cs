using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class User : EntityBase
{
    public string UserEmail { get; private set; } = string.Empty;
    public string UserName { get; private set; } = string.Empty;
    public byte[] PasswordHash { get; private set; } = [];
    public byte[] PasswordSalt { get; private set; } = [];
    public byte[]? UserImage { get; private set; }
    [JsonIgnore]
    public IEnumerable<UserProject> UserProjects { get; private set; } = [];
    [JsonIgnore]
    public IEnumerable<Stat> Stats { get; private set; } = [];

    public static User Create(string userName, string userEmail, byte[] passwordHash, byte[] passwordSalt, byte[]? userImage = null)
    {
        return new User
        {
            UserName = userName,
            UserEmail = userEmail,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            UserImage = userImage
        };
    }
}