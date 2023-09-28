using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsCalculator : MonoBehaviour
{
    private TextMeshProUGUI text;
    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

        float bestTime = PlayerPrefs.GetFloat("BestTime");
        int bestMinutes = Mathf.FloorToInt(bestTime / 60);
        int bestSeconds = Mathf.FloorToInt(bestTime % 60);
        int bestMS = Mathf.FloorToInt((bestTime * 1000) % 1000);

        text.text = "Total Deaths: " + PlayerPrefs.GetInt("Deaths") + "\n" +
            "Enemies Destroyed: " + PlayerPrefs.GetInt("EnemiesDefeated") + "\n" +
            "Best Time: " + bestMinutes + ":" + bestSeconds + ":" + bestMS;
    }

}
