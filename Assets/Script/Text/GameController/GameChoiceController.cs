using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameChoiceController : MonoBehaviour
{
    public GameController gameController;

    public string HIDE_TRIGGER = "IsHide";
    public GameObject ChoiceBar;
    public Animator animator;
    public List<TextMeshProUGUI> textsChoice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hide()
    {
        animator.SetBool(HIDE_TRIGGER, true);
    }
    public void Show()
    {
        animator.SetBool(HIDE_TRIGGER, false);
    }
    public void Setup(ChoceStoryScene choice)
    {
        for (int i = 0; i < choice.choice.Count; i++)
        {
            textsChoice[i].text = choice.choice[i].label;
            textsChoice[i].GetComponent<GameChoiceLabelController>().nextStoryScene = choice.choice[i].nextScene;

        }
        StartClickable();
    }
    public void ValidChoice(GameScene scene)
    {
        gameController.currentScene = scene;
        StopClickable();
        gameController.MakeAction();
    }
    /// <summary>
    /// Prevent the user to click on choice
    /// </summary>
    public void StopClickable()
    {
        foreach (var item in textsChoice)
        {
            item.GetComponent<GameChoiceLabelController>().IsClickable = false;

        }
       
    }
    public void StartClickable()
    {
        foreach (var item in textsChoice)
        {
            item.GetComponent<GameChoiceLabelController>().IsClickable = true;
        }
    }
}
