using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMLessThan : SMTwoInput
{
    public override object Output()
    {
        if (!CheckInputs()) { return null; }
        return (int)input_a.Output() < (int)input_b.Output();
    }
}
