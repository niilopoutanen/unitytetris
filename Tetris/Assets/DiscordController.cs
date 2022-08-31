using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;
using System;
using System.Security.Cryptography;

public class DiscordController : MonoBehaviour
{
    public Discord.Discord discord;
    public string playerlocation;
    // Start is called before the first frame update
    void Start()
    {
        string stat = "";
        if (playerlocation == "Menu")
        {
            stat = "In main menu";
        }
        else if (playerlocation == "Game")
        {
            stat = "Playing Tetris";
        }
        discord = new Discord.Discord(1014431358833152010, (System.UInt64)Discord.CreateFlags.NoRequireDiscord);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            State = stat,
            Assets =
            {
                LargeImage = "logo"
            }
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Discord.Result.Ok)
            {
                Debug.LogError("Everything is fine!");
            }
        });
    }
    public void LogProblemsFunction(Discord.LogLevel level, string message)
    {
        Console.WriteLine("Discord:{0} - {1}", level, message);
    }

    // Update is called once per frame
    void Update()
    {
        discord.RunCallbacks();
        discord.SetLogHook(Discord.LogLevel.Debug, LogProblemsFunction);

    }
}
