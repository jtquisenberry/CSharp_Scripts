# CSharp_Scripts
CSharp Snippets in CSX Form

## Usage
CSX files are C# script files. They can be edited in Visual Studio Code, which makes us of Intellisense.
Scripts must be run using a command line application `scriptcs`.

## Installation of scriptcs
To install scriptcs, first install Chocolatey using PowerShell run in administrative mode.
Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))
See https://chocolatey.org/install

Use chocolatey to install scriptcs
cinst scriptcs
See https://code.visualstudio.com/docs/editor/versioncontrol

## Execution Example
cd basic
scriptcs .\dogs.csx
