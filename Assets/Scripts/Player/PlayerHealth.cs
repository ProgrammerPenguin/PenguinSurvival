using UnityEngine;
using UnityEngine.UI; // UI ���� �ڵ�
using System.Collections;
using System.Collections.Generic;

// �÷��̾� ĳ������ ����ü�μ��� ������ ���
public class PlayerHealth : LivingEntity
{
    //public Slider HealthSlider; // ü���� ǥ���� UI �����̴�

    //public AudioClip DeathClip; // ��� �Ҹ�
    //public AudioClip HitClip; // �ǰ� �Ҹ�
    //public AudioClip ItemPickupClip; // ������ ���� �Ҹ�

    //private AudioSource _audioPlayer; // �÷��̾� �Ҹ� �����
    //private Animator _animator; // �÷��̾��� �ִϸ�����

    private PlayerMovement _movement; // �÷��̾� ������ ������Ʈ
    private bool isDamage;
    private bool isNoDamage;
    private SkinnedMeshRenderer[] _meshRenderer;

    private void Awake()
    {
        // ����� ������Ʈ�� ��������
        //_audioPlayer = GetComponent<AudioSource>();
        //_animator = GetComponent<Animator>();

        _movement = GetComponent<PlayerMovement>();
        _meshRenderer = GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    
    protected override void OnEnable()
    {
        // LivingEntity�� OnEnable() ���� (���� �ʱ�ȭ)
        base.OnEnable();

        // ü�� �����̵带 �ٽ� ����
        //HealthSlider.gameObject.SetActive(true);
        //HealthSlider.maxValue = InitialHealth;
        //HealthSlider.value = CurrentHealth;

        // ������Ʈ�� �ٽ� Ȱ��ȭ
        _movement.enabled = true;
    }

    // ü�� ȸ��
    public override void RestoreHealth(float newHealth)
    {
        // LivingEntity�� RestoreHealth() ���� (ü�� ����)
        base.RestoreHealth(newHealth);
        //HealthSlider.value = CurrentHealth;
    }

    // ������ ó��
    public override void OnDamage(float damage, Vector3 hitPoint)
    {
        // LivingEntity�� OnDamage() ����(������ ����)
        base.OnDamage(damage, hitPoint);
        if (IsDead == false)
        {
            //_audioPlayer.PlayOneShot(HitClip);
        }
        //HealthSlider.value = CurrentHealth;
    }

    // ��� ó��
    public override void Die()
    {
        // LivingEntity�� Die() ����(��� ����)
        base.Die();

        //HealthSlider.gameObject.SetActive(false);

        // ������Ʈ�� �ٽ� Ȱ��ȭ
        _movement.enabled = false;

        //_audioPlayer.PlayOneShot(DeathClip);

        //_animator.SetTrigger(PlayerAnimID.Die);
    }

    private void OnTriggerStay(Collider other)
    {
        // �����۰� �浹�� ��� �ش� �������� ����ϴ� ó��
        if (other.tag == "Enemy")
        {
            Debug.Log($"qeqw{CurrentHealth}");
            if (!isDamage)
            {
                Monster monster = other.GetComponent<Monster>();
                Animator animMonster = other.GetComponent<Animator>();
                animMonster.SetTrigger(MonsterAnimID.DoAttack);
                OnDamage(monster.Damage, transform.position);
                StartCoroutine(TakeDamage());

            }

        }
                
    }

    IEnumerator TakeDamage()
    {
        isNoDamage = true;
        isDamage = true;
        StartCoroutine(NoDamage());
        yield return new WaitForSeconds(3f);

        isNoDamage = false;
        isDamage = false;
    }
    
    IEnumerator NoDamage()
    {
        while(isNoDamage)
        {
            yield return new WaitForSeconds(0.1f);
            foreach (SkinnedMeshRenderer mesh in _meshRenderer)
            {
                mesh.enabled = false;
            }
            yield return new WaitForSeconds(0.1f);
            foreach (SkinnedMeshRenderer mesh in _meshRenderer)
            {
                mesh.enabled = true;
            }
        }
        
    }
}