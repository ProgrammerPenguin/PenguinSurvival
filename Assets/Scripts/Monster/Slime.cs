using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster
{
    public override void DestroyMonster()
    {
        base.DestroyMonster();

        SlimeObjectPool.ReturnObject(this);
    }
}
