using UnityEngine;

// ������ ���� ���� ���θ� �����ϴ� ���� �Ŵ���
public class GameManager : Singleton<GameManager>
{

    private int _score = 0; // ���� ���� ����
    public Animator _anim { get; private set; }
   
    public bool IsGameover { get; private set; } // ���� ���� ����

    public Transform PlayerTransform;
    public GameObject FireTransform;

    public float MinDistance;
    public float MaxDistance;

    private void Start()
    {
        //PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // public GameObject Player;


    // ������ �߰��ϰ� UI ����
    public void AddScore(int newScore)
    {
        // ���� ������ �ƴ� ���¿����� ���� ���� ����
        if (!IsGameover)
        {
            // ���� �߰�
            _score += newScore;
            // ���� UI �ؽ�Ʈ ����
            //UIManager.instance.UpdateScoreText(_score);
        }
    }

    // ���� ���� ó��
    public void EndGame()
    {
        // ���� ���� ���¸� ������ ����
        IsGameover = true;
        // ���� ���� UI�� Ȱ��ȭ
        //UIManager.instance.SetActiveGameoverUI(true);
    }
}