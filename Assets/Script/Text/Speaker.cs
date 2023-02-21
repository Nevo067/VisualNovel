using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Speaker", menuName = "Data/New Speaker")]
[System.Serializable]
public class Speaker : ScriptableObject
{
    public string nameCharacter;
    public Color color;
    public List<Sprite> sprites;
    public SpriteController prefab;


}
