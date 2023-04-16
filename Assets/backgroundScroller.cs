using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScroller : MonoBehaviour
{
    private static bool isActive;
    
    private float offset;
    private float resist;
    private Material mat;

    private Rigidbody2D playerBody;
   
    public static void setActive(bool boolean)
    {
        isActive = boolean;
    }
    public static bool getActive()
    {
        return isActive;
    }
    // Start is called before the first frame update
    void Start()
    {
        switch(name)
        {
            case "Hill":
                resist = 80f;
                break;
            case "Layer2":
                resist = 70f;
                break;
            case "Layer3":
                resist = 60f;
                break;
            case "Layer4":
                resist = 50f;
                break;
            case "Layer5":
                resist = 40f;
                break;
            case "Layer6":
                resist = 30f;
                break;
            default:
                resist = 80f;
                break;
        }
        mat = GetComponent<Renderer>().material;
        playerBody = GameObject.Find("HeroKnight").GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) {
            
        }
        else if (playerBody.velocity.x > 0)
        {
            offset += (Time.deltaTime * playerBody.velocity.x) / resist;
            mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
        else if (playerBody.velocity.x < 0)
        {   
            offset += (Time.deltaTime * playerBody.velocity.x) / resist;
            mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
        
    }

}
