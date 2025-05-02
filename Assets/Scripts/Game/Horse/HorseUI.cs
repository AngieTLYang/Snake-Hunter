using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class HorseUI : MonoBehaviour
{
    private TMP_Text _horseCountText;
    public int _currentHorse { get; private set; }

    private void Awake()
    {
        _horseCountText = GetComponent<TMP_Text>();
    }

    public void AddHorseCount()
    {
        _currentHorse++;
        _horseCountText.text = $"Horse Count : {_currentHorse}";
    }

    public void DeduceHorseCount()
    {
        _currentHorse--;
        _horseCountText.text = $"Horse Count : {_currentHorse}";
    }
}
