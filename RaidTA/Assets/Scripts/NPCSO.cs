using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "Assets/NPC")]
public class NPCSO : ScriptableObject
{
    public string npc_name;
    public GameObject npc_prefab;
}
