using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
// 점수와 게임 오버 여부를 관리하는 게임 매니저
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

    public bool IsGameover { get; private set; } // 게임 오버 상태

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

    // 점수를 추가하고 UI 갱신
    public void AddScore(int newScore)
    {
        // 게임 오버가 아닌 상태에서만 점수 증가 가능
        if (!IsGameover)
        {
            // 점수 추가
            // 점수 UI 텍스트 갱신
            //UIManager.instance.UpdateScoreText(_score);
        }
    }

    // 게임 오버 처리
    public void EndGame()
    {
        // 게임 오버 상태를 참으로 변경
        IsGameover = true;
        // 게임 오버 UI를 활성화
        //UIManager.instance.SetActiveGameoverUI(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}