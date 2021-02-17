using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell Database", menuName = "Assets/Databases/SpellDB")]
public class SpellDB : ScriptableObject
{
    public SpellSO[] spells;
}
