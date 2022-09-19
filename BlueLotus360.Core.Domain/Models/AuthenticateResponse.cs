﻿using BlueLotus360.Core.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Models
{
    public class UserAuthenticationResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string JwtToken { get; set; }

        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }

        public UserAuthenticationResponse(User user, string jwtToken, string refreshToken)
        {
            Id = user.UserKey;
            FirstName = user.UserID;
            LastName = user.UserID;
            Username = user.UserID;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}
