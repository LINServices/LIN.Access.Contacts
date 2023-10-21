using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIN.Access.Contacts;




public class Message
{
    public string Result { get; set; }
    public MessageTypes Type { get; set; }
}

public enum MessageTypes
{
    Text,
    Command
}