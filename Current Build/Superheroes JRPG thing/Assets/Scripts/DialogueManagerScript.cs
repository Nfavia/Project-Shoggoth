using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerScript : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    public Queue<string> sentences; //This is similar to an Array but can be changed much more easily

    public static bool nextSentence = false;

    // Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}

    private void Update()
    {
        //This checks if the player has tried to progress to the next sentence using a static bool that is activated within the Dialogue Tigger script
        if (nextSentence)
        {
            DisplayNextSentence();
            nextSentence = false;
        }
    }


    // Method to start Dialogue system. Dialogue is sent from an NPC or other controller to this to be set up in the Queue
    public void StartDialogue(Dialogue dialogue)
    {

        animator.SetBool("IsOpen", true);

        Debug.Log("Starting Conversation with" + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    /* 
     * This method actually displays the text within the text box and when called mulitple times, will cycle through available dialogue. 
     *
     * 
    */
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();

        StartCoroutine(TypeSentence(sentence));

    }

    // Types out the entire sentence given one letter at a time
    IEnumerator TypeSentence(string sentence)
    {

        dialogueText.text = "";

        yield return new WaitForSeconds(0.5f); // TEMPORARY for purposes of the test dialogue box

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

    }

    // Ends Dialogue.... As its name implies 
    void EndDialogue()
    {
        Debug.Log ("End of Conversation");
        animator.SetBool("IsOpen", false);
        DialogueTriggerNPC.startTalking = false;
        DialogueTriggerNPC.talking = false;
    }
}
