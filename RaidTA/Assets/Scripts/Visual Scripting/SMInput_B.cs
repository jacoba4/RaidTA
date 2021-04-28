using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMInput_B : SMInput
{
    public SMTwoInput node;

    protected override void Start()
    {
        base.Start();
        node = gameObject.GetComponentInParent<SMTwoInput>();
    }

    public override void Link(DragableOutput o)
    {
        base.Link(o);
        node.LinkB(o.node);
    }

    public override void Unlink()
    {
        base.Unlink();
        node.UnlinkB();
    }
}
