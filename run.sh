#!/bin/bash

# Program: Exit Sign
# Author: Nathan Eduvala

echo "Removing old binary files"
echo "..."
rm *.dll
echo "..."
rm *.exe
echo "Binary files have been removed"

echo "view list of source files"
ls -l

echo "Compile UI.cs to create the file: UI.dll"
mcs -target:library -r:System.Windows.Forms.dll -r:System.Drawing.dll -out:ExitmainUI.dll ExitmainUI.cs

echo "Compile Exitmain.cs and link the previously created UI.dll file to create an executable file."
mcs -r:System -r:System.Windows.Forms -r:ExitmainUI.dll -out:Exitmain.exe Exitmain.cs

echo "View the list of files in the current folder"
ls -l

echo "Run the program: Exit Sign"
./Exitmain.exe

echo "The script has been terminated."
