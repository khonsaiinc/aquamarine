using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName ="Dialogue/Sentence", order = 0) ]
public class Dialogue : ScriptableObject
{

    public string nameCharacter;
    public Sprite spriteCharacter;

    [TextArea(minLines: 3 , maxLines: 10)]
    public string[] dialogue;

}
