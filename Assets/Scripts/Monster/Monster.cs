using System.Collections;
using UnityEngine;
using UnityEngine.AI; // AI, 내비게이션 시스템 관련 코드를 가져오기

// 적 AI를 구현한다
public class Monster : LivingEntity
{
    // 적 AI를 구현한다
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