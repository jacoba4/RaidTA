using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SMVector3 : SMNode
{
    public Vector3 value;
    InputField x;
    InputField y;
    InputField z;

    private void Start()
    {
        InputField[] fields = GetComponentsInChildren<InputField>();
        x = fields[0];
        y = fields[1];
        z = fields[2];
        value = Vector3.zero;
    }

    public override object Output()
    {
        return value;
    }

    public void ChangeValueX()
    {
        if (x.text.Length == 0 || x.text == "-") { return; }
        value.x = float.Parse(x.text);
    }

    public void ChangeValueY()
    {
        if (y.text.Length == 0 || y.text == "-") { return; }
        value.y = float.Parse(y.text);
    }

    public void ChangeValueZ()
    {
        if (z.text.Length == 0 || z.text == "-") { return; }
        value.z = float.Parse(z.text);
    }
}
