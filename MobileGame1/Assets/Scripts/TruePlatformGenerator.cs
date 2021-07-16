using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruePlatformGenerator : MonoBehaviour
{
    [SerializeField] private Transform startingPrefab;
    [SerializeField] private Transform prefab1;
    public Vector3 SpawnPosition;

    private void Awake()
    {
        Debug.Log("Starting");
        Transform lastLevelPartTransform = SpawnLevelPart(SpawnPosition);
        lastLevelPartTransform = SpawnLevelPart(startingPrefab.Find("EndPosition").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
        Debug.Log("Finishing");
    }

    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
        Debug.Log("Spawning");
        Transform levelPartTransform = Instantiate(prefab1, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
