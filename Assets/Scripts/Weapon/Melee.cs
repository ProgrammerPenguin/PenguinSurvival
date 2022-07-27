using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon
{
    public BoxCollider meleeArea;
    public TrailRenderer trailEffect;
    public float AttackDelay;
    public bool IsAttackReady;
    public float WeaponSpeed;
    public void Use()
    {
       StartCoroutine(Swing());
    }
    IEnumerator Swing()
    {
        yield return null;
        meleeArea.enabled = true;
        trailEffect.enabled = true;

        yield return new WaitForSeconds(7f);
        meleeArea.enabled = false;
        trailEffect.enabled = false;
        //trailEffect.startColor = trailEffect.startColor = Color.yellow;
    }

}
