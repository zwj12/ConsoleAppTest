﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Configuration
{
    public class Config
    {
        public static void CreateAppSettings()
        {
            // Get the application configuration file.
            System.Configuration.Configuration config =
              ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            string sectionName = "appSettings";

            // Add an entry to appSettings.
            int appStgCnt =
                ConfigurationManager.AppSettings.Count;
            string newKey = "NewKey" + appStgCnt.ToString();

            string newValue = DateTime.Now.ToLongDateString() +
              " " + DateTime.Now.ToLongTimeString();

            config.AppSettings.Settings.Add(newKey, newValue);



            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);

            AppSettingsSection appSettingSection =
  (AppSettingsSection)config.GetSection(sectionName);     
            
            // Force a reload of the changed section. This 
            // makes the new values available for reading.
            ConfigurationManager.RefreshSection(sectionName);

            // Get the AppSettings section.
            appSettingSection =
              (AppSettingsSection)config.GetSection(sectionName);

            ConfigurationManager.RefreshSection(sectionName);

            Console.WriteLine();
            Console.WriteLine("Using GetSection(string).");
            Console.WriteLine("AppSettings section:");
            Console.WriteLine(
              appSettingSection.SectionInformation.GetRawXml());
        }

        public static void MapExeConfiguration()
        {

            // Get the application configuration file.
            System.Configuration.Configuration config =
              ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            Console.WriteLine(config.FilePath);

            if (config == null)
            {
                Console.WriteLine(
                  "The configuration file does not exist.");
                Console.WriteLine(
                 "Use OpenExeConfiguration to create the file.");
            }

            // Create a new configuration file by saving 
            // the application configuration to a new file.
            string appName =
              Environment.GetCommandLineArgs()[0];

            string configFile = string.Concat(appName,
              ".2.config");
            config.SaveAs(configFile, ConfigurationSaveMode.Full);

            // Map the new configuration file.
            ExeConfigurationFileMap configFileMap =
                new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = configFile;

            // Get the mapped configuration file
            config =
               ConfigurationManager.OpenMappedExeConfiguration(
                 configFileMap, ConfigurationUserLevel.None);

            // Make changes to the new configuration file. 
            // This is to show that this file is the 
            // one that is used.
            string sectionName = "consoleSection";

            //ConsoleSection customSection =
            //  (ConsoleSection)config.GetSection(sectionName);

            //if (customSection == null)
            //{
            //    customSection = new ConsoleSection();
            //    config.Sections.Add(sectionName, customSection);
            //}
            //else
            //    // Change the section configuration values.
            //    customSection =
            //        (ConsoleSection)config.GetSection(sectionName);

            //customSection.ConsoleElement.BackgroundColor =
            //    ConsoleColor.Green;
            //customSection.ConsoleElement.ForegroundColor =
            //    ConsoleColor.Red;

            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of the changed section. This 
            // makes the new values available for reading.
            ConfigurationManager.RefreshSection(sectionName);

            // Set console properties using the 
            // configuration values contained in the 
            // new configuration file.
            //Console.BackgroundColor =
            //  customSection.ConsoleElement.BackgroundColor;
            //Console.ForegroundColor =
            //  customSection.ConsoleElement.ForegroundColor;
            //Console.Clear();

            Console.WriteLine();
            Console.WriteLine("Using OpenMappedExeConfiguration.");
            Console.WriteLine("Configuration file is: {0}",
              config.FilePath);
        }
    }
}
