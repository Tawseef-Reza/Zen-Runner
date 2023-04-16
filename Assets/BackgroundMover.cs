using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    private float backgroundRestrict;
    // Start is called before the first frame update
    void Start()
    {
       backgroundRestrict = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, backgroundRestrict, transform.position.z);
    }
}
