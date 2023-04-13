# Introduction 
This is a boilerplate project using playwright for .Net Core

# Getting Started
More information about Playwright can be found here - https://playwright.dev/dotnet/docs/intro

 1. Clone the project
 2. SlowCheetah - as a visual studio extension and ensure it is also installed as a nuget package
 3. NUnit 3 Test Adapter - as a visual studio extension
 4. NUnit VS Templates - as a visual studio extension
 5. From command line, navigate to where the main test directory lives
 6. Install required browsers using this command - replace netX with actual output folder name, f.ex. net6.0.
*pwsh bin\Debug\netX\playwright.ps1 install*

# Build and Test
You can run your tests one of two ways:
 * Run using Test Explorer
 * From command line, navigate to where the main test directory lives, and run the command *dotnet test*

# Outstanding Items
 * Reporting
 * Logging
 * Cross browser configuration
 * Setup hooks
 * Environment configuration transformation Setup

# Contribute
If you want to contribute, please reach out to Antwan Maddox