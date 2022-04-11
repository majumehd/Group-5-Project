using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHints : MonoBehaviour
{
   // Start is called before the first frame update
    void Start()
    {
        strartQuaternion = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void snapRotation()
    {
        transform.rotation = startQuarternion;
    }
}
