using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC Database", menuName = "Assets/Databases/NPCDB")]
public class NPCDB : ScriptableObject
{
    public NPCSO[] npcs;
}
