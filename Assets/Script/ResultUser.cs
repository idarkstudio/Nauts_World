using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Newtonsoft.Json;
public class ResultUser
{
    [JsonProperty]
    public string Principal { get; set; }
    [JsonProperty]
    public bool SetName { get; set; }

    public ResultUser()
    {
        Principal = "None";
        SetName = false;
    }

    public ResultUser(string principal, bool setName)
    {
        Principal = principal;
        SetName = setName;
    }
}
