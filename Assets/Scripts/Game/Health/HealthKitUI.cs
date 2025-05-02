using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class HealthKitUI : MonoBehaviour
{
    private TMP_Text _healthKitCountText;
    public int _currentHealthKit { get; private set; }

    private void Awake()
    {
        _healthKitCountText = GetComponent<TMP_Text>();
    }

    public void UpdateHealthKitCount()
    {
        _currentHealthKit++;
        _healthKitCountText.text = $"Health Kit Count : {_currentHealthKit}";
    }

}
