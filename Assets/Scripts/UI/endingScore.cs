using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class endingScore : MonoBehaviour
{
    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        float bestTime = PlayerPrefs.GetFloat("BestTime");
        int bestMinutes = Mathf.FloorToInt(bestTime / 60);
        int bestSeconds = Mathf.FloorToInt(bestTime % 60);
        int bestMS = Mathf.FloorToInt((bestTime * 1000) % 1000);

        PlayerDataManager playerDataManager = GameObject.Find("PlayerDataManager")?.GetComponent<PlayerDataManager>();
        PlayerData playerData = playerDataManager.playerData;

        float yourTime = playerData.totalTime;
        int yourMinutes = Mathf.FloorToInt(yourTime / 60);
        int yourSeconds = Mathf.FloorToInt(yourTime % 60);
        int yourMS = Mathf.FloorToInt((yourTime * 1000) % 1000);

        string formattedTime = string.Format("BEST TIME: {0:00}:{1:00}:{2:000}\nYOUR TIME: {3:00}:{4:00}:{5:000}",
            bestMinutes, bestSeconds, bestMS, yourMinutes, yourSeconds, yourMS);

        text.text = formattedTime;
    }
}
