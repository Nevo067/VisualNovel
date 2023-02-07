using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBarController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI characterText;
    // Start is called before the first frame update

    private int sentenceIndex = 0;
    public StoryScene currentScene;
    public Speaker currentSpeaker;
    private StateTextBar state = StateTextBar.COMPLETED;
    public enum StateTextBar
    {
        PLAYING,COMPLETED
    }

    void Start()
    {
        //StartCoroutine(TypeText(currentScene.listSentence[sentenceIndex].text));
        PlaySentence();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = 0;
        PlaySentence();
    }
    public void PlaySentence()
    {
        currentSpeaker  = currentScene.listSentence[sentenceIndex].speaker;
        StartCoroutine(TypeText(currentScene.listSentence[sentenceIndex].text));
        
    }
    /// <summary>
    /// Play the next sentence and change sentenceIndex
    /// </summary>
    public void PlayNextSentence()
    {
        if(StateTextBar.COMPLETED == state)
        {
            if(!IsLastSentence())
            {
                sentenceIndex = 0;
            }
            else 
            {
                sentenceIndex++;
            }
            
            PlaySentence();
        }
       
    }
    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        characterText.text = currentSpeaker.nameCharacter;
        characterText.color = currentSpeaker.color;
        int indexWord = 0;
        state = StateTextBar.PLAYING;

        while(state != StateTextBar.COMPLETED)
        {
            barText.text += text[indexWord];
            yield return new WaitForSeconds(0.05f);
            indexWord++;
            if(indexWord >= text.Length)
            {
                state = StateTextBar.COMPLETED;
                break;
            }
                
        }


    }
    public bool IsLastSentence() 
    {
        return sentenceIndex <= currentScene.listSentence.Count;
    }
}
