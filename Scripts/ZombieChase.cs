using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieChase : MonoBehaviour
{
    public GameObject TheZombie;
    public AudioSource JumpScareSound;

    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Action"))
        {
            //ob odprtju vrat se prikaže zombie in aktivira "jumpscare" zvok
            TheZombie.SetActive(true);
            JumpScareSound.Play();
            }
        }
    }

