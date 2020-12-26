using RjRegalado.YouTubeDownloader.Core;
using RjRegalado.YouTubeDownloader.UI.Helpers;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using static RjRegalado.YouTubeDownloader.UI.Helpers.TextboxHelper;

namespace RjRegalado.YouTubeDownloader.UI
{
    public partial class frmMain : Form
    {

        BackgroundWorker _resolveBg = new BackgroundWorker();
        BackgroundWorker _downloadIndividualBg = new BackgroundWorker();
        BackgroundWorker _downloadHighResBg = new BackgroundWorker();
        MergeAurgumentObj _mergeFileParam = new MergeAurgumentObj();
        PopulateTextboxDelegate _del = TextboxHelper.PopulateTextbox;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {
            try
            {
                disableControls(Controls);
                cboAV.Items.Clear();
                cboAudioOnly.Items.Clear();
                cboVideoOnly.Items.Clear();
                txtAvResolution.Text = "";
                txtResult.Text = "";
                pgbMuxed.Value = 0;
                pgbAudio.Value = 0;
                pgbVideo.Value = 0;
                pgbHighRes.Value = 0;


                _del(ref txtResult, string.Format("Checking {0}", txtLink.Text), true);

                _resolveBg.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                _del(ref txtResult, string.Format("Error: {0}", ex.Message));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                txtLink.Text = "https://www.youtube.com/watch?v=EwRdKJURDHw";
                disableControls(Controls);
                txtLink.Enabled = true;
                btnResolve.Enabled = true;

                _resolveBg.WorkerReportsProgress = true;
                _downloadIndividualBg.WorkerReportsProgress = true;
                _downloadHighResBg.WorkerReportsProgress = true;

                _resolveBg.WorkerSupportsCancellation = true;
                _downloadIndividualBg.WorkerSupportsCancellation = true;
                _downloadHighResBg.WorkerSupportsCancellation = true;

                _resolveBg.DoWork += (bgs, bgo) =>
                {
                    try
                    {
                        var ytResult = YouTubeHelper.GetDowloadUrlsAsync(txtLink.Text)
                        .Result;
                        foreach (var item in ytResult)
                        {
                            _resolveBg.ReportProgress(0, item);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Unable to resolve the link");
                    }

                };

                _resolveBg.ProgressChanged += (bgs, bge) =>
                {

                    var obj = bge.UserState as YouTubeLinksObj;

                    _del(ref txtResult, obj.Resolution);

                    if (obj.Type.Contains("Muxed"))
                    {

                        cboAV.Items.Add(new YouTubeLinksObj
                        {
                            Resolution = obj.Resolution,
                            URL = obj.URL,
                            Title = obj.Title
                        });
                        cboAV.SelectedIndex = 0;
                    }

                    if (obj.Type.Contains("Audio-only"))
                    {

                        cboAudioOnly.Items.Add(new YouTubeLinksObj
                        {
                            Resolution = obj.Resolution,
                            URL = obj.URL,
                            Title = obj.Title
                        });
                        cboAudioOnly.SelectedIndex = 0;
                    }

                    if (obj.Type.Contains("Video-only"))
                    {

                        cboVideoOnly.Items.Add(new YouTubeLinksObj
                        {
                            Resolution = obj.Resolution,
                            URL = obj.URL,
                            Title = obj.Title
                        });
                        cboVideoOnly.SelectedIndex = 0;
                    }
                };

                _resolveBg.RunWorkerCompleted += (bgs, bge) =>
                {
                    if (bge.Error != null)
                    {
                        txtLink.Enabled = true;
                        btnResolve.Enabled = true;
                        _del(ref txtResult, string.Format("Error: {0}", bge.Error.Message));
                    } else
                    {
                        _del(ref txtResult, "Video has been resolved");
                        enableControls(Controls);
                    }
                    
                };

                _downloadIndividualBg.DoWork += (bgs, bge) =>
                {
                    try
                    {
                        var obj = bge.Argument as SaveFileArgumentObj;
                        WebClient client = new WebClient();

                        client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                                                          "Windows NT 5.2; .NET CLR 1.0.3705;)");

                        client.DownloadProgressChanged += (bgWCs, bgWCe) =>
                        {

                            if (obj.Type == "Muxed")
                            {
                                if (_downloadIndividualBg.IsBusy)
                                {
                                    _downloadIndividualBg.ReportProgress(0, "Downloading Low Resolution video...");
                                }

                                if (pgbMuxed.InvokeRequired)
                                {
                                    pgbMuxed.Invoke(new MethodInvoker(delegate
                                    {
                                        pgbMuxed.Value = bgWCe.ProgressPercentage;
                                    }));
                                }
                            }

                            if (obj.Type == "Audio-only")
                            {
                                if (_downloadIndividualBg.IsBusy)
                                {
                                    _downloadIndividualBg.ReportProgress(0, "Downloading Audio...");
                                }

                                if (pgbAudio.InvokeRequired)
                                {
                                    pgbAudio.Invoke(new MethodInvoker(delegate
                                    {
                                        pgbAudio.Value = bgWCe.ProgressPercentage;
                                    }));
                                }
                            }

                            if (obj.Type == "Video-only")
                            {
                                if (_downloadIndividualBg.IsBusy)
                                {
                                    _downloadIndividualBg.ReportProgress(0, "Downloading High Resolution Video (no audio)...");
                                }

                                if (pgbVideo.InvokeRequired)
                                {
                                    pgbVideo.Invoke(new MethodInvoker(delegate
                                    {
                                        pgbVideo.Value = bgWCe.ProgressPercentage;
                                    }));
                                }
                            }

                        };

                        client.DownloadFileCompleted += (bgs2, bge2) =>
                        {
                            if (obj.Type == "Muxed")
                            {
                                if (pgbMuxed.InvokeRequired)
                                {
                                    pgbMuxed.Invoke(new MethodInvoker(delegate
                                    {
                                        pgbMuxed.Value = 100;
                                        enableControls(Controls);
                                    }));
                                }
                            }

                            if (obj.Type == "Audio-only")
                            {
                                if (pgbAudio.InvokeRequired)
                                {
                                    pgbAudio.Invoke(new MethodInvoker(delegate
                                    {
                                        pgbAudio.Value = 100;
                                        enableControls(Controls);
                                    }));
                                }
                            }

                            if (obj.Type == "Video-only")
                            {
                                if (pgbVideo.InvokeRequired)
                                {
                                    pgbVideo.Invoke(new MethodInvoker(delegate
                                    {
                                        pgbVideo.Value = 100;
                                        enableControls(Controls);
                                    }));
                                }
                            }

                        };

                        client.DownloadFileAsync(new Uri(obj.URL), obj.FileName);
                        while (client.IsBusy)
                        {

                        }

                        var process = new Process()
                        {
                            StartInfo =
                    {
                        FileName = "explorer.exe",
                        Arguments = Path.GetDirectoryName(obj.FileName),
                        WindowStyle = ProcessWindowStyle.Normal,
                        CreateNoWindow = true,

                    }
                        };

                        process.Start();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                };

                _downloadIndividualBg.ProgressChanged += (bgs1, bge1) =>
                {
                    //pgbMuxed.Value = bge1.ProgressPercentage;
                    _del(ref txtResult, bge1.UserState.ToString());
                };

                _downloadIndividualBg.RunWorkerCompleted += (bgs2, bge2) =>
                {
                    if (bge2.Error != null)
                    {
                        _del(ref txtResult, string.Format("Error: {0}", bge2.Error.Message));
                    }
                };

                _downloadHighResBg.DoWork += (bgs, bge) =>
                {
                    try
                    {
                        var audioInfo = new YouTubeLinksObj();
                        var videoInfo = new YouTubeLinksObj();
                        var obj = bge.Argument as SaveFileArgumentObj;

                        if (cboAudioOnly.InvokeRequired)
                        {
                            cboAudioOnly.Invoke(new MethodInvoker(delegate
                            {
                                audioInfo = (cboAudioOnly.SelectedItem as YouTubeLinksObj);
                            }));
                        }

                        if (cboVideoOnly.InvokeRequired)
                        {
                            cboVideoOnly.Invoke(new MethodInvoker(delegate
                            {
                                videoInfo = (cboVideoOnly.SelectedItem as YouTubeLinksObj);
                            }));
                        }

                        _downloadHighResBg.ReportProgress(0, "Downloading High Resolution Video");

                        WebClient clientAudio = new WebClient();
                        WebClient clientVideo = new WebClient();

                        clientAudio.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                                                          "Windows NT 5.2; .NET CLR 1.0.3705;)");
                        clientVideo.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                                                          "Windows NT 5.2; .NET CLR 1.0.3705;)");

                        clientAudio.DownloadProgressChanged += (bgWCs, bgWCe) =>
                        {
                            if (pgbAudio.InvokeRequired)
                            {
                                pgbAudio.Invoke(new MethodInvoker(delegate
                                {
                                    pgbAudio.Value = bgWCe.ProgressPercentage;
                                }));
                            }
                        };

                        clientVideo.DownloadProgressChanged += (bgWCs, bgWCe) =>
                        {
                            if (pgbVideo.InvokeRequired)
                            {
                                pgbVideo.Invoke(new MethodInvoker(delegate
                                {
                                    pgbVideo.Value = bgWCe.ProgressPercentage;
                                }));
                            }
                        };

                        clientAudio.DownloadFileCompleted += (bgs2, bge2) =>
                        {
                            if (pgbAudio.InvokeRequired)
                            {
                                pgbAudio.Invoke(new MethodInvoker(delegate
                                {
                                    pgbAudio.Value = 100;
                                }));
                            }
                        };

                        clientVideo.DownloadFileCompleted += (bgs2, bge2) =>
                        {
                            if (pgbVideo.InvokeRequired)
                            {
                                pgbVideo.Invoke(new MethodInvoker(delegate
                                {
                                    pgbVideo.Value = 100;
                                }));
                            }
                        };

                        clientAudio.DownloadFileAsync(new Uri(audioInfo.URL), string.Format("{0}.audio-file-tmp", obj.FileName));
                        clientVideo.DownloadFileAsync(new Uri(videoInfo.URL), string.Format("{0}.video-file-tmp", obj.FileName));



                        while (clientAudio.IsBusy || clientVideo.IsBusy)
                        {
                            var audioPercentage = 0;
                            var videoPercentage = 0;

                            if (pgbAudio.InvokeRequired)
                            {
                                pgbAudio.Invoke(new MethodInvoker(delegate
                                {
                                    audioPercentage = int.Parse(pgbAudio.Value.ToString());
                                }));
                            }

                            if (pgbVideo.InvokeRequired)
                            {
                                pgbVideo.Invoke(new MethodInvoker(delegate
                                {
                                    videoPercentage = int.Parse(pgbVideo.Value.ToString());
                                }));
                            }

                            _downloadHighResBg.ReportProgress(
                                Convert.ToInt32((audioPercentage * 0.25) + (videoPercentage * 0.25))
                            );
                        }

                        ConvertFileAsync(_mergeFileParam);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                };

                _downloadHighResBg.ProgressChanged += (bgs1, bge1) =>
                {

                    if (bge1.UserState != null)
                    {
                        _del(ref txtResult, bge1.UserState.ToString());
                    }

                    if (pgbHighRes.InvokeRequired)
                    {
                        pgbHighRes.Invoke(new MethodInvoker(delegate
                        {
                            pgbHighRes.Value = bge1.ProgressPercentage;
                        }));
                    }
                    else
                    {
                        pgbHighRes.Value = bge1.ProgressPercentage;
                    }
                };

                _downloadHighResBg.RunWorkerCompleted += (bgs2, bge2) =>
                {
                    if (bge2.Error != null)
                    {
                        _del(ref txtResult, string.Format("Error: {0}", bge2.Error.Message));
                    }

                    pgbMuxed.Value = 0;
                    pgbAudio.Value = 0;
                    pgbHighRes.Value = 0;
                    enableControls(Controls);
                };
            }
            catch (Exception ex)
            {
                _del(ref txtResult, string.Format("Error: {0}", ex.Message));

            }
        }
        
