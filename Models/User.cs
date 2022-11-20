using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JWTAuth.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}

