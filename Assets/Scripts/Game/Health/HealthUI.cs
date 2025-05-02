using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    private TMP_Text _healthText;
    private HealthController _healthController;

    private void Awake()
    {
        _healthText = GetComponent<TMP_Text>();

    }

    public void UpdateHealthText()
    {
        _healthController = _player.GetComponent<HealthController>();
        _healthController.OnHealthChange.AddListener(UpdateHealthText);
        _healthText.text = $"{_healthController.GetCurrentHealth} / 100";
    }
}
