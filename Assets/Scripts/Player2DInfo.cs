using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu (menuName = "Scriptable Objects/Player2D Info", fileName = "New Player2D Info")]
public class Player2DInfo : ScriptableObject
{
     
     
     
     public Vector3Int Position
     {
          get;
          private set;
     }

     public void UpdatePlayerPosition(Vector3Int newpos)
     {
          Position = newpos;
     }
}
