using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject _Meleeweapon;
    public GameObject _Rangeweapon;
    Animator _anim;

    private float _totalAnimTime;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _totalAnimTime = _anim.
       
    }
    private void Update()
    {
        if (_Meleeweapon.activeSelf == true)
        {
            MeleeAttack(_Meleeweapon);
        }
        //if (_Rangeweapon.activeSelf == true)
        //{
        //    RangeAttack(_Rangeweapon);
        //}
    }
    public void MeleeAttack(GameObject Melee)
    {
        if (_Meleeweapon == null)
        {
            return;
        }
        Melee meleeWeapon = Melee.GetComponent<Melee>();
        meleeWeapon.AttackDelay += Time.deltaTime;
        meleeWeapon.IsAttackReady = meleeWeapon.rate < meleeWeapon.AttackDelay;
        if (meleeWeapon.IsAttackReady)
        {
            meleeWeapon.Use();
            _anim.SetFloat("AttackSpeed", meleeWeapon.WeaponSpeed);
            _anim.SetTrigger(PlayerAnimID.MeleeAttack);
            meleeWeapon.AttackDelay = 0;
        }
    }

    public void RangeAttack(GameObject Range)
    {
        if (Range == null)
        {
            return;
        }
        Range RangeWeapon = Range.GetComponent<Range>();
        RangeWeapon.AttackDelay += Time.deltaTime;
        RangeWeapon.IsAttackReady = RangeWeapon.rate < RangeWeapon.AttackDelay;
        if (RangeWeapon.IsAttackReady)
        {
            RangeWeapon.Use();
            _anim.SetTrigger(PlayerAnimID.GunAttack);
            RangeWeapon.AttackDelay = 0;
        }
    }
}
