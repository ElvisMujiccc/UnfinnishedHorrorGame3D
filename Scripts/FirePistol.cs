using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public GameObject TheGun;
    public GameObject MuzzleFlash;
    public AudioSource GunFireSound;
    public bool IsFiring = false;
    public float TargetDistance;
    public int DamageAmount = 5;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(IsFiring == false)
            {
                StartCoroutine(FiringPistol());
            }
        }    
    }

    IEnumerator FiringPistol()
    {
        RaycastHit Shot;
        IsFiring = true;

        //razdalja streljanja/Povezava na skripto ZombieDeath
        if(Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            Shot.transform.SendMessage("DamageZombie", DamageAmount, SendMessageOptions.DontRequireReceiver);

        }
        //Animacija streljanja
        TheGun.GetComponent<Animation>().Play("PistolShoot");
        MuzzleFlash.SetActive(true);
        MuzzleFlash.GetComponent<Animation>().Play("MuzzleAnim");
        GunFireSound.Play();
        yield return new WaitForSeconds(0.5f);
        IsFiring = false;
    }
}
