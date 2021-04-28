using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMOR : SMTwoInput
{
    public override object Output()
    {
        return (bool)input_a.Output() || (bool)input_b.Output();
    }
}
