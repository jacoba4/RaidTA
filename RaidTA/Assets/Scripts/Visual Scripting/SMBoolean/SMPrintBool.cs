using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMPrintBool : SMOneInput
{
    public override void Execute()
    {
        Debug.Log((bool)input_a.Output());
        base.Execute();
    }
}
