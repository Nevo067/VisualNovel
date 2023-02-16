using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public List<GameObject> background;

    private string ANIM_TRIGGER = "IsErase";
    private int indexZ;
    private int indexBackground;

    public int IndexBackground { get => indexBackground; set => indexBackground = value; }

    // Start is called before the first frame update
    void Start()
    {
        ChangeAlphaBackgroundExceptFirst();
        indexZ = 0;
        indexBackground = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EraseBackground(int index)
    {
        
        if (index >= 0 && index < background.Count )
        {
            int indexBoucle = 0;
            foreach (var item in background)
            {
                if(indexBoucle != index)
                {
                    background[indexBoucle].GetComponent<SpriteRenderer>().sortingOrder = -100;
                }
                indexBoucle++;
            }
            Animator anim = background[index].GetComponent<Animator>();
            background[index].GetComponent<SpriteRenderer>().sortingOrder = indexZ;
            anim.SetBool(ANIM_TRIGGER, true);
            
        }
        else 
        {
            Debug.Log("Bug Background");
        }
        
    }
    public void EraseBackground()
    {
        EraseBackground(indexBackground);
    }
    public void ChangeAlphaBackgroundExceptFirst()
    {
        for (int i = 0; i < background.Count; i++)
        {
            if(i > 0)
            {
                ChangeAlphaBackground(background[i],0);

            }
        }
    }
    public void ShowBackground(int i)
    {
        indexZ = (indexZ -1);
        background[i].GetComponent<SpriteRenderer>().sortingOrder = indexZ;
        ChangeAlphaBackground(background[i], 1);
        Animator anim = background[i].GetComponent<Animator>();
        anim.SetBool(ANIM_TRIGGER, false);

    }

    private void ChangeAlphaBackground(GameObject backgroundChange,int alpha)
    {
        SpriteRenderer spriteRenderer = backgroundChange.GetComponent<SpriteRenderer>();
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }
    /// <summary>
    /// Find index of gifted gameobject. If it is not in background return -1
    /// </summary>
    /// <param name="backgroundGame"></param>
    /// <returns></returns>
    public int findIndex(GameObject backgroundGame)
    {
        int indexBackground = 0;
        foreach (var item in background)
        {
            if(item.gameObject.name == backgroundGame.name)
            {
                return indexBackground;
            }
            indexBackground++;
        }
        return -1;
    }
    
}
