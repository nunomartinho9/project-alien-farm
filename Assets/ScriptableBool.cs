using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptable Objects/Scriptable Bool")]
public class ScriptableBool : ScriptableObject
{
    public bool isActive;

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}
