using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public List<string> dialogue = new List<string>();

    public List<Sprite> sprites= new List<Sprite>();
    private bool canSpeak = false;
    private bool isSpeaking = true;
    public GameObject _talkPanel;
    public TextMeshProUGUI _talkText;
    public Image TalkingPerson;
    private int _talkIndex = 0;

    private void Start()
    {
        _talkText.text = dialogue[_talkIndex];
        TalkingPerson.sprite = sprites[_talkIndex]; 
        //_talkPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 

        }

        if (isSpeaking && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogue.Count - 1 == _talkIndex)
            {
                isSpeaking = false;
                _talkPanel.SetActive(false);
            }
            else
            {
                _talkIndex++;
                TalkingPerson.sprite = sprites[_talkIndex];
                _talkText.text = dialogue[_talkIndex];
            }
        }
        else if (canSpeak && Input.GetKeyDown(KeyCode.E))
        {
            isSpeaking = true;
            _talkPanel.SetActive(true);
            _talkIndex = 0;
            TalkingPerson.sprite = sprites[_talkIndex];
            _talkText.text = dialogue[_talkIndex]; 
        }
    }

    public void SetCanSpeak(bool newCanSpeak)
    {
        canSpeak = newCanSpeak;
    }

    public bool IsSpeaking()
    {
        return isSpeaking; 
    }

    public void CopyDialogue(List<string> newDialogue)
    {
        dialogue.Clear();
        dialogue.AddRange(newDialogue);
    }
}
