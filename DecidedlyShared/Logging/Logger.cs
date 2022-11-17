﻿using System;
using StardewModdingAPI;
using StardewValley;

namespace DecidedlyShared.Logging
{
    public class Logger
    {
        private readonly IMonitor monitor;

        private ITranslationHelper translationHelper;
        //private HashSet<> messageQueue;

        public Logger(IMonitor monitor, ITranslationHelper translationHelper = null)
        {
            this.monitor = monitor;
            this.translationHelper = translationHelper;
        }

        public void Log(string logMessage, LogLevel logLevel = LogLevel.Info, bool displayInHud = false)
        {
            this.monitor.Log(logMessage, logLevel);

            // If this is marked as should be displayed, we display it on the screen if we're in-game.
            if (Context.IsWorldReady && (displayInHud))
            {
                HUDMessage message = new(logMessage, 2);

                if (!Game1.doesHUDMessageExist(logMessage))
                    Game1.addHUDMessage(message);
            }
        }

        public void Error(string logMessage, bool displayInHud = false)
        {
            this.Log(logMessage, LogLevel.Error, displayInHud);
        }

        public void Warn(string logMessage, bool displayInHud = false)
        {
            this.Log(logMessage, LogLevel.Warn, displayInHud);
        }

        public void Exception(Exception e)
        {
            this.monitor.Log($"Exception: {e.Message}", LogLevel.Error);
            this.monitor.Log($"Full exception data: \n{e.Data}", LogLevel.Error);
        }
    }
}