        public void ConvertFileAsync(MergeAurgumentObj param)
        {
            // convert audio to aac
            if (txtResult.InvokeRequired)
            {
                txtResult.Invoke(new MethodInvoker(delegate {
                    txtResult.Enabled = true;
                    txtResult.ReadOnly = true;
                }));
            }

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = string.Format("{0}\\ffmpeg\\ffmpeg.exe", Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)),
                    Arguments = string.Format("-hide_banner -stats -i {0} -b:a 192K -vn {1}.aac", param.AudioFile, param.Filename),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                },
                EnableRaisingEvents = true
            };

            process.Start();

            string processOutput = null;
            while ((processOutput = process.StandardError.ReadLine()) != null)
            {
                if (txtResult.InvokeRequired)
                {
                    txtResult.Invoke(new MethodInvoker(delegate
                    {
                        txtResult.Text += "\r\n" + processOutput;
                        txtResult.SelectionStart = txtResult.Text.Length;
                        txtResult.ScrollToCaret();
                        txtResult.Refresh();
                    }));
                }

            }

            _downloadHighResBg.ReportProgress(65);

            // convert video to mp4
            process = null;
            process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = string.Format("{0}\\ffmpeg\\ffmpeg.exe", Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)),
                    Arguments = string.Format("-hide_banner -stats -i {0} {1}.mp4", param.VideoFile, param.Filename),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                },
                EnableRaisingEvents = true
            };

            process.Start();

            

            processOutput = null;
            while ((processOutput = process.StandardError.ReadLine()) != null)
            {
                if (txtResult.InvokeRequired)
                {
                    txtResult.Invoke(new MethodInvoker(delegate {
                        txtResult.Text += "\r\n" + processOutput;
                        txtResult.SelectionStart = txtResult.Text.Length;
                        txtResult.ScrollToCaret();
                        txtResult.Refresh();
                    }));
                }

            }
            _downloadHighResBg.ReportProgress(80);

            // merge 2 files
            process = null;
            process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = string.Format("{0}\\ffmpeg\\ffmpeg.exe", Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)),
                    Arguments = string.Format("-hide_banner -stats -i {0}.mp4 -i {1}.aac -c:v copy -map 0:v:0 -map 1:a:0 {2}", param.Filename, param.Filename, param.Filename),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                },
                EnableRaisingEvents = true
            };

            process.Start();
            processOutput = null;
            while ((processOutput = process.StandardError.ReadLine()) != null)
            {
                if (txtResult.InvokeRequired)
                {
                    txtResult.Invoke(new MethodInvoker(delegate
                    {
                        txtResult.Text += "\r\n" + processOutput;
                        txtResult.SelectionStart = txtResult.Text.Length;
                        txtResult.ScrollToCaret();
                        txtResult.Refresh();
                    }));
                }

            }
            _downloadHighResBg.ReportProgress(95);

            //clean up
            File.Delete(param.AudioFile);
            File.Delete(param.VideoFile);
            File.Delete(string.Format("{0}.aac", param.Filename));
            File.Delete(string.Format("{0}.mp4", param.Filename));
            _downloadHighResBg.ReportProgress(100);

            process = new Process()
            {
                StartInfo =
                {
                    FileName = "explorer.exe",
                    Arguments = Path.GetDirectoryName(param.Filename),
                    WindowStyle = ProcessWindowStyle.Normal,
                    CreateNoWindow = true,
                    
                }
            };

            process.Start();

        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                var ytInfo = (cboAV.SelectedItem as YouTubeLinksObj);
                var extName = ytInfo.Resolution.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .Last()
                    .Trim()
                    .Replace(")", "");

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = string.Format("{0} File |*.{0}", extName);
                saveFileDialog1.Title = "Save a Video File";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    disableControls(Controls);

                    _downloadIndividualBg.RunWorkerAsync(new SaveFileArgumentObj()
                    {
                        FileName = saveFileDialog1.FileName,
                        URL = ytInfo.URL,
                        Type = "Muxed"
                    });
                }
            }
            catch (Exception ex)
            {
                _del(ref txtResult, string.Format("Error: {0}", ex.Message));
            }
        }

        private void enableControls(Control.ControlCollection Controls)
        {
            foreach (Control c in Controls)
            {

                if (c.InvokeRequired)
                {
                    c.Invoke(new MethodInvoker(delegate {
                        c.Enabled = true;
                    }));
                }
                else
                {
                    c.Enabled = true;
                }
            }
        }

        private void disableControls(Control.ControlCollection Controls)
        {
            foreach (Control c in Controls)
            {
                c.Enabled = false;
            }
            lblLink.Enabled = true;
        }

        private void btnMp3_Click(object sender, EventArgs e)
        {
            try
            {
                var ytInfo = (cboAudioOnly.SelectedItem as YouTubeLinksObj);
                var extName = ytInfo.Resolution.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .Last()
                    .Trim()
                    .Replace(")", "");

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = string.Format("{0} File |*.{0}|AAC Audio File|*.aac", extName);
                saveFileDialog1.Title = "Save an Audio File";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    if (Path.GetExtension(saveFileDialog1.FileName).ToLower() == "aac")
                    {
                        throw new Exception("Not Yet Implemented");
                    }

                    disableControls(Controls);
                    _downloadIndividualBg.RunWorkerAsync(new SaveFileArgumentObj()
                    {
                        FileName = saveFileDialog1.FileName,
                        URL = ytInfo.URL,
                        Type = "Audio-only"
                    });

                    //while (_downloadIndividualBg.IsBusy)
                    //{
                    //    //wait
                    //}
                }
            }
            catch (Exception ex)
            {
                _del(ref txtResult, string.Format("Error: {0}", ex.Message));
            }
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            try
            {
                var ytInfo = (cboVideoOnly.SelectedItem as YouTubeLinksObj);
                var extName = ytInfo.Resolution.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .Last()
                    .Trim()
                    .Replace(")", "");

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = string.Format("{0} File |*.{0}", extName);
                saveFileDialog1.Title = "Save a Video File";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    disableControls(Controls);

                    _downloadIndividualBg.RunWorkerAsync(new SaveFileArgumentObj()
                    {
                        FileName = saveFileDialog1.FileName,
                        URL = ytInfo.URL,
                        Type = "Video-only"
                    });
                }
            }
            catch (Exception ex)
            {
                _del(ref txtResult, string.Format("Error: {0}", ex.Message));
            }
        }

        private void cboAudioOnly_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var audioInfo = (cboAudioOnly.SelectedItem as YouTubeLinksObj);
                var videoInfo = (cboVideoOnly.SelectedItem as YouTubeLinksObj);

                var audioText = "";
                var videoText = "";

                if (audioInfo != null)
                {
                    audioText = audioInfo.Resolution
                        .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                        .First()
                        .Replace("Audio-only", "")
                        .Trim();
                }

                if (videoInfo != null)
                {
                    videoText = videoInfo.Resolution
                        .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)[1]
                        .Trim();
                }

                txtAvResolution.Text = string.Format("{0} @ {1}", audioText, videoText);
            }
            catch (Exception ex)
            {
                _del(ref txtResult, string.Format("Error: {0}", ex.Message));
            }

        }

        private void cboVideoOnly_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var audioInfo = (cboAudioOnly.SelectedItem as YouTubeLinksObj);
                var videoInfo = (cboVideoOnly.SelectedItem as YouTubeLinksObj);

                var audioText = "";
                var videoText = "";

                if (audioInfo != null)
                {
                    audioText = audioInfo.Resolution
                        .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                        .First()
                        .Replace("Audio-only", "")
                        .Trim();
                }

                if (videoInfo != null)
                {
                    videoText = videoInfo.Resolution
                        .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)[1]
                        .Trim();
                }

                txtAvResolution.Text = string.Format("{0} @ {1}", audioText, videoText);
            }
            catch (Exception ex)
            {
                _del(ref txtResult, string.Format("Error: {0}", ex.Message));
            }
        }

        private void btnAV_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "mp4 File |*.mp4";
                saveFileDialog1.Title = "Save High Resolution Video";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    disableControls(Controls);

                    _mergeFileParam = new MergeAurgumentObj()
                    {
                        AudioFile = string.Format("{0}.audio-file-tmp", saveFileDialog1.FileName),
                        VideoFile = string.Format("{0}.video-file-tmp", saveFileDialog1.FileName),
                        Filename = saveFileDialog1.FileName
                    };

                    _downloadHighResBg.RunWorkerAsync(new SaveFileArgumentObj() { FileName = saveFileDialog1.FileName });
                }
            }
            catch (Exception ex)
            {
                _del(ref txtResult, string.Format("Error: {0}", ex.Message));
            }
        }

        private void lblLink_Click(object sender, EventArgs e)
        {
            try
            {
                var process = new Process()
                {
                    StartInfo =
                    {
                        FileName = "explorer.exe",
                        Arguments = "https://www.rjregalado.com/",
                        WindowStyle = ProcessWindowStyle.Normal,
                        CreateNoWindow = true
                    }
                };

                process.Start();
            }
            catch (Exception ex)
            {
                _del(ref txtResult, string.Format("Error: {0}", ex.Message));
            }
        }
    }
}
