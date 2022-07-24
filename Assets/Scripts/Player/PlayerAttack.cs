//using UnityEngine;

//// �־��� Gun ������Ʈ�� ��ų� ������
//// �˸��� �ִϸ��̼��� ����ϰ� IK�� ����� ĳ���� ����� �ѿ� ��ġ�ϵ��� ����
//public class PlayerAttack : MonoBehaviour
//{
//    public Transform GunPivot; // �� ��ġ�� ������
//    public Transform LeftHandMount; // ���� ���� ������, �޼��� ��ġ�� ����
//    public Transform RightHandMount; // ���� ������ ������, �������� ��ġ�� ����

//    private Gun _gun; // ����� ��
//    private PlayerInput _input; // �÷��̾��� �Է�
//    private Animator _animator; // �ִϸ����� ������Ʈ

//    private void Awake()
//    {
//        // ����� ������Ʈ���� ��������
//        _gun = GetComponentInChildren<Gun>();
//        _input = GetComponent<PlayerInput>();
//        _animator = GetComponent<Animator>();
//    }

//    private void Start()
//    {
//    }

//    private void OnEnable()
//    {
//        // ���Ͱ� Ȱ��ȭ�� �� �ѵ� �Բ� Ȱ��ȭ
//        _gun.gameObject.SetActive(true);
//    }

//    private void OnDisable()
//    {
//        // ���Ͱ� ��Ȱ��ȭ�� �� �ѵ� �Բ� ��Ȱ��ȭ
//        _gun.gameObject.SetActive(false);
//    }

//    private void Update()
//    {
//        // �Է��� �����ϰ� �� �߻��ϰų� ������
//        if (_input.CanFire)
//        {
//            _gun.Fire();
//        }

//        if (_input.CanReload)
//        {
//            if (_gun.TryReload())
//            {
//                _animator.SetTrigger(PlayerAnimID.Reload);
//            }
//        }
//    }

//    // ź�� UI ����
//    private void UpdateUI()
//    {
//        if (_gun != null && UIManager.instance != null)
//        {
//            //// UI �Ŵ����� ź�� �ؽ�Ʈ�� źâ�� ź��� ���� ��ü ź���� ǥ��
//            //UIManager.instance.UpdateAmmoText(gun.AmmoInMagazine, gun.RemainAmmonCount);
//        }
//    }

//    // �ִϸ������� IK ����
//    private void OnAnimatorIK(int layerIndex)
//    {
//        GunPivot.position = _animator.GetIKHintPosition(AvatarIKHint.RightElbow);

//        //// �޼�
//        //_animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
//        //_animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandMount.position);
//        //_animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
//        //_animator.SetIKPosition(AvatarIKGoal.RightHand, RightHandMount.position);

//        // ���� �ڵ带 ���̱� ���� Ȯ���Լ��� ����� ��ũ���� Uitle�� Extension�� ����
//        _animator.SetIKPositionAndWeight(AvatarIKGoal.LeftHand, LeftHandMount.position);
//        _animator.SetIKPositionAndWeight(AvatarIKGoal.RightHand, RightHandMount.position);



//        //// ������
//        //_animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
//        //_animator.SetIKRotation(AvatarIKGoal.LeftHand, LeftHandMount.rotation);
//        //_animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
//        //_animator.SetIKRotation(AvatarIKGoal.RightHand, RightHandMount.rotation);

//        // ���� �ڵ带 ���̱� ���� Ȯ���Լ��� ����� ��ũ���� Uitle�� Extension�� ����
//        _animator.SetIKRotationAndWeight(AvatarIKGoal.LeftHand, LeftHandMount.rotation);
//        _animator.SetIKRotationAndWeight(AvatarIKGoal.RightHand, RightHandMount.rotation);

//    }
//}