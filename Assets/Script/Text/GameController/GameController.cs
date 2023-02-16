using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public TextBarController textBarController;
    public BackgroundController backgroundController;
    public GameChoiceController gameChoiceController;

    private State state = State.IDLE;

    public GameScene currentScene 
    {
        get { return textBarController.currentScene; }
        set { textBarController.currentScene = value; } 
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public enum State
    {
        IDLE, ANIMATE, CHOICE
    }
    //Input
    public void OnAction(InputValue input)
    {

        MakeAction();
        
        
    }
    public void MakeAction()
    {
        Debug.Log(state);
        if (state == State.IDLE && textBarController.IsLastSentence())
        {
            Debug.Log(textBarController.currentScene.nextScene as StoryScene is StoryScene);
            if (textBarController.currentScene.nextScene as StoryScene is StoryScene)
            {
                Debug.Log("BOOM");
                textBarController.sentenceIndex = 0;
                textBarController.PlayNextScene();
                StartCoroutine(ChangeScene());
            }
            else if (textBarController.currentScene.nextScene as ChoceStoryScene is ChoceStoryScene)
            {
                
                textBarController.currentScene = textBarController.currentScene.nextScene;
                Debug.Log(textBarController.currentScene);
                textBarController.sentenceIndex = 0;
                StartCoroutine(ChangeScene());
            }

        }
        else if(state == State.CHOICE)
        {
            
            StartCoroutine(ChangeScene());
        }
        else
        {
            textBarController.PlayNextSentence();
        }
    }
    public IEnumerator ChangeScene()
    {
        
        
        if(state == State.CHOICE)
        {
            textBarController.EraseText();
            textBarController.Hide();
            backgroundController.EraseBackground();
            
            yield return new WaitForSeconds(1f);
            state = State.ANIMATE;
            gameChoiceController.Hide();
            yield return new WaitForSeconds(1f);
            state = State.IDLE;

        }
        if (textBarController.currentScene is StoryScene)
        {
            textBarController.EraseText();
            textBarController.Hide();
            backgroundController.EraseBackground();
            int index = textBarController.currentScene.background;
            Debug.Log(index);
            backgroundController.ShowBackground(index);
            yield return new WaitForSeconds(1f);
            backgroundController.IndexBackground = index;
            state = State.ANIMATE;
            yield return new WaitForSeconds(1f);
            textBarController.Show();
            yield return new WaitForSeconds(1f);
            textBarController.PlayNextSentence();
            state = State.IDLE;
        }
        else if(textBarController.currentScene is ChoceStoryScene)
        {
            state = State.ANIMATE;
            ChoceStoryScene choice = textBarController.currentScene as ChoceStoryScene;
            Debug.Log(choice);
            gameChoiceController.Setup(choice);
            gameChoiceController.Show();
            yield return new WaitForSeconds(1f);
            state = State.CHOICE;
        }
        
    }

}
