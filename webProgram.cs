/*
* (c) Copyright, Real-Time Innovations, 2021.  All rights reserved.
* RTI grants Licensee a license to use, modify, compile, and create derivative
* works of the software solely for use with RTI Connext DDS. Licensee may
* redistribute copies of the software provided that all such copies are subject
* to this license. The software is provided "as is", with no warranty of any
* type, including any warranty for fitness for any purpose. RTI is under no
* obligation to maintain or support the software. RTI shall not be liable for
* any incidental or consequential damages arising out of the use or inability
* to use the software.
*/

using System;

namespace web
{
    /// <summary>
    /// Runs SensorDataPublisher or SensorDataSubscriber.
    /// </summary>
    public static class SensorDataProgram
    {
        /// <summary>
        /// The Main function runs the publisher or the subscriber.
        /// </summary>
        public static void Main(string[] args)
        {
            var arguments = ParseArguments(args);
            if (arguments == null)
            {
                return;
            }

            if (arguments.Pub)
            {
                Console.WriteLine($"Running SensorDataPublisher on domain {arguments.Domain}");
                SensorDataPublisher.RunPublisher(arguments.Domain, arguments.SampleCount);
            }
            else
            {
                Console.WriteLine($"Running SensorDataSubscriber on domain {arguments.Domain}");
                SensorDataSubscriber.RunSubscriber(arguments.Domain, arguments.SampleCount);
            }
        }

        private class Arguments
        {
            public bool Pub { get; set; }
            public bool Sub { get; set; }
            public int Domain { get; set; }
            public int SampleCount { get; set; } = int.MaxValue;
            public bool Version { get; set; }
        }

        // Uses the System.CommandLine package to parse the program arguments.
        private static Arguments ParseArguments(string[] args)
        {
            // Create a root command with some options
            var rootCommand = new System.CommandLine.RootCommand
            {
                new System.CommandLine.Option<bool>(
                    new string[] { "--pub", "-p" },
                description: "Whether to run the publisher application"),
                new System.CommandLine.Option<bool>(
                    new string[] { "--sub", "-s" },
                description: "Whether to run the subscriber application"),
                new System.CommandLine.Option<int>(
                    new string[] { "--domain", "-d" },
                getDefaultValue: () => 0,
                description: "Domain ID used to create the DomainParticipant"),
                new System.CommandLine.Option<int>(
                    new string[] { "--sample-count", "-c" },
                getDefaultValue: () => int.MaxValue,
                description: "Number of samples to publish or subscribe to"),
                new System.CommandLine.Option<bool>(
                    "--version",
                    description: "Displays the RTI Connext version"),
                };

            rootCommand.Description = "Example RTI Connext Publisher and Subscriber."
            + "\nSee README.txt for more information";

            Arguments result = null;
            rootCommand.Handler = System.CommandLine.Invocation.CommandHandler.Create(
                (Arguments arguments) => result = arguments);

            System.CommandLine.CommandExtensions.Invoke(rootCommand, args);

            if (result == null)
            {
                return null;
            }

            if (result.Version)
            {
                Console.WriteLine(Rti.Dds.Core.ServiceEnvironment.Instance.Version);
                return null;
            }

            if (!result.Pub && !result.Sub)
            {
                Console.WriteLine(rootCommand.Description);
                Console.WriteLine("\nYou can specify --pub or --sub to choose which application to run (or -h for help).");
                Console.WriteLine("For example:\n    dotnet run -- --pub\n");
                Console.Write("Which one do you want to run? Enter 'pub' or 'sub' > ");
                var choice = Console.ReadLine();
                result.Pub = choice.StartsWith("p", StringComparison.OrdinalIgnoreCase);
            }

            if (result.SampleCount < 0)
            {
                result.SampleCount = int.MaxValue;
            }

            return result;
        }
    }
} // namespace web
