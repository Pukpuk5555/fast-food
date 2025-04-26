using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using UnityEngine.UI;

public class RetryButtonHandler : MonoBehaviour
{
    [Header("ข้อมูลด่าน")]
    public string[] levelNames = { "Level_1", "Level_2", "Level_3", "Level_4" };  // ใช้ Array เก็บชื่อด่าน

    async void Start()
    {
        if (UnityServices.State != ServicesInitializationState.Initialized)
        {
            await UnityServices.InitializeAsync();
            Debug.Log("Unity Services Initialized");
        }
    }

    // ฟังก์ชันที่ผูกกับปุ่ม Try Again
    public void OnRetryButtonClicked(int levelIndex)
    {
        // ดึงชื่อด่านจาก array ตาม index ที่กด
        string levelName = levelNames[levelIndex];

        int retryCount = PlayerPrefs.GetInt($"RetryCount_{levelName}", 0);
        retryCount++;

        PlayerPrefs.SetInt($"RetryCount_{levelName}", retryCount);
        PlayerPrefs.Save();

        CustomEvent retryLevel = new CustomEvent("level_retry")
        {
            { "level", levelName },
            { "retry_count", retryCount },
            { "button_id", $"RetryButton_{levelName}" }
        };

        AnalyticsService.Instance.RecordEvent(retryLevel);

        Debug.Log($"[Analytics] Button {levelName} Retry clicked | Retry Count: {retryCount}");
    }
}
