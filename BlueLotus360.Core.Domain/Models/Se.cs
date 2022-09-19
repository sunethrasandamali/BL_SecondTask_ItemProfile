using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Models
{
    public class RefreshToken
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public string ReasonRevoked { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public bool IsRevoked => Revoked != null;
        public bool IsActive => !IsRevoked && !IsExpired;
    }

    public class AppSettings
    {
        public string Secret { get; set; } = "eea163e5ae59bceac7439806386f3e3bd468bd6e72161d9c16e48fcd58e53bd44f4297f5187623153da0035a6fb73a131f0514a968b354245c99a56c43f8a681";

        // refresh token time to live (in days), inactive tokens are
        // automatically deleted from the database after this time
        public int RefreshTokenTTL { get; set; } = 1;
    }
}
