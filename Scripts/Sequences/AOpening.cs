using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class AOpening : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject FadeScreenIn;
    public GameObject TextBox;

    
    void Start()
    {
        ThePlayer.GetComponent<FirstPersonController>().enabled = false; //Igralec se ob zaèetku igre ne more premikati
        StartCoroutine(ScenePlayer ());
    }

    IEnumerator ScenePlayer()
    {
        //ob prièetku igre sprožimo dialog
        yield return new WaitForSeconds(1.5f);
        FadeScreenIn.SetActive(false);
        TextBox.GetComponent<TextMeshProUGUI>().text = "What is this?";
        yield return new WaitForSeconds(2f);
        ThePlayer.GetComponent<FirstPersonController>().enabled = true; //Igralec se lahko premika
        TextBox.GetComponent<TextMeshProUGUI>().text = "I need to get out of here.";
        yield return new WaitForSeconds(2f);
        TextBox.GetComponent<TextMeshProUGUI>().text = "";

    }
}
