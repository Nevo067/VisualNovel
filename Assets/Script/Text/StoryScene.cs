using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Data/New Story Scene")]
public class StoryScene : GameScene
{
    public List<Sentence> listSentence;
    
    
    // Start is called before the first frame update
    [System.Serializable]
    public struct Sentence
    {
        public Speaker speaker;
        public string text;
        public List<Action> actions;

        [System.Serializable]
        public struct Action
        {
            public Speaker speaker;
            public int indexSprite;
            public Vector2 coords;
            public TypeAction type;
            public float moveSpeed;
        }
        [System.Serializable]
        public enum TypeAction
        {
            NONE, APPEAR, MOVE, DISAPEAR
        }

        
    }
}
