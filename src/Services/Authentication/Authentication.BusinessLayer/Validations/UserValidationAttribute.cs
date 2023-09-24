﻿using Authentication.BusinessLayer.Dtos;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Authentication.BusinessLayer.Validations
{
    public class UserValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is UserDto user)
            {
                if (user.Nickname is null)
                {
                    ErrorMessage = "Имя пользователя является обязательным к заполнению";
                    return false;
                }

                if (!Regex.Match(user.Nickname, @"^[^\%/\\&\?\,\'\;:!-+!@#\$\^*)(]{1,100}$").Success)
                {
                    ErrorMessage = "Имя пользователя не должно быть более 1 и менее 100 символов" +
                        ", а также не должна содержать спецсимволы";
                    return false;
                }

                if (user.Email is null)
                {
                    ErrorMessage = "Электронная почта является обязательной к заполнению";
                    return false;
                }

                if (!Regex.Match(
                    user.Email, @"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;]{0,1}\s*)+$")
                    .Success)
                {
                    ErrorMessage = "Невалидный email";
                    return false;
                }

                if (user.Phone is not null)
                {
                    if (!Regex.Match(
                    user.Phone, @"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}")
                    .Success)
                    {
                        ErrorMessage = "Невалидный формат номера телефона";
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}