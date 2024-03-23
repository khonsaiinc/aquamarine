using UnityEngine;
using Ink.Runtime;
using Unity.Mathematics;

public class InkExternalFunctions
{
    public void Bind(Story story, DialogueTalking afterTalking)
    {
        story.BindExternalFunction("grabItem", (string itemName) => grabItemManager(itemName, afterTalking));
        story.BindExternalFunction("clearNPC", (string destroyNPC) => ClearNPC(destroyNPC, afterTalking));
        story.BindExternalFunction("questCheck", (string whoTalked) => Talked(whoTalked, afterTalking));
        story.BindExternalFunction("openItem", (string itemName) => openItemManager(itemName, afterTalking));
        story.BindExternalFunction("neighborEvent", (string sleepOrsurvey) => NeighborEvent(sleepOrsurvey, afterTalking));
        story.BindExternalFunction("doorLockEvent", (string actions) => DoorLockEvent(actions, afterTalking));
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
            case "CloseBox":
                afterTalking.setVase.CloseBox();
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
                QuestManager.instance.OnCompleteQuest();
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
                QuestManager.instance.ResetStock();
                break;
            case "MoveOldlady":
                QuestCheck.questTalkOldLady = true;
                afterTalking.oldLadyTalking.moveOldlady();
                break;
            case "DisableTriggerTakedaChangeShift":
                QuestCheck.questTalkTakeda_inSuperMarket = true;
                afterTalking.disableTalking.DisableTirgger();
                afterTalking.disableTalking.changeShift = false;
                QuestManager.instance.OnCompleteQuest();
                break;
            case "TakedaFrontSuperMarketDay2":
                QuestCheck.questTalkTakedaDay2 = true;
                afterTalking.takedaOutsideDay2.isTalkedEnableDoor();
                QuestManager.instance.ResetStock();
                break;
            default:
                Debug.Log("it's not correct on argument, dosen't work");
                break;
        }

    }

    public void NeighborEvent(string sleepOrsurvey, DialogueTalking afterTalking)
    {
        switch (sleepOrsurvey)
        {
            case "Survey":
                QuestCheck.NeighborSurvey = true;
                afterTalking.surveyEvent.StartNeighborSurveyEvent();
                QuestManager.instance.OnCompleteQuest();
                break;
            case "Sleep":
                QuestCheck.questCheckWakeUpDay2 = true;
                afterTalking.surveyEvent.ContinueToSleep();
                QuestManager.instance.OnCompleteQuest();
                QuestManager.instance.OnCompleteQuest();
                QuestCheck.canChangeOutfit = true;
                afterTalking.changeOutfit.WardrobeOpen();
                break;
            default:
                Debug.Log("it's not correct on argument, dosen't work");
                break;
        }
    }

    public void DoorLockEvent(string actions, DialogueTalking afterTalking)
    {
        switch (actions)
        {
            case "StartTimeline":
                afterTalking.timelineToPlay.Play();
                break;
            case "UnlockDoor":
                afterTalking.dialogueInTimeline.OnEndDialogue();
                break;
            default:
                Debug.Log("it's not correct on argument, dosen't work");
                break;
        }
    }
}