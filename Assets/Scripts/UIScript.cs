using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIScript : MonoBehaviour
{
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;

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

    internal void UpdateMap(int currentLevel, MenuController mc)
    {
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        MusicController music = FindObjectOfType<MusicController>();

        if (currentLevel == 5)
        {
            enemySpawner.SetSpawnInterval(0.1f);
            music.PlayLevel5();
            level1.SetActive(false);
            level2.SetActive(true);
        }
        if (currentLevel == 10)
        {
            enemySpawner.SetSpawnInterval(0.05f);
            music.PlayLevel10();
            level2.SetActive(false);
            level3.SetActive(true);
        }
        if (currentLevel == 15)
        {
            mc.SwitchScene("Victory");
            Destroy(gameObject);
        }
    }
}
