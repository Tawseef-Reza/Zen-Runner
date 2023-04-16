using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    public int range = 100;
    public int innerRange = 10;
    public int width;
    public int height;
    public RuleTile ruleTile;
    public Tilemap tilemap;
    public int randomnity;
    private bool instantiated = false;

    [SerializeField]
    GameObject[] randomItem;
    void Start()
    {
        
        tilemap = GetComponent<Tilemap>();
        
        int x = 7;
        int y = -6;
        int edits = range / innerRange / 2;
        
        for (int i = 0; i < edits; i++)
        {
            makeFeature(x, y);
            x += innerRange;
            for (int j = 0; j < innerRange; j++)
            {
                tilemap.SetTile(new Vector3Int(j + x, y, 0), ruleTile);

                tilemap.SetTile(new Vector3Int(j + x, y + 1, 0), ruleTile);

                tilemap.SetTile(new Vector3Int(j+x, y+2, 0), ruleTile);
            }
            x+= innerRange;
            instantiated = false;

        }
        //print("done");
        
    }
    void makeFeature(int startingX, int startingY)
    {
        int stopperStart = startingY;
        int stopperEnd = innerRange - startingY;
        
        for (int y = startingY; y < height; y++)
        {
            stopperStart += Random.Range(1, 3);
            stopperEnd -= Random.Range(0, 3);
            for (int iterator = stopperStart; iterator < stopperEnd; iterator++)
            {
                if (Random.Range(0, 20) == 19)
                {
                    //print("this ran");
                    tilemap.SetTile(new Vector3Int(startingX + iterator, y, 0), null);
                    
                }
                else
                tilemap.SetTile(new Vector3Int(startingX + iterator, y, 0), ruleTile);
            
            }

            InstantiateItem(Random.Range(0, 2) == 0 ? startingX + stopperStart : startingX + stopperEnd, y, instantiated);

        }


    }
    void InstantiateItem(int xPos, int y, bool isInstantiated)
    {

        if (isInstantiated)
        {

        }
        else
        {
            Instantiate(randomItem[Random.Range(0, 2)], new Vector3(xPos, y+5, -1), Quaternion.identity);
            print($"instantiated at{xPos}, {y + 2}");
            instantiated = true;
        }
    }
}

