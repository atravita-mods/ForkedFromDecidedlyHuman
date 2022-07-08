﻿using System;
using System.Collections.Generic;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Characters;

namespace SmartBuilding.Logging
{
    public class Logger
    {
        private IMonitor monitor;
        private ITranslationHelper translationHelper;
        //private HashSet<> messageQueue;
        
        public Logger(IMonitor monitor, ITranslationHelper translationHelper)
        {
            this.monitor = monitor;
            this.translationHelper = translationHelper;
        }

        public void Log(string logMessage, LogLevel logLevel = LogLevel.Info)
        {
            monitor.Log(logMessage, logLevel);

            // If it's a high priority LogLevel, we display it on the screen.
            if (logLevel >= LogLevel.Warn)
            {
                HUDMessage message = new HUDMessage(logMessage, 2);

                if (!Game1.doesHUDMessageExist(logMessage))
                    Game1.addHUDMessage(message);
            }
        }

        public void Exception(Exception e)
        {
            monitor.Log($"Exception: {e.Message}", LogLevel.Error);
            monitor.Log($"Full exception data: \n{e.Data}", LogLevel.Error);
        }
    }
}