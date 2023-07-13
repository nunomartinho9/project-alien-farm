using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu (menuName = "Scriptable Objects/Item", fileName = "New Item")]
public class Item : ScriptableObject
{
   public TileBase tile;
   public Sprite sprite;
   public ItemType type;
   public ActionType actionType;
   public Vector2Int range = new Vector2Int(5, 4);
   public bool stackable = true;
}

public enum ItemType
{
   Seed,
   Tool,
   Building
}

public enum ActionType
{
   Plow,
   Dig,
   Chop,
   Plant,
   None
}