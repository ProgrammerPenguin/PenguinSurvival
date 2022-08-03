using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Monster
{
    public override void DestroyMonster()
    {
        base.DestroyMonster();

        GolemObjectPool.ReturnObject(this);
    }
}
