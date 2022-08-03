using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogWarrior : Monster
{
    public override void DestroyMonster()
    {
        base.DestroyMonster();

        DogWarriorObjectPool.ReturnObject(this);
    }
}
