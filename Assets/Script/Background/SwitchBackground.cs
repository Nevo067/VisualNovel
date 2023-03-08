using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchBackground : MonoBehaviour
{

    public bool isSwitched = false;
    public Image image1;
    public Image image2;
    private Animator animator;

    private string SWITCHFIRST_TRIGGER = "SwitchFirst";
    private string SWITCHSECOND_TRIGGER = "SwitchSecond";
    private void Awake()
    {
        animator = GetComponent<Animator>();
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
            image2.sprite = sprite;
            animator.SetTrigger(SWITCHFIRST_TRIGGER);
        }
        else
        {
            image1.sprite = sprite;
            animator.SetTrigger(SWITCHSECOND_TRIGGER);
        }
        isSwitched = !isSwitched;
    }

    public void SetImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            image1.sprite = sprite;
        }
        else
        {
            image2.sprite = sprite;
        }
    }

    public Sprite GetImage()
    {
        if (!isSwitched)
        {
            return image1.sprite;
        }
        else
        {
            return image2.sprite;
        }
    }
    
}
