using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour {


    public Text NameText;
    public Text DialogueText;
    public GameObject DialogBox;
    public Queue<string> Sentences;
    public bool IsTalking;
    public bool ActivateMiniGame;

	// Use this for initialization
	void Start () {
        Sentences = new Queue<string>();
        DialogBox.SetActive(false);
        IsTalking = false;
        ActivateMiniGame = false;
    }
	
 public void StartDialogue(NewDialogue dialogue)
    {
         NameText.text = dialogue.Name[0];
        IsTalking = true;
        Sentences.Clear();

        foreach (string Sentence in dialogue.Sentences)
        {
            Sentences.Enqueue(Sentence);
        }
        DisplayNextSentence();

    }
    public void DisplayNextSentence()
    {
        if(Sentences.Count == 0)
        {

            EndDialogue();
            return;
        }
        Debug.Log(Sentences.Count);

        string Sentence = Sentences.Dequeue();
        DialogueText.text = Sentence;
     }
    public void EndDialogue()
    {
        IsTalking = false;
        DialogBox.SetActive(false);

        Debug.Log("EndOfConvo");
    }
}
