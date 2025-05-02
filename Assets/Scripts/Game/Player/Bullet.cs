using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        DestroyWhenOffScreen();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Debug.Log("collision.gameObject.layer == LayerMask.NameToLayer(\"Wall\")");
            Destroy(gameObject);
        }
        if (collision.GetComponent<EnemyMovement>() || collision.GetComponent<EnemyWander>())
        {
            Debug.Log("collision.GetComponent<EnemyMovement>() || collision.GetComponent<EnemyWander>()");
            HealthController healthController = collision.GetComponent<HealthController>();
            healthController.TakeDamage(10);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void DestroyWhenOffScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < 0 || screenPosition.x > _camera.pixelWidth ||
            screenPosition.y < 0 || screenPosition.y > _camera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }
}
