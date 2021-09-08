using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    Vector3 cameraoffset;

    // Start is called before the first frame update
    void Start()
    {
        // This will help camera to keep track on Ball with an offset so to see the ball too...   
        cameraoffset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
       // Recommended to use this piece of code in LateUpdate() method for smooth working and animation.
        transform.position = player.transform.position + cameraoffset;
    }
}

