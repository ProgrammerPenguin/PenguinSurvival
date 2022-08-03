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
    public PlayerHealth playerHealth;
    public PlayerInput playerInput;
    public PlayerLevel playerLevel;
    public PlayerAttack playerAttack;
    public float playTime;
    public bool isBattle;

    public GameObject TitleUI;
    public GameObject GameUI;
    public TextMeshProUGUI PlayerLevelTxt;
    public TextMeshProUGUI playTimeTxt;
    public TextMeshProUGUI playerHealthTxt;
    public TextMeshProUGUI playerGoldTxt;
    public Image SwordImage;
    public Image GunImage;
    public Image MagicImage;
    public Slider Experience;

    public bool IsGameover { get; private set; } // ���� ���� ����

    public Transform PlayerTransform;

    public Range _range;
    public Magic _magic;

    
    private void Start()
    {
        //PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        isBattle = false;
    }

    public void GameStart()
    {
        TitleCam.SetActive(false);
        GameCam.SetActive(true);

        TitleUI.SetActive(false);
        GameUI.SetActive(true);

        //MonsterSpawner.SetActive(true);
        playerInput.enabled = true;
        isBattle = true;
    }

    private void Update()
    {
        if(isBattle)
        {
            playTime += Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        PlayerLevelTxt.text = "" + playerLevel.PlayerCurrentLevel;
        
        playerHealthTxt.text = playerHealth.CurrentHealth + "/" + playerHealth.InitialHealth;
        playerGoldTxt.text = "" + playerLevel.PlayerGold;
        int hour = (int)(playTime / 3600);
        int min = (int)((playTime - hour * 3600) / 60);
        int second = (int)playTime % 60;
        playTimeTxt.text = hour + ":" + min + ":" + second;
        if (playerAttack._Meleeweapon.activeSelf == true)
        {
            SwordImage.enabled = true;
        }
        if (playerAttack._Rangeweapon.activeSelf == true)
        {
            GunImage.enabled = true;
        }
        if (playerAttack._Magicweapon.activeSelf == true)
        {
            MagicImage.enabled = true;
        }

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