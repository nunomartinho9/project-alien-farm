using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
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

   [NonSerialized] public UnityEvent updateResourcesEvent;
   
   public int Wood => wood;

   public int Rocks => rocks;

   public int StarCrops => starCrops;

   public int Seeds => seeds;

   public int MaxResources => maxStacks;

   private void OnEnable()
   {
      if (updateResourcesEvent == null) 
         updateResourcesEvent = new UnityEvent();
   }

   public void AddWood(int amount)
   {
      wood = Mathf.Clamp(wood+amount, 0, maxStacks);
      updateResourcesEvent?.Invoke();
   }
   
   public void AddRocks(int amount)
   {
      rocks = Mathf.Clamp(rocks+amount, 0, maxStacks);
      updateResourcesEvent?.Invoke();
   }
   
   public void AddStarCrops(int amount)
   {
      starCrops = Mathf.Clamp(starCrops+amount, 0, maxStacks);
      updateResourcesEvent?.Invoke();
   }
   
   public void AddSeeds(int amount)
   {
      seeds = Mathf.Clamp(seeds+amount, 0, maxStacks);
      updateResourcesEvent?.Invoke();
   }

   public void UseSeed()
   {
      //if (seeds <= 0) return;
      seeds--;
      updateResourcesEvent?.Invoke();
   }
   
   public void UseWood(int amount)
   {
      wood -= amount;
      updateResourcesEvent?.Invoke();
   }
   
   public void UseRocks(int amount)
   {
      rocks -= amount;
      updateResourcesEvent?.Invoke();
   }
   public void UseStarCrop(int amount)
   {
      starCrops -= amount;
      updateResourcesEvent?.Invoke();
   }
   
   public void UpgradeMaxStacks()
   {
      maxStacks += upgradeAmount;
      updateResourcesEvent?.Invoke();
   }
   
   public void Reset()
   {
      wood = 0;
      rocks = 0;
      starCrops = 0;
      seeds = 5;
      maxStacks = startingMaxStacks;
      updateResourcesEvent?.Invoke();

   }

   public void CallEvent()
   {
      updateResourcesEvent?.Invoke();
   }
   
}
