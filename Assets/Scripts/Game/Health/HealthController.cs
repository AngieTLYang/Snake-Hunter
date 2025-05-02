using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maximumHealth;
    private VenomController _venomController;
    private HorseController _horseController;

    private void Awake()
    {
        _venomController = GetComponent<VenomController>();
        _horseController = GetComponent<HorseController>();
    }

    public float GetCurrentHealth
    {
        get
        {
            return _currentHealth;
        }
    }
    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maximumHealth;
        }
    }

    public bool IsInvincible { get; set; }

    public UnityEvent OnDied;
    public UnityEvent OnDamaged;
    public UnityEvent OnHealthChange;
    public void TakeDamage(int damageAmount)
    {
        Debug.Log(gameObject.name + " TakeDamage.");

        if (_currentHealth == 0)
        {
            return;
        }
        if (IsInvincible)
        {
            return;
        }
        _currentHealth -= damageAmount;

        OnHealthChange.Invoke();
        Debug.Log(gameObject.name + "OnHealthChange.Invoke();");

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
        if(_currentHealth == 0)
        {
            OnDied.Invoke();
            Debug.Log(gameObject.name + " has died.");
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(int amountToAdd)
    {
        if (_venomController != null && _horseController != null)
        {
            int currentVenom = _venomController._currentVenom;
            int currentHorse = _horseController._currentHorse;
            if (currentVenom > 0 && currentHorse > 0)
            {
                _currentHealth += amountToAdd;
                _venomController.UseVenom();
                _horseController.UseHorse();
                OnHealthChange.Invoke();
            }
        }
        //if(_currentHealth == _maximumHealth)
        //{
        //    return;
        //}
        //_currentHealth += amountToAdd;

        //OnHealthChange.Invoke();
        //if(_currentHealth > _maximumHealth)
        //{
        //    _currentHealth = _maximumHealth;
        //}
    }
}
