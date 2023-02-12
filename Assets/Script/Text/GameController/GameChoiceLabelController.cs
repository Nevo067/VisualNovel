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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(isClickable)
        {
            choiceController.ValidChoice(nextStoryScene);
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Click");
    }

    
}
