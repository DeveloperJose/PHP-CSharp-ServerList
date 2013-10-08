/*
 * Copyright 2013 Gamemakergm <gamemakergmdev@gmail.com>
 * This work is licensed under the Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License. 
 * To view a copy of this license, visit http://creativecommons.org/licenses/by-nc-sa/3.0/ or send a letter to
 * Creative Commons, 444 Castro Street, Suite 900, Mountain View, California, 94041, USA.
 */
using System;
using ServerListAPI;
namespace ConsoleExample
{
    /// <summary>
    /// Sample test of a server.
    /// </summary>
    public sealed class ServerExample : IHeartbeatServer
    {
        #region IHeartbeatServer Members
        /// <summary>
        /// Logs messages from the Heartbeater.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("HeartbeatManager>>>: {0}", message);
            Console.ResetColor();
        }
        /// <summary>
        /// Web address to your IP getter file (ip.php)
        /// </summary>
        public string IPAddress { get { return "http://www.safaree.org/ip.php"; } }
        #endregion

        #region Main Instance
        /// <summary>
        /// Main server example instance.
        /// </summary>
        public static ServerExample Server { get; set; }
        #endregion

        #region Dummy Data
        /// <summary>
        /// Dummy data to be sent to heartbeat.
        /// </summary>
        public bool IsPublic { get; private set; }
        /// <summary>
        /// Dummy data to be sent to heartbeat.
        /// </summary>
        public string ServerName { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new server example.
        /// </summary>
        /// <param name="serverName">Server name (Dummy data)</param>
        /// <param name="isPublic">If the server is public (Dummy data)</param>
        public ServerExample(string serverName, bool isPublic)
        {
            ServerName = serverName;
            IsPublic = isPublic;
            Server = this;
        }
        #endregion
    }
}
