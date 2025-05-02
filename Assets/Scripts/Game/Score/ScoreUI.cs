using UnityEngine;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    private TMP_Text _scoreText;
    [SerializeField]
    private GameObject _player;
    private ScoreController _scoreController;
    private void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
        _scoreController = _player.GetComponent<ScoreController>();
        _scoreText.text = $"Score: {_scoreController.Score} / {_scoreController.TargetScore}";
    }

    public void UpdateScore()
    {
        _scoreText.text = $"Score: {_scoreController.Score} / {_scoreController.TargetScore}";
    }
}
