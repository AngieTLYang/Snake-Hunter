using UnityEngine;
using UnityEngine.Events;

public class VenomController : MonoBehaviour
{
    public int _currentVenom { get; private set; }

    public UnityEvent OnVenomCollected, OnVenomUsed;

    public void AddVenom()
    {
        _currentVenom++;
        OnVenomCollected.Invoke();
    }

    public void UseVenom()
    {
        _currentVenom--;
        OnVenomUsed.Invoke();
    }
}
