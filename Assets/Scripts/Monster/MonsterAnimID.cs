using UnityEngine;

public static class MonsterAnimID
{
    public static readonly int HasTarget = Animator.StringToHash("HasTarget");
    public static readonly int DoAttack = Animator.StringToHash("DoAttack");
    public static readonly int DoHit = Animator.StringToHash("DoHit");
    public static readonly int DoDie = Animator.StringToHash("DoDie");
}