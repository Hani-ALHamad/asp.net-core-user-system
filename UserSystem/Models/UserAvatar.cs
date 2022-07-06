using System;
using System.Collections.Generic;

namespace UserSystem.Models
{
    public partial class UserAvatar
    {
        public int ID { get; set; }
        public string UserID { get; set; } = null!;
        public byte[]? AvatarData { get; set; } = null!;
    }
}
