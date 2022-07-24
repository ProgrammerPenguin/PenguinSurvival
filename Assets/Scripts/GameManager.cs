using UnityEngine;

// ������ ���� ���� ���θ� �����ϴ� ���� �Ŵ���
public class GameManager : Singleton<GameManager>
{

    private int _score = 0; // ���� ���� ����
    public bool IsGameover { get; private set; } // ���� ���� ����

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