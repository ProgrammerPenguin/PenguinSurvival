using UnityEngine;

// 플레이어 캐릭터를 조작하기 위한 사용자 입력을 감지
// 감지된 입력값을 다른 컴포넌트들이 사용할 수 있도록 제공
public class PlayerInput : MonoBehaviour
{
    public string MoveAxisName = "Vertical"; // 앞뒤 움직임을 위한 입력축 이름
    public string RotateAxisName = "Horizontal"; // 좌우 회전을 위한 입력축 이름

    
    // 값 할당은 내부에서만 가능
    public float MoveDirection { get; private set; } // 감지된 움직임 입력값
    public float RotateDirection { get; private set; } // 감지된 회전 입력값

    // 매프레임 사용자 입력을 감지
    private void Update()
    {
        // 게임오버 상태에서는 사용자 입력을 감지하지 않는다
        //if (GameManager.Instance.IsGameover)
        //{
        //    MoveDirection = 0;
        //    RotateDirection = 0;

        //    return;
        //}

        // move에 관한 입력 감지
        MoveDirection = Input.GetAxis(MoveAxisName);
        // rotate에 관한 입력 감지
        RotateDirection = Input.GetAxis(RotateAxisName);

        

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Attack();
        //Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
        Vector3 mPosition = Input.mousePosition;
        Vector3 oPosition = transform.position;
        //mPosition.y = oPosition.y - Camera.main.transform.position.y;
        //Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (GroupPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointTolook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));

        }
    }

    //public void Attack()
    //{
    //    if (_weapon == null)
    //    {
    //        return;
    //    }
    //    FireDelay += Time.deltaTime;
    //    isFireReady = _weapon.rate < FireDelay;

    //    if (isFireReady && fDown)
    //    {
    //        _weapon.Use();
    //        _anim.SetTrigger(PlayerAnimID.Attack);
    //        FireDelay = 0;
    //    }
    //}
}