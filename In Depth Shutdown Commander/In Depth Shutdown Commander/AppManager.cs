using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Program_Help_Info;

namespace In_Depth_Shutdown_Commander
{
    internal class AppManager
    {
        // Define generic class constructor
        static AppManager() {}

        // Import external powrprof.dll
        [DllImport("powrprof.dll")]
        // Define method setting parameters of suspended state for sleep
        public static extern bool SetSuspendState(bool hibernate, bool forceVritical, bool disableWakeEvent);

        // Define method to verify commands from user input
        public static void VerifyCommandInput(string user_input, string[] help_options, string[] help_commands)
        {
            // Declare & initialize t_command as lowercased user input
            string t_command = user_input.ToLower();
            // Declare & initialize string array t_help_list with "help"
            string[] t_help_list = {"help"};
            // Declare & initialize string array t_command_list
            string[] t_command_list = {""};

            // Execute LowerArrayStrings to merge lowercased arrays into t_help_list
            t_help_list = LowerArrayStrings(help_options, t_help_list);
            // Execute LowerArrayStrings to merge lowercased arrays into t_command_list
            t_command_list = LowerArrayStrings(help_commands, t_command_list);

            /*
            * Check if lowercased user input command is in lowercased arrays;
            * t_help_list or t_command_list
            */
            if (t_help_list.Contains(t_command) || t_command_list.Contains(t_command))
            {
                // Call ExecuteCommand based on provided lowercased user input
                Commands.ExecuteCommand(t_command);
            }
            else
            {
                // Output error message to user
                Console.WriteLine($@"Please enter a correct application command.");
            }
        }

        // Define method to take string arrays and return lowercased array
        public static string[] LowerArrayStrings(string[] StringArray, string[] ArrayToConcat)
        {
            // Foreach loop for string str in StringArray parameter
            foreach (string str in StringArray)
            {
                // Declare & initialize t_loweredStr to lowercased str in parameter
                string t_loweredStr = str.ToLower();
                // Set value of ArrayToConcat parameter to concatenated values of t_loweredStr
                ArrayToConcat = ArrayToConcat.Concat(new string[] {t_loweredStr}).ToArray();
            }

            // Return lowercased concatenated array
            return ArrayToConcat;
        }

        // Define method to calculate hours based on user input
        public static uint CalcHours(uint t_hours)
        {
            // Call UIntExceptionHandler to validate user input & return uint
            t_hours = UIntExceptionHandler(t_hours);
            
            // Set value of t_hours_to_seconds to t_hours * 3600
            uint t_hours_to_seconds = t_hours * 3600;
            // Return uint value of t_hours to seconds
            return t_hours_to_seconds;
        }

        // Define method to calculate minutes based on user input
        public static uint CalcMinutes(uint t_minutes)
        {
            // Call UIntExceptionHandler to validate user input & return uint
            t_minutes = UIntExceptionHandler(t_minutes);

            // Set value of t_minutes_to_seconds to t_minutes * 60
            uint t_minutes_to_seconds = t_minutes * 60;
            // Return uint value of t_minutes to seconds
            return t_minutes_to_seconds;
        }

        // Define method to calculate total of hours, minutes, & seconds
        public static uint CalcTotal(uint hoursInSec, uint minutesInSec, uint seconds)
        {
            // Declare & initialize uint t_total
            uint t_total = 0;
            // Set t_total to value of hoursInSec, minutesInSec, & seconds parameters
            t_total = hoursInSec + minutesInSec + seconds;
            // Return uint value of t_total
            return t_total;
        }

        // Define method to output char value
        public static void nCharString(uint number, char character)
        {
            // Declare & initialize uint t_num_iterations as number parameter
            uint t_num_iterations = number;
            // Declare & initialize char t_special_char as char parameter
            char t_special_char = character;

            // For loop of uint less than iterations
            for (uint i = 0; i < t_num_iterations; i++)
            {
                // Output char
                Console.Write(t_special_char);
            }

            // Output empty newline
            Console.WriteLine();
        }

        // Define method to handle uint exceptions
        public static uint UIntExceptionHandler(uint u)
        {
            // Declare & initialize boolean t_success
            bool t_success = false;

            // While t_success is false
            while (t_success == false)
            {
                // Try block for attempts
                try
                {
                    // Convert user input to uint
                    u = Convert.ToUInt32(Console.ReadLine());
                    // Set t_success to true to break while loop
                    t_success = true;
                }
                // Catch exceptions
                catch (Exception e)
                {
                    // Output error message to user
                    Console.Write(e.Message);
                    // Output custom message to correct error to user
                    Console.WriteLine($@" " + "Please enter an integer starting from 0 or higher.");
                }
            }

            // Return uint value of u
            return u;
        }
    }
}