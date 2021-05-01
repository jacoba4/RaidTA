using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMWait : SMOneInput
{
    public override void Execute()
    {
        if (!CheckInputs()) { return; }
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds((int)input_a.Output());
        base.Execute();
    }
}
