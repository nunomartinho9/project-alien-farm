using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float startingHp = 100f;
    public float attackRange = 2f;
    public LayerMask whatIsGround, whatIsPlayer;
}
