using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TouchItem : MonoBehaviour
{
    private CenterTouch _centerTouch;
    // Start is called before the first frame update
    void Awake()
    {
        _centerTouch = GameObject.Find("GameObject").GetComponent<CenterTouch>();   

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _centerTouch.StartAnim();
        Destroy(gameObject);
    }
    
}
