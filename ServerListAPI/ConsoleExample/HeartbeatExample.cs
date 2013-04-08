/*
 * Copyright 2013 Gamemakergm <gamemakergm@safaree.org>
 * This work is licensed under the Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License. 
 * To view a copy of this license, visit http://creativecommons.org/licenses/by-nc-sa/3.0/ or send a letter to
 * Creative Commons, 444 Castro Street, Suite 900, Mountain View, California, 94041, USA.
 */
using System.Collections.Specialized;
using ServerListAPI;
namespace ConsoleExample
{
    /// <summary>
    /// Example of a heartbeat to be pumped.
    /// </summary>
    public sealed class HeartbeatExample : IHeartbeat
    {
        /// <summary>
        /// Name of heartbeat.
        /// </summary>
        public string Name { get { return "ExampleBeat"; } }
        /// <summary>
        /// URL to send data to.
        /// Web address to your main .php file (beat.php)
        /// </summary>
        public string BeatURL { get { return "http://www.safaree.org/beat.php"; } }
        /// <summary>
        /// Data values to post.
        /// </summary>
        public NameValueCollection Data
        {
            get
            {
                /*
                 * Create new collection every time.
                 * We do this to send new values in case values were updated from somewhere.
                 * Ex: Modifying values inside the game for the server.
                 */
                NameValueCollection temp = new NameValueCollection() 
                { 
                    { "serverName", ServerExample.Server.ServerName },
                    { "isPublic", ServerExample.Server.IsPublic.ToString() }
                };
                return temp;
            }
        }
    }
}
