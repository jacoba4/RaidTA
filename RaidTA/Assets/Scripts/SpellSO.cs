using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Assets/Spell")]
public class SpellSO : ScriptableObject
{
    public string spell_name;
    public GameObject spell_prefab;
}
