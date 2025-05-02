using UnityEngine;

public class AddHealth : MonoBehaviour
{
    private VenomController _venomController;
    private HorseController _horseController;
    private HealthController _healthController;
    private void Awake()
    {
        _venomController = GetComponent<VenomController>();
        _horseController = GetComponent<HorseController>();
        _healthController = GetComponent<HealthController>();

    }
    public void addHealth()
    {
        if (_venomController != null && _horseController != null)
        {
            int currentVenom = _venomController._currentVenom;
            int currentHorse = _horseController._currentHorse;
            if(currentVenom > 0 && currentHorse > 0)
            {
                _healthController.AddHealth(10);
                _venomController.UseVenom();
                _horseController.UseHorse();
            }
        }
    }
}
