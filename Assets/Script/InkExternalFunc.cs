using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{  
    public void Bind(Story story,DialogueTalking afterTalking)
    {
        story.BindExternalFunction("grabItem", (string itemName) => grabItemManager(itemName,afterTalking));

        story.BindExternalFunction("clearNPC", (string destroyNPC) => ClearNPC(destroyNPC,afterTalking));

        story.BindExternalFunction("questCheck", (string whoTalked) => Talked(whoTalked,afterTalking));

    }

    public void Unbind(Story story) 
    {
        story.UnbindExternalFunction("grabItem");
        
        story.UnbindExternalFunction("clearNPC");
    }

    public void grabItemManager(string itemName,DialogueTalking afterTalking){
        switch (itemName)
        {
            case "Box":
                afterTalking.setVase.GetBox();
                break;

            default:
                Debug.Log("it's not correct on argument, dosen't work");
                break;
        }
    }

    public void ClearNPC(string destroyNPC,DialogueTalking afterTalking)
    {
        switch (destroyNPC)
        {
            case "Destroy":
                afterTalking.setVase.NPCDestroy();
                break;

            default:
                Debug.Log("it's not correct on argument, dosen't work");
                break;
        }
        
    }

    public void Talked(string whoTalked,DialogueTalking afterTalking)
    {
        switch (whoTalked)
        {
            case "TakedaFrontSuperMarket":
                QuestCheck.questTalkTakeda = true;
                afterTalking.takedaOutside.isTalkedEnableDoor();
                break;

            default:
                Debug.Log("it's not correct on argument, dosen't work");
                break;
        }
        
    }
}