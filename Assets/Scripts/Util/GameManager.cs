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
    public GameObject DogWarriorSpawner;
    public GameObject GruntSpawner;
    public GameObject SpearManSpawner;
    public GameObject GolemSpawner;
    public PlayerHealth playerHealth;
    public PlayerInput playerInput;
    public PlayerLevel playerLevel;
    public PlayerAttack playerAttack;
    public float playTime;
    public bool isBattle;

    public GameObject TitleUI;
    public GameObject GameUI;
    public GameObject FirstChooseUI;
    public GameObject MenuUI;
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
        FirstChooseUI.SetActive(true);
        TitleUI.SetActive(false);

        ////MonsterSpawner.SetActive(true);
        //playerInput.enabled = true;
        //isBattle = true;
    }

    public void SwordChoose()
    {
        playerAttack._Meleeweapon.SetActive(true);
        MonsterSpawner.SetActive(true);
        playerInput.enabled = true;
        isBattle = true;
        FirstChooseUI.SetActive(false);
        TitleCam.SetActive(false);
        GameCam.SetActive(true);

        //TitleUI.SetActive(false);
        GameUI.SetActive(true);
    }

    public void GunChoose()
    {
        playerAttack._Rangeweapon.SetActive(true);
        MonsterSpawner.SetActive(true);
        playerInput.enabled = true;
        isBattle = true;
        FirstChooseUI.SetActive(false);
        TitleCam.SetActive(false);
        GameCam.SetActive(true);

       // TitleUI.SetActive(false);
        GameUI.SetActive(true);
    }

    public void MagicChoose()
    {
        playerAttack._Magicweapon.SetActive(true);
        MonsterSpawner.SetActive(true);
        playerInput.enabled = true;
        isBattle = true;
        FirstChooseUI.SetActive(false);
        TitleCam.SetActive(false);
        GameCam.SetActive(true);

       // TitleUI.SetActive(false);
        GameUI.SetActive(true);
    }
    private void Update()
    {
        if(isBattle)
        {
            playTime += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _magic.rate -= 0.1f;
            _range.rate -= 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            _magic.rate += 0.1f;
            _range.rate += 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            playerAttack._Meleeweapon.SetActive(true);
            playerAttack._Rangeweapon.SetActive(false);
            playerAttack._Magicweapon.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            playerAttack._Meleeweapon.SetActive(false);
            playerAttack._Rangeweapon.SetActive(true);
            playerAttack._Magicweapon.SetActive(false); ;
        }

        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            playerAttack._Meleeweapon.SetActive(false);
            playerAttack._Rangeweapon.SetActive(false);
            playerAttack._Magicweapon.SetActive(true);
        }

        if (playTime > 10f)
        {
            DogWarriorSpawner.SetActive(true);
            GruntSpawner.SetActive(true);
        }

        if (playTime > 20f)
        {
            GolemSpawner.SetActive(true);
            SpearManSpawner.SetActive(true);
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

    public void ResumeGame()
    {
        MenuUI.SetActive(false);
        Time.timeScale = 1.0f;
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