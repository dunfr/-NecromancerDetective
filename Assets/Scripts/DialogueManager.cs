using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text _nameText;
    public Text _dialogueText;
    private Queue<string> _sentences;
    // Start is called before the first frame update
    void Start()
    {
        _sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        _nameText.text = dialogue.name;
        _sentences.Clear();
        foreach (string _sentence in dialogue._sentences) 
        {
            _sentences.Enqueue(_sentence);
        }
        DisplayNextSentences();
    }
    public void DisplayNextSentences()
    {
        if(_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string _sentence = _sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(_sentence));
    }
    IEnumerator TypeSentence(string _sentence)
    {
        _dialogueText.text = "";
        foreach(char letter in _sentence.ToCharArray())
        {
            _dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        Debug.Log("End");
    }


}
