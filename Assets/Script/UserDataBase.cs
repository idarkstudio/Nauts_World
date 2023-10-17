using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResultUser 
{
    public string principal;
    public bool setName;

    public ResultUser()
    {
        this.principal = "None";
        this.setName = false;
    }

    public ResultUser(string principal, bool setName) 
    {
        this.principal = principal;
        this.setName = setName;
    }
  
}
