using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SMInt : SMNode
{
    public int value;
    InputField field;

    private void Start()
    {
        field = GetComponentInChildren<InputField>();
        value = -1;
    }

    public override object Output()
    {
        return value;
    }

    public void ChangeValue()
    {
        if(field.text.Length == 0) { return; }
        value = int.Parse(field.text);
    }
}
