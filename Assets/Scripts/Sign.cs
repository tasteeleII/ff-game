using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{

    public GameObject dialogueBox;
    public Text dialogueText;
    public string dialogue;
    public bool dialogueOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogueOn)
        {

            if (dialogueBox.activeInHierarchy)
            {

                dialogueBox.SetActive(false);

            }
            else
            {

                dialogueBox.SetActive(true);
                dialogueText.text = dialogue;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            dialogueOn = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            dialogueOn = false;
            dialogueBox.SetActive(false);

        }

    }

}
