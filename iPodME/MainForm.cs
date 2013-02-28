/* 
 
  iPodME [iPod Media Encoder]
  ---------------------------
  version 2.4, November 21th, 2010

  Copyright (C) 2008-2010 Noda (Lasorsa Yohan)

  This software is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this software.

  Permission is granted to anyone to use this software for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this software must not be misrepresented; you must not
     claim that you wrote the original software. If you use this software
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original software.
  3. Usage of any part of this software in a commercial product is forbidden
     without specific prior written permission of the authors.     
  4. This notice may not be removed or altered from any source distribution.  

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace iPodME
{
    public partial class MainWindow : Form
    {
        #region listbox data & values

        private static string[] priority_text = 
        {
            "Idle",
            "Normal",
            "High",
        };

        private static ProcessPriorityClass[] priority_val =
        {
            ProcessPriorityClass.Idle,
            ProcessPriorityClass.Normal,
            ProcessPriorityClass.AboveNormal
        };

        private static string[] size_text =
        {
            "1280x720",
            "1024x768",
            "960x640",
            "640x480",
            "480x320",
            "320x240"
        };

        private static string[] encoder_text =
        {
            "x264",
            "xvid",
        };

        private static string[] enc_mode_text = 
        {
            "Average bitrate",
            "Constant quality",
            "Output size",
        };

        private static string[] enc_mode_val = 
        {
            "-b ",
            "-crf ",
            "-b ",
            "-b ",
            "-qscale ",
            "-b ",
        };

        private static string[] aud_freq_text = 
        {
            "22050",
            "44100",
            "48000",
        };

        private static string[] aud_br_text = 
        {
            "64",
            "96",
            "128",
            "160"
        };

        private static string[] profile_text = 
        {
            "Slow, size",
            "Slow, quality",
            "Fast, size",
            "Fast, quality",
            "Turbo, size",
            "Turbo, quality",
            "Custom",
        };

        private static string[] enc_profile_text = 
        {
            "Default",
            "Good quality",
            "Best quality"
        };

        private static string[] aspect_text =
        {
            "Original",
            "4:3",
            "16:9"
        };

        #endregion

        #region encoding profiles & parameters

        private const string defaultEncOpts = "-maxrate 1500k -bufsize 4M -g 250 -coder 0 -threads 0 -acodec libfaac -ac 2";

        private static string[] enc_profile_val = 
        {
            "-level 30 -flags +loop -flags2 -wpred-dct8x8 ",
            "-level 30 -flags +loop -flags2 -wpred-dct8x8 -subq 2 -cmp +chroma -refs 2 -me_method epzs -partitions +parti4x4+partp4x4+partp8x8 ",
            "-level 30 -flags +loop -flags2 -wpred-dct8x8 -subq 4 -cmp +chroma -me_method umh -me_range 16 -trellis 2 -mbd 2 -refs 3 -partitions +parti4x4+partp4x4+partp8x8 ",
            "",
            "-trellis 2 -cmp 2 -subcmp 2 ",
            "-me_method umh -me_range 16 -trellis 2 -cmp 2 -subcmp 2 ",
        };

        private static string[] profile_val = 
        {
            "-vcodec libx264 -level 30 -flags +loop -flags2 -wpred-dct8x8 -crf 24 -ab 128k -subq 4 -cmp +chroma -me_method umh -me_range 16 -trellis 1 -mbd 2 -refs 3 -partitions +parti4x4+partp4x4+partp8x8",
            "-vcodec libx264 -level 30 -flags +loop -flags2 -wpred-dct8x8 -crf 19 -ab 128k -subq 4 -cmp +chroma -me_method umh -me_range 16 -trellis 1 -mbd 2 -refs 3 -partitions +parti4x4+partp4x4+partp8x8",
            "-vcodec libx264 -level 30 -flags +loop -flags2 -wpred-dct8x8 -crf 24 -ab 128k -subq 2 -cmp +chroma -me_method epzs -refs 2 -partitions +parti4x4+partp4x4+partp8x8",
            "-vcodec libx264 -level 30 -flags +loop -flags2 -wpred-dct8x8 -crf 19 -ab 128k -subq 2 -cmp +chroma -me_method epzs -refs 2 -partitions +parti4x4+partp4x4+partp8x8",
            "-vcodec libxvid -qscale 6 -ab 128k",
            "-vcodec libxvid -qscale 4 -ab 128k",
            ""
        };

        #endregion

        #region constants

        private static float[] fps = { 10f, 12f, 15f, 20f, 24000f / 1001f, 24f, 25000f / 1001f, 25f, 30000f / 1001f, 30f };
        private static string[] fps_val = { "10", "12", "15", "20", "24000/1001", "24", "25000/1001", "25", "30000/1001", "30" };
        private const string prog_info = "iPodME v2.4 by Noda // 2010";
        private const string encName = "\\ffmpeg.exe";
        private const string mpbName = "\\mp4box.exe";
        private const string jsdllName = "\\js32.dll";
        private const string helpName = "\\iPodME Help.html";
        private const string donationLink = "http://tinyurl.com/yqdydd";

        #endregion

        // to shutdown computer
        [DllImport("user32.dll")]
        static extern bool ExitWindowsEx(uint uFlags, uint dwReason); 
        
        private string tempPath = Path.GetTempPath() + Path.GetRandomFileName();
        private string outputDir = Path.GetDirectoryName(Application.ExecutablePath) + "\\";
        private List<string> files = new List<string>();
        private Process proc;
        private bool cancel = false, getInfos;
        private int count, curr_duration, curr_fps, curr_width, curr_height;
        private string curr_file = "";
        private int[] quantizer = { 21, 3 };
        private int bitrate = 512, target_size = 50;
        private Stopwatch eta_timer;


        public MainWindow()
        {
            // init window
            InitializeComponent();

            sizeSelect.DataSource = size_text;
            prioSelect.DataSource = priority_text;
            profileSelect.DataSource = profile_text;
            encoderSelect.DataSource = encoder_text;
            encProfSelect.DataSource = enc_profile_text;
            encModeSelect.DataSource = enc_mode_text;
            audFreqSelect.DataSource = aud_freq_text;
            audRateSelect.DataSource = aud_br_text;
            aspectSelect.DataSource = aspect_text;

            profileSelect.SelectedIndex = 2;
            sizeSelect.SelectedIndex = 4;
            encoderSelect.SelectedIndex = 0;
            encProfSelect.SelectedIndex = 1;
            encModeSelect.SelectedIndex = 1;
            audFreqSelect.SelectedIndex = 1;
            audRateSelect.SelectedIndex = 2;
            aspectSelect.SelectedIndex = 0;

            consoleTextBox.AppendText("\n\r");
            CheckForIllegalCrossThreadCalls = false;
            setProgress(prog_info);
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            listBox.Dock = DockStyle.Fill;

            loadSettings();
            encModeSelect_SelectedIndexChanged(null, null); // refresh box
            outputDirBox.Text = outputDir;

            // create the temporary files
            try
            {
                // create ffmpeg exe
                Directory.CreateDirectory(tempPath);
                Stream file = new FileStream(tempPath + encName, FileMode.Create, FileAccess.Write);
                BinaryWriter writer = new BinaryWriter(file);
                writer.Write(iPodME.Properties.Resources.ffmpeg);
                writer.Close();
                file.Close();
                file.Dispose();

                // create mp4box exe
                file = new FileStream(tempPath + mpbName, FileMode.Create, FileAccess.Write);
                writer = new BinaryWriter(file);
                writer.Write(iPodME.Properties.Resources.mp4box);
                writer.Close();
                file.Close();
                file.Dispose();

                // create js32 dll
                file = new FileStream(tempPath + jsdllName, FileMode.Create, FileAccess.Write);
                writer = new BinaryWriter(file);
                writer.Write(iPodME.Properties.Resources.js32);
                writer.Close();
                file.Close();
                file.Dispose();

                // create the help file
                file = new FileStream(tempPath + helpName, FileMode.Create, FileAccess.Write);
                writer = new BinaryWriter(file);
                writer.Write(iPodME.Properties.Resources.iPodME_Help.ToCharArray());
                writer.Close();
                file.Close();
                file.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Error creating temp files.");
                cleanQuit();
                Dispose();
            }
        }

        private void loadSettings() 
        {
            string cfgPath = Path.ChangeExtension(Application.ExecutablePath, ".cfg");
            if (File.Exists(cfgPath))
            {
                try
                {
                    BinaryReader reader = new BinaryReader(File.OpenRead(cfgPath));

                    // read settings
                    shutdownCheck.Checked = reader.ReadBoolean();
                    stretchCheck.Checked = reader.ReadBoolean();
                    prioSelect.SelectedIndex = reader.ReadInt32();
                    sizeSelect.SelectedIndex = reader.ReadInt32();
                    profileSelect.SelectedIndex = reader.ReadInt32();
                    encoderSelect.SelectedIndex = reader.ReadInt32();
                    encProfSelect.SelectedIndex = reader.ReadInt32();
                    encModeSelect.SelectedIndex = reader.ReadInt32();
                    bitrate = reader.ReadInt32();
                    quantizer[0] = reader.ReadInt32();
                    quantizer[1] = reader.ReadInt32();
                    target_size = reader.ReadInt32();
                    deinterlaceCheck.Checked = reader.ReadBoolean();
                    resampleCheck.Checked = reader.ReadBoolean();
                    audFreqSelect.SelectedIndex = reader.ReadInt32();
                    audRateSelect.SelectedIndex = reader.ReadInt32();
                    addParamBox.Text = reader.ReadString();
                    outputDir = reader.ReadString();
                    fixAspectCheck.Checked = reader.ReadBoolean();
                    aspectSelect.Text = reader.ReadString();

                    if (outputDir == "" || !Directory.Exists(outputDir))
                        outputDir = Path.GetDirectoryName(Application.ExecutablePath) + "\\";
                }
                catch (IOException) { }
            }
        }

        private void saveSettings()
        {
            string cfgPath = Path.ChangeExtension(Application.ExecutablePath, ".cfg");
            try
            {
                BinaryWriter writer = new BinaryWriter(File.Create(cfgPath));

                // save settings
                writer.Write(shutdownCheck.Checked);                // bool
                writer.Write(stretchCheck.Checked);                 // bool
                writer.Write((Int32)prioSelect.SelectedIndex);      // int
                writer.Write((Int32)sizeSelect.SelectedIndex);      // int
                writer.Write((Int32)profileSelect.SelectedIndex);   // int
                writer.Write((Int32)encoderSelect.SelectedIndex);   // int
                writer.Write((Int32)encProfSelect.SelectedIndex);   // int
                writer.Write((Int32)encModeSelect.SelectedIndex);   // int
                writer.Write((Int32)bitrate);                       // int
                writer.Write((Int32)quantizer[0]);                  // int
                writer.Write((Int32)quantizer[1]);                  // int
                writer.Write((Int32)target_size);                   // int
                writer.Write(deinterlaceCheck.Checked);             // bool
                writer.Write(resampleCheck.Checked);                // bool
                writer.Write((Int32)audFreqSelect.SelectedIndex);   // int
                writer.Write((Int32)audRateSelect.SelectedIndex);   // int
                writer.Write(addParamBox.Text);                     // string

                if (outputDir == Path.GetDirectoryName(Application.ExecutablePath) + "\\")
                    writer.Write("");
                else
                    writer.Write(outputDir);                        // string

                writer.Write(fixAspectCheck.Checked);               // bool
                writer.Write(aspectSelect.Text);                    // string
                writer.Close();
            }
            catch (IOException) {}
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                ShowInTaskbar = false;
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            notifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void addFiles_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (openFileDialog.FileNames != null)
            {
                // add files
                foreach (string s in openFileDialog.FileNames)
                    files.Add(s);
                updateListBox();
            }
        }

        private void listBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] dragFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
                // add files
                foreach (string s in dragFiles)
                    files.Add(s);
                updateListBox();
            }
        }

        private void listBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void convert_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                try
                {
                    cancel = true;
                    consoleTextBox.AppendText("Conversion cancelled.\n\r");
                    if (proc != null && !proc.HasExited)
                        proc.Kill();
                }
                catch (Exception)
                { }
            }
            else
            {
                if (Directory.Exists(outputDir))
                {
                    convert.Text = "Cancel";
                    profileSelect.Enabled = false;
                    sizeSelect.Enabled = false;
                    stretchCheck.Enabled = false;
                    fixAspectCheck.Enabled = false;
                    groupBox3.Enabled = false;
                    groupBox4.Enabled = false;
                    groupBox5.Enabled = false;
                    browse.Enabled = false;
                    backgroundWorker.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("Error, invalid output folder !");
                }
            }
        }

        private void initEncoderProc()
        {
            // init ffmpeg process
            proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = tempPath + encName;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;

            proc.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(proc_DataReceived);
            proc.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(proc_DataReceived);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            count = 1;

            // encode files
            while (files.Count > 0)
            {
                string filename = files[0];
                curr_file = filename;
                string args_info = "-y -i \"" + filename + "\"";

                // initialize some values
                curr_duration = 0;
                curr_height = 0;
                curr_width = 0;
                curr_fps = -1;
                
                getInfos = true;

                initEncoderProc();
                proc.StartInfo.Arguments = args_info;
                eta_timer = null;

                try
                {
                    setProgress("Initializing encoder...");

                    // first get infos from file
                    proc.Start();
                    proc.PriorityClass = priority_val[prioSelect.SelectedIndex];
                    proc.BeginErrorReadLine();
                    proc.BeginOutputReadLine();
                    proc.WaitForExit();
                    proc.CancelErrorRead();
                    proc.CancelOutputRead();
                    proc.Close();
                    proc.Dispose();

                    // then convert it
                    string args_conv = computeArgs(filename, computeSize());

                    consoleTextBox.AppendText("ffmpeg.exe " + args_conv + "\n\r");
                    getInfos = false;
                    initEncoderProc();
                    proc.StartInfo.Arguments = args_conv;

                    proc.Start();
                    proc.PriorityClass = priority_val[prioSelect.SelectedIndex];
                    proc.BeginErrorReadLine();
                    proc.BeginOutputReadLine();
                    proc.WaitForExit();
                    proc.CancelErrorRead();
                    proc.CancelOutputRead();
                    proc.Close();
                    proc.Dispose();

                    if (!cancel)
                    {
                        // finally add subtitles if applicable
                        checkAndAddSubs(filename);
                        count++;

                        // conversion finished
                        if (eta_timer != null)
                        {
                            eta_timer.Stop();
                            long time = eta_timer.ElapsedMilliseconds / 1000;
                            consoleTextBox.AppendText("Total time elapsed: " + (time / 3600).ToString("00") + "h" + ((time / 60) % 60).ToString("00") + "m" + (time % 60).ToString("00") + "s" + "\n\r");
                        }
                        files.Remove(curr_file);
                        updateListBox();
                    }
                    else
                    {
                        if (eta_timer != null)
                            eta_timer.Stop();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    break;
                }
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            proc = null;
            curr_file = "";
            convert.Text = "Convert";
            profileSelect.Enabled = true;
            sizeSelect.Enabled = true;
            stretchCheck.Enabled = true;
            fixAspectCheck.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            groupBox5.Enabled = true;
            browse.Enabled = true;
            cancel = false;
            stretchCheck_CheckedChanged(null, null);    // force refresh
            setProgress(prog_info);
            consoleTextBox.AppendText("Ready.\n\r");

            if (shutdownCheck.Checked && !cancel)
            {
                cleanQuit();
                saveSettings();
                ExitWindowsEx(1, 0);
            }
        }

        private void proc_DataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (getInfos)
                {
                    if ((curr_duration == 0) && e.Data.Contains("Duration:"))
                        setDuration(e.Data);
                    else if ((curr_height == 0) && (curr_width == 0) && (curr_fps == -1) && e.Data.Contains("Video:"))
                        setSizeAndFramerate(e.Data);
                }
                else
                {
/*                    // awful hack to check for ffmpeg/libx264 timebase detection problem
                    if(e.Data.Contains("WARNING codec timebase is very high.")) {
                        MessageBox.Show("The current video framerate was incorrectly detected by the x264 encoder,\n which will cause the video to be incompatible with iTunes.\n\nYou should cancel the current conversion and use one of the \"turbo\" presets\ninstead, or a custom one with \"xvid\" as the encoder.", "Warning");
                    }
*/
                    if (e.Data.StartsWith("frame="))
                        updateProgress(e.Data);
                    else if (!e.Data.StartsWith("ISO File") && !e.Data.StartsWith("Importing"))
                        consoleTextBox.AppendText(e.Data + "\r");
                }
            }
            catch (Exception)
            { }
        }

        private void cleanQuit()
        {
            try
            {
                cancel = true;
                if (proc != null && !proc.HasExited)
                {
                    proc.Kill();
                    proc.WaitForExit();
                }
                notifyIcon.Visible = false;
                notifyIcon.Dispose();
                File.Delete(tempPath + encName);
                File.Delete(tempPath + mpbName);
                File.Delete(tempPath + jsdllName);
                File.Delete(tempPath + helpName);
                Directory.Delete(tempPath);
            }
            catch (Exception)
            { }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (proc != null && !proc.HasExited)
            {
                // confirm exit
                if (MessageBox.Show("Do you really want to quit?\nCurrent conversion will be cancelled!", "Confirm exit", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            cleanQuit();
            saveSettings();
        }

        private void prioSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (proc != null && !proc.HasExited)
            {
                proc.PriorityClass = priority_val[prioSelect.SelectedIndex];
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            files.Clear();
            if (curr_file != "")
                files.Add(curr_file);
            updateListBox();
        }

        private void showConsole_CheckedChanged(object sender, EventArgs e)
        {
            resizeWindow();
        }

        private void profileSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            resizeWindow();
        }

        private void encModeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (encModeSelect.SelectedIndex == 0)
            {
                rateControlLabel.Text = "Bitrate (kbps) :";
                rateBox.Text = bitrate.ToString();
            }
            else if (encModeSelect.SelectedIndex == 1)
            {
                rateControlLabel.Text = "Quantizer :";
                rateBox.Text = quantizer[encoderSelect.SelectedIndex].ToString();
            }
            else
            {
                rateControlLabel.Text = "File size (MB) :";
                rateBox.Text = target_size.ToString();
            }
        }

        private void rateBox_Validated(object sender, EventArgs e)
        {
            if (encModeSelect.SelectedIndex == 0)
            {
                try
                {
                    int num = int.Parse(rateBox.Text);
                    if (num >= 100 && num <= 1500)
                    {
                        bitrate = num;
                    }
                    else if (num > 1500)
                    {
                        bitrate = 1500;
                        rateBox.Text = bitrate.ToString();
                    }
                    else if (num < 100)
                    {
                        bitrate = 100;
                        rateBox.Text = bitrate.ToString();
                    }
                }
                catch (Exception)
                {
                    rateBox.Text = bitrate.ToString();
                }
            }
            else if (encModeSelect.SelectedIndex == 1)
            {
                try
                {
                    int num = int.Parse(rateBox.Text);
                    if (num >= 1 && num <= 51)
                    {
                        quantizer[encoderSelect.SelectedIndex] = num;
                    }
                    else if (num > 51)
                    {
                        quantizer[encoderSelect.SelectedIndex] = 51;
                        rateBox.Text = quantizer[encoderSelect.SelectedIndex].ToString();
                    }
                    else if (num < 1)
                    {
                        quantizer[encoderSelect.SelectedIndex] = 1;
                        rateBox.Text = quantizer[encoderSelect.SelectedIndex].ToString();
                    }
                }
                catch (Exception)
                {
                    rateBox.Text = quantizer[encoderSelect.SelectedIndex].ToString();
                }
            }
            else 
            {
                try
                {
                    int num = int.Parse(rateBox.Text);
                    if (num >= 1)
                    {
                        target_size = num;
                    }
                    else if (num < 1)
                    {
                        target_size = 1;
                        rateBox.Text = target_size.ToString();
                    }
                }
                catch (Exception)
                {
                    rateBox.Text = target_size.ToString();
                }
            }

        }

        private void consoleTextBox_TextChanged(object sender, EventArgs e)
        {
            consoleTextBox.ScrollToCaret();
        }

        private void resampleCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (resampleCheck.Checked)
            {
                audFreqLabel.Enabled = true;
                audFreqSelect.Enabled = true;
            }
            else
            {
                audFreqLabel.Enabled = false;
                audFreqSelect.Enabled = false;
            }
        }

        private void listBox_DataSourceChanged(object sender, EventArgs e)
        {
            if (files.Count == 0)
                convert.Enabled = false;
            else
                convert.Enabled = true;
        }

        private void encoderSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (encModeSelect.SelectedIndex == 0)
                rateBox.Text = bitrate.ToString();
            else if (encModeSelect.SelectedIndex == 1)
                rateBox.Text = quantizer[encoderSelect.SelectedIndex].ToString();
            else
                rateBox.Text = target_size.ToString();
        }

        private void donateLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(donationLink);
            }
            catch { }
        }

        private void helpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
