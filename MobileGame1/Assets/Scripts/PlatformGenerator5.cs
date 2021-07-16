using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator5 : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_PLATFORM = 20f;

    //[SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> woodPartList;
    [SerializeField] private List<Transform> girderPartList;
    [SerializeField] private List<Transform> cloudPartList;
    [SerializeField] private List<Transform> steelPartList;
    [SerializeField] private Rigidbody2D player;

    private Transform lastLevelPartTransform;
    private Vector3 lastEndPosition;
    private int currentFloor;
    public float xPosition;
    public float floorGapScreenPercentage;
    public List<int> platformGapLengths;
    private float height;
    private Vector2 screenBounds;

    private void Awake() {
        
        currentFloor = 5;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        height = -screenBounds.y * 1.17f + currentFloor * floorGapScreenPercentage * screenBounds.y;
        lastLevelPartTransform = SpawnLevelPart(LevelPart(currentFloor), new Vector3(xPosition, height, 0));

        int startingSpawnLevelParts = 3;
        for (int i = 0; i < startingSpawnLevelParts; i++) {
            SpawnLevelPart();
        }
    }

    private void Update() {
        if (Vector3.Distance(transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_PLATFORM) {
            // Spawn another level part
            Debug.Log("SPAWNING5");
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart() {
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position + new Vector3(platformGapLengths[Random.Range(0, platformGapLengths.Count)], 0, 0);
        Transform chosenLevelPart = LevelPart(currentFloor);
        lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition) {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

    private Transform LevelPart(int currentFloor) {
        //This is used to determine the tilemap being used. Determinant on currentFloor
        if (currentFloor >= 60) {
            return steelPartList[Random.Range(0, steelPartList.Count)];
        } else if (currentFloor >= 40) {
            return cloudPartList[Random.Range(0, cloudPartList.Count)];
        } else if (currentFloor >= 20) {
            return girderPartList[Random.Range(0, girderPartList.Count)];
        } else {
            return woodPartList[Random.Range(0, woodPartList.Count)];
        }
    }

    public Vector3 getLastEndPosition() {
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position + new Vector3(5, 0, 0);
        return lastEndPosition;
    }
    
    public void SetPosition(float x, float y) {
        xPosition = x;
        height = y;
    }
}