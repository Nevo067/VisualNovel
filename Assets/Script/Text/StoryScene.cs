using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Data/New Story Scene")]
public class StoryScene : ScriptableObject
{
    public List<Sentence> listSentence;
    public Sprite background;
    public StoryScene nextScene;
    // Start is called before the first frame update
    [System.Serializable]
    public struct Sentence
    {
        public Speaker speaker;
        public string text;
        
    }
}
