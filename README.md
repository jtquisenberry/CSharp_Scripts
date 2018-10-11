# CSharp_Scripts
CSharp Snippets in CSX Form

## Usage
CSX files are C# script files. They can be edited in Visual Studio Code, which makes us of Intellisense.
Scripts must be run using a command line application `scriptcs`.

## Installation of scriptcs
To install scriptcs, first install Chocolatey using PowerShell run in administrative mode. <br>
`Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))` <br>
See https://chocolatey.org/install

Use chocolatey to install scriptcs
cinst scriptcs
See https://code.visualstudio.com/docs/editor/versioncontrol

## Execution Example
`cd basic`
`scriptcs .\dogs.csx`


## Create new xUnit project
`dotnet new xunit --force`

## Run a specific test
`dotnet test --filter "FullyQualifiedName=unit_testing001.Arrays_Test.AAAAATest1"`

## Restart the C# interpreter.
1. Press F1.
2. Select Omnisharp: Restart Omnisharp.


# How to Copy InterView Cake Code
1. Ensure that the project is an xunit project: `dotnet new xunit`.
2. Copy a unit testing .CS file. 
3. Change the namespace to something unique with respect to the project. 
4. Copy references.
5. Copy everything below the references from Interview cake to the namespaces.
6. Fix indentation within the namespace.
7. Run the tests by clicking "Run All Tests" or "Debug All Tests".
