using System.Collections;
using UnityEngine;
using UnityEngine.AI; // AI, 내비게이션 시스템 관련 코드를 가져오기

// 적 AI를 구현한다
public class Monster : LivingEntity
{
    public Transform Target;
    public bool IsChase;

    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;
    private Material _material;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
   


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
        _material = GetComponentInChildren<SkinnedMeshRenderer>().material;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        ChaseStart();
    }
    void ChaseStart()
    {
        IsChase = true;
        _animator.SetBool(SlimeAnimID.HasTarget, true);
    }
    private void Update()
    {
        if (IsChase)
        {
            _navMeshAgent.SetDestination(Target.position);
        }
    }

    void FreezeVelocity()
    {
        if (IsChase)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        FreezeVelocity();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Melee")
        {
            Weapon weapon = other.GetComponent<Weapon>();
            OnDamage(weapon.damage, transform.position);
            Vector3 KnockBack = transform.position - other.transform.position; 
            StartCoroutine(HitEffect(KnockBack));
            Debug.Log($"{CurrentHealth}"); // 지워야함
        }
    }

    public override void OnDamage(float damage, Vector3 hitPoint)
    {
        base.OnDamage(damage, hitPoint);
    }

    IEnumerator HitEffect(Vector3 KnockBack)
    {
        _material.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        if(CurrentHealth > 0)
        {
            _material.color = Color.white;
            KnockBack = KnockBack.normalized;
            KnockBack += Vector3.up;
            _rigidbody.AddForce(KnockBack * 5, ForceMode.Impulse);
        }
        else
        {
            IsChase = false;
            _animator.SetTrigger(SlimeAnimID.DoDie);
            _material.color = Color.gray;
            gameObject.layer = 12;
            Destroy(gameObject, 4);
        }
    }

}