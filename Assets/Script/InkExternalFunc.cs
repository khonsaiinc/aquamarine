using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{
    public void Bind(Story story, DialogueTalking afterTalking)
    {
        story.BindExternalFunction("grabItem", (string itemName) => grabItemManager(itemName, afterTalking));
        story.BindExternalFunction("clearNPC", (string destroyNPC) => ClearNPC(destroyNPC, afterTalking));
        story.BindExternalFunction("questCheck", (string whoTalked) => Talked(whoTalked, afterTalking));
        story.BindExternalFunction("openItem", (string itemName) => openItemManager(itemName, afterTalking));
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("grabItem");
        story.UnbindExternalFunction("clearNPC");
        story.UnbindExternalFunction("questCheck");
        story.UnbindExternalFunction("openItem");
    }

    public void grabItemManager(string itemName, DialogueTalking afterTalking)
    {
        switch (itemName)
        {
            case "Box":
                afterTalking.setVase.GetBox();
                break;
            case "OpenBox":
                afterTalking.setVase.OpenBox();
                break;
            default:
                Debug.Log("it's not correct on argument, dosen't work");
                break;
        }
    }
    public void openItemManager(string itemName, DialogueTalking afterTalking)
    {
        switch (itemName)
        {
            case "OpenBox":
                afterTalking.setVase.OpenBox();
                break;
            default:
                Debug.Log("it's not correct on argument, dosen't work");
                break;
        }
    }

    public void ClearNPC(string destroyNPC, DialogueTalking afterTalking)
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

    public void Talked(string whoTalked, DialogueTalking afterTalking)
    {
        switch (whoTalked)
        {
            case "TakedaFrontSuperMarket":
                QuestCheck.questTalkTakeda = true;
                afterTalking.takedaOutside.isTalkedEnableDoor();
                break;
            case "MoveOldlady":
                QuestCheck.questTalkOldLady = true;
                afterTalking.oldLadyTalking.moveOldlady();
                break;
            case "DisableTriggerTakedaChangeShift":
                QuestCheck.questTalkTakeda_inSuperMarket = true;
                afterTalking.disableTalking.DisableTirgger();
                afterTalking.disableTalking.changeShift = false;
                break;
            default:
                Debug.Log("it's not correct on argument, dosen't work");
                break;
        }

    }
}