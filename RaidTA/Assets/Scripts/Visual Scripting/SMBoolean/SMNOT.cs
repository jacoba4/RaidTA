using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMNOT : SMOneInput
{
    public override object Output()
    {
        return !(bool)input_a.Output();
    }
}
