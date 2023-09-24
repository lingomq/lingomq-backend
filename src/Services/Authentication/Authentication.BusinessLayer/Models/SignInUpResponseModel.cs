﻿using Authentication.BusinessLayer.Validations;

namespace Authentication.BusinessLayer.Models
{
    [UserValidation]
    public class SignInUpResponseModel
    {
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public string? Number { get; set; }
        public string? Password { get; set; }
    }
}
