using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public int Health;
    public int Damage;
    public List<Transform> SpawnPoints;
}


