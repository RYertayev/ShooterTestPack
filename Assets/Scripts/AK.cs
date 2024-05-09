using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK : MonoBehaviour
{
    public float range = 200f;
    public Transform fpsCam;
    public ParticleSystem impact;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Instantiate(impact, hit.point, Quaternion.identity);
        }
    }
}
