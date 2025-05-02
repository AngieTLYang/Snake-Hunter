using UnityEngine;
using UnityEngine.Events;

public class HealthCollectableBehaviour : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField]
    private int _healthAmount;

    public UnityEvent OnHealthKitCollected;
    public void OnCollected(GameObject Player)
    {
        OnHealthKitCollected.Invoke();
        Player.GetComponent<HealthController>().AddHealth(_healthAmount);
    }
}
