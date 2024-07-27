using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageModel     
{
    public MessageModel(string notification, string status)
    {
        this.notification = notification;
        this.status = status;
    }

    public string notification { get; set; }
  public string status{get; set; }
}
