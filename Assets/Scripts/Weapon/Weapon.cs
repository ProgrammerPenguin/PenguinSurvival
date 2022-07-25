using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type { Melee, Range};
    public Type type;
    public int damage;
    public float rate;
    public BoxCollider meleeArea;
    public TrailRenderer trailEffect;

    public void Use()
    {
        if (type == Type.Melee)
        {
            StartCoroutine(Swing());
        }

    }
    IEnumerator Swing()
    {

        yield return new WaitForSeconds(0.1f);
        meleeArea.enabled = true;
        trailEffect.startColor = Color.red;

        yield return new WaitForSeconds(0.5f);
        meleeArea.enabled = false;
        trailEffect.startColor = trailEffect.startColor = Color.yellow;
    }
}
