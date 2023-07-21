using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu (menuName = "Scriptable Objects/Resources Container", fileName = "New Resources Container")]
public class ResourcesContainer : ScriptableObject
{
   private int wood;
   private int rocks;
   private int starCrops;
  [SerializeField] private int seeds = 5;

   [SerializeField] private int startingMaxStacks = 100;
   [SerializeField] private int upgradeAmount = 100;
   private int maxStacks;

   public int Wood => wood;

   public int Rocks => rocks;

   public int StarCrops => starCrops;

   public int Seeds => seeds;

   public int MaxResources
   {
      get => maxStacks;
      set => maxStacks = value;
   }

   private void OnEnable()
   {
      // to test
      maxStacks = startingMaxStacks;
   }

   public void AddWood(int amount)
   {
      wood = Mathf.Clamp(wood+amount, 0, maxStacks);
   }
   
   public void AddRocks(int amount)
   {
      rocks = Mathf.Clamp(rocks+amount, 0, maxStacks);
   }
   
   public void AddStarCrops(int amount)
   {
      starCrops = Mathf.Clamp(starCrops+amount, 0, maxStacks);
   }
   [ContextMenu("Add seeds")]
   public void AddSeeds(int amount)
   {
      seeds = Mathf.Clamp(seeds+amount, 0, maxStacks);
   }

   public void UseSeed()
   {
      //if (seeds <= 0) return;
      seeds--;
   }
   
   public void UseWood(int amount)
   {
      wood -= amount;
   }
   
   public void UseRocks(int amount)
   {
      rocks -= amount;
   }
   public void UseStarCrop(int amount)
   {
      starCrops -= amount;
   }
   
   public void UpgradeMaxStacks()
   {
      maxStacks += upgradeAmount;
   }
   
   public void Reset()
   {
      wood = 0;
      rocks = 0;
      starCrops = 0;
      seeds = 5;
      maxStacks = startingMaxStacks;

   }
   
}
