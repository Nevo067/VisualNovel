using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewChoiceStoryScene", menuName = "Data/New Choice Story Scene")]
public class ChoceStoryScene : GameScene
{
    public List<ChoiceLabel> choice;

    [System.Serializable]
    public struct ChoiceLabel
    {
        string label;
        StoryScene storyScene;
    }
}
