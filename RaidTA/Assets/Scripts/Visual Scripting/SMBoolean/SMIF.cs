using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMIF : SMOneInput
{
    public SMNode exec_false_next;
    public override void Execute()
    {
        Debug.Log((bool)input_a.Output());
        if((bool)input_a.Output())
        {
            exec_next.Execute();
        }
        else
        {
            exec_false_next.Execute();
        }
    }

    public void SetNextFalse(SMNode n)
    {
        exec_false_next = n;
        if (n != null)
        {
            if (n.GetPrev() != this)
            {
                n.SetPrev(this);
            }
        }
    }
}
