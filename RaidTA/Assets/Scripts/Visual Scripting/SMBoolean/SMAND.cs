using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMAND : SMTwoInput
{
    public override object Output()
    {
        CheckInputs();
        return (bool)input_a.Output() && (bool)input_b.Output();
    }
}
