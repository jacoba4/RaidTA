using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Database", menuName = "Assets/Databases/UnitDB")]
public class UnitDB : ScriptableObject
{
    public UnitSO[] units;
}
