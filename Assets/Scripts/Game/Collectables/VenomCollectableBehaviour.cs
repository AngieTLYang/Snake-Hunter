using UnityEngine;
using UnityEngine.Events;

public class VenomCollectableBehaviour : MonoBehaviour, ICollectableBehaviour
{
    public UnityEvent OnVenomCollected;
    public void OnCollected(GameObject Player)
    {
        OnVenomCollected.Invoke();
        Player.GetComponent<VenomController>().AddVenom();
    }
}
