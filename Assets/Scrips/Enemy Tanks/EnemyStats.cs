using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyStats : ScriptableObject
{
    public new string name;

    public float moveSpeed;
    public float fireSpeed;

    public int healthPoints;
    public int score;

    public Sprite [] design;
}
