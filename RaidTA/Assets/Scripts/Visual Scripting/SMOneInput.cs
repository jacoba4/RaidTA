using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMOneInput : SMNode
{
    public SMNode input_a;

    protected virtual void CheckInputs()
    {
        if(input_a == null) { ErrorInputA(); }
    }
    protected void ErrorInputA()
    {
        Debug.LogError("Invalid Input A");
    }

    public void LinkA(SMNode input)
    {
        input_a = input;
    }

    public void UnlinkA()
    {
        input_a = null;
    }
}
