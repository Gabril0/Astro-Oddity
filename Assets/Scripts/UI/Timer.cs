using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float time;
    private TextMeshProUGUI text;

    public float Time { get => time; set => time = value; }

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

        PlayerDataManager playerDataManager = GameObject.Find("PlayerDataManager")?.GetComponent<PlayerDataManager>();
        PlayerData playerData = playerDataManager.playerData;
        Time = playerData.totalTime;
    }

    void Update()
    {
        Time += UnityEngine.Time.deltaTime;

        int minutes = Mathf.FloorToInt(Time / 60);
        int seconds = Mathf.FloorToInt(Time % 60);
        int ms = Mathf.FloorToInt((Time * 1000) % 1000);

        string formatedTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, ms);

        text.text = formatedTime;
    }
}
