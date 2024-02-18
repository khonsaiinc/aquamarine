using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{  
    public void Bind(Story story,SetVase setVase)
    {
        story.BindExternalFunction("grabItem", (string itemName) => grabItemManager(itemName,setVase));

        story.BindExternalFunction("clearNPC", (string destroyNPC) => ClearNPC(destroyNPC,setVase));

    }

    public void Unbind(Story story) 
    {
        story.UnbindExternalFunction("grabItem");
        
        story.UnbindExternalFunction("clearNPC");
    }

    public void grabItemManager(string itemName,SetVase vase){
        switch (itemName)
        {
            case "Box":
                vase.ShowVaseImage();
                break;

            default:
                Debug.Log("it's not correct on argument, dosen't work");
                break;
        }
    }

    public void ClearNPC(string destroyNPC,SetVase vase)
    {
        switch (destroyNPC)
        {
            case "Destroy":
                vase.NPCDestroy();
                break;

            default:
                Debug.Log("it's not correct on argument, dosen't work");
                break;
        }
        
    }
}