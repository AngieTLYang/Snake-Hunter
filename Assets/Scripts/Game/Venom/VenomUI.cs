using TMPro;
using UnityEngine;

public class VenomUI : MonoBehaviour
{
    private TMP_Text _venomCountText;
    public int _currentVenom { get; private set; }

    private void Awake()
    {
        _venomCountText = GetComponent<TMP_Text>();
    }

    public void AddVenomCount()
    {
        _currentVenom++;
        _venomCountText.text = $"Venom Count : {_currentVenom}";
    }

    public void DeduceVenomCount()
    {
        _currentVenom--;
        _venomCountText.text = $"Venom Count : {_currentVenom}";
    }
}
