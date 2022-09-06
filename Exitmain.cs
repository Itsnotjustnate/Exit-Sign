//==========================================================================================|
// Program name: "Exit Sign". 
// The main function of this program is to display an exit sign that can be shown or
// hidden by the click of a button.
// This program demonstrates how to make panels, place text and objects in a panel, how
// to declare a button and connect it to an action, and how to declare a UI in software.
//       Copyright (C) 2022 Nathan Eduvala
//
// This file is part of the software program "Exit Sign"
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//==========================================================================================|
//
// Author Information
//   Author name: Nathan Eduvala
//   Author email: nathaneduvala@csu.fullerton.edu
//
// Program Information
//  Program name: Exit Sign
//  Programming languages: Two modules in C#
//  Date program began: 2022-Sep-03
//  Date of last update: 2022-Sep-04
//  Date of reorganization of comments: 2022-Sep-04
//  Files in this program: Exitmain.cs, ExitmainUI.cs
//  Status: Finished
//
// This file
//   File name: Exitmain.cs
//   Language: C#
//   Compile: mcs -target:library -r:System.Windows.Forms.dll -r:System.Drawing.dll -out:ExitmainUI.dll ExitmainUI.cs
//   Link: mcs -r:System -r:System.Windows.Forms -r:ExitmainUI.dll -out:Exitmain.exe Exitmain.cs
//
//==========================================================================================|
//==========================================================================================|
//==============================  Begin coding down below  =================================|
//==========================================================================================|
//==========================================================================================|

using System;
using System.Windows.Forms;
public class Exitmain
{
    public static void Main()
    {
        System.Console.WriteLine("The main function of the program, Exit Sign will begin now.");
        ExitmainUI UI_form = new ExitmainUI();
        Application.Run(UI_form);
        System.Console.WriteLine("The graphics for this program has ended. Good bye.");
    }
}