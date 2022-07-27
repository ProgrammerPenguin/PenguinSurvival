using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipWeapon : MonoBehaviour
{
    public Transform WeaponEquipPostion;

    private Melee _sword;
    private Range _gun;
    private Animator _animator;

    private void Awake()
    {
        _gun = GetComponentInChildren<Range>();
        _sword = GetComponentInChildren <Melee>();
        _animator = GetComponent<Animator>();
    }

    
    //private void OnEnable()
    //{
    //    // ���Ͱ� Ȱ��ȭ�� �� �ѵ� �Բ� Ȱ��ȭ
    //    _gun.gameObject.SetActive(true);
    //}

    //private void OnDisable()
    //{
    //    // ���Ͱ� ��Ȱ��ȭ�� �� �ѵ� �Բ� ��Ȱ��ȭ
    //    _gun.gameObject.SetActive(false);
    //}
    private void OnAnimatorIK(int layerIndex)
    {
        //gunPivot.position = _animator.GetIKHintPosition(AvatarIKHint.RightElbow);

        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
        _animator.SetIKPosition(AvatarIKGoal.RightHand, WeaponEquipPostion.position);

        //_animator.SetIKTransformAndWeight(AvatarIKGoal.LeftHand, leftHandMount);
        //_animator.SetIKTransformAndWeight(AvatarIKGoal.RightHand, rightHandMount);

        // ������
        //_animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
        // _animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandMount.position);
         //_animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
         //_animator.SetIKRotation(AvatarIKGoal.RightHand, WeaponEquipPostion.rotation);

        // _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
        // _animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandMount.rotation);
    } 

}
