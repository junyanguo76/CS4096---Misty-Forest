using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
     public enum StatusList
    {
         Healing, Bleeding, DecreaseDefence, IncreaseDefense,
        IncreaseAttack, DecreaseAttack,IncreaseSpeed,DecreaseSpeed,Normal
    };
    public StatusList statusType;
    public int lastTime = 3;
    
}
