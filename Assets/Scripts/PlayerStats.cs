using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int fatValue = 100;
    public int FatValue { get { return fatValue; } }

    [SerializeField] private TextMeshProUGUI fatValueText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        fatValueText.text = "Fat: " + fatValue.ToString();
    }

    public void ReduceFat(int fat)
    {
        fatValue -= fat;
        fatValue = Mathf.Max(fatValue, 0);
        UpdateUI();
    }

    public void IncreaseFat(int fat)
    {
        fatValue += fat;
        UpdateUI();
    }
}
