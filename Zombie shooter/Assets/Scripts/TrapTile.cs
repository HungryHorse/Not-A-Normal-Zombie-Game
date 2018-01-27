using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrapTile {

    public string name;
    public GameObject tileVisualPrefab;
    public GameObject hoverVisual;
    public GameObject noHover;
    public List<int> eligibleTiles;


}
