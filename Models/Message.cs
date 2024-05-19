using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class Message
    {
        public Message()
        {
            Messages = new HashSet<Message>();
            RoomMessages = new HashSet<RoomMessage>();
        }
        public int ID { get; set; }    
        public string Content { get; set; }
        public string creatorID { get; set; }
        public int? ParentMessageID { get; set; }
        public DateTime createdAT { get; set; } = DateTime.Now;
        public virtual TaiKhoan userNavigation { get; set; }
        public virtual Message MessageNavigation { get; set; }
 
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<RoomMessage> RoomMessages { get; set; }

    }
}
