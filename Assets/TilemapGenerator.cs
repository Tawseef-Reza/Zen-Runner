using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    public int width;
    public int height;
    public RuleTile ruleTile;

    void Start()
    {

        Tilemap tilemap = GetComponent<Tilemap>();

        foreach (int i in new int[] {1,2,3,4,5,6})
        {
            tilemap.SetTile(new Vector3Int(i, i, 0), ruleTile);
        }
        print("done");
        
    }
}

