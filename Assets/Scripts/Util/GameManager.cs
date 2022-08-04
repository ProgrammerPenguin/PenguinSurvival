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

    public bool IsGameover { get; private set; } // 게임 오버 상태

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

    public void ResumeGame()
    {
        MenuUI.SetActive(false);
        Time.timeScale = 1.0f;
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