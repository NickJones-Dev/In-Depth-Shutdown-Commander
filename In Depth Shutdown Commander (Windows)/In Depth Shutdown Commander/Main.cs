/*
 * File: Main.cs
 * Author: Nick Jones
 * 2026-01-09
 * Description:
    This application's purpose is to provide options
    to enable the user to power off or logout of their system more flexibly.
 */

using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using Program_Help_Info;
using In_Depth_Shutdown_Commander;

public class Program
{
    static void Main()
    {
        // Set console output encoding to UTF-8
        Console.OutputEncoding = Encoding.UTF8;
        // Call nCharString to output graphic
        AppManager.nCharString(69, '*');
        // Output string to console
        Console.WriteLine($@"Welcome to the In Depth Shutdown Commander." +
            "\n" +
            HelpInformation.m_greeting);
        // Call nCharString to output graphic
        AppManager.nCharString(69, '*');

        // Console.WriteLine(AppManager.CalcHours());

        // While loop to activate program
        while (true) {
            // Declare string for user command option
            string user_option;
            // Input string to user command option
            user_option = Console.ReadLine() ?? "";

            // Call VerifyCommandInput to check if user string input in arrays
            AppManager.VerifyCommandInput(user_option, HelpInformation.m_help_options, HelpInformation.m_commands);
        }
    }
}