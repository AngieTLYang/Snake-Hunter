using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameLevel level;
    public SpriteRenderer backgroundRenderer;
    public GameObject enemyPrefab;

    [SerializeField]
    private float _timeToWaitBeforeExit;

    private Color targetColor;
    private Color baseColor;
    private float lerpSpeed = 0.5f; // Smoothness (lower = smoother)
    private float variationSpeed = 0.5f; // Speed of color variation (higher = faster fluctuation)
    private float hueVariation = 0.3f; // Max variation range for hue (can be adjusted)

    // Define main colors for each level
    private Color firstLevelColor = new Color(1f, 0f, 0f); // Red for FirstLevel
    private Color secondLevelColor = new Color(0f, 1f, 0f); // Green for SecondLevel
    private Color thirdLevelColor = new Color(0f, 0f, 1f); // Blue for ThirdLevel

    private void Awake()
    {
        instance = this;
        level = GameLevel.FirstLevel;
        SetMainColor(); // Set the initial color for the first level
    }

    private void Update()
    {
        // Smoothly transition between the current background color and the target color
        backgroundRenderer.color = Color.Lerp(backgroundRenderer.color, targetColor, lerpSpeed * Time.deltaTime);

        // Continuously update the color with slight variations
        UpdateColorVariation();
    }

    private void UpdateColorVariation()
    {
        // Randomly adjust the hue within the specified range around the base color
        float randomHueShift = Random.Range(-hueVariation, hueVariation);

        // Convert the base color to HSL and apply the variation
        Color.RGBToHSV(baseColor, out float h, out float s, out float v);
        h += randomHueShift;

        // Ensure hue stays within [0, 1] range
        h = Mathf.Repeat(h, 1f);

        // Set the new color with the adjusted hue (keep saturation and value the same)
        targetColor = Color.HSVToRGB(h, s, v);
    }

    public void LevelUp()
    {
        switch (level)
        {
            case GameLevel.FirstLevel:
                level = GameLevel.SecondLevel;
                Debug.Log("FirstLevel to SecondLevel");
                SpawnEnemy();
                break;
            case GameLevel.SecondLevel:
                level = GameLevel.ThirdLevel;
                Debug.Log("SecondLevel to ThirdLevel");
                break;
            case GameLevel.ThirdLevel:
                Debug.Log("ThirdLevel to finish");
                break;
        }
        SetMainColor();
    }

    private void SetMainColor()
    {
        // Set the main color based on the current level
        switch (level)
        {
            case GameLevel.FirstLevel:
                baseColor = firstLevelColor;
                break;
            case GameLevel.SecondLevel:
                baseColor = secondLevelColor;
                break;
            case GameLevel.ThirdLevel:
                baseColor = thirdLevelColor;
                break;
        }

        // Immediately apply the base color as the target color for transition
        targetColor = baseColor;
    }
    private void SpawnEnemy()
    {
        // Instantiate the enemy prefab at the specified position (left side of the field)
        Vector3 spawnPosition = new Vector3(-10f, 0f, 0f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // Instantiate at spawnPoint
    }

    public void OnPlayerDied()
    {
        Invoke(nameof(EndGame), _timeToWaitBeforeExit);
    }

    private void EndGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

public enum GameLevel
{
    FirstLevel,
    SecondLevel,
    ThirdLevel
}
