using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMNode : MonoBehaviour
{
    public SMNode exec_prev;
    public SMNode exec_next;
    public virtual void Input(){}
    public virtual void Execute()
    {
        if(exec_next != null)
        {
            exec_next.Execute();
        }
    }
    public virtual object Output() { return null; }

    public SMNode GetPrev()
    {
        return exec_prev;
    }
    public void SetPrev(SMNode n)
    {
        exec_prev = n;
        if(n != null)
        {
            if (n.GetNext() != this)
            {
                n.SetNext(this);
            }
        }
    }

    public SMNode GetNext()
    {
        return exec_next;
    }
    public void SetNext(SMNode n)
    {
        exec_next = n;
        if (n != null)
        {
            if (n.GetPrev() != this)
            {
                n.SetPrev(this);
            }
        }
    }
}
