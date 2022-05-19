using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    public int EnemyHealth = 20;
    public GameObject TheEnemy;
    public int StatusCheck;
    public AudioSource JumpScareMusic;

    void DamageZombie(int DamageAmount) 
    { 
        EnemyHealth -= DamageAmount; //Odštejemo življenje nasprotniku 
    }

    void Update()
    {
            if(EnemyHealth <= 0 && StatusCheck == 0)
        {
            this.GetComponent<ZombieAI>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            StatusCheck = 2; //Prepreèi, da ponovimo if stavek

            //Prekinemo animacijo premikanja nasprotnika in aktiviramo animacijo, ko nasprotnika pokonèamo
            TheEnemy.GetComponent<Animation>().Stop("ZombieWalk1");
            TheEnemy.GetComponent<Animation>().Play("ZombieDeath");
            JumpScareMusic.Stop();
        }
    }
}
