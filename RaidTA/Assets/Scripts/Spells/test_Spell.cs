using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Spell : MonoBehaviour
{
    public int detonation_time;
    public int damage;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Detonate");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Detonate()
    {
        yield return new WaitForSeconds(detonation_time);
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);
        for(int i = 0; i < hits.Length; i++)
        {
            if(hits[i].tag == "Player")
            {
                hits[i].GetComponent<Unit>().TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
