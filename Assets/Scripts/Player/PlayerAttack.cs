using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject _Meleeweapon;
    public GameObject _Rangeweapon;
    public GameObject _Magicweapon;
    public Melee meleeWeapon;
    public Range rangeWeapon;
    public Magic magicWeapon;
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
            RangeAttack();
        }
        if(_Magicweapon.activeSelf == true)
        {
            MagicAttack();
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

    public void RangeAttack()
    {
        if (_Rangeweapon == null)
        {
            return;
        }
        rangeWeapon.AttackDelay += Time.deltaTime;
        rangeWeapon.IsAttackReady = rangeWeapon.rate < rangeWeapon.AttackDelay;
        if (rangeWeapon.IsAttackReady)
        {
            rangeWeapon.Use();
            _anim.SetTrigger(PlayerAnimID.GunAttack);
            rangeWeapon.AttackDelay = 0;
        }
    }

    public void MagicAttack()
    {
        if (_Magicweapon == null)
        {
            return;
        }
        magicWeapon.AttackDelay += Time.deltaTime;
        magicWeapon.IsAttackReady = magicWeapon.rate < magicWeapon.AttackDelay;
        if (magicWeapon.IsAttackReady)
        {
            magicWeapon.Use();
            //_anim.SetTrigger(PlayerAnimID.GunAttack);
            magicWeapon.AttackDelay = 0;
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
