using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public Unit owner;
    Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;   
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = 0.2f * (owner.hp / owner.max_hp);
        transform.localScale = localScale;
    }
}
