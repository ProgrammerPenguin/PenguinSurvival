using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : Monster
{
    public override void DestroyMonster()
    {
        base.DestroyMonster();

        GruntObjectPool.ReturnObject(this);
    }
}
