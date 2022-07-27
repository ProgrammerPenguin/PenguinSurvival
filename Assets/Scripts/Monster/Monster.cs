using System.Collections;
using UnityEngine;
using UnityEngine.AI; // AI, 내비게이션 시스템 관련 코드를 가져오기

// 적 AI를 구현한다
public class Monster : LivingEntity
{
    private Transform Target;
    public bool IsChase;
    
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;
    private Material _material;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private GameManager _gameManager;
    public bool Isdie;



    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
        _material = GetComponentInChildren<SkinnedMeshRenderer>().material;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _gameManager = GameManager.Instance;
        Isdie = false;

        ChaseStart();
        StartCoroutine(UpdatePath());
    }
    void ChaseStart()
    {
        IsChase = true;
        _animator.SetBool(SlimeAnimID.HasTarget, true);
    }

    new public void OnEnable()
    {
        if (Isdie == true)
        {
            Isdie = false;
            ChaseStart();
            StartCoroutine(UpdatePath());
        }
    }
    private IEnumerator UpdatePath()
    {
        while(true)
        {
            if (Isdie == false)
            {
                _navMeshAgent.SetDestination(_gameManager.PlayerTransform.position);
            }

            yield return new WaitForSeconds(0.25f);
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
            Melee weapon = other.GetComponent<Melee>();
            OnDamage(weapon.damage, transform.position);
            Vector3 KnockBack = transform.position - other.transform.position;
            StartCoroutine(HitEffect(KnockBack));
            //Debug.Log($"{CurrentHealth}"); // 지워야함
        }
        if (other.tag == "Bullet")
        {
            Bullet bulltet = other.GetComponent<Bullet>();
            OnDamage(bulltet.damage, transform.position);
            StartCoroutine(HitEffect(new Vector3(0f,0f,0f)));
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

        if (CurrentHealth > 0)
        {
            _material.color = Color.white;
            KnockBack = KnockBack.normalized;
            KnockBack += Vector3.back;
            _rigidbody.AddForce(KnockBack * 200, ForceMode.Impulse);
        }
        else
        {
            IsChase = false;
            Isdie = true;
            _animator.SetTrigger(SlimeAnimID.DoDie);
            _material.color = Color.gray;
            gameObject.layer = 12;
            Invoke("DestroyMonster", 4f);
        }
    }

    private void DestroyMonster()
    {
        _animator.SetTrigger(SlimeAnimID.DoDie);
        _material.color = Color.white;
        gameObject.layer = 11;
        CurrentHealth = InitialHealth;
        
        
        ObjectPool.ReturnObject(this);
        
    }

}