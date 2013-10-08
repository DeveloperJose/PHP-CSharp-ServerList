/*
 * Copyright 2013 Gamemakergm <gamemakergmdev@gmail.com>
 * This work is licensed under the Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License. 
 * To view a copy of this license, visit http://creativecommons.org/licenses/by-nc-sa/3.0/ or send a letter to
 * Creative Commons, 444 Castro Street, Suite 900, Mountain View, California, 94041, USA.
 */
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Timers;

namespace ServerListAPI
{
    /// <summary>
    /// Manages the heartbeat pumping.
    /// </summary>
    public sealed class HeartbeatManager
    {
        #region Manager Variables
        /// <summary>
        /// Contains all the heartbeats that should be sent by this manager.
        /// </summary>
        private IHeartbeat Heartbeat { get; set; }
        /// <summary>
        /// Server that contains the information that is essential for the manager.
        /// </summary>
        private IHeartbeatServer Server { get; set; }
        /// <summary>
        /// Whether or not the manager is running.
        /// </summary>
        private bool IsRunning { get; set; }
        #endregion

        #region Timer Variables
        /// <summary>
        /// System.Threading Timer that sends heartbeats.
        /// </summary>
        private Timer UpdateTimer { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new manager that pumps a heartbeat at a specified interval.
        /// </summary>
        /// <param name="heartbeat">Heartbeat to pump.</param>
        /// <param name="interval">Interval to pump at.</param>
        /// <param name="server">Server that manages the Heartbeat information.</param>
        public HeartbeatManager(IHeartbeat heartbeat, TimeSpan interval, IHeartbeatServer server)
        {
            Heartbeat = heartbeat;
            Server = server;

            UpdateTimer = new Timer(interval.TotalMilliseconds);
            UpdateTimer.Start();
            UpdateTimer.Elapsed += UpdateTimerHandler;

            IsRunning = true;

            Server.Log("Manager started!");
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Restarts the manager if it is stopped.
        /// </summary>
        public void Restart()
        {
            if (IsRunning) return; // It's running, no need to start it again.
            Server.Log("Restarting manager.");
            UpdateTimer.Start();
            UpdateTimer.Elapsed += UpdateTimerHandler;
        }
        /// <summary>
        /// Stops the manager.
        /// Use this when shutting down the server.
        /// </summary>
        public void Stop()
        {
            if (!IsRunning) return; // It's already stopped...
            Server.Log("Stopping manager.");
            UpdateTimer.Stop();
            UpdateTimer.Elapsed -= UpdateTimerHandler;
        }
        /// <summary>
        /// Changes the interval between pumps.
        /// </summary>
        /// <param name="milliseconds">Interval to pump at in milliseconds.</param>
        public void ChangeInterval(double milliseconds)
        {
            UpdateTimer.Interval = milliseconds;
        }
        /// <summary>
        /// Changes the interval between pumps.
        /// </summary>
        /// <param name="interval">Interval to pump at.</param>
        public void ChangeInterval(TimeSpan interval)
        {
            ChangeInterval(interval.TotalMilliseconds);
        }
        #endregion

        #region ISender Members
        /// <summary>
        /// Timer elapsed event listener.
        /// Pumps the heartbeat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args">Data containing info on event.</param>
        private void UpdateTimerHandler(object sender, ElapsedEventArgs args)
        {
            using (WebClient webClient = new WebClient())
            {
                string ipAddress;
                bool validIP = GetIPAddress(out ipAddress);
                if (!validIP)
                {
                    Server.Log("Invalid ip gotten from web file! Make sure you used the ip.php included!");
                    Stop();
                    return;
                }
                NameValueCollection temp = new NameValueCollection(Heartbeat.Data) // Get the rest of the data to add key.
                    {
                        { "ip", ipAddress } // This is the key. If you delete this, the database won't work.
                    };
                Server.Log(String.Format("Sent {0} beat!", Heartbeat.Name));
                string response = Encoding.ASCII.GetString(webClient.UploadValues(Heartbeat.BeatURL, temp)); // Get the response.
                Server.Log(String.Format("{0} returned: {1}", Heartbeat.Name, response));
                
            }
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Gets your external IPAddress
        /// </summary>
        /// <returns>True if the ip is a valid ip. False if otherwise.</returns>
        private bool GetIPAddress(out string ip)
        {
            ip = "";
            if (String.IsNullOrEmpty(Server.IPAddress)) // You're supposed to put a web address.
            {
                Server.Log("You didn't specify a web address to your ip getter file!");
                return false;
            }
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    ip = webClient.DownloadString(Server.IPAddress); // Get ip from php file.
                    IPAddress temp; // Used for checking.
                    return IPAddress.TryParse(ip, out temp); // Check for valid ip.
                }
                catch (WebException e)
                {
                    if (e.Status == WebExceptionStatus.NameResolutionFailure) // Not resolved.
                    {
                        Server.Log(String.Format("{0} couldn't be resolved! Most likely bad url! " +
                                                    "Make sure the address is correct.", Server.IPAddress));
                    }
                    else if (e.Status == WebExceptionStatus.UnknownError) // Probably didn't put http at the beginning.
                    {
                        Server.Log(String.Format("Unknown error for {0}! Most likely you didn't add http to the address string.",
                            Server.IPAddress));
                    }
                    else if (e.Status == WebExceptionStatus.ProtocolError) // Most likely 404
                    {
                        HttpWebResponse response = e.Response as HttpWebResponse;
                        if (response.StatusCode == HttpStatusCode.NotFound)
                        {
                            Server.Log(String.Format("Your IP address page({0}) wasn't found! 404", Server.IPAddress));
                        }
                    }
                }
                return false;
            }
        }
        #endregion
    }
}
