using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject _Meleeweapon;
    public GameObject _Rangeweapon;
    public Melee meleeWeapon;
    Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
       
    }
    private void Update()
    {
        if (_Meleeweapon.activeSelf == true)
        {
            MeleeAttack();
        }
        if (_Rangeweapon.activeSelf == true)
        {
            RangeAttack(_Rangeweapon);
        }
    }
    public void MeleeAttack()
    {
        if (_Meleeweapon == null)
        {
            return;
        }
        //Melee meleeWeapon = Melee.GetComponent<Melee>();
        meleeWeapon.AttackDelay += Time.deltaTime;
        meleeWeapon.IsAttackReady = meleeWeapon.rate < meleeWeapon.AttackDelay;
        if (meleeWeapon.IsAttackReady)
        {
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
            //_anim.SetTrigger(PlayerAnimID.GunAttack);
            RangeWeapon.AttackDelay = 0;
        }
    }

    void Test()
    {
        Debug.Log("테스트 코드입니다");
    }

    void MeleeWeaponOn()
    {
        meleeWeapon.meleeArea.enabled = true;
        meleeWeapon.trailEffect.enabled = true;
    }

    void MeleeWeaponOff()
    {
        meleeWeapon.meleeArea.enabled = false;
        meleeWeapon.trailEffect.enabled = false;
    }
}
