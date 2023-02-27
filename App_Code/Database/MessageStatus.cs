using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MessageStatus
/// </summary>
public class MessageStatus
{
    public string message { get; set; }
    public bool status { get; set; }

    public MessageStatus(string message, bool status)
    {
        this.message = message;
        this.status = status;
    }
}