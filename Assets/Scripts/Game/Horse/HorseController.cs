using UnityEngine;
using UnityEngine.Events;

public class HorseController : MonoBehaviour
{
    public int _currentHorse { get; private set; }

    public UnityEvent OnHorseCollected, OnHorseUsed;

    public void AddHorse()
    {
        _currentHorse++;
        Debug.Log("OnHorseAdded");
        OnHorseCollected.Invoke();
    }

    public void UseHorse()
    {
        _currentHorse--;
        Debug.Log("OnHorseUsed");
        OnHorseUsed.Invoke();
    }
}
