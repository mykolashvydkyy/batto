using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySo", menuName = "SO/Enemy")]
public class EnemySo : ScriptableObject
{
    public string Name;
    public float MinReaction;
    public float MaxReaction;
}
