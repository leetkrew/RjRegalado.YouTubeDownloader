namespace RjRegalado.YouTubeDownloader.UI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLink = new System.Windows.Forms.TextBox();
            this.btnResolve = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.cboAV = new System.Windows.Forms.ComboBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pgbMuxed = new System.Windows.Forms.ProgressBar();
            this.cboAudioOnly = new System.Windows.Forms.ComboBox();
            this.btnMp3 = new System.Windows.Forms.Button();
            this.pgbAudio = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pgbVideo = new System.Windows.Forms.ProgressBar();
            this.btnVideo = new System.Windows.Forms.Button();
            this.cboVideoOnly = new System.Windows.Forms.ComboBox();
            this.txtAvResolution = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pgbHighRes = new System.Windows.Forms.ProgressBar();
            this.btnAV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLink
            // 
            this.txtLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLink.Location = new System.Drawing.Point(15, 25);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(319, 20);
            this.txtLink.TabIndex = 0;
            // 
            // btnResolve
            // 
            this.btnResolve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResolve.Location = new System.Drawing.Point(348, 22);
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Size = new System.Drawing.Size(116, 23);
            this.btnResolve.TabIndex = 1;
            this.btnResolve.Text = "Resolve";
            this.btnResolve.UseVisualStyleBackColor = true;
            this.btnResolve.Click += new System.EventHandler(this.btnResolve_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(15, 395);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(453, 104);
            this.txtResult.TabIndex = 10;
            // 
            // cboAV
            // 
            this.cboAV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAV.FormattingEnabled = true;
            this.cboAV.Location = new System.Drawing.Point(15, 85);
            this.cboAV.Name = "cboAV";
            this.cboAV.Size = new System.Drawing.Size(319, 21);
            this.cboAV.TabIndex = 2;
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Location = new System.Drawing.Point(348, 85);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(116, 23);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "Download Low Res.";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "YouTube Link";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Audio/Video";
            // 
            // pgbMuxed
            // 
            this.pgbMuxed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbMuxed.Location = new System.Drawing.Point(15, 112);
            this.pgbMuxed.Name = "pgbMuxed";
            this.pgbMuxed.Size = new System.Drawing.Size(449, 23);
            this.pgbMuxed.TabIndex = 7;
            // 
            // cboAudioOnly
            // 
            this.cboAudioOnly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAudioOnly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAudioOnly.FormattingEnabled = true;
            this.cboAudioOnly.Location = new System.Drawing.Point(15, 174);
            this.cboAudioOnly.Name = "cboAudioOnly";
            this.cboAudioOnly.Size = new System.Drawing.Size(319, 21);
            this.cboAudioOnly.TabIndex = 4;
            this.cboAudioOnly.SelectedIndexChanged += new System.EventHandler(this.cboAudioOnly_SelectedIndexChanged);
            // 
            // btnMp3
            // 
            this.btnMp3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMp3.Location = new System.Drawing.Point(348, 174);
            this.btnMp3.Name = "btnMp3";
            this.btnMp3.Size = new System.Drawing.Size(116, 23);
            this.btnMp3.TabIndex = 5;
            this.btnMp3.Text = "Save Audio";
            this.btnMp3.UseVisualStyleBackColor = true;
            this.btnMp3.Click += new System.EventHandler(this.btnMp3_Click);
            // 
            // pgbAudio
            // 
            this.pgbAudio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbAudio.Location = new System.Drawing.Point(15, 201);
            this.pgbAudio.Name = "pgbAudio";
            this.pgbAudio.Size = new System.Drawing.Size(449, 23);
            this.pgbAudio.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Audio Only";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Video Only";
            // 
            // pgbVideo
            // 
            this.pgbVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbVideo.Location = new System.Drawing.Point(15, 281);
            this.pgbVideo.Name = "pgbVideo";
            this.pgbVideo.Size = new System.Drawing.Size(452, 23);
            this.pgbVideo.TabIndex = 14;
            // 
            // btnVideo
            // 
            this.btnVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVideo.Location = new System.Drawing.Point(348, 254);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(119, 23);
            this.btnVideo.TabIndex = 7;
            this.btnVideo.Text = "Save Video";
            this.btnVideo.UseVisualStyleBackColor = true;
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // cboVideoOnly
            // 
            this.cboVideoOnly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboVideoOnly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVideoOnly.FormattingEnabled = true;
            this.cboVideoOnly.Location = new System.Drawing.Point(15, 254);
            this.cboVideoOnly.Name = "cboVideoOnly";
            this.cboVideoOnly.Size = new System.Drawing.Size(319, 21);
            this.cboVideoOnly.TabIndex = 6;
            this.cboVideoOnly.SelectedIndexChanged += new System.EventHandler(this.cboVideoOnly_SelectedIndexChanged);
            // 
            // txtAvResolution
            // 
            this.txtAvResolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAvResolution.Location = new System.Drawing.Point(15, 339);
            this.txtAvResolution.Name = "txtAvResolution";
            this.txtAvResolution.ReadOnly = true;
            this.txtAvResolution.Size = new System.Drawing.Size(319, 20);
            this.txtAvResolution.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(360, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "High Definition Video (Choose profile from Audio and Video Only dropdown)";
            // 
            // pgbHighRes
            // 
            this.pgbHighRes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbHighRes.Location = new System.Drawing.Point(15, 366);
            this.pgbHighRes.Name = "pgbHighRes";
            this.pgbHighRes.Size = new System.Drawing.Size(451, 23);
            this.pgbHighRes.TabIndex = 19;
            // 
            // btnAV
            // 
            this.btnAV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAV.Location = new System.Drawing.Point(348, 339);
            this.btnAV.Name = "btnAV";
            this.btnAV.Size = new System.Drawing.Size(119, 23);
            this.btnAV.TabIndex = 9;
            this.btnAV.Text = "Save High Res.";
            this.btnAV.UseVisualStyleBackColor = true;
            this.btnAV.Click += new System.EventHandler(this.btnAV_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 511);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pgbHighRes);
            this.Controls.Add(this.btnAV);
            this.Controls.Add(this.txtAvResolution);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pgbVideo);
            this.Controls.Add(this.btnVideo);
            this.Controls.Add(this.cboVideoOnly);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pgbAudio);
            this.Controls.Add(this.btnMp3);
            this.Controls.Add(this.cboAudioOnly);
            this.Controls.Add(this.pgbMuxed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.cboAV);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnResolve);
            this.Controls.Add(this.txtLink);
            this.MinimumSize = new System.Drawing.Size(500, 550);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YouTube Downloader (by RJ Regalado)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Button btnResolve;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.ComboBox cboAV;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pgbMuxed;
        private System.Windows.Forms.ComboBox cboAudioOnly;
        private System.Windows.Forms.Button btnMp3;
        private System.Windows.Forms.ProgressBar pgbAudio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar pgbVideo;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.ComboBox cboVideoOnly;
        private System.Windows.Forms.TextBox txtAvResolution;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar pgbHighRes;
        private System.Windows.Forms.Button btnAV;
    }
}

