using UnityEngine;

public class Venom : MonoBehaviour
{
    private Camera _camera;
    [SerializeField]
    private int _venomDamage;
    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        DestroyWhenOffScreen();
    }
    public void SetDamage(int damage)
    {
        _venomDamage = damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Venom OnTriggerEnter2D");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Debug.Log("collision.gameObject.layer == LayerMask.NameToLayer(\"Wall\")"); 
            Destroy(gameObject);
        }

        if (collision.GetComponent<PlayerMovement>())
        {
            Debug.Log("collision.GetComponent<Player>()");
            HealthController healthController = collision.GetComponent<HealthController>();
            healthController.TakeDamage(_venomDamage);
            //Destroy(collision.gameObject);
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
