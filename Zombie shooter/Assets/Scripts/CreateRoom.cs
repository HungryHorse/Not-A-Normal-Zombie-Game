using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoom : MonoBehaviour {

    GameObject floorTile;
    GameObject Player;
    int[,] map;
    int[,] savedMap;
    public TrapTile[] trapTiles;
    public int mapSizeX;
    public int mapSizeY;
    public bool buildMode;
    public int trapChoice;

	// Use this for initialization
	void Start () {

        map = new int[mapSizeX, mapSizeY];
        savedMap = new int[mapSizeX, mapSizeY];

        for (int x = 0; x < mapSizeX; x++)
        {
            for(int y = 0; y < mapSizeY; y++)
            {
                map[x, y] = 0;
                savedMap[x, y] = 0;
            }
        }

        GenerateMapVisual();

        Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

        if (buildMode)
        {

            for (int x = 0; x < mapSizeX; x++)
            {
                for (int y = 0; y < mapSizeY; y++)
                {
                    if (GetActualMouseX() == x && GetActualMouseY() == y)
                    {
                        if (trapTiles[trapChoice].eligibleTiles.Contains(savedMap[x, y]))
                        {
                            map[x, y] = -1;
                        }
                        else
                        {
                            map[x, y] = -2;
                        }
                    }
                    else
                    {
                        map[x, y] = savedMap[x, y];
                    }
                }
            }

            DestroyMapVisual();
            GenerateMapVisual();
        }
    }

    void GenerateMapVisual()
    {
        Transform MapObject = new GameObject("MapObj").transform;
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                if (map[x,y] == -1)
                {
                    TrapTile tt = trapTiles[savedMap[x, y]];
                    GameObject go = (GameObject)Instantiate(tt.hoverVisual, new Vector3(x, 0, y), Quaternion.identity);
                    go.transform.SetParent(MapObject);
                }
                else if(map[x, y] == -2)
                {
                    TrapTile tt = trapTiles[savedMap[x, y]];
                    GameObject go = (GameObject)Instantiate(tt.noHover, new Vector3(x, 0, y), Quaternion.identity);
                    go.transform.SetParent(MapObject);
                }
                else
                {
                    TrapTile tt = trapTiles[savedMap[x, y]];
                    GameObject go = (GameObject)Instantiate(tt.tileVisualPrefab, new Vector3(x, 0, y), Quaternion.identity);
                    go.transform.SetParent(MapObject);
                }
            }
        }
    }

    void DestroyMapVisual()
    {
        GameObject MapObject = GameObject.Find("MapObj");
        Destroy(MapObject);
    }

    int GetActualMouseX()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        int x = (int)Mathf.Round(((mousePos.x / Camera.main.transform.position.y) * 1.709f));
        return x;
    }

    int GetActualMouseY()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        int y = (int)Mathf.Round(((mousePos.y / Camera.main.transform.position.y) * 1.709f));
        return y;
    }

    public void BuildMode()
    {
        buildMode = !buildMode;
        Player.SetActive(!Player.activeInHierarchy);
    }

    public void SetTrap(int x, int y)
    {
        savedMap[x, y] = trapChoice;
    }
}
