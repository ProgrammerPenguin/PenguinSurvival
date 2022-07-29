using UnityEngine;

// �÷��̾� ĳ���͸� ����� �Է¿� ���� �����̴� ��ũ��Ʈ
public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f; // �յ� �������� �ӵ�
    public float RotateSpeed = 180f; // �¿� ȸ�� �ӵ�

    private PlayerInput _input; // �÷��̾� �Է��� �˷��ִ� ������Ʈ
    private Rigidbody _rigidbody; // �÷��̾� ĳ������ ������ٵ�
    private Animator _animator; // �÷��̾� ĳ������ �ִϸ�����

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        // ����� ������Ʈ���� ������ ��������
    }

    // FixedUpdate�� ���� ���� �ֱ⿡ ���� �����
    private void FixedUpdate()
    {
        // ���� ���� �ֱ⸶�� ������, ȸ��, �ִϸ��̼� ó�� ����
        move();
        FreezeRotation();
        //rotate();
        if (_input.MoveDirection != 0)
        {
            _animator.SetFloat(PlayerAnimID.Move, _input.MoveDirection);
        }
        if (_input.RotateDirection != 0)
        {
            _animator.SetFloat(PlayerAnimID.Move, _input.RotateDirection);
        }
        
        
    }

    void FreezeRotation()
    {
        _rigidbody.angularVelocity = Vector3.zero;
    }
    // �Է°��� ���� ĳ���͸� �յڷ� ������
    private void move()
    {
        
        float accelerationX = MoveSpeed * _input.RotateDirection;
        float accelerationZ = MoveSpeed * _input.MoveDirection;
     
        _rigidbody.velocity = new Vector3(accelerationX, _rigidbody.velocity.y , accelerationZ);
    }


}