using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{  
    public void Bind(Story story,SetVase setVase)
    {
        story.BindExternalFunction("grabItem", (string itemName) => grabItemManager(itemName,setVase));

    }

    public void Unbind(Story story) 
    {
        story.UnbindExternalFunction("grabItem");
    }

    public void grabItemManager(string itemName,SetVase vase){
        switch (itemName)
        {
            case "Box":
                vase.ShowVaseImage();
                Debug.Log("it's correct on argument, works, Show: " + itemName);
                break;
            default:
                Debug.Log("it's not correct on argument, dosen't work");
                break;
        }
    }
}