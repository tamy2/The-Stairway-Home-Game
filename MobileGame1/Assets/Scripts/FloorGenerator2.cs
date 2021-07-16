using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator2 : MonoBehaviour
{

    //[SerializeField] private Transform levelPart_Start;
    [SerializeField] private PlatformGenerator1 platformGenerator1;
    [SerializeField] private PlatformGenerator2 platformGenerator2;
    [SerializeField] private PlatformGenerator3 platformGenerator3;
    [SerializeField] private PlatformGenerator4 platformGenerator4;
    //PlatformGenerator5 will be the one that's constantly spawned
    [SerializeField] private PlatformGenerator5 platformGenerator5;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Transform ground;
    private PlatformGenerator5 lastFloorPart;
    private float lastEndXPosition;
    private float lastEndHeight;
    private int currentFloor;
    public float floorGapHeight;
    public float xPosition;
    public float lowestPlatformHeight;

    private void Awake() {
        currentFloor = 0;
        //lastFloorPart = SpawnFloor(xPosition, lowestPlatformHeight);
        //lastEndXPosition =  lastFloorPart.getLastEndPosition().x;
        //lastEndHeight = lastFloorPart.getLastEndPosition().y + floorGapHeight;
        //numberOfFloorsSpawned = 0;

        //int startingSpawnFloors = 3;
        for (int i = 1; i <= 5; i++) {
            SpawnFloor(i);
        }
    }

    private void Update() {
        //THIS IS THE KEY THING TO CHANGE
        if (transform.position.y - lastEndHeight < floorGapHeight) {
            // Spawn another level part
            SpawnFloor(5);
        }
    }

    private void SpawnFloor(int whichGenerator) {
        float currentXPositionToSpawn = transform.position.x - 20;
        switch (whichGenerator) {
            case 1:
                Instantiate(platformGenerator1);
                break;
            case 2:
                Instantiate(platformGenerator2);
                break;
            case 3:
                Instantiate(platformGenerator3);
                break;
            case 4:
                Instantiate(platformGenerator4);
                break;
            case 5:
                lastFloorPart = Instantiate(platformGenerator5);
                lastEndHeight = lastFloorPart.getLastEndPosition().y + floorGapHeight;
                break;
        }
    }

    /*private PlatformGenerator SpawnFloor(float spawnXPosition, float spawnHeight) {
        PlatformGenerator floorPart = Instantiate(platformGenerator5);
        return floorPart;
    }*/
}