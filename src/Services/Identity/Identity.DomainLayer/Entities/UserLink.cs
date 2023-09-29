﻿using System.ComponentModel.DataAnnotations;

namespace Identity.DomainLayer.Entities
{
    public class UserLink : BaseEntity
    {
        [Required(ErrorMessage = "Поле user_info_id является обязательным полем")]
        public Guid UserInfoId { get; set; }
        [Required(ErrorMessage = "Поле link_id является обязательным полем")]
        public Guid LinkId { get; set; }
        [Required(ErrorMessage = "Поле href является обязательным полем")]
        [MaxLength(256, ErrorMessage = "Поле href не может содержать более 256 символов")]
        public UserInfo? UserInfo { get; set; }
        public UserLink? Link { get; set; }
        public string? Href { get; set; }
    }
}