using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    public Slider ExperienceSlider;
    public int PlayerCurrentLevel;
    public int PlayerCurrentExperience;
    public int PlayerMaxExperience;
    public int PlayerGold;

    private int OverExperience;
    private void OnEnable()
    {

    }
    private void Update()
    {
        ExperienceSlider.maxValue = PlayerMaxExperience;
        ExperienceSlider.value = PlayerCurrentExperience;
        if (PlayerCurrentExperience >= PlayerMaxExperience)
        {
            OverExperience = PlayerCurrentExperience - PlayerMaxExperience;
            ++PlayerCurrentLevel;
            PlayerMaxExperience += 100;
            PlayerCurrentExperience = OverExperience;
        }
    }

    void LevelUp()
    {

    }
}
