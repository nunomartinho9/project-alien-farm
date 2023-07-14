using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu (menuName = "Scriptable Objects/Player2D Info", fileName = "New Player2D Info")]
public class Player2DInfo : ScriptableObject
{
     public Vector3Int position;
}
