using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMTwoInput : SMOneInput
{
    public SMNode input_b;
    protected override void CheckInputs()
    {
        base.CheckInputs();
        if(input_b == null) { ErrorInputB(); }
    }
    protected void ErrorInputB()
    {
        Debug.LogError("Invalid Input B");
    }
    
    public void LinkB(SMNode input)
    {
        input_b = input;
    }

    public void UnlinkB()
    {
        input_b = null;
    }
}
