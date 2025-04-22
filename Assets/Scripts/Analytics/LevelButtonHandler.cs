using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using UnityEngine.UI;

public class LevelButtonHandler : MonoBehaviour
{
    [Header("Level Data")]
    public string[] levelNames = { "Level_1", "Level_2", "Level_3", "Level_4" };  // ใช้ Array เก็บชื่อด่าน

    async void Start()
    {
        if (UnityServices.State != ServicesInitializationState.Initialized)
        {
            await UnityServices.InitializeAsync();
            Debug.Log("Unity Services Initialized");
        }
    }

    public void OnLevelButtonClicked(int levelIndex)
    {
        // ดึงชื่อด่านจาก array ตาม index ที่กด
        string levelName = levelNames[levelIndex];

        int replayCount = PlayerPrefs.GetInt($"ReplayCount_{levelName}", 0);
        replayCount++;

        PlayerPrefs.SetInt($"ReplayCount_{levelName}", replayCount);
        PlayerPrefs.Save();

        CustomEvent replayLevel = new CustomEvent("level_replay")
        {
            { "level", levelName },
            { "replay_count", replayCount },
            { "button_id", $"Button_{levelName}" }
        };

        AnalyticsService.Instance.RecordEvent(replayLevel);

        Debug.Log($"[Analytics] Button {levelName} clicked | Replay Count: {replayCount}");
    }
}
