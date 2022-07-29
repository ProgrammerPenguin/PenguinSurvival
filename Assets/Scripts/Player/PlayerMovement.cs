using UnityEngine;

// 플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f; // 앞뒤 움직임의 속도
    public float RotateSpeed = 180f; // 좌우 회전 속도

    private PlayerInput _input; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody _rigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator _animator; // 플레이어 캐릭터의 애니메이터

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        // 사용할 컴포넌트들의 참조를 가져오기
    }

    // FixedUpdate는 물리 갱신 주기에 맞춰 실행됨
    private void FixedUpdate()
    {
        // 물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행
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
    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void move()
    {
        
        float accelerationX = MoveSpeed * _input.RotateDirection;
        float accelerationZ = MoveSpeed * _input.MoveDirection;
     
        _rigidbody.velocity = new Vector3(accelerationX, _rigidbody.velocity.y , accelerationZ);
    }


}