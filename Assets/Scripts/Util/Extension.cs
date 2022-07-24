using UnityEngine;

// �޼��常���
// ���� Ŭ�������� ��
public static class Extension
{
    public static void SetIKPositionAndWeight(this Animator animator, AvatarIKGoal goal, Vector3 goalPosition, float weight = 1f)
    {
        animator.SetIKPositionWeight(goal, weight);
        animator.SetIKPosition(goal, goalPosition);
    }

    public static void SetIKRotationAndWeight(this Animator animator, AvatarIKGoal goal, Quaternion goalQuaternion, float weight = 1f)
    {
        animator.SetIKRotationWeight(goal, weight);
        animator.SetIKRotation(goal, goalQuaternion);
    }
}
