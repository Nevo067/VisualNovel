using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public TextBarController textBarController;
    public BackgroundController backgroundController;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Input
    public void OnAction(InputValue input)
    {
        textBarController.PlayNextSentence();
        if (textBarController.IsLastSentence())
        {

            backgroundController.EraseBackground();
        }
        
        
    }
}
