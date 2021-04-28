using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SMInput_A : SMInput
{
    public SMOneInput node;

    protected override void Start()
    {
        base.Start();
        node = gameObject.GetComponentInParent<SMOneInput>();
    }

    public override void Link(DragableOutput o)
    {
        base.Link(o);
        node.LinkA(o.node);
    }

    public override void Unlink()
    {
        base.Unlink();
        node.UnlinkA();
    }
}
