using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRotation : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform Camera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Camera.rotation;
    }
}
