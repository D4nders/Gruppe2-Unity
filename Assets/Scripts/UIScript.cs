using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIScript : MonoBehaviour
{
    public Image experienceFill;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI experienceText;

    public void UpdateExpBar(int totalExp, int previousLevelExp, int nextLevelExp)
    {
        int currentLevelExp = totalExp - previousLevelExp;
        int expToNextLevel = nextLevelExp - previousLevelExp;

        experienceFill.fillAmount = (float)currentLevelExp / expToNextLevel;
        experienceText.text = currentLevelExp + " / " + expToNextLevel;
    }

    public void UpdateLevelText(int level)
    {
        levelText.text = level.ToString();
    }

    public Image healthFill;
    public void UpdateHealthBar(int totalHealth, int health)
    {
        healthFill.fillAmount = (float)health / totalHealth;
    }
}
