using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using In_Depth_Shutdown_Commander;

namespace Program_Help_Info
{
    internal static class HelpInformation
    {
        // Define generic class constructor
        static HelpInformation() {}

        // Declare & initialize program greeting
        public static string m_greeting = "Please provide a command to continue, or enter \"Help\" for assistance.";

        // Declare & initialize version number
        public static string m_app_version = "1.0";

        // Declare & initialize member array "help options"
        public static string[] m_help_options = new string[] {
            "Commands",
            "About" };

        // Declare & initialize member array "commands"
        public static string[] m_commands = new string[] {
            "Logout",
            "Logout-t",
            "Sleep",
            "Sleep-t",
            "Hibernate",
            "Hibernate-t",
            "Shutdown",
            "Shutdown-t",
            "Restart",
            "Restart-t",
            "Quit"};

        // Define method to output values of array to user
        public static void ListHelpOptions(string[] options)
        {
            AppManager.nCharString(69, '*');
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(options[i]);
            }
            AppManager.nCharString(69, '*');
        }

        // Define method to output values of array to user
        public static void Command(string[] commands)
        {
            AppManager.nCharString(69, '*');
            for (int i = 0; i < commands.Length; i++)
            {
                Console.WriteLine(commands[i]);
            }
            AppManager.nCharString(69, '*');
        }

        // Define method to output about information to user
        public static void About(string version)
        {
            // Call nCharString to output graphic
            AppManager.nCharString(69, '*');
            // Output about data string to console
            Console.WriteLine($@"In Depth Shutdown Commander
An application for more system 
power off, log out, and suspension control, including timers.
Version: {version}
License: MIT
Built with C#
© 2026 Nick Jones");
            // Call nCharString to output graphic
            AppManager.nCharString(69, '*');
        }
    }
}