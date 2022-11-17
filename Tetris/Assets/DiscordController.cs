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
        try
        {
            string stat = "";
            if (playerlocation == "Menu")
            {
                stat = "In main menu";
            }
            else if (playerlocation == "Game")
            {
                stat = "Playing Unity Tetris";
            }
            discord = new Discord.Discord(1014431358833152010, (System.UInt64)Discord.CreateFlags.NoRequireDiscord);
            var activityManager = discord.GetActivityManager();
            var activity = new Discord.Activity
            {
                State = stat,
                Details = "",
                Assets =
            {
                LargeImage = "logo"
            }
            };
            activityManager.UpdateActivity(activity, (res) =>
            {
                if (res == Discord.Result.Ok)
                {
                    Debug.Log("Discord initialize successful.");
                }
            });
        }
        catch (ResultException)
        {
            Debug.Log("Discord not running");
        }
    }
    public void LogProblemsFunction(Discord.LogLevel level, string message)
    {
        Console.WriteLine("Discord:{0} - {1}", level, message);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            discord.RunCallbacks();
        }
        catch { }

    }
}
