using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class User
{
    public string userName;
    public string principal;

    public User(string name, string principal) 
    {
        this.userName = name;
        this.principal = principal;
    }
    public User()
    {
        this.userName = "Vacio";
        this.principal = "000000";
    }
    //public string UserName { get => userName; set => userName = value; }
    //public string Principa { get => principal; set => principal = value; }
}
