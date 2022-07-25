using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    bool isFireReady;
    float FireDelay;
    public Weapon _weapon;
    Animator _anim;


    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Attack();
    }
    public void Attack()
    {
        if (_weapon == null)
        {
            return;
        }
        FireDelay += Time.deltaTime;
        isFireReady = _weapon.rate < FireDelay;

        if (isFireReady)
        {
            _weapon.Use();
            _anim.SetTrigger(PlayerAnimID.Attack);
            FireDelay = 0;
        }
    }
}
