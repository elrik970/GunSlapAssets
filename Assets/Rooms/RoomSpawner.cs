using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject instantiated;
    public int RoomAmount = 10;
    public GridLayout grid;
    public GameObject FilledInRoom;
    public Tilemap KillMap;
    public GameObject LoadLastRoom;
    public int FailSafeAmount = 100;
    private string Direction = "right";
    public GameObject[] Rooms;
    public Tilemap MainMap;
    public GameObject LastPlaced;
    public int RoomSize;
    public GameObject[,] RoomSpots;
    private Vector2 NextSpot;
    private Vector2 CurrentSpot = new Vector2();
    void Start()
    {
        RoomSpots = new GameObject[RoomAmount*2,RoomAmount*2];
        for (int i = 0; i < RoomAmount*2;i++) {
            for (int j = 0; j < RoomAmount*2;j++)  {
                RoomSpots[i,j] = null;
            }
        }
        CurrentSpot.x = Mathf.FloorToInt (RoomAmount);
        CurrentSpot.y = Mathf.FloorToInt (RoomAmount);
        RoomSpots[(int)CurrentSpot.x,(int)CurrentSpot.y] = LastPlaced;
        int z = 0;
        for (int i = 0; i < RoomAmount;)  
        {  
            Direction = RandomDirection();
            Vector2 TempSpot = MoveInDirection(Direction, CurrentSpot);
            if (TempSpot.x < RoomAmount*2&&TempSpot.x>0&&TempSpot.y < RoomAmount*2&&TempSpot.y > 0) {
                CurrentSpot = TempSpot;
                if (RoomSpots[(int)TempSpot.x,(int)TempSpot.y] == null) {
                    i++;
                    CurrentSpot = TempSpot;
                    if (LoadLastRoom!=null&&i==RoomAmount) {
                        instantiated = (GameObject)GameObject.Instantiate(LoadLastRoom, new Vector3(CurrentSpot.x*RoomSize-(Mathf.FloorToInt (RoomAmount)*RoomSize),CurrentSpot.y*RoomSize-(Mathf.FloorToInt (RoomAmount)*RoomSize),0), Quaternion.identity,transform);
                        CombineTileMaps(instantiated);
                    }
                    else {
                        instantiated = (GameObject)GameObject.Instantiate(FindGoodRoom(Direction), new Vector3(CurrentSpot.x*RoomSize-(Mathf.FloorToInt (RoomAmount)*RoomSize),CurrentSpot.y*RoomSize-(Mathf.FloorToInt (RoomAmount)*RoomSize),0), Quaternion.identity,transform);
                        CombineTileMaps(instantiated);
                    }
                    RoomSpots[(int)CurrentSpot.x,(int)CurrentSpot.y] = instantiated;
                    LastPlaced = instantiated;
                }
                else {
                    LastPlaced = RoomSpots[(int)CurrentSpot.x,(int)CurrentSpot.y];
                    Debug.Log("AlreadyBeenThere");
                }
            }
            z++;
            if (z > RoomAmount * FailSafeAmount) {
                Debug.LogWarning("Fail Safe Activated, took too long to generate rooms. BTW I'M ELRIK");
                break;
            }
            
        } 
        AddWalls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    string RandomDirection() {
        // Component[] AllDoors = LastPlaced.GetComponentsInChildren<Doors>();
        Doors[] AllDoors = LastPlaced.GetComponent<AllDoors>().AllDoorsChildren;
        // foreach (Doors Door in AllDoors) {
        //     DoorDirections+=1;
        // }
        int DoorDirections = AllDoors.Length;
        string[] PossibleDirections = new string[AllDoors.Length*2];
        DoorDirections = 0;
        foreach (Doors Door2 in AllDoors) {
            if (Door2.right) {
                Vector2 Spot = MoveInDirection("right",CurrentSpot);
                if (RoomSpots[(int)Spot.x,(int)Spot.y]==null) {
                    PossibleDirections[DoorDirections] = "right";
                    DoorDirections+=1;
                    PossibleDirections[DoorDirections] = "right";
                    DoorDirections+=1;
                }
                // else {
                //     PossibleDirections[DoorDirections] = "right";
                //     DoorDirections+=1;
                // }
            }
            if (Door2.left) {
                Vector2 Spot = MoveInDirection("left",CurrentSpot);
                if (RoomSpots[(int)Spot.x,(int)Spot.y]==null) {
                    PossibleDirections[DoorDirections] = "left";
                    DoorDirections+=1;
                    PossibleDirections[DoorDirections] = "left";
                    DoorDirections+=1;
                }
                // else {
                //     PossibleDirections[DoorDirections] = "left";
                //     DoorDirections+=1;
                // }
            }
            if (Door2.up) {
                Vector2 Spot = MoveInDirection("up",CurrentSpot);
                if (RoomSpots[(int)Spot.x,(int)Spot.y]==null) {
                    PossibleDirections[DoorDirections] = "up";
                    DoorDirections+=1;
                    PossibleDirections[DoorDirections] = "up";
                    DoorDirections+=1;
                }
                // else {
                //     PossibleDirections[DoorDirections] = "up";
                //     DoorDirections+=1;
                // }
            }
            if (Door2.down) {
                Vector2 Spot = MoveInDirection("down",CurrentSpot);
                if (RoomSpots[(int)Spot.x,(int)Spot.y]==null) {
                    PossibleDirections[DoorDirections] = "down";
                    DoorDirections+=1;
                    PossibleDirections[DoorDirections] = "down";
                    DoorDirections+=1;
                }
                // else {
                //     PossibleDirections[DoorDirections] = "down";
                //     DoorDirections+=1;
                // }
            }
            
        }
        for (int i = 0; i < AllDoors.Length*3;i++) {
            int NumDir = Random.Range(0, PossibleDirections.Length);
            if (PossibleDirections[NumDir] != null) {
                return PossibleDirections[NumDir];
            }
        }
        Debug.LogWarning("Couldn't find any directrions");
        return "right";
    }
    Vector2 MoveInDirection(string Dir, Vector2 Spot) {
        if (Dir == "up") {
            Spot = new Vector2(Spot.x,Spot.y+1);
        }
        if (Dir == "down") {
            Spot = new Vector2(Spot.x,Spot.y-1);
        }
        if (Dir == "right") {
            Spot = new Vector2(Spot.x+1,Spot.y);
        }
        if (Dir == "left") {
            Spot = new Vector2(Spot.x-1,Spot.y);
        }
        return Spot;
    }
    GameObject FindGoodRoom(string Dir) {
        int NumToStart = Random.Range(0, Rooms.Length);
        for (int i = NumToStart; i < Rooms.Length;i++) {
            // Component[] AllDoors = Rooms[i].GetComponentsInChildren<Doors>();
            Component[] AllDoors = Rooms[i].GetComponent<AllDoors>().AllDoorsChildren;
            foreach (Doors Door in AllDoors) {
                // Debug.Log(Door.Exits);
                if (Door.right&&Dir == "left") {
                    return Rooms[i];
                }
                if (Door.left&&Dir == "right") {
                    return Rooms[i];
                }
                if (Door.up&&Dir == "down") {
                    return Rooms[i];
                }
                if (Door.down&&Dir == "up") {
                    return Rooms[i];
                }
            }
        }  
        for (int i = 0; i < NumToStart;i++) {
            // Component[] AllDoors = Rooms[i].GetComponentsInChildren<Doors>();
            Component[] AllDoors = Rooms[i].GetComponent<AllDoors>().AllDoorsChildren;
            foreach (Doors Door in AllDoors) {
                // Debug.Log(Door.Exits);
                if (Door.right&&Dir == "left") {
                    return Rooms[i];
                }
                if (Door.left&&Dir == "right") {
                    return Rooms[i];
                }
                if (Door.up&&Dir == "down") {
                    return Rooms[i];
                }
                if (Door.down&&Dir == "up") {
                    return Rooms[i];
                }
            }
        }  
        Debug.LogWarning("No Room That has the proper exits have been found");
        return null;
    }
    private void CombineTileMaps(GameObject room) {
        // Tilemap[] maps = room.GetComponentsInChildren<Tilemap>();
        Tilemap[] maps = room.GetComponent<AllDoors>().ThisTileMap;

        foreach (Tilemap tilemap in maps) {

            // BoundsInt bounds = tilemap.cellBounds;
            // TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
            if (tilemap.gameObject.tag == "Kill") {
                for (int x = -16; x < 16; x++) {
                    for (int y = -16; y < 16; y++) {
                        Vector3Int SpotToCell = grid.WorldToCell(new Vector3(CurrentSpot.x*RoomSize-(Mathf.FloorToInt (RoomAmount)*RoomSize),CurrentSpot.y*RoomSize-(Mathf.FloorToInt (RoomAmount)*RoomSize),0));
                        KillMap.SetTile(new Vector3Int(x+SpotToCell.x,SpotToCell.y+y,0),tilemap.GetTile(new Vector3Int(x,y,0)));
                    }
                }
                // Destroy(tilemap.transform.parent.gameObject);
                Destroy(tilemap.gameObject);
            }
            else if (tilemap.gameObject.layer == LayerMask.NameToLayer("Ground")) {
                for (int x = -16; x < 16; x++) {
                    for (int y = -16; y < 16; y++) {
                        Vector3Int SpotToCell = grid.WorldToCell(new Vector3(CurrentSpot.x*RoomSize-(Mathf.FloorToInt (RoomAmount)*RoomSize),CurrentSpot.y*RoomSize-(Mathf.FloorToInt (RoomAmount)*RoomSize),0));
                        MainMap.SetTile(new Vector3Int(x+SpotToCell.x,SpotToCell.y+y,0),tilemap.GetTile(new Vector3Int(x,y,0)));
                    }
                }
                // Destroy(tilemap.transform.parent.gameObject);
                Destroy(tilemap.gameObject);
            }
            
        }
    }
    void AddWalls() {
        for (int i = 0; i < RoomAmount*2;i++) {
            for (int j = 0; j < RoomAmount*2;j++) {
                if (RoomSpots[i,j]!=null) {
                    
                    if (RoomSpots[i+1,j]==null) {
                        CurrentSpot = new Vector2(i+1,j);
                        instantiated = (GameObject)GameObject.Instantiate(FilledInRoom, new Vector3(CurrentSpot.x*RoomSize-(Mathf.FloorToInt (RoomAmount)*RoomSize),CurrentSpot.y*RoomSize-(Mathf.FloorToInt (RoomAmount)*RoomSize),0), Quaternion.identity);
                        CombineTileMaps(instantiated);
                    }
                    if (RoomSpots[i-1,j]==null) {
                        CurrentSpot = new Vector2(i-1,j);
                        instantiated = (GameObject)GameObject.Instantiate(FilledInRoom, new Vector3(CurrentSpot.x*RoomSize-(Mathf.FloorToInt (RoomAmount)*RoomSize),CurrentSpot.y*RoomSize-(Mathf.FloorToInt (RoomAmount)*RoomSize),0), Quaternion.identity);
                        CombineTileMaps(instantiated);
                    }
                    if (RoomSpots[i,j+1]==null) {
                        CurrentSpot = new Vector2(i,j+1);
                        instantiated = (GameObject)GameObject.Instantiate(FilledInRoom, new Vector3(CurrentSpot.x*RoomSize-(Mathf.FloorToInt (RoomAmount)*RoomSize),CurrentSpot.y*RoomSize-(Mathf.FloorToInt (RoomAmount)*RoomSize),0), Quaternion.identity);
                        CombineTileMaps(instantiated);
                    }
                    if (RoomSpots[i,j-1]==null) {
                        CurrentSpot = new Vector2(i,j-1);
                        instantiated = (GameObject)GameObject.Instantiate(FilledInRoom, new Vector3(CurrentSpot.x*RoomSize-(Mathf.FloorToInt (RoomAmount)*RoomSize),CurrentSpot.y*RoomSize-(Mathf.FloorToInt (RoomAmount)*RoomSize),0), Quaternion.identity);
                        CombineTileMaps(instantiated);
                    }
                }
            }
        }
    }
}