//                System.Diagnostics.Process.Start(tempPath + helpName);
                new HelpDialog(tempPath + helpName).ShowDialog();
            }
            catch { }
        }

        private void showOptions_CheckedChanged(object sender, EventArgs e)
        {
            if (showOptions.Checked)
            {
                listBox.Dock = DockStyle.Top;
                groupBox6.Visible = true;
            }
            else
            {
                listBox.Dock = DockStyle.Fill;
                groupBox6.Visible = false;
            }
        }

        private void stretchCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (stretchCheck.Checked)
                fixAspectCheck.Enabled = false;
            else
                fixAspectCheck.Enabled = true;
        }

        private void aspectSelect_Validated(object sender, EventArgs e)
        {
            aspectSelect.Text = aspectSelect.Text.Trim().Replace(',', '.'); ;
            String ar = aspectSelect.Text;
            if (ar != aspect_text[0])
            {
                try
                {
                    int idx_sep = ar.IndexOf(':');
                    if (idx_sep > 0)
                    {
                        int width = int.Parse(ar.Substring(0, idx_sep));
                        int height = int.Parse(ar.Substring(idx_sep + 1));
                        if (width <= 0 || height <= 0)
                            throw new Exception();
                    }
                    else
                    {
                        float ratio = float.Parse(ar, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                        if (ratio <= 0)
                            throw new Exception();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Invalid aspect ratio!\nFormat:   WIDTH:HEIGHT or RATIO\n\nExamples:   3:2, 640:480 or 1.85, 2.33", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    aspectSelect.Text = aspect_text[0];
                }
            }
        }

        private void browse_Click(object sender, EventArgs e)
        {
            outputFolderDialog.SelectedPath = outputDir;
            outputFolderDialog.ShowDialog();
            outputDir = outputFolderDialog.SelectedPath;
            if (!outputDir.EndsWith("\\"))
                outputDir += "\\";
            outputDirBox.Text = outputDir;
        }

        private void updateListBox()
        {
            List<string> listData = new List<string>();
            foreach (string file in files)
                listData.Add(Path.GetFileName(file));
            listBox.DataSource = null;
            listBox.DataSource = listData;
        }
        
        private void resizeWindow()
        {
            if (showConsole.Checked)
            {
                if (profileSelect.SelectedIndex == 6)
                {
                    groupBox3.Visible = true;
                    groupBox4.Visible = true;
                    groupBox5.Visible = true;
                    groupBox2.Size = new Size(Width - 14, groupBox2.Size.Height);
                }
                else
                {
                    groupBox3.Visible = false;
                    groupBox4.Visible = false;
                    groupBox5.Visible = false;
                    groupBox2.Size = new Size(288, groupBox2.Size.Height);
                    groupBox2.Size = new Size(Width - 14, groupBox2.Size.Height);
                }
                groupBox2.Visible = true;
            }
            else
            {
                if (profileSelect.SelectedIndex == 6)
                {
                    groupBox3.Visible = true;
                    groupBox4.Visible = true;
                    groupBox5.Visible = true;
                    groupBox2.Size = new Size(Width - 14, groupBox2.Size.Height);
                }
                else
                {                    
                    groupBox2.Size = new Size(Width - 14, groupBox2.Size.Height);
                    groupBox3.Visible = false;
                    groupBox4.Visible = false;
                    groupBox5.Visible = false;
                }
                groupBox2.Visible = false;
            }
        }

        private void setProgress(string s)
        {
            notifyIcon.Text = s;
            infoBox.Text = s;
        }

        private void setDuration(string s)
        {
            try
            {
                string dur = s.Substring(s.IndexOf("Duration:") + 10, 8);
                curr_duration = int.Parse(dur.Substring(0, 2)) * 3600 + int.Parse(dur.Substring(3, 2)) * 60 + int.Parse(dur.Substring(6, 2));
            }
            catch(Exception) 
            { }        
        }

        private void setSizeAndFramerate(string s)
        {
            try
            {
                // set size
                int idx_st = s.IndexOf(',', s.IndexOf(',') + 1) + 2;
                string siz;                
                if (s[s.IndexOf(' ', idx_st) + 1] == '[')
                    siz = s.Substring(idx_st, s.IndexOf(' ', idx_st) - idx_st);
                else
                    siz = s.Substring(idx_st, s.IndexOf(',', idx_st) - idx_st);
                int idx_ax = siz.IndexOf('x') + 1;
                curr_width = int.Parse(siz.Substring(0, idx_ax - 1));
                curr_height = int.Parse(siz.Substring(idx_ax, siz.Length - idx_ax));

                // set fps
                int idx_fps = s.LastIndexOf(',') + 2; ;
                string s_fps = s.Substring(idx_fps, s.IndexOf(' ', idx_fps) - idx_fps);
                float v_fps = float.Parse(s_fps, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                int best_idx = 0;
                float min_diff = Math.Abs(v_fps - fps[0]);

                // search for the closest standard frame rate
                for (int i = 1; i < fps.Length; i++)
                {
                    float diff = Math.Abs(v_fps - fps[i]);
                    if (diff < min_diff)
                    {
                        best_idx = i;
                        min_diff = diff;
                    }
                }
                curr_fps = best_idx;
                
                //consoleTextBox.AppendText("\n\r\n\r--DEBUG START\n\r.Net version: " + Environment.Version + "\nBase string: '" + s + "'\nFPS String: '" + s_fps + "'\nFPS val: " + v_fps + "\nFPS idx: " + curr_fps + "\nFPS set: " + fps_val[curr_fps] + "\n\r--DEBUG END\n\r\n\r");
            }
            catch (Exception)
            { MessageBox.Show("An error occured while detecting video format.\nThe output video may be unreadable."); }
        }
        
        private void updateProgress(string s)
        {
            try
            {
                // start the ETA timer on the first call
                if (eta_timer == null)
                    eta_timer = System.Diagnostics.Stopwatch.StartNew();

                string fps = s.Substring(s.IndexOf("fps=") + 4, 3);
                int idx_at = s.IndexOf("time=") + 5;
                int time = int.Parse(s.Substring(idx_at, s.IndexOf('.', idx_at) - idx_at));
                long etaa = ((eta_timer.ElapsedMilliseconds * (long)curr_duration / (long)time) - eta_timer.ElapsedMilliseconds) / 1000;
//                DateTime eta = new DateTime((eta_timer.ElapsedTicks * (long)curr_duration / (long)time) - eta_timer.ElapsedTicks, DateTimeKind.Local);
//                setProgress("File " + count + "/" + (files.Count + count - 1) + "    FPS:" + fps + "    Progress: " + (time * 100 / curr_duration) + "%    ETA: " + eta.Hour.ToString("00") + ":" + eta.Minute.ToString("00") + ":" + eta.Second.ToString("00"));
                setProgress("File " + count + "/" + (files.Count + count - 1) + "    FPS:" + fps + "    Progress: " + (time * 100 / curr_duration) + "%    ETA: " + (etaa/3600).ToString("00") + ":" + ((etaa/60) % 60).ToString("00") + ":" + (etaa % 60).ToString("00"));
            }
            catch (Exception)
            { }
        }

        private string computeSize()
        {
            string size = "";

            if (stretchCheck.Checked)
            {
                size = " -s " + size_text[sizeSelect.SelectedIndex];
            }
            else
            {
                string newsize = size_text[sizeSelect.SelectedIndex];
                int idx_ax = newsize.IndexOf('x') + 1;
                int width = int.Parse(newsize.Substring(0, idx_ax - 1));
                int height = int.Parse(newsize.Substring(idx_ax, newsize.Length - idx_ax));
                float ar = (float)curr_width / (float)curr_height;
                int nwidth = width, nheight;

                // check if resize is needed
                if (curr_width > width || curr_height > height)
                {
                    // first try to fit width
                    nheight = (int)Math.Round((float)width / ar, 0);
                    nheight = (int)(16 * Math.Round((float)nheight / 16, 0));  // round to nearest multiple of 16

                    // check if the new height fits in the desired one
                    if (nheight > height)
                    {
                        // if not, fit the height
                        nheight = height;
                        nwidth = (int)Math.Round((float)height * ar, 0);
                        nwidth = (int)(16 * Math.Round((float)nwidth / 16, 0));  // round to nearest multiple of 16
                    }

                    size = " -s " + nwidth + "x" + nheight;
                }
            }            
            return size;
        }

        private string computeAspectRatio()
        {
            string aspect = "";

            if (stretchCheck.Checked && (profileSelect.SelectedIndex != 6 || aspectSelect.Text == aspect_text[0]))
            {
                aspect = " -aspect " + size_text[sizeSelect.SelectedIndex].Replace('x', ':');
            }
            else if (profileSelect.SelectedIndex == 6 && aspectSelect.Text != aspect_text[0])
            {
                aspect = " -aspect " + aspectSelect.Text;
            }
            else
            {
                string newsize = size_text[sizeSelect.SelectedIndex];
                int idx_ax = newsize.IndexOf('x') + 1;
                int width = int.Parse(newsize.Substring(0, idx_ax - 1));
                int height = int.Parse(newsize.Substring(idx_ax, newsize.Length - idx_ax));
                float ar = (float)curr_width / (float)curr_height;
                int nwidth = width, nheight;

                // check if resize is needed
                if (curr_width > width || curr_height > height)
                {
                    // first try to fit width
                    nheight = (int)Math.Round((float)width / ar, 0);
                    nheight = (int)(16 * Math.Round((float)nheight / 16, 0));  // round to nearest multiple of 16

                    // check if the new height fits in the desired one
                    if (nheight > height)
                    {
                        // if not, fit the height
                        nheight = height;
                        nwidth = (int)Math.Round((float)height * ar, 0);
                        nwidth = (int)(16 * Math.Round((float)nwidth / 16, 0));  // round to nearest multiple of 16
                    }

                    aspect = " -aspect " + nwidth + ":" + nheight;
                }
                else
                {
                    aspect = " -aspect " + curr_width + ":" + curr_height;
                }
            }
            return aspect;
        }

        private string computeFramerate()
        {
            string framerate = "";
            if (curr_fps != -1)
                framerate = "-r " + fps_val[curr_fps] + " ";
            return framerate;
        }

        private string computeArgs(string filename, string size)
        {
            string args = "";

            args += "-y -i \"" + filename + "\" -f mp4 " + computeFramerate();

            if (profileSelect.SelectedIndex == 6)
            {
                args += "-vcodec lib" + encoderSelect.Text + " ";
                args += enc_profile_val[encProfSelect.SelectedIndex + encoderSelect.SelectedIndex * 3];
                args += enc_mode_val[encModeSelect.SelectedIndex + encoderSelect.SelectedIndex * 3];
                if (encModeSelect.SelectedIndex == 0) 
                    args += bitrate.ToString() + "k -bt " + (bitrate/2).ToString() + "k ";
                else if (encModeSelect.SelectedIndex == 1)
                    args += quantizer[encoderSelect.SelectedIndex].ToString() + " ";
                else
                {
                    int br = ((target_size * 8192 * 1024) / curr_duration) - (int.Parse(audRateSelect.Text) * 1024);
                    if (br <= 1024) br = 1024;
                    args += br.ToString() + " -bt " + (br/2).ToString() + " ";
                }
                if (deinterlaceCheck.Checked) 
                    args += "-deinterlace ";
                args += defaultEncOpts;
                // quick fix for xvid aspect ratio bug and automatic or custom aspect ratio correction
                if (encoderSelect.SelectedIndex == 1 || stretchCheck.Checked || fixAspectCheck.Checked || aspectSelect.Text != aspect_text[0])
                    args += computeAspectRatio();
                if (resampleCheck.Checked) 
                    args += " -ar " + audFreqSelect.Text;
                args += " -ab " + audRateSelect.Text + "k";
                args += size + " ";
                args += addParamBox.Text;
                args += " \"" + outputDir + Path.GetFileNameWithoutExtension(filename);
                if (Path.GetExtension(filename).ToLower() == ".mp4")
                    args += "_converted";
                args += ".mp4\"";
            }
            else
            {
                args += profile_val[profileSelect.SelectedIndex] + size + " " + defaultEncOpts;
                // quick fix for xvid aspect ratio bug and automatic aspect ratio correction
                if (profileSelect.SelectedIndex >= 4 || stretchCheck.Checked || fixAspectCheck.Checked)
                    args += computeAspectRatio();
                args += " -ar 44100 \"" + outputDir + Path.GetFileNameWithoutExtension(filename);
                if (Path.GetExtension(filename).ToLower() == ".mp4")
                    args += "_converted";
                args += ".mp4\"";
            }

            return args;
        }

        private void checkAndAddSubs(string filename)
        {
            string basePath = Path.GetDirectoryName(filename);
            string baseName = Path.GetFileNameWithoutExtension(filename);
            string[] subs = Directory.GetFiles(basePath, baseName + "*.srt");
            string[] convSubs = new string[subs.Length];

            if (subs.Length > 0)
            {
                setProgress("Adding subtitles...");
                string args_subs = "";

                for (int i = 0; i < subs.Length; i++)
                {
                    // convert sub file to UTF-8
                    convSubs[i] = tempPath + "\\" + Path.GetFileName(subs[i]);

                    StreamWriter writer = null;
                    StreamReader reader = null;
                    try
                    {
                        writer = new StreamWriter(convSubs[i], false, Encoding.UTF8);
                        reader = new StreamReader(subs[i], Encoding.Default, true);
                        writer.Write(reader.ReadToEnd());
                        consoleTextBox.AppendText("Converted subtitle file " + Path.GetFileName(subs[i]) + " to UTF-8 successfully.\n\r");

                        // add subtitle file to mp4box arguments
                        args_subs += " -add \"" + convSubs[i] + "\"";

                        // check if language code is present
                        string langCode = Path.GetFileNameWithoutExtension(subs[i]).Substring(baseName.Length);
                        if ((langCode.Length == 3 || langCode.Length == 4) && langCode[0] == '.')
                        {
                            args_subs += ":lang=" + langCode.Substring(1).ToLower();
                        }
                    }
                    catch (IOException ex)
                    {
                        consoleTextBox.AppendText("File error while converting subtitle file " + Path.GetFileName(subs[i]) + " :\n\r" + " " + ex.Message + "\n\r");
                    }
                    finally
                    {
                        if (writer != null) 
                            writer.Close();
                        if (reader != null) 
                            reader.Close();
                    }
                }
                args_subs += " \"" + outputDir + baseName + ".mp4\"";
                consoleTextBox.AppendText("\n\rmp4box.exe " + args_subs + "\n\r");

                // init mp4box process
                proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = tempPath + mpbName;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.Arguments = args_subs;

                proc.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(proc_DataReceived);
                proc.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(proc_DataReceived);

                proc.Start();
                proc.PriorityClass = priority_val[prioSelect.SelectedIndex];
                proc.BeginErrorReadLine();
                proc.BeginOutputReadLine();
                proc.WaitForExit();
                proc.CancelErrorRead();
                proc.CancelOutputRead();
                proc.Close();
                proc.Dispose();

                // clean up temp files
                foreach (string sub in convSubs)
                    if (File.Exists(sub))
                        File.Delete(sub);
            }
        }

    }
}