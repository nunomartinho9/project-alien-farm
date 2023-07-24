using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptable Objects/Recipe Data")]
public class RecipeData : ScriptableObject
{
    [SerializeField] private ResourcesContainer resources;
    [SerializeField] private int amountOfWood;
    [SerializeField] private int amountOfStone;
    [SerializeField] private int amountOfStars;


    public bool Craft()
    {
        if (!CanCraft()) return false;
        resources.UseWood(amountOfWood);
        resources.UseRocks(amountOfStone);
        resources.UseStarCrop(amountOfStars);
        return true;

    }

    public bool CanCraft()
    {
        return resources.Wood >= amountOfWood && resources.Rocks >= amountOfStone && resources.StarCrops >= amountOfStars;
    }


}
