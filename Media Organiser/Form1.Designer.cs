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
            this._cMediaButton = new System.Windows.Forms.Button();
            this._fileListView = new System.Windows.Forms.ListView();
            this._fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._filePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._fileType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._fileComment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._fileCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._fileImage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._createPlaylist = new System.Windows.Forms.Button();
            this._saveToPlaylist = new System.Windows.Forms.Button();
            this._deletePlaylist = new System.Windows.Forms.Button();
            this._playlistListView = new System.Windows.Forms.ListView();
            this.playlistName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playlistID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._playlistName = new System.Windows.Forms.Label();
            this._addCat = new System.Windows.Forms.Button();
            this._editCategories = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(178, 73);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(415, 430);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // _cMediaButton
            // 
            this._cMediaButton.Location = new System.Drawing.Point(599, 509);
            this._cMediaButton.Name = "_cMediaButton";
            this._cMediaButton.Size = new System.Drawing.Size(121, 23);
            this._cMediaButton.TabIndex = 7;
            this._cMediaButton.Text = "Choose Media";
            this._cMediaButton.UseVisualStyleBackColor = true;
            this._cMediaButton.Click += new System.EventHandler(this._cMediaButton_Click);
            // 
            // _fileListView
            // 
            this._fileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._fileName,
            this._filePath,
            this._fileType,
            this._fileComment,
            this._fileCategory,
            this._fileImage});
            this._fileListView.Location = new System.Drawing.Point(599, 22);
            this._fileListView.Name = "_fileListView";
            this._fileListView.Size = new System.Drawing.Size(601, 481);
            this._fileListView.TabIndex = 11;
            this._fileListView.UseCompatibleStateImageBehavior = false;
            this._fileListView.View = System.Windows.Forms.View.Details;
            this._fileListView.DoubleClick += new System.EventHandler(this._fileListView_SelectedIndexChanged);
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
            this._fileComment.Width = 124;
            // 
            // _fileCategory
            // 
            this._fileCategory.Text = "Categories";
            this._fileCategory.Width = 109;
            // 
            // _fileImage
            // 
            this._fileImage.Text = "Image";
            this._fileImage.Width = 112;
            // 
            // _createPlaylist
            // 
            this._createPlaylist.AutoSize = true;
            this._createPlaylist.Location = new System.Drawing.Point(4, 509);
            this._createPlaylist.Margin = new System.Windows.Forms.Padding(1);
            this._createPlaylist.Name = "_createPlaylist";
            this._createPlaylist.Size = new System.Drawing.Size(157, 23);
            this._createPlaylist.TabIndex = 12;
            this._createPlaylist.Text = "Create playlist";
            this._createPlaylist.UseVisualStyleBackColor = true;
            this._createPlaylist.Click += new System.EventHandler(this._createPlaylist_Click);
            // 
            // _saveToPlaylist
            // 
            this._saveToPlaylist.AutoSize = true;
            this._saveToPlaylist.Location = new System.Drawing.Point(4, 534);
            this._saveToPlaylist.Margin = new System.Windows.Forms.Padding(1);
            this._saveToPlaylist.Name = "_saveToPlaylist";
            this._saveToPlaylist.Size = new System.Drawing.Size(157, 23);
            this._saveToPlaylist.TabIndex = 13;
            this._saveToPlaylist.Text = "Save playlist";
            this._saveToPlaylist.UseVisualStyleBackColor = true;
            this._saveToPlaylist.Click += new System.EventHandler(this._saveToPlaylist_Click);
            // 
            // _deletePlaylist
            // 
            this._deletePlaylist.AutoSize = true;
            this._deletePlaylist.Location = new System.Drawing.Point(4, 559);
            this._deletePlaylist.Margin = new System.Windows.Forms.Padding(1);
            this._deletePlaylist.Name = "_deletePlaylist";
            this._deletePlaylist.Size = new System.Drawing.Size(157, 23);
            this._deletePlaylist.TabIndex = 15;
            this._deletePlaylist.Text = "Delete playlist";
            this._deletePlaylist.UseVisualStyleBackColor = true;
            this._deletePlaylist.Click += new System.EventHandler(this._deletePlaylist_Click);
            // 
            // _playlistListView
            // 
            this._playlistListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.playlistName,
            this.playlistID});
            this._playlistListView.Location = new System.Drawing.Point(4, 73);
            this._playlistListView.Name = "_playlistListView";
            this._playlistListView.Size = new System.Drawing.Size(157, 430);
            this._playlistListView.TabIndex = 16;
            this._playlistListView.UseCompatibleStateImageBehavior = false;
            this._playlistListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._playlistListView_MouseDoubleClick);
            // 
            // playlistName
            // 
            this.playlistName.Text = "";
            this.playlistName.Width = 100;
            // 
            // playlistID
            // 
            this.playlistID.Text = "";
            this.playlistID.Width = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // _playlistName
            // 
            this._playlistName.AutoSize = true;
            this._playlistName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this._playlistName.Location = new System.Drawing.Point(172, 22);
            this._playlistName.Name = "_playlistName";
            this._playlistName.Size = new System.Drawing.Size(101, 31);
            this._playlistName.TabIndex = 18;
            this._playlistName.Text = "Playlist";
            // 
            // _addCat
            // 
            this._addCat.Location = new System.Drawing.Point(736, 509);
            this._addCat.Name = "_addCat";
            this._addCat.Size = new System.Drawing.Size(138, 23);
            this._addCat.TabIndex = 19;
            this._addCat.Text = "Add Category";
            this._addCat.UseVisualStyleBackColor = true;
            this._addCat.Click += new System.EventHandler(this._addCat_Click);
            // 
            // _editCategories
            // 
            this._editCategories.Location = new System.Drawing.Point(736, 538);
            this._editCategories.Name = "_editCategories";
            this._editCategories.Size = new System.Drawing.Size(138, 24);
            this._editCategories.TabIndex = 20;
            this._editCategories.Text = "Edit Categories";
            this._editCategories.UseVisualStyleBackColor = true;
            this._editCategories.Click += new System.EventHandler(this._editCategories_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1219, 636);
            this.Controls.Add(this._editCategories);
            this.Controls.Add(this._addCat);
            this.Controls.Add(this._playlistName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._playlistListView);
            this.Controls.Add(this._deletePlaylist);
            this.Controls.Add(this._saveToPlaylist);
            this.Controls.Add(this._createPlaylist);
            this.Controls.Add(this._fileListView);
            this.Controls.Add(this._cMediaButton);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button _cMediaButton;
        private System.Windows.Forms.ListView _fileListView;
        private System.Windows.Forms.ColumnHeader _fileName;
        private System.Windows.Forms.ColumnHeader _filePath;
        private System.Windows.Forms.ColumnHeader _fileType;
        private System.Windows.Forms.ColumnHeader _fileComment;
        private System.Windows.Forms.ColumnHeader _fileCategory;
        private System.Windows.Forms.Button _createPlaylist;
        private System.Windows.Forms.Button _saveToPlaylist;
        private System.Windows.Forms.Button _deletePlaylist;
        private System.Windows.Forms.ListView _playlistListView;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label _playlistName;
        private System.Windows.Forms.ColumnHeader playlistName;
        private System.Windows.Forms.ColumnHeader playlistID;
        private System.Windows.Forms.Button _addCat;
        private System.Windows.Forms.ColumnHeader _fileImage;
        private System.Windows.Forms.Button _editCategories;
    }
}

