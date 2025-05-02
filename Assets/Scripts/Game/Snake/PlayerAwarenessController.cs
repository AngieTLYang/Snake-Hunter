using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }
    public bool CloseToPlayer { get; private set; }
    public Vector2 DirectionToPlayer {  get; private set; }

    [SerializeField]
    private float _playerAwarenessDistance;

    [SerializeField]
    private float _playerCloseDistance;

    private Transform _player;

    private void Awake()
    {
        _player = FindFirstObjectByType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;
        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }

        if(enemyToPlayerVector.magnitude <= _playerCloseDistance)
        {
            CloseToPlayer = true;
        }
        else
        {
            CloseToPlayer = false;
        }
    }
}
