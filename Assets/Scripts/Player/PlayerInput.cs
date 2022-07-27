using UnityEngine;

// �÷��̾� ĳ���͸� �����ϱ� ���� ����� �Է��� ����
// ������ �Է°��� �ٸ� ������Ʈ���� ����� �� �ֵ��� ����
public class PlayerInput : MonoBehaviour
{
    public string MoveAxisName = "Vertical"; // �յ� �������� ���� �Է��� �̸�
    public string RotateAxisName = "Horizontal"; // �¿� ȸ���� ���� �Է��� �̸�

    
    // �� �Ҵ��� ���ο����� ����
    public float MoveDirection { get; private set; } // ������ ������ �Է°�
    public float RotateDirection { get; private set; } // ������ ȸ�� �Է°�

    // �������� ����� �Է��� ����
    private void Update()
    {
        // ���ӿ��� ���¿����� ����� �Է��� �������� �ʴ´�
        //if (GameManager.Instance.IsGameover)
        //{
        //    MoveDirection = 0;
        //    RotateDirection = 0;

        //    return;
        //}

        // move�� ���� �Է� ����
        MoveDirection = Input.GetAxis(MoveAxisName);
        // rotate�� ���� �Է� ����
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