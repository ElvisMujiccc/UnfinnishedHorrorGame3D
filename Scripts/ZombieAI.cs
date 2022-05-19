using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject theEnemy;
    public float enemySpeed;
    public bool attackTrigger = false;
    public bool isAttacking = false;
    public AudioSource hurtSound1;
    public AudioSource hurtSound2;
    public AudioSource hurtSound3;
    public int hurtGen;
    public GameObject HurtFlash;

    void Update()
    {
        transform.LookAt(thePlayer.transform); //Nasprotnik je konstantno obrnjen proti igralcu
        if (attackTrigger == false)
        {
            //Nasprotniku se aktivira animacija sprehajanja in priène se sprehajati do igralca
            enemySpeed = 0.01f;
            theEnemy.GetComponent<Animation>().Play("ZombieWalk1");
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, enemySpeed);
        }
        if(attackTrigger == true && isAttacking == false)
        {
            //Ko nasprotnik aktivira trigger postavljen ob igralcu, spremeni animacijo v attack in napade igralca
            enemySpeed = 0;
            theEnemy.GetComponent<Animation>().Play("ZombieAttack");
            StartCoroutine(InflictDamage());
        }
    }

    void OnTriggerEnter()
    {
        attackTrigger = true;
    }
    void OnTriggerExit()
    {
        attackTrigger = false;
    }


    IEnumerator InflictDamage()
    {
        isAttacking = true;

        //Zvok poškodbe igralca
        if (hurtGen == 1)
        {
            hurtSound1.Play();
        }
        else if (hurtGen == 2)
        {
            hurtSound2.Play();
        }
        else
        {
            hurtSound3.Play();
        }

        HurtFlash.SetActive(true); //ob udarcu se ekran zasveti v rahlo rdeèo barvo, da opazimo, da smo poškodovani
        yield return new WaitForSeconds(0.1f);
        HurtFlash.SetActive(false); //izklopimo rahlo rdeèo barvo
        yield return new WaitForSeconds(1.1f);
        PlayerHealth.currentHealth -= 5; //igralec nam odbije 5 števil življenja
        hurtGen = Random.Range(1, 4);
        yield return new WaitForSeconds(0.9f);
        isAttacking = false;
    }
}
