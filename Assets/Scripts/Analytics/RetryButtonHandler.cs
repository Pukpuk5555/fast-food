using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using UnityEngine.UI;

public class RetryButtonHandler : MonoBehaviour
{
    [Header("�����Ŵ�ҹ")]
    public string[] levelNames = { "Level_1", "Level_2", "Level_3", "Level_4" };  // �� Array �纪��ʹ�ҹ

    async void Start()
    {
        if (UnityServices.State != ServicesInitializationState.Initialized)
        {
            await UnityServices.InitializeAsync();
            Debug.Log("Unity Services Initialized");
        }
    }

    // �ѧ��ѹ���١�Ѻ���� Try Again
    public void OnRetryButtonClicked(int levelIndex)
    {
        // �֧���ʹ�ҹ�ҡ array ��� index ��衴
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
