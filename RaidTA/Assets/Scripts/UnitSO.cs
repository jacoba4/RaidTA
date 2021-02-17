using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Assets/Unit")]
public class UnitSO : ScriptableObject
{
    public string unit_name;
    public GameObject unit_prefab;
}
