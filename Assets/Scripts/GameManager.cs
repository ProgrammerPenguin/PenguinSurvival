using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
// ������ ���� ���� ���θ� �����ϴ� ���� �Ŵ���
public class GameManager : Singleton<GameManager>
{

    public GameObject TitleCam;
    public GameObject GameCam;
    public GameObject MonsterSpawner;
    public PlayerInput playerInput;
    public float playTime;
    public bool isBattle;

    public GameObject TitleUI;
    public GameObject GameUI;
    public TextMeshProUGUI LevelTxt;
    public TextMeshProUGUI playTimeTxt;
    public TextMeshProUGUI playerHealth;
    public TextMeshProUGUI playerGold;
    public Image Sword;
    public Image Gun;
    public Image Magic;
    public RectTransform Expercine;
    public RectTransform ExpercineBar;

    public bool IsGameover { get; private set; } // ���� ���� ����

    public Transform PlayerTransform;

    public Range _range;
    public Magic _magic;

    
    private void Start()
    {
        //PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void GameStart()
    {
        TitleCam.SetActive(false);
        GameCam.SetActive(true);

        TitleUI.SetActive(false);
        GameUI.SetActive(true);

        MonsterSpawner.SetActive(true);
        playerInput.enabled = true;
    }

    // ������ �߰��ϰ� UI ����
    public void AddScore(int newScore)
    {
        // ���� ������ �ƴ� ���¿����� ���� ���� ����
        if (!IsGameover)
        {
            // ���� �߰�
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

    public void ExitGame()
    {
        Application.Quit();
    }
}