using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform t = GetComponent<Transform>();
        t.rotation = new Quaternion(t.rotation.x + 1, t.rotation.y + 1, t.rotation.z + 1, t.rotation.w);
    }
}
