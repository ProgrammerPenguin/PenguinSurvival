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

    // �Է°��� ���� ĳ���͸� �յڷ� ������
    private void move()
    {
        //// �Ÿ� = �ӷ� * �ð�
        //float movementAmount = MoveSpeed * Time.fixedDeltaTime;
        //// ������ ĳ���� �����̴�
        //Vector3 directoin = _input.MoveDirection * transform.forward;
        //Vector3 offset = movementAmount * directoin;
        float accelerationX = MoveSpeed * _input.RotateDirection;
        float accelerationZ = MoveSpeed * _input.MoveDirection;
        // ����Ƽ�� ����ȭ �� ��������� �߿��ϴ�. ���ʺ��� ���������� �Ǵµ�
        // �Ʒ� �Ŀ����� float �� Vector3 �� ���궧���� �׷���. ���Ϳ����� Ƚ�� �����̴�.
        //Vector3 deltaPosition = transform.forward * MoveSpeed * _input.MoveDirection * Time.fixedDeltaTime;
        //Vector3 deltaPosition2 = transform.forward * MoveSpeed * _input.RotateDirection * Time.fixedDeltaTime;

        //_rigidbody.MovePosition(_rigidbody.position + deltaPosition + deltaPosition2);
        _rigidbody.velocity = new Vector3(accelerationX, _rigidbody.velocity.y , accelerationZ);
    }

    // �Է°��� ���� ĳ���͸� �¿�� ȸ��
    //private void rotate()
    //{
    //    float rotationAmount = _input.RotateDirection * RotateSpeed * Time.fixedDeltaTime;

    //    Quaternion deltaRotation = Quaternion.Euler(0f, rotationAmount, 0f);
    //    _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
    //}
}