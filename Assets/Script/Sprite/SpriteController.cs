using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    private SpriteSwitcher spriteSwitcher;
    
    private Animator animator;
    private RectTransform rect;

    private string TRIGGER_SHOW = "show";
    private string TRIGGER_HIDE = "hide";

    private void Awake()
    {
        spriteSwitcher = this.GetComponent<SpriteSwitcher>();
        animator = this.GetComponent<Animator>();
        rect = this.GetComponent<RectTransform>();
    }
    public void Setup(Sprite sprite)
    {
        spriteSwitcher.SetImage(sprite);
    }
    public void Show(Vector2 coord)
    {
        FalseAllAnimatorParametter();
        animator.SetBool(TRIGGER_SHOW, true);
        rect.localPosition = coord;
    }
    public void Hide()
    {
        FalseAllAnimatorParametter();
        animator.SetBool(TRIGGER_HIDE, true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void FalseAllAnimatorParametter()
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            animator.SetBool(parameter.name, false);
        }
    }

    /// <summary>
    /// Move the sprite toward a position
    /// </summary>
    /// <param name="finalPosition"></param>
    /// <param name="speed"></param>
    public void Move(Vector2 finalPosition, float speed)
    {
        StartCoroutine(MoveCorotine(finalPosition, speed));
    }
    /// <summary>
    /// Move the sprite toward a position.
    /// </summary>
    /// <param name="finalPosition"></param>
    /// <param name="speed"></param>
    /// <returns></returns>
    public IEnumerator MoveCorotine(Vector2 finalPosition,float speed)
    {
        while(rect.localPosition.x != finalPosition.x && rect.localPosition.y != finalPosition.y)
        {
            rect.localPosition = Vector2.MoveTowards(rect.localPosition, finalPosition, Time.deltaTime * 1000f * speed);
            yield return new WaitForSeconds(0.01f);

        }
    }
    public void SwitchSprite(Sprite sprite)
    {
        if (spriteSwitcher.GetImage() != sprite)
        {
            spriteSwitcher.SwitchImage(sprite);
        }
    }

    
}
