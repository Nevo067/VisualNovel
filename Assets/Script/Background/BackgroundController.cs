using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public List<GameObject> background;

    private string ANIM_TRIGGER = "IsErase";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EraseBackground(int index)
    {
        
        if (index >= 0 && index < background.Count )
        {
            Animator anim = background[index].GetComponent<Animator>();
            anim.SetBool(ANIM_TRIGGER, true);
        }
        else 
        {
            Debug.Log("Bug Background");
        }
        
    }
    public void EraseBackground()
    {
        EraseBackground(0);
    }
}
