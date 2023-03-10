using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchBackground : MonoBehaviour
{

    public bool isSwitched = false;
    public GameObject image1;
    public GameObject image2;
    public Animator animator;

    private string SWITCHFIRST_TRIGGER = "SwitchFirst";
    private string SWITCHSECOND_TRIGGER = "SwitchSecond";
    private void Awake()
    {
        //animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            image2.GetComponent<SpriteRenderer>().sprite = sprite;
            animator.SetTrigger(SWITCHFIRST_TRIGGER);
        }
        else
        {
            image1.GetComponent<SpriteRenderer>().sprite = sprite;
            animator.SetTrigger(SWITCHSECOND_TRIGGER);
        }
        isSwitched = !isSwitched;
    }
    public string GetCurrentSwitchNameAnimator()
    {
        if (animator != null)
        {
            if (!isSwitched)
            {
                
                return SWITCHFIRST_TRIGGER;
            }
            else
            {

                return SWITCHSECOND_TRIGGER;
            }
            
        }
        return "";
    }

    public void SetImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            image1.GetComponent<SpriteRenderer>().sprite = sprite;
        }
        else
        {
            image2.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }

    public Sprite GetImage()
    {
        if (!isSwitched)
        {
            return image1.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            return image2.GetComponent<SpriteRenderer>().sprite;
        }
    }
    
}
