using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Controls;

using static RyzenADJ.RyzenAdjAPI;

namespace RyzenADJ
{
    internal enum AccentState
    {
        ACCENT_DISABLED = 1,
        ACCENT_ENABLE_GRADIENT = 0,
        ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
        ACCENT_ENABLE_BLURBEHIND = 3,
        ACCENT_INVALID_STATE = 4
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct AccentPolicy
    {
        public AccentState AccentState;
        public int AccentFlags;
        public int GradientColor;
        public int AnimationId;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct WindowCompositionAttributeData
    {
        public WindowCompositionAttribute Attribute;
        public IntPtr Data;
        public int SizeOfData;
    }

    internal enum WindowCompositionAttribute
    {
        // ...
        WCA_ACCENT_POLICY = 19
        // ...
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string dir = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        private Timer timer;

        List<MenuItem> userProfiles = new List<MenuItem>(); // Keeps track of all user-created profiles

        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        public MainWindow()
        {
            InitializeComponent();
            List<Profiles> profiles = new List<Profiles>();
            
            profiles.Add(new Profiles() { Title = "Item1" });
            profiles.Add(new Profiles() { Title = "Item2" });
            profiles.Add(new Profiles() { Title = "Item3" });

            foreach (var item in profiles)
            {
                MenuItem newProfileItem = new MenuItem();
                newProfileItem.Header = item.Title;
                userProfiles.Add(newProfileItem);
                usrprofiles.Items.Add(newProfileItem);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EnableBlur();
        }

        internal void EnableBlur()
        {
            var windowHelper = new WindowInteropHelper(this);

            var accent = new AccentPolicy();
            accent.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;

            var accentStructSize = Marshal.SizeOf(accent);

            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData();
            data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;

            SetWindowCompositionAttribute(windowHelper.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Info_MouseEnter(object sender, MouseEventArgs e)
        {
            var imgSource = e.Source as System.Windows.Controls.Image;
            imgSource.Opacity = 1;
        }

        private void Info_MouseLeave(object sender, MouseEventArgs e)
        {
            var imgSource = e.Source as System.Windows.Controls.Image;
            imgSource.Opacity = 0.50;
        }

        public void RcheckBox1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rcheckBox1.Fill != Brushes.Green)
            {
                rcheckBox1.Fill = Brushes.Green;
                cube1.Visibility = Visibility.Visible;
                rect1s.Visibility = Visibility.Visible;
                slider1.Visibility = Visibility.Visible;
                lab1.Visibility = Visibility.Visible;
            }
            else
            {
                rcheckBox1.Fill = Brushes.Transparent;
                cube1.Visibility = Visibility.Hidden;
                rect1s.Visibility = Visibility.Hidden;
                slider1.Visibility = Visibility.Hidden;
                lab1.Visibility = Visibility.Hidden;
            }

        }

        public void RcheckBox2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rcheckBox2.Fill != Brushes.Green)
            {
                rcheckBox2.Fill = Brushes.Green;
                cube2.Visibility = Visibility.Visible;
                rect2s.Visibility = Visibility.Visible;
                slider2.Visibility = Visibility.Visible;
                lab2.Visibility = Visibility.Visible;
            }
            else
            {
                rcheckBox2.Fill = Brushes.Transparent;
                cube2.Visibility = Visibility.Hidden;
                rect2s.Visibility = Visibility.Hidden;
                slider2.Visibility = Visibility.Hidden;
                lab2.Visibility = Visibility.Hidden;
            }
        }

        public void RcheckBox3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rcheckBox3.Fill != Brushes.Green)
            {
                rcheckBox3.Fill = Brushes.Green;
                cube3.Visibility = Visibility.Visible;
                rect3s.Visibility = Visibility.Visible;
                slider3.Visibility = Visibility.Visible;
                lab3.Visibility = Visibility.Visible;
            }
            else
            {
                rcheckBox3.Fill = Brushes.Transparent;
                cube3.Visibility = Visibility.Hidden;
                rect3s.Visibility = Visibility.Hidden;
                slider3.Visibility = Visibility.Hidden;
                lab3.Visibility = Visibility.Hidden;
            }
        }

