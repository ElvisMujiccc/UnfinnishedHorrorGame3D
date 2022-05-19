using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class BFirstTrigger : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject TextBox;
    public GameObject DestroyTrigger;

    private void OnTriggerEnter()
    {
        StartCoroutine (ScenePlayer ());
    }

    IEnumerator ScenePlayer()
    {
        //Dialog
        TextBox.GetComponent<TextMeshProUGUI>().text = "There's a note on a table";
        yield return new WaitForSeconds(2.5f);
        TextBox.GetComponent<TextMeshProUGUI>().text = "There's also a weapon next to it";
        yield return new WaitForSeconds(2.5f);
        TextBox.GetComponent<TextMeshProUGUI>().text = "I should take it";
        yield return new WaitForSeconds(2.5f);
        TextBox.GetComponent<TextMeshProUGUI>().text = "";
        Destroy(DestroyTrigger); //izklopi se trigger, ki je sprožil ta dialog
    }
}
