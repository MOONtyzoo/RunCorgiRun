using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreFloaterSpawner : MonoBehaviour
{
    public static ScoreFloaterSpawner Instance {get; private set;}
    
    [SerializeField] private Transform scoreFloaterPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("More than one ScoreFloaterSpawner in scene!");
            Destroy(gameObject);
        }
    }

    public void SpawnScoreFloater(Vector3 spawnPosition, float value)
    {
        Transform scoreFloater = Instantiate(scoreFloaterPrefab, spawnPosition, Quaternion.identity, transform);
        string symbol = value > 0 ? "+" : "";
        scoreFloater.GetComponentInChildren<TextMeshPro>().text = $"{symbol}{value}";
        Destroy(scoreFloater.gameObject, 0.833f);
    }
}
