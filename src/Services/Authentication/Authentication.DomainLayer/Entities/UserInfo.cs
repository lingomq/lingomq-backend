﻿namespace Authentication.DomainLayer.Entities
{
    public class UserInfo : BaseEntity
    {
        public string? Nickname { get; set; }
        public string? ImageUri { get; set; } = "static/default.png";
        public string? Additional { get; set; } = "";
        public DateTime? CreationalDate { get; set; } = DateTime.Now;
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        public bool IsRemoved { get; set; } = false;
        public UserRole? Role { get; set; }
        public User? User { get; set; }
    }
}
