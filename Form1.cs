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
            Brush blackbrush1 = new SolidBrush(Color.Black);

            //font declaration
            Font font = new Font("Times New Roman", 12.0f);

            // to allign the string inside the rectangles
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            // l mafrod tkon global list we deh list the burst time
            List<int> burst_time = new List<int>();

            // list containing the Process names synchronized with the burst_time list
            List<string> Process_names = new List<string>();

            // to use it in drawing the rectangles later
            List<Rectangle> Process = new List<Rectangle>();
            // List<string> starting_time = new List<string>();

            //the first arrival time variable
            int CPU_Starting_Time = 200;

            burst_time.Add(100);
            burst_time.Add(50);
            burst_time.Add(100);
            burst_time.Add(75);
            burst_time.Add(200);
            burst_time.Add(100);

            Process_names.Add("P1");
            Process_names.Add("P2");
            Process_names.Add("P3");
            Process_names.Add("P4");
            Process_names.Add("P1");
            Process_names.Add("P1");
            string CPU_Staring_time_String = CPU_Starting_Time.ToString();

            // to draw the first arrival time
            // there is a bug here 
            gObject.DrawString(CPU_Staring_time_String, font, blackbrush1, 5 , 50);

            // CPU_Starting_Time = 10;
            int CPU_Starting_Time1 = CPU_Starting_Time;
            CPU_Starting_Time = 10;
            //to add the rectangles items and to draw the list of the burst time under the rectangles
            for (var x = 0; x < burst_time.Count; x++)
            {
                Process.Add(new Rectangle { Width = burst_time[x], Height = 40, X = CPU_Starting_Time, Y = 10 });

                CPU_Starting_Time += burst_time[x];
                CPU_Starting_Time1 += burst_time[x];
                string starting_time = CPU_Starting_Time1.ToString();
                gObject.DrawString(starting_time, font, blackbrush1, CPU_Starting_Time - 15, 50);
            }

            // to draw the rectangles and to write the Process's names inside it
            for(var o = 0; o < Process.Count; o++)
            {
                RectangleF temp = Process[o];
                gObject.DrawRectangle(blackpen1, Process[o]);
                gObject.DrawString(Process_names[o], font, blackbrush1, temp, sf);               
            }
            // :"D :"D :"D
        }
    }
}
