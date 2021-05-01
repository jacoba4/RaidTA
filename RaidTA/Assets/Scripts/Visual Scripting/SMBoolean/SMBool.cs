using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SMBool : SMNode
{
    public bool value;
    Dropdown d;

    public void Start()
    {
        d = GetComponentInChildren<Dropdown>();
        value = true;
    }
    public override object Output()
    {
        return value;
    }

    public void ChangeValue()
    {
        value = d.value == 0;
    }
}
