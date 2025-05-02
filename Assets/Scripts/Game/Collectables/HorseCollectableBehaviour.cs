using UnityEngine;
using UnityEngine.Events;

public class HorseCollectableBehaviour : MonoBehaviour, ICollectableBehaviour
{
    public UnityEvent OnHorseCountChanged;
    public void OnCollected(GameObject Player)
    {
        Debug.Log("OnCollected(GameObject Player)");
        Player.GetComponent<HorseController>().AddHorse();
    }
}
