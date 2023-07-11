using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBreakable
{
    BreakableData Data { get;  }
    void Damage();
    

}
