using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMan : Monster
{
    public override void DestroyMonster()
    {
        base.DestroyMonster();

        SpearManObjectPool.ReturnObject(this);
    }
}
