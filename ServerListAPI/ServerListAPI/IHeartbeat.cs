/*
 * Copyright 2013 Gamemakergm <gamemakergm@safaree.org>
 * This work is licensed under the Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License. 
 * To view a copy of this license, visit http://creativecommons.org/licenses/by-nc-sa/3.0/ or send a letter to
 * Creative Commons, 444 Castro Street, Suite 900, Mountain View, California, 94041, USA.
 */
using System.Collections.Specialized;
namespace ServerListAPI
{
    /// <summary>
    /// Represents a heartbeat.
    /// </summary>
    public interface IHeartbeat
    {
        /// <summary>
        /// Name of heartbeat.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Data values to post.
        /// </summary>
        NameValueCollection Data { get; }
        /// <summary>
        /// URL to send data to.
        /// Web address to your main .php file (beat.php)
        /// </summary>
        string BeatURL { get; }
    }
}
