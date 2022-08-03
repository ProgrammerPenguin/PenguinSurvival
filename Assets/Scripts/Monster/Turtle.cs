using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : Monster
{
    public override void DestroyMonster()
    {
        base.DestroyMonster();

        TurtleObjectPool.ReturnObject(this);
        
    }
}
