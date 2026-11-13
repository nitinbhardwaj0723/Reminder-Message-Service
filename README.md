# Reminder Message Service

A simple and lightweight C# Windows Forms application that automatically writes reminder messages to a log file at regular 5-minute intervals.

## Features

- Automatically logs reminder messages every 5 minutes.
- Starts with the first message and follows a predefined sequence.
- Repeats messages from the beginning after reaching the last message.
- Start and Stop Service controls.
- Displays the current and next reminder.
- Saves messages with date and time.
- Automatically creates a text log file.

## Technologies Used

- C#
- Windows Forms
- .NET Framework 4.8
- System.Windows.Forms.Timer
- File Handling

## How It Works

1. Click **Start Service** to begin.
2. The first reminder is logged immediately.
3. The next reminder is logged every 5 minutes.
4. After the last message, the sequence starts again.
5. Click **Stop Service** to stop the timer.

## Log File Location

The application automatically creates:

`Documents/ReminderLog.txt`

Example:

```text
13-11-2026 11:00:00 - Take a short break!
13-11-2026 11:05:00 - Stay focused on your goals.
13-11-2026 11:10:00 - Drink some water!
```
**Developed By:** Nitin
**Roll Number:** 2402371
**Branch:** Vocational IT
