using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Program_Help_Info;

namespace In_Depth_Shutdown_Commander
{
    internal class Commands
    {
        // Define generic class constructor
        static Commands() {}

        // Define method to start countdown timer for nonstandard operator commands
        public static void CountdownTimer(string command_input)
        {
            /*
             * Declare & initialize unit variables for countdown
             * Hours, Minutes, Seconds
             */
            uint t_hours = 0;
            uint t_minutes = 0;
            uint t_seconds = 0;

            // Declare an initialize uint for miliseconds as 1 second
            int t_milliseconds = 1000;

            // Output message to user
            Console.WriteLine($@"Please enter time in hours for the countdown timer.");
            // Call CalcHours to calculate & verify user input
            t_hours = AppManager.CalcHours(t_hours);

            // Output message to user
            Console.WriteLine($@"Please enter time in minutes for the countdown timer.");
            // Call CalcMinutes to calculate & verify user input
            t_minutes = AppManager.CalcMinutes(t_minutes);

            // Output message to user
            Console.WriteLine($@"Please enter time in seconds for the countdown timer.");
            // Set value of t_seconds from validated user input uint
            t_seconds = AppManager.UIntExceptionHandler(t_seconds);

            // Declare & initialize CD_timer
            uint CD_Timer = AppManager.CalcTotal(t_hours, t_minutes, t_seconds);

            // While loop to decrement countdown timer until 0 seconds left
            while (CD_Timer > 0)
            {
                // Sleep main thread for 1000 miliseconds (or 1 second)
                Thread.Sleep(t_milliseconds);
                // Decrement countdown timer
                CD_Timer--;
            }

            // Switch statement to execute based on input string
            switch (command_input)
            {
                // Case user input logout-t
                case "logout-t":
                    // Call process to logout of system
                    Process.Start("shutdown", $@"/l");
                    // Break case statement
                    break;
                // Case user input sleep-t
                case "sleep-t":
                    // Call SetSuspendState to sleep system
                    AppManager.SetSuspendState(false, true, true);
                    // Break case statement
                    break;
                // Case user input hibernate-t
                case "hibernate-t":
                    // Call process to hibernate system
                    Process.Start("shutdown", $@"/h");
                    // Break case statement
                    break;
                case "shutdown-t":
                    // Call process to shutdown system
                    Process.Start("shutdown");
                    // Break case statement
                    break;
                case "restart-t":
                    // Call process to restart system
                    Process.Start("shutdown", $@"/r");
                    // Break case statement
                    break;
            }
        }

        // Define method to execute user input command by string case statement
        public static void ExecuteCommand(string command_input)
        {
            // Declare & initialize array t_timer_commands
            string[] t_timer_commands = new string[]
            {
                "logout-t",
                "sleep-t",
                "hibernate-t",
                "shutdown-t",
                "restart-t"
            };

            // Switch statement to execute based on input string
            switch (command_input)
            {
                // Case user input help
                case "help":
                    // Call ListHelpOptions to display list of options
                    HelpInformation.ListHelpOptions(HelpInformation.m_help_options);
                    // Break case statement
                    break;
                // Case user input commands
                case "commands":
                    // Call ListHelpOptions to display list of commands
                    HelpInformation.ListHelpOptions(HelpInformation.m_commands);
                    // Break case statement
                    break;
                // Case user input about
                case "about":
                    // Call About to application information to user
                    HelpInformation.About(HelpInformation.m_app_version);
                    // Break case statement
                    break;
                // Case user input logout
                case "logout":
                    // Call process to logout of system
                    Process.Start("shutdown", $@"/l");
                    // Break case statement
                    break;
                // Case user input sleep
                case "sleep":
                    // Call SetSuspendState to suspend system in sleep
                    AppManager.SetSuspendState(false, true, true);
                    // Break case statement
                    break;
                // Case user input hibernate
                case "hibernate":
                    // Call process to hibernate system
                    Process.Start("shutdown", $@"/h");
                    // Break case statement
                    break;
                // Case user input shutdown
                case "shutdown":
                    // Call process to shutdown system
                    Process.Start("shutdown");
                    // Break case statement
                    break;
                // Case user input restart
                case "restart":
                    // Call process to restart system
                    Process.Start("shutdown", $@"/r");
                    // Break case statement
                    break;
                // Case user input contains timer command
                case var input when t_timer_commands.Contains(input):
                    // Call CountdownTimer to set timer
                    CountdownTimer(command_input);
                    // Break case statement
                    break;
                // Case user input quit
                case "quit":
                    // Exit application with successful completion
                    Environment.Exit(0);
                    // Break case statement
                    break;
            }
        }
    }
}