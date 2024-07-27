using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserRegisterModel 
{
    public UserRegisterModel(string username)
    {
        this.username = username;
    }

    public UserRegisterModel    (string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public string username {get; set;}
    public string password { get; set;}
}
