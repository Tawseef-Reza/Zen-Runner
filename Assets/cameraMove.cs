using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    private Transform breakpointStart;
    private Transform breakpointEnd;
    private Transform playerTransform;
    private 
    // Start is called before the first frame update
    void Start()
    {
        breakpointStart = GameObject.Find("BreakpointStart").transform;
        breakpointEnd = GameObject.Find("BreakpointEnd").transform;
        playerTransform = GameObject.Find("HeroKnight").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerTransform.position.x < breakpointStart.position.x)
        {
            if (backgroundScroller.getActive())
            {
                backgroundScroller.setActive(false);
            }    
            transform.position = new Vector3(breakpointStart.position.x, transform.position.y, transform.position.z);
        }
        else if (playerTransform.position.x > breakpointEnd.position.x)
        {
            if (backgroundScroller.getActive())
            {
                backgroundScroller.setActive(false);
            }
            transform.position = new Vector3(breakpointEnd.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            if (!backgroundScroller.getActive())
            {
                backgroundScroller.setActive(true);
            }
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, breakpointStart.position.x, breakpointEnd.position.x)
                , transform.position.y
                , transform.position.z
            );
        }
    }
}
