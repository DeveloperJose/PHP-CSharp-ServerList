/*
 * Copyright 2013 Gamemakergm <gamemakergm@safaree.org>
 * This work is licensed under the Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License. 
 * To view a copy of this license, visit http://creativecommons.org/licenses/by-nc-sa/3.0/ or send a letter to
 * Creative Commons, 444 Castro Street, Suite 900, Mountain View, California, 94041, USA.
 */
namespace ServerListAPI
{
    /// <summary>
    /// Defines the fundamental things the HeartbeatManager needs.
    /// </summary>
    public interface IHeartbeatServer
    {
        /// <summary>
        /// Logs messages from the Heartbeater.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void Log(string message);
        /// <summary>
        /// Web address to your IP getter file (ip.php)
        /// </summary>
        string IPAddress { get; }
    }
}
