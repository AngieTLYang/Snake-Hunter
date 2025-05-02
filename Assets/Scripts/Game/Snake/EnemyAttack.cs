using TMPro;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private int _damageAmount;
    [SerializeField]
    private int _venomDamageAmount;

    [SerializeField]
    private GameObject __venomPrefab;
    [SerializeField]
    private float _venomSpeed;
    [SerializeField]
    private float _venomCooldown = 0f; // Time between venom attacks

    private float _venomCooldownTimer;

    private PlayerAwarenessController _playerAwarenessController;

    private void Awake()
    {
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
    }

    private void Update()
    {
        _venomCooldownTimer -= Time.deltaTime;
        if (_playerAwarenessController.CloseToPlayer && _venomCooldownTimer <= 0f)
        {
            SpitVenom();
            _venomCooldownTimer = _venomCooldown;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.TakeDamage(_damageAmount);
        }
    }

    private void SpitVenom()
    {
        Debug.Log("spit venom");
        GameObject venom = Instantiate(__venomPrefab, transform.position, transform.rotation);
        Rigidbody2D rigidbody = venom.GetComponent<Rigidbody2D>();
        rigidbody.linearVelocity = _venomSpeed * transform.up;

        Venom venomScript = venom.GetComponent<Venom>();
        if (venomScript != null)
        {
            venomScript.SetDamage(_venomDamageAmount); // Cast to int if needed
        }
    }
}
