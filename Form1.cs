using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace os2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics gObject = canvas.CreateGraphics();


            
            // pen and brush declaration
            Pen blackpen1 = new Pen(Color.Black, 2);
            Pen bluepen1 = new Pen(Color.Blue, 2);
            Pen redpen1 = new Pen(Color.Red, 2);
            Pen orangepen1 = new Pen(Color.Orange, 2);
            Pen greenpen1 = new Pen(Color.Green, 2);
            Pen yellowpen1 = new Pen(Color.Yellow, 2);
            Pen purplepen1 = new Pen(Color.Purple, 2);
            Pen pinkpen1 = new Pen(Color.Pink, 2);

            Pen Drawing_Pen;

            Brush blackbrush1 = new SolidBrush(Color.Black);
            Brush bluebrush1 = new SolidBrush(Color.Blue);
            Brush redbrush1 = new SolidBrush(Color.Red);
            Brush orangebrush1 = new SolidBrush(Color.Orange);
            Brush greenbrush1 = new SolidBrush(Color.Green);
            Brush yellowbrush1 = new SolidBrush(Color.Yellow);
            Brush purplebrush1 = new SolidBrush(Color.Purple);
            Brush pinkbrush1 = new SolidBrush(Color.Pink);

            Brush Drawing_Brush;
            //font declaration
            Font font = new Font("Times New Roman", 12.0f);

            // to allign the string inside the rectangles
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            // l mafrod tkon global list we deh list the burst time
            List<int> burst_time = new List<int>();

            //list lel burst time b3d ma darbtha f l factor
            List<int> burst_time_modified = new List<int>();


            // list has the Process names synchronized with the burst_time list
            List<string> Process_names = new List<string>();


            //list has the process arrival time 
            List<int> arrival_time = new List<int>();


            //List has the input process name without anything being repeated
            List<string> process_list = new List<string>();

            // to use it in drawing the rectangles later
            List<Rectangle> Process = new List<Rectangle>();
            // List<string> starting_time = new List<string>();

            //the first arrival time variable
            int CPU_Starting_Time = 1000;

            //the total average waiting time
            int avg_waiting = 0;

            burst_time.Add(60);
            burst_time.Add(50);
            burst_time.Add(100);
            burst_time.Add(75);
            burst_time.Add(200);
           // burst_time.Add(100);
           // burst_time.Add(100);
           // burst_time.Add(100);
           // burst_time.Add(100);
           // burst_time.Add(100);
           // burst_time.Add(100);
           // burst_time.Add(100);
           // burst_time.Add(100);
           // burst_time.Add(100);


            for (var c = 0; c < burst_time.Count; c++)
            {
                burst_time_modified.Add(burst_time[c]);
            }

            Process_names.Add("P1");
            Process_names.Add("P2");
            Process_names.Add("P3");
            Process_names.Add("P4");
            Process_names.Add("P1");
            // Process_names.Add("P1");
            // Process_names.Add("P1");
            // Process_names.Add("P1");
            // Process_names.Add("P1");
            // Process_names.Add("P1");
            // Process_names.Add("P1");
            // Process_names.Add("P1");
            // Process_names.Add("P1");
            // Process_names.Add("P1");


            process_list.Add("P1");
            process_list.Add("P2");
            process_list.Add("P3");
            process_list.Add("P4");



            arrival_time.Add(1000);
            arrival_time.Add(1000);
            arrival_time.Add(1000);
            arrival_time.Add(1000);

            

            string CPU_Staring_time_String = CPU_Starting_Time.ToString();



            //   int sum_of_burst_time = 0;
            bool small = true;

            int CPU_Starting_Time1 = CPU_Starting_Time;
            int CPU_Starting_Time2 = CPU_Starting_Time;
            CPU_Starting_Time = 30;
            // to draw the first arrival time

            gObject.DrawString(CPU_Staring_time_String, font, blackbrush1, CPU_Starting_Time - 5, 150);
        //to add the rectangles items and to draw the list of the burst time under the rectangles

        L:
            for (var a = 0; a < burst_time.Count; a++)
            {
                if (burst_time_modified[a] < 50)
                    small = false;
            }
            if (small == false)
            {
                for (var b = 0; b < burst_time.Count; b++)
                {
                    burst_time_modified[b] *= 2;
                }
                small = true;
                goto L;
            }
            int sum = 0;
            for (var k = 0; k < burst_time_modified.Count; k++)
            {
                sum += burst_time_modified[k];
            }

            canvas.Width = sum + 100;

            for (var x = 0; x < burst_time.Count; x++)
            {
                Process.Add(new Rectangle { Width = burst_time_modified[x], Height = 40, X = CPU_Starting_Time, Y = 110 });
                CPU_Starting_Time += burst_time_modified[x];
                CPU_Starting_Time1 += burst_time[x];
                string starting_time = CPU_Starting_Time1.ToString();
                gObject.DrawString(starting_time, font, blackbrush1, CPU_Starting_Time - 15, 150);
            }

            // to draw the rectangles and to write the Process's names inside it
            for (var o = 0; o < Process.Count; o++)
            {
                if (Process_names[o] == "P1" || Process_names[o] == "p1")
                    Drawing_Pen = greenpen1;
                else if (Process_names[o] == "P2" || Process_names[o] == "p2")
                    Drawing_Pen = bluepen1;
                else if (Process_names[o] == "P3" || Process_names[o] == "p3")
                    Drawing_Pen = redpen1;
                else if (Process_names[o] == "P4" || Process_names[o] == "p4")
                    Drawing_Pen = purplepen1;
                else if (Process_names[o] == "P5" || Process_names[o] == "p5")
                    Drawing_Pen = pinkpen1;
                else if (Process_names[o] == "P6" || Process_names[o] == "p6")
                    Drawing_Pen = orangepen1;
                else if (Process_names[o] == "P1" || Process_names[o] == "p1")
                    Drawing_Pen = yellowpen1;
                else
                    Drawing_Pen = blackpen1;

                if (Process_names[o] == "P1" || Process_names[o] == "p1")
                    Drawing_Brush = greenbrush1;
                else if (Process_names[o] == "P2" || Process_names[o] == "p2")
                    Drawing_Brush = bluebrush1;
                else if (Process_names[o] == "P3" || Process_names[o] == "p3")
                    Drawing_Brush = redbrush1;
                else if (Process_names[o] == "P4" || Process_names[o] == "p4")
                    Drawing_Brush = purplebrush1;
                else if (Process_names[o] == "P5" || Process_names[o] == "p5")
                    Drawing_Brush = pinkbrush1;
                else if (Process_names[o] == "P6" || Process_names[o] == "p6")
                    Drawing_Brush = orangebrush1;
                else if (Process_names[o] == "P1" || Process_names[o] == "p1")
                    Drawing_Brush = yellowbrush1;
                else
                    Drawing_Brush = blackbrush1;

                RectangleF temp = Process[o];
                gObject.DrawRectangle(Drawing_Pen, Process[o]);
                gObject.DrawString(Process_names[o], font, Drawing_Brush, temp, sf);
            }
            // :"D :"D :"D






            ///
            ///another new code for the waiting time calculation
            ///
            int min = 0, max = 0, counter = 0;
            List<int> waiting_time = new List<int>();
            List<int> process_burst_time = new List<int>();
            int temp2 = 0;
            int temp3 = CPU_Starting_Time2;
            for(var f = 0; f <process_list.Count; f++)
            {
                for (var g = 0; g < Process_names.Count; g++)
                {
                    temp3 += burst_time[g];
                    if (process_list[f] == Process_names[g] && counter == 0)
                    {
                        min = arrival_time[f];
                        max = temp3;
                        counter++;
                        temp2 += burst_time[g];

                    }
                    else if (process_list[f] == Process_names[g])
                    {
                        max = temp3;
                        temp2 += burst_time[g];
                    }
                }
                process_burst_time.Add(temp2);
                counter = 0; temp2 = 0;
                waiting_time.Add(max - min - process_burst_time[f]);
                temp3 = CPU_Starting_Time2;
            }
            int sum_of_waiting_time = 0;
            for(var w = 0; w < waiting_time.Count; w++)
            {
                sum_of_waiting_time += waiting_time[w];
            }
            avg_waiting = sum_of_waiting_time / process_list.Count;

            string r1 = "The Average Waiting Time = ";
            string r2 = avg_waiting.ToString();
            string rt = r1 + r2;
            gObject.DrawString(rt, font, blackbrush1, 30, 180);

            ///
            /// new code for the waiting time
            ///

            /*
                List<string> total_process = new List<string>();

                int[] proccess_time = new int[30];

                for (var u = 0; u < Process_names.Count; u++)
                {
                    while (u + 1 < Process_names.Count)
                    {
                        if (Process_names[u] != Process_names[u + 1])
                        {
                            for (var f = 0; f < total_process.Count; f++)
                            {
                                if (total_process[f] == Process_names[u])
                                    ;
                                else
                                    total_process.Add(Process_names[u]);
                            }
                        }
                    }
                    // feh hena bug
                }
               // int no_of_process = total_process.Count;

                for (var l = 0; l < total_process.Count; l++)
                {
                    for (var q = 0; q < burst_time.Count; q++)
                    {
                        if (total_process[l] == Process_names[q])
                            proccess_time[l] += burst_time[q];
                    }
                }
                int a1 = 0;
                int[] waiting_time = new int[30];
                for (var g = 0; g < burst_time.Count; g++)
                {
                    for (var e1 = 0; e1 < total_process.Count; e1++)
                    {
                        if (Process_names[g] == total_process[e1])
                        {
                            proccess_time[e1] -= burst_time[g];
                            a1 = e1;
                        }
                    }
                    if (proccess_time[a1] > 0 && Process_names[g] != total_process[a1])
                    {
                        waiting_time[a1] += burst_time[g];
                    }
                }

                for (var u1 = 0; u1 < total_process.Count; u1++)
                {
                    avg_waiting += waiting_time[u1];
                }
                
            */
        }

    }
}
