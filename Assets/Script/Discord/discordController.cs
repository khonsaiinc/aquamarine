using UnityEngine;
using Discord;
using System.IO;
using Newtonsoft.Json.Linq;

public class DiscordController : MonoBehaviour
{
    public string discordApplicationID;
    [Tooltip("Path to the JSON file containing the Discord application ID")]
    public string discordAppIDFilePath = "Assets/Script/Discord/discordApplicationID.json";

    private Discord.Discord discord;

    void Start()
    {
      if (string.IsNullOrEmpty(discordApplicationID))
      {
        // Try to load from JSON file (optional)
        if (TryLoadDiscordIDFromFile())
        {
          Debug.Log("Successfully loaded Discord application ID from JSON file.");
        }
        else
        {
          Debug.LogError("Failed to load Discord application ID. Please ensure the file exists and is properly formatted.");
          return; // Exit to prevent further issues
        }
      }
    
      long applicationID = long.Parse(discordApplicationID);
      discord = new Discord.Discord(applicationID, (System.UInt64)Discord.CreateFlags.Default);
    
      var activityManager = discord.GetActivityManager();
      var activity = new Activity
      {
        Assets =
        {
          SmallImage = "icon" // Replace with your small image asset name
        }
      };
    
      activityManager.UpdateActivity(activity, (result) =>
      {
        if (result == Result.Ok)
        {
          Debug.Log("Everything is fine!, Sent to Discord");
        }
        else
        {
          Debug.LogError($"Failed to update Discord activity: {result}");
        }
      });
    }

    void Update()
    {
        try
        {
            discord.RunCallbacks();
        }
        catch
        {
            Destroy(gameObject);
        }
    }

    void OnApplicationQuit()
    {
        var activityManager = discord.GetActivityManager();
        var activity = new Activity(); // No details needed

        activityManager.UpdateActivity(activity, (result) =>
        {
            if (result == Result.Ok)
            {
                Debug.Log("Game closed, Discord status cleared");
            }
            else
            {
                Debug.LogError($"Failed to clear Discord activity on application quit: {result}");
            }
        });
    }

    void OnDisable()
    {
        var activityManager = discord.GetActivityManager();
        var activity = new Activity
        {
            // No details
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Result.Ok)
            {
                Debug.Log("Game closed, Discord status cleared");
            }
        });
    }

    private bool TryLoadDiscordIDFromFile()
    {
        if (!File.Exists(discordAppIDFilePath))
        {
            return false;
        }

        try
        {
            using (StreamReader reader = File.OpenText(discordAppIDFilePath))
            {
                string jsonString = reader.ReadToEnd();
                JObject jsonObject = JObject.Parse(jsonString);

                discordApplicationID = jsonObject["DiscordAppliID"].ToString();
                return true;
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error loading Discord application ID from JSON file: {ex.Message}");
            return false;
        }
    }
}
