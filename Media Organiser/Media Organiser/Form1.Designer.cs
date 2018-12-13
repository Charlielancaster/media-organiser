namespace Media_Organiser
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this._playlistTextBox = new System.Windows.Forms.TextBox();
            this._cMediaButton = new System.Windows.Forms.Button();
            this._fileListView = new System.Windows.Forms.ListView();
            this._fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._filePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._fileType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._fileComment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._fileCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._createPlaylist = new System.Windows.Forms.Button();
            this._saveToPlaylist = new System.Windows.Forms.Button();
            this._loadPlaylist = new System.Windows.Forms.Button();
            this._deletePlaylist = new System.Windows.Forms.Button();
            this._playlistListView = new System.Windows.Forms.ListView();
            this.logoBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(178, 63);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(574, 430);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // _playlistTextBox
            // 
            this._playlistTextBox.Location = new System.Drawing.Point(178, 22);
            this._playlistTextBox.Name = "_playlistTextBox";
            this._playlistTextBox.Size = new System.Drawing.Size(508, 20);
            this._playlistTextBox.TabIndex = 4;
            // 
            // _cMediaButton
            // 
            this._cMediaButton.Location = new System.Drawing.Point(178, 499);
            this._cMediaButton.Name = "_cMediaButton";
            this._cMediaButton.Size = new System.Drawing.Size(121, 23);
            this._cMediaButton.TabIndex = 7;
            this._cMediaButton.Text = "Choose Media";
            this._cMediaButton.UseVisualStyleBackColor = true;
            this._cMediaButton.Click += new System.EventHandler(this._cPlaylistButton_Click);
            // 
            // _fileListView
            // 
            this._fileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._fileName,
            this._filePath,
            this._fileType,
            this._fileComment,
            this._fileCategory});
            this._fileListView.Location = new System.Drawing.Point(758, 63);
            this._fileListView.Name = "_fileListView";
            this._fileListView.Size = new System.Drawing.Size(442, 430);
            this._fileListView.TabIndex = 11;
            this._fileListView.UseCompatibleStateImageBehavior = false;
            this._fileListView.View = System.Windows.Forms.View.Details;
            // 
            // _fileName
            // 
            this._fileName.Text = "File Name";
            this._fileName.Width = 70;
            // 
            // _filePath
            // 
            this._filePath.Text = "File Path";
            this._filePath.Width = 73;
            // 
            // _fileType
            // 
            this._fileType.Text = "File Type";
            // 
            // _fileComment
            // 
            this._fileComment.Text = "File Comment";
            this._fileComment.Width = 94;
            // 
            // _fileCategory
            // 
            this._fileCategory.Text = "Category";
            this._fileCategory.Width = 139;
            // 
            // _createPlaylist
            // 
            this._createPlaylist.AutoSize = true;
            this._createPlaylist.Location = new System.Drawing.Point(4, 497);
            this._createPlaylist.Margin = new System.Windows.Forms.Padding(1);
            this._createPlaylist.Name = "_createPlaylist";
            this._createPlaylist.Size = new System.Drawing.Size(83, 23);
            this._createPlaylist.TabIndex = 12;
            this._createPlaylist.Text = "Create playlist";
            this._createPlaylist.UseVisualStyleBackColor = true;
            this._createPlaylist.Click += new System.EventHandler(this._createPlaylist_Click);
            // 
            // _saveToPlaylist
            // 
            this._saveToPlaylist.AutoSize = true;
            this._saveToPlaylist.Location = new System.Drawing.Point(4, 522);
            this._saveToPlaylist.Margin = new System.Windows.Forms.Padding(1);
            this._saveToPlaylist.Name = "_saveToPlaylist";
            this._saveToPlaylist.Size = new System.Drawing.Size(83, 23);
            this._saveToPlaylist.TabIndex = 13;
            this._saveToPlaylist.Text = "Save playlist";
            this._saveToPlaylist.UseVisualStyleBackColor = true;
            this._saveToPlaylist.Click += new System.EventHandler(this._saveToPlaylist_Click);
            // 
            // _loadPlaylist
            // 
            this._loadPlaylist.AutoSize = true;
            this._loadPlaylist.Location = new System.Drawing.Point(4, 547);
            this._loadPlaylist.Margin = new System.Windows.Forms.Padding(1);
            this._loadPlaylist.Name = "_loadPlaylist";
            this._loadPlaylist.Size = new System.Drawing.Size(83, 23);
            this._loadPlaylist.TabIndex = 14;
            this._loadPlaylist.Text = "Load playlist";
            this._loadPlaylist.UseVisualStyleBackColor = true;
            // 
            // _deletePlaylist
            // 
            this._deletePlaylist.AutoSize = true;
            this._deletePlaylist.Location = new System.Drawing.Point(4, 572);
            this._deletePlaylist.Margin = new System.Windows.Forms.Padding(1);
            this._deletePlaylist.Name = "_deletePlaylist";
            this._deletePlaylist.Size = new System.Drawing.Size(83, 23);
            this._deletePlaylist.TabIndex = 15;
            this._deletePlaylist.Text = "Delete playlist";
            this._deletePlaylist.UseVisualStyleBackColor = true;
            // 
            // _playlistListView
            // 
            this._playlistListView.Location = new System.Drawing.Point(4, 63);
            this._playlistListView.Name = "_playlistListView";
            this._playlistListView.Size = new System.Drawing.Size(157, 430);
            this._playlistListView.TabIndex = 16;
            this._playlistListView.UseCompatibleStateImageBehavior = false;
            // 
            // logoBox
            // 
            this.logoBox.Location = new System.Drawing.Point(4, 13);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(157, 44);
            this.logoBox.TabIndex = 17;
            this.logoBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1219, 636);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this._playlistListView);
            this.Controls.Add(this._deletePlaylist);
            this.Controls.Add(this._loadPlaylist);
            this.Controls.Add(this._saveToPlaylist);
            this.Controls.Add(this._createPlaylist);
            this.Controls.Add(this._fileListView);
            this.Controls.Add(this._cMediaButton);
            this.Controls.Add(this._playlistTextBox);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.TextBox _playlistTextBox;
        private System.Windows.Forms.Button _cMediaButton;
        private System.Windows.Forms.ListView _fileListView;
        private System.Windows.Forms.ColumnHeader _fileName;
        private System.Windows.Forms.ColumnHeader _filePath;
        private System.Windows.Forms.ColumnHeader _fileType;
        private System.Windows.Forms.ColumnHeader _fileComment;
        private System.Windows.Forms.ColumnHeader _fileCategory;
        private System.Windows.Forms.Button _createPlaylist;
        private System.Windows.Forms.Button _saveToPlaylist;
        private System.Windows.Forms.Button _loadPlaylist;
        private System.Windows.Forms.Button _deletePlaylist;
        private System.Windows.Forms.ListView _playlistListView;
        private System.Windows.Forms.PictureBox logoBox;
    }
}

