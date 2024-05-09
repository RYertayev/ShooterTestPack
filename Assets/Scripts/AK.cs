using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AK : MonoBehaviour
{
    public float range = 200f;
    public Transform fpsCam;
    public ParticleSystem impact;
    public AudioSource source;
    public AudioClip shoot_sound;
    private bool isShoot;
    //Ammo
    public int currentAmmo = 16;
    public int spare_ammo = 16;
    public int magazine = 52;
    public Text ammoText;
    public Text magazineText;
    // Start is called before the first frame update
    void Start()
    {
        isShoot = true;
        ammoText.text = currentAmmo.ToString();
        magazineText.text = magazine.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if(currentAmmo == 0)
        {
          Reload();   
        }
        if(magazine == 4)
        {
            isShoot = false;
        }
       
        
    }
    void Shoot()
    {
        if(isShoot && currentAmmo > 0)
        {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Instantiate(impact, hit.point, Quaternion.identity);
        }
        currentAmmo -= 1;
        ammoText.text = currentAmmo.ToString();
        source.PlayOneShot(shoot_sound);
        }
    }
    void Reload()
    {
        magazine -= 16;
        currentAmmo = spare_ammo;
        ammoText.text = currentAmmo.ToString();
        magazineText.text = magazine.ToString();
        
    }
}