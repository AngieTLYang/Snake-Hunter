using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level1 : MonoBehaviour
{
    public static Level1 instance;
    public GameLevel level;
    public GameObject enemyPrefab;

    [SerializeField]
    private int _timeToWaitBeforeExit;
    public Animator transition;
    private void Awake()
    {
        instance = this;
    }
    public void LevelUp()
    {
        Debug.Log("LevelUp");
        StartCoroutine(LoadLevel2AfterDelay());
    }

    private IEnumerator LoadLevel2AfterDelay()
    {
        Debug.Log("transition.SetTrigger(\"levelup\");");
        transition.SetTrigger("levelup");
        yield return new WaitForSeconds(1f);
        Debug.Log("Now loading scene");
        SceneManager.LoadScene("Level2");
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