using System.Collections;
using UnityEngine;
using UnityEngine.AI; // AI, ������̼� �ý��� ���� �ڵ带 ��������

// �� AI�� �����Ѵ�
public class Monster : LivingEntity
{
    // �� AI�� �����Ѵ�
    public class Enemy : LivingEntity
    {
        private Rigidbody _rigidbody;
        private BoxCollider _boxCollider;
        public int maxheal;
        public int minheal;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _boxCollider = GetComponent<BoxCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Melee")
            {
                Weapon weapon = other.GetComponent<Weapon>();
                maxheal -= weapon.damage;
                //OnDamage(weapon.damage, other.transform.position);
                  Debug.Log($"{minheal}");
            }
        }

        public override void OnDamage(float damage, Vector3 hitPoint)
        {

            base.OnDamage(damage, hitPoint);
        }
    }
}