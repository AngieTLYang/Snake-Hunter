using UnityEngine;

public class Collectable : MonoBehaviour
{
    private ICollectableBehaviour _collectableBehaviour;

    private void Awake()
    {
        _collectableBehaviour = GetComponent<ICollectableBehaviour>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement>();
        Debug.Log(gameObject.name + "collision.GetComponent<PlayerMovement>");
        if (player != null)
        {
            _collectableBehaviour.OnCollected(player.gameObject);
            Debug.Log(gameObject.name + "collected");
            Destroy(gameObject);
        }
    }
}
