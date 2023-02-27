using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "SpawnPointArray", menuName = "Roguelike_Prototype/SpawnPointArray", order = 0)]
public class SpawnPointArray : ScriptableObject
{
    public List<GameObject> spawnPoint = new List<GameObject>();
}
