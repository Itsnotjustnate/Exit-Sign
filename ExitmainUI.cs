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
//   File name: ExitmainUI.cs
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
using System.Drawing;
using System.Windows.Forms;
public class ExitmainUI : Form 
{
    //declaring the program form attributes
    private const int formwidth = 1280;
    private const int formheight = 1024;
    private Size ui_size = new Size(formwidth, formheight);

    //declaring the program header panel
    private const int header_panel_height = 100;
    private Panel header_panel = new Panel();
    private Point header_panel_location = new Point(0,0);
    private Size header_panel_size = new Size(formwidth, header_panel_height);
    private Color header_panel_color = Color.LightGreen;

    //declaring the program graphic panel
    private const int graphic_panel_height = 800;
    private Graphic_panel sign_panel = new Graphic_panel();
    private Point graphic_panel_location = new Point(0, header_panel_height);
    private Size graphic_panel_size = new Size(formwidth, graphic_panel_height);
    private Color graphic_panel_color = Color.Gray;

    //declaring the program control panel
    private const int control_panel_height = formheight - header_panel_height - graphic_panel_height;
    private Panel control_panel = new Panel();
    private Point control_panel_location = new Point(0,header_panel_height + graphic_panel_height);
    private Size control_panel_size = new Size(formwidth, control_panel_height);
    private Color control_panel_color = Color.Aquamarine;

    //declaring header label attributes
    private String header_message_text = "Exit Sign by Nathan Eduvala";
    private Label header_message = new Label();
    private Point header_message_location = new Point(100,15);
    private Font header_message_font = new Font("Arial", 25, FontStyle.Bold);
    private Size header_message_size = new Size(200,60);

    //declaring Exit label attributes
    private String graphic_message_text = "EXIT";
    private Label graphic_message = new Label();
    private Point graphic_message_location = new Point(100,20);
    private Font graphic_message_font = new Font("Arial", 80, FontStyle.Bold);
    private Size graphic_message_size = new Size(200,400);
    
    //declaring the basic form of the buttons
    private const int button_height = 40;
    private const int button_width  = 120;
    private Size button_size = new Size(button_width,button_height);

    //declaring the attributes of the show/hide button in the control panel
    private Color arrow_button_color = Color.GhostWhite;
    private Point arrow_button_location = new Point(240,15);
    private Button arrow_button = new Button();

    //declaring the attributes of the exit button in the control panel
    private Color exit_button_color = Color.Crimson;
    private Point exit_button_location = new Point(960,15);
    private Button exit_button = new Button();

    //visibility of the arrow
    private static bool arrow_visible = false;

    public ExitmainUI()
    {
        //attributes of the form
        Text = "Exit Sign";
        Size = ui_size;
        MaximumSize = ui_size;
        MinimumSize = ui_size;

        //constructing the header panel
        header_panel.BackColor = header_panel_color;
        header_panel.Size = header_panel_size;
        header_panel.Location = header_panel_location;
        header_panel.Controls.Add(header_message);

        //constructing the graphic panel
        sign_panel.BackColor = graphic_panel_color;
        sign_panel.Size = graphic_panel_size;
        sign_panel.Location = graphic_panel_location;
        sign_panel.Controls.Add(graphic_message);

        //constructing the control panel
        control_panel.BackColor = control_panel_color;
        control_panel.Size = control_panel_size;
        control_panel.Location = control_panel_location;
        
        //constructing the header message
        header_message.Text = "Exit Sign by Nathan Eduvala";
        header_message.Font = header_message_font;
        header_message.TextAlign = ContentAlignment.MiddleCenter;
        header_message.Size = new Size(1024, 50);
        header_message.Location = header_message_location;

        //constructing the header message
        graphic_message.Text = "EXIT";
        graphic_message.Font = graphic_message_font;
        graphic_message.TextAlign = ContentAlignment.MiddleCenter;
        graphic_message.Size = new Size(1024, 125);
        graphic_message.Location = graphic_message_location;

        //constructing the show/hide button
        arrow_button.BackColor = arrow_button_color;
        arrow_button.Size = button_size;
        arrow_button.Location = arrow_button_location;
        arrow_button.Text = "Show";
        arrow_button.TextAlign = ContentAlignment.MiddleCenter;
        arrow_button.Click += new EventHandler(arrow);
        arrow_button.TabIndex = 1;
        arrow_button.TabStop = true;

        //constructing the exit button
        exit_button.BackColor = exit_button_color;
        exit_button.Size = button_size;
        exit_button.Location = exit_button_location;
        exit_button.Text = "Exit";
        exit_button.TextAlign = ContentAlignment.MiddleCenter;
        exit_button.Click += new EventHandler(terminate_execution);
        exit_button.TabIndex = 4;
        exit_button.TabStop = true;


        //adding buttons to the control panel
        control_panel.Controls.Add(arrow_button);
        control_panel.Controls.Add(exit_button);

        //adding the panels to the UI form
        Controls.Add(header_panel);
        Controls.Add(sign_panel);
        Controls.Add(control_panel);
    }

    //method to execute when the show/hide button receives a mouse click
       protected void arrow(Object sender, EventArgs h)
    {
        if(arrow_visible)
        {
            arrow_visible = false;
            arrow_button.Text = "Show";
        }
        else
        {
            arrow_visible = true;
            arrow_button.Text = "Hide";
        }
        sign_panel.Invalidate();
    }

    //method to execute when the exit button receives a mouse click
    protected void terminate_execution(Object sender, EventArgs i)
    {
        System.Console.WriteLine("This program will end execution.");
        Close();
    }

    //derived class from the Panel class
    public class Graphic_panel: Panel 
    {
        //constructor for derived class Graphic_panel
        public Graphic_panel() 
        {
            Console.WriteLine("A graphic enabled panel was created");
        }

        //methods called inside of this OnPaint can only output onto the middle panel alone.
        protected override void OnPaint(PaintEventArgs ee) 
        {
            Graphics graph = ee.Graphics;
            if(arrow_visible) 
            {
                //functions for displaying the arrow
                int y = 362;
                while (y < 512)
                {
                    graph.FillEllipse(Brushes.Yellow,200,y,40,40);
                    y += 50;
                }
                int x = 200;
                while (x < 950)
                {
                    graph.FillEllipse(Brushes.Yellow,x,312,40,40);
                    graph.FillEllipse(Brushes.Yellow,x,512,40,40);
                    x += 50;
                }
                y = 162;
                while (y < 312)
                {
                    graph.FillEllipse(Brushes.Yellow,900,y,40,40);
                    graph.FillEllipse(Brushes.Yellow,900,y+400,40,40);
                    y += 50;
                }

                graph.FillEllipse(Brushes.Yellow,950,162,40,40);
                graph.FillEllipse(Brushes.Yellow,950,662,40,40);
                x = 1000;
                y = 162;
                while (x < 1180)
                {
                    graph.FillEllipse(Brushes.Yellow,x,y,40,40);
                    graph.FillEllipse(Brushes.Yellow,x,824-y,40,40);
                    x += 40;
                    y += 35;
                }
                y = 335;
                while (y < 502)
                {
                    graph.FillEllipse(Brushes.Yellow,1190,y,40,40);
                    y += 50;
                }
            }
            base.OnPaint(ee);
        }
    }
}