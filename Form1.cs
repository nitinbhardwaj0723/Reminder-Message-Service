using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ReminderMessageService
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        int index = 0;

        string[] messages = {
            "Take a short break!",
            "Stay focused on your goals.",
            "Drink some water!",
            "Keep learning something new."
        };

        string file = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "ReminderLog.txt");

        Label status, current, next;

        public Form1()
        {
            InitializeComponent();

            Text = "Reminder Message Service";
            Size = new Size(480, 320);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.WhiteSmoke;

            Label heading = new Label
            {
                Text = "REMINDER MESSAGE SERVICE",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                Location = new Point(55, 25),
                AutoSize = true
            };
            Controls.Add(heading);

            status = new Label
            {
                Text = "● Service Stopped",
                ForeColor = Color.Red,
                Location = new Point(165, 75),
                AutoSize = true
            };
            Controls.Add(status);

            current = new Label
            {
                Text = "Current: No reminder",
                Location = new Point(45, 120),
                AutoSize = true
            };
            Controls.Add(current);

            next = new Label
            {
                Text = "Next: " + messages[0],
                Location = new Point(45, 155),
                AutoSize = true
            };
            Controls.Add(next);

            Button start = new Button
            {
                Text = "Start Service",
                Location = new Point(70, 210),
                Size = new Size(140, 40)
            };
            Controls.Add(start);

            Button stop = new Button
            {
                Text = "Stop Service",
                Location = new Point(250, 210),
                Size = new Size(140, 40)
            };
            Controls.Add(stop);

            timer.Interval = 300000;

            timer.Tick += (s, e) => SaveReminder();

            start.Click += (s, e) => {
                timer.Stop();
                SaveReminder();
                timer.Start();
                status.Text = "● Service Running";
                status.ForeColor = Color.Green;
            };

            stop.Click += (s, e) => {
                timer.Stop();
                status.Text = "● Service Stopped";
                status.ForeColor = Color.Red;
            };
        }

        void SaveReminder()
        {
            string message = messages[index];

            File.AppendAllText(file,
                DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")
                + " - " + message + Environment.NewLine);

            current.Text = "Current: " + message;

            index = (index + 1) % messages.Length;
            next.Text = "Next: " + messages[index];
        }
    }
}