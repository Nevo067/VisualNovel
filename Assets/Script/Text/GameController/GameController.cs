using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public TextBarController textBarController;
    public BackgroundController backgroundController;

    private State state = State.IDLE;


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
        IDLE, ANIMATE
    }
    //Input
    public void OnAction(InputValue input)
    {
        
        if (state == State.IDLE && textBarController.IsLastSentence())
        {
            textBarController.sentenceIndex = 0;
            textBarController.PlayNextScene();
            StartCoroutine(ChangeScene());
        }
        else
        {
            textBarController.PlayNextSentence();
        }
        
        
    }
    public IEnumerator ChangeScene()
    {
        state = State.ANIMATE;
        textBarController.EraseText();
        textBarController.Hide();
        backgroundController.EraseBackground();
        yield return new WaitForSeconds(1f);
        textBarController.Show();
        yield return new WaitForSeconds(1f);
        textBarController.PlayNextSentence();
        state = State.IDLE;
    }

}
