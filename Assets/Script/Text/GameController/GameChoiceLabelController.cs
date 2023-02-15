using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class GameChoiceLabelController : MonoBehaviour, IPointerEnterHandler,IPointerDownHandler
{
    private bool isClickable;
    // Start is called before the first frame update
    public Color defaultColor;
    public Color hoverColor;
    public TextMeshProUGUI textMesh;
    public GameScene nextStoryScene;
    public GameChoiceController choiceController;

    public bool IsClickable { get => isClickable; set => isClickable = value; }

    void Start()
    {
        textMesh = this.GetComponent<TextMeshProUGUI>();
        textMesh.color = defaultColor;
        isClickable = true;
        choiceController = GameObject.FindObjectOfType<GameChoiceController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isClickable)
        {
            Debug.Log("click");
            choiceController.ValidChoice(nextStoryScene);
        }
        else
        {
            Debug.Log("cant clickable");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       
    }

    
}
