/*
 * Copyright 2013 Gamemakergm <gamemakergm@safaree.org>
 * This work is licensed under the Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License. 
 * To view a copy of this license, visit http://creativecommons.org/licenses/by-nc-sa/3.0/ or send a letter to
 * Creative Commons, 444 Castro Street, Suite 900, Mountain View, California, 94041, USA.
 */
using System;
using ServerListAPI;
namespace ConsoleExample
{
    /// <summary>
    /// Example program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Example heartbeat.
        /// </summary>
        private static HeartbeatExample Heartbeat { get; set; }
        /// <summary>
        /// Manager of the heartbeat.
        /// </summary>
        private static HeartbeatManager Manager { get; set; }
        /// <summary>
        /// Program's entry point.
        /// </summary>
        /// <param name="args">Commandline arguments.</param>
        public static void Main(string[] args)
        {
            Console.Title = "Gamemakergm's Heartbeater.";
            new ServerExample("[MCTest] Gamemakergm's Awesome Build", true); // Create a new server for demonstration purposes.
            Heartbeat = new HeartbeatExample(); // Create the new heartbeat.
            Manager = new HeartbeatManager(Heartbeat, TimeSpan.FromSeconds(5), ServerExample.Server); // 
            while (true)
            {
                if (Console.ReadLine().Equals("h")) Console.WriteLine("H");
            }
        }
    }
}
