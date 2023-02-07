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
        
        if (textBarController.IsLastSentence())
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
        textBarController.EraseText();
        textBarController.Hide();
        backgroundController.EraseBackground();
        yield return new WaitForSeconds(1f);
        textBarController.Show();
        yield return new WaitForSeconds(1f);
        textBarController.PlayNextSentence();
    }

}
