using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class GameChoiceLabelController : MonoBehaviour, IPointerEnterHandler,IPointerDownHandler
{
    // Start is called before the first frame update
    public Color defaultColor;
    public Color hoverColor;
    public TextMeshProUGUI textMesh;
    public StoryScene nextStoryScene;

    void Start()
    {
        textMesh = this.GetComponent<TextMeshProUGUI>();
        textMesh.color = defaultColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
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
