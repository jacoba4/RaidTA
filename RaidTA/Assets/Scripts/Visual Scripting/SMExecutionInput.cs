using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SMExecutionInput : SMExecution
{
    SMExecutionOutput output;

    public void Link(SMNode o)
    {
        Link();
        node.SetPrev(o);
    }

    public override void Unlink()
    {
        base.Unlink();
        node.SetPrev(null);
    }
}

    
