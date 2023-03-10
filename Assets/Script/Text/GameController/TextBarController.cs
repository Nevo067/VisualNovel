using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextBarController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI characterText;
    public GameObject bar;
    public GameObject parent;
    // Start is called before the first frame update

    public Animator animator;

    public int sentenceIndex = 0;
    public GameScene currentScene;
    public Speaker currentSpeaker;
    private StateTextBar state = StateTextBar.COMPLETED;

    private Dictionary<Speaker, SpriteController> sprites;
    public GameObject spritesPrefabs;

    public string HIDE_TRIGGER = "IsHide";
    public enum StateTextBar
    {
        PLAYING,COMPLETED
    }

    void Start()
    {
        //StartCoroutine(TypeText(currentScene.listSentence[sentenceIndex].text));
        sprites = new Dictionary<Speaker, SpriteController>();
        Debug.Log(sprites);
        animator = bar.GetComponent<Animator>();
        sentenceIndex = 0;


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
        StoryScene storyScene = currentScene as StoryScene;
        currentSpeaker  = storyScene.listSentence[sentenceIndex].speaker;
        StartCoroutine(TypeText(storyScene.listSentence[sentenceIndex].text));
        ActSpeaker();
        
    }
    /// <summary>
    /// Play the next sentence and change sentenceIndex
    /// </summary>
    public void PlayNextSentence()
    {
        if(StateTextBar.COMPLETED == state)
        {

            /*
            if (IsLastSentence())
            {
                
                sentenceIndex = 0;
                PlayNextScene();
                
                
            }
            */
            PlaySentence();
            sentenceIndex++;


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
    private void ActSpeaker()
    {
        StoryScene storyScene = currentScene as StoryScene;
        List<StoryScene.Sentence.Action> actions = storyScene.listSentence[sentenceIndex].actions;
        for (int i = 0; i < actions.Count; i++)
        {
            ActSpeaker(actions[i]);
        }
    }

    private void ActSpeaker(StoryScene.Sentence.Action action)
    {
        SpriteController spriteController = null;

        switch(action.type)
        {
            case StoryScene.Sentence.TypeAction.APPEAR:
                Debug.Log(sprites);
                if(!sprites.ContainsKey(action.speaker))
                {
                    Transform transformNewObject = spritesPrefabs.transform;
                    RectTransform rectTransform = spritesPrefabs.GetComponent<RectTransform>();
                    spriteController = Instantiate(action.speaker.prefab.gameObject,spritesPrefabs.transform.position,transform.rotation,parent.transform).GetComponent<SpriteController>();

                    spriteController.gameObject.GetComponent<RectTransform>().position = rectTransform.position;
                    /*
                    spriteController.transform.position = transformNewObject.position;
                    spriteController.transform.rotation = transform.rotation;
                    */
                    sprites.Add(action.speaker, spriteController);
                }
                else
                {
                    spriteController = sprites[action.speaker];
                }
                spriteController.Setup(action.speaker.sprites[action.indexSprite]);
                spriteController.Show(action.coords);
                break;

            case StoryScene.Sentence.TypeAction.MOVE:
                if (sprites.ContainsKey(action.speaker))
                {
                    spriteController = sprites[action.speaker];
                    spriteController.Move(action.coords, action.moveSpeed);
                }
                break;

            case StoryScene.Sentence.TypeAction.DISAPEAR:
                if (sprites.ContainsKey(action.speaker))
                {
                    spriteController = sprites[action.speaker];
                    spriteController.Hide();
                }
                break;
            case StoryScene.Sentence.TypeAction.NONE:
                if (sprites.ContainsKey(action.speaker))
                {
                    spriteController = sprites[action.speaker];
                }
                break;

        }
        if(spriteController != null)
        {
            spriteController.SwitchSprite(action.speaker.sprites[action.indexSprite]);
        }
    }

    /// <summary>
    /// Return True if it is the last sentence of sentence's list
    /// </summary>
    /// <returns></returns>
    public bool IsLastSentence() 
    {
        StoryScene storyScene = currentScene as StoryScene;
        return sentenceIndex >= storyScene.listSentence.Count;
    }

    public void Hide()
    {
        
        animator.SetBool(HIDE_TRIGGER, true);
        
    }
    public void Show()
    {
        animator.SetBool(HIDE_TRIGGER, false);
    }
    public void EraseText()
    {
        barText.text = "";
    }

    public void PlayNextScene()
    {
        StoryScene storyScene = currentScene as StoryScene;
        currentScene = storyScene.nextScene;
    }
}
