using UnityEngine;
using UnityEngine.Events;
public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private int _targetScore;
    public int TargetScore => _targetScore;
    public int Score { get; private set; }

    public UnityEvent OnScoreChanged;
    public UnityEvent OnLevelUp;
    public void AddScore(int amount)
    {
        Score += amount;
        OnScoreChanged.Invoke();
        if(Score >= _targetScore)
        {
            OnLevelUp.Invoke();
        }
    }
}