        public void RcheckBox4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rcheckBox4.Fill != Brushes.Green)
            {
                rcheckBox4.Fill = Brushes.Green;
                cube4.Visibility = Visibility.Visible;
                rect4s.Visibility = Visibility.Visible;
                slider4.Visibility = Visibility.Visible;
                lab4.Visibility = Visibility.Visible;
            }
            else
            {
                rcheckBox4.Fill = Brushes.Transparent;
                cube4.Visibility = Visibility.Hidden;
                rect4s.Visibility = Visibility.Hidden;
                slider4.Visibility = Visibility.Hidden;
                lab4.Visibility = Visibility.Hidden;
            }
        }

        public void RcheckBox5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rcheckBox5.Fill != Brushes.Green)
            {
                rcheckBox5.Fill = Brushes.Green;
                cube5.Visibility = Visibility.Visible;
                rect5s.Visibility = Visibility.Visible;
                slider5.Visibility = Visibility.Visible;
                lab5.Visibility = Visibility.Visible;
            }
            else
            {
                rcheckBox5.Fill = Brushes.Transparent;
                cube5.Visibility = Visibility.Hidden;
                rect5s.Visibility = Visibility.Hidden;
                slider5.Visibility = Visibility.Hidden;
                lab5.Visibility = Visibility.Hidden;
            }
        }

        public void RcheckBox6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rcheckBox6.Fill != Brushes.Green)
            {
                rcheckBox6.Fill = Brushes.Green;
            }
            else
            {
                rcheckBox6.Fill = Brushes.Transparent;
            }
        }

        public void RcheckBox7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rcheckBox7.Fill != Brushes.Green)
            {
                rcheckBox7.Fill = Brushes.Green;
            }
            else
            {
                rcheckBox7.Fill = Brushes.Transparent;
            }
        }

        public void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (rcheckBox6.Fill == Brushes.Green)
                AutoStart();
            else
                ClearAutoStart();

            if (rcheckBox7.Fill == Brushes.Green)
                SetTimer();

            Console.WriteLine(init_ryzenadj_library());
            Console.WriteLine(set_stapm_limit(25000));
            cleanup_ryzenadj_library();

            //RunExe();
            MessageBox.Show("Done!");
        }

        private string GetSlidersValues()
        {
            string args = "";

            if (rcheckBox1.Fill == Brushes.Green)
            {
                int spm = int.Parse(slider1.Value.ToString());
                args = args + $"--stapm-limit={spm}000 ";
            }
            if (rcheckBox2.Fill == Brushes.Green)
            {
                int sfl = int.Parse(slider2.Value.ToString());
                args = args + $"--fast-limit={sfl}000 ";
            }
            if (rcheckBox3.Fill == Brushes.Green)
            {
                int ssl = int.Parse(slider3.Value.ToString());
                args = args + $"--slow-limit={ssl}000 ";
            }
            if (rcheckBox4.Fill == Brushes.Green)
            {
                int tmp = int.Parse(slider4.Value.ToString());
                args = args + $"--tctl-temp={tmp} ";
            }
            if (rcheckBox5.Fill == Brushes.Green)
            {
                int vrm = int.Parse(slider5.Value.ToString());
                string vrmhex = vrm.ToString("X");
                args = args + $"--vrmmax-current=0x{vrmhex} ";
            }

            return args;
        }

        //public void RunExe()
        //{
        //    string args = GetSlidersValues();

        //    try
        //    {
        //        Process.Start(new ProcessStartInfo
        //        {
        //            FileName = $"{dir}\\ryzenadj1.exe",
        //            UseShellExecute = false,
        //            CreateNoWindow = true,
        //            Arguments = args,
        //            RedirectStandardOutput = true
        //        });
        //    }

        //    catch
        //    {
        //        MessageBox.Show("Can't find ryzenadj.exe in current folder");
        //    }
        //}

        public void SetTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 5000;

            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            //RunExe();
            MessageBox.Show("123");
        }

        public void AutoStart()
        {
            var batFile = CreateBat();
            RegistryKey rkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rkey.SetValue("RyzenAdj", batFile);
        }

        public void ClearAutoStart()
        {
            RegistryKey rkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if ((string)rkey.GetValue("RyzenAdj") != null)
            {
                rkey.DeleteValue("RyzenAdj");
            }
        }

        public string CreateBat()
        {
            string args = GetSlidersValues();

            string batFilePath = $"{dir}\\autostart.bat";

            if (!File.Exists(batFilePath))
            {
                using (FileStream fs = File.Create(batFilePath))
                {
                    fs.Close();
                }
            }

            using (StreamWriter sw = new StreamWriter(batFilePath))
            {
                sw.WriteLine($"%~dp0\\ryzenadj.exe {args}");
            }

            return batFilePath;

        }

        public void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            TaskIcon.Visibility = Visibility.Visible;

            string title = "Ryzen Adjustment Tool";
            string text = "RyzenAdj is still running in background. Double click taskbar icon to restore.";

            TaskIcon.ShowBalloonTip(title, text, Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Info);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void RestoreWin_Click(object sender, RoutedEventArgs e)
        {
            Show();
            TaskIcon.Visibility = Visibility.Collapsed;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            slider1.Value = 12; slider2.Value = 12; slider3.Value = 12; slider4.Value = 60; slider5.Value = 25000;
            //RunExe();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            slider1.Value = 15; slider2.Value = 15; slider3.Value = 15; slider4.Value = 65; slider5.Value = 30000;
            //RunExe();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            slider1.Value = 25; slider2.Value = 25; slider3.Value = 25; slider4.Value = 75; slider5.Value = 50000;
            //RunExe();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            slider1.Value = 30; slider2.Value = 30; slider3.Value = 30; slider4.Value = 85; slider5.Value = 60000;
            //RunExe();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            slider1.Value = 35; slider2.Value = 35; slider3.Value = 35; slider4.Value = 90; slider5.Value = 70000;
            //RunExe();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            slider1.Value = 40; slider2.Value = 40; slider3.Value = 40; slider4.Value = 90; slider5.Value = 80000;
            //RunExe();
        }

        private void Slider6_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider6 = sender as System.Windows.Controls.Slider;
            var value = slider6.Value;

            if (value == 1)
            {
                performance_mode.Content = "Maximum Power Savings";
                performance_mode.Foreground = Brushes.LawnGreen;
                slider1.Value = 12; slider2.Value = 12; slider3.Value = 12; slider4.Value = 60; slider5.Value = 25000;
            }
            if (value == 2)
            {
                performance_mode.Content = "Moderate Power Savings";
                performance_mode.Foreground = Brushes.Lime;
                slider1.Value = 15; slider2.Value = 15; slider3.Value = 15; slider4.Value = 65; slider5.Value = 30000;
            }
            if (value == 3)
            {
                performance_mode.Content = "Balanced";
                performance_mode.Foreground = Brushes.Coral;
                slider1.Value = 25; slider2.Value = 25; slider3.Value = 25; slider4.Value = 75; slider5.Value = 50000;
            }
            if (value == 4)
            {
                performance_mode.Content = "Performance Mode";
                performance_mode.Foreground = Brushes.Orange;
                slider1.Value = 30; slider2.Value = 30; slider3.Value = 30; slider4.Value = 85; slider5.Value = 60000;
            }
            if (value == 5)
            {
                performance_mode.Content = "Maximum Performance";
                performance_mode.Foreground = Brushes.OrangeRed;
                slider1.Value = 35; slider2.Value = 35; slider3.Value = 35; slider4.Value = 90; slider5.Value = 70000;
            }
            if (value == 6)
            {
                performance_mode.Foreground = Brushes.Red;
                performance_mode.Content = "Ultra Gaming Performance";
                slider1.Value = 40; slider2.Value = 40; slider3.Value = 40; slider4.Value = 90; slider5.Value = 80000;
            }


        }
    }

    class Profiles
    {
        public string Title { get; set; }
    }
}
