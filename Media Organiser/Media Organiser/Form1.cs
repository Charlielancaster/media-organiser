using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Organiser
{
    public partial class Form1 : Form
    {
        protected string resume = "Start";
        SaveFuncs savefuncs = new SaveFuncs();
        //List<Whizzyfile> listinscope = new List<Whizzyfile>();
        public Playlist spl = new Playlist();

        public Form1()
        {
            InitializeComponent();
        }

        public WhizzyFileList AddFilesToNewList(List<Whizzyfile> wf)
        {
            WhizzyFileList whizzyfiles = new WhizzyFileList();

            whizzyfiles.filelistID = 0;
            whizzyfiles.whizzyfiles = wf;
            return whizzyfiles;
        }

        public Playlist AddListToPlaylist(string name, WhizzyFileList wfiles)
        {
            Playlist playlist = new Playlist();

            playlist.playlistID = 0;
            playlist.playlistname = name;
            playlist.playlistcount = wfiles.Count;
            playlist.whizzyfiles = wfiles;

            return playlist;
        }

        public string GetFilePath(int ID, List<Whizzyfile> fileList)
        {
            string filePath = fileList.First(item => item.fileID == ID).Filepath;
            return filePath;
        }
        

        private void _chooseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this._playlistTextBox.Text = openFileDialog.FileName;
            }
        }

        private void _startButton_Click(object sender, EventArgs e)
        {
            if(resume == "Start")
            {
                axWindowsMediaPlayer1.URL = _playlistTextBox.Text;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                resume = "Resume";
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void _pauseButton_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void _stopButton_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void _playlistList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_playlistListBox.SelectedIndex >= 0)
            {
                axWindowsMediaPlayer1.URL = GetFilePath(_playlistListBox.SelectedIndex, spl);
                _playlistTextBox.Text = _playlistListBox.Text;
            }
        }

        private void _createPlaylist_Click(object sender, EventArgs e)
        {
            

            //funcs;
        }

        private void _saveToPlaylist_Click(object sender, EventArgs e)
        {
            bool exists = savefuncs.checkExists(_playlistTextBox.Text);

            if (exists)
            {
                savefuncs.saveFile(spl, _playlistTextBox.Text);
            }
            else
            {
                using (DialogBox dialogbox = new DialogBox())
                {
                    if (dialogbox.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                        savefuncs.saveFile(spl, dialogbox.textboxdata);
                    }
                }
            }
        }

        private void _cPlaylistButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            List<Whizzyfile> listinscope = new List<Whizzyfile>();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                int numFiles = openFileDialog.FileNames.Length;

                for (int i = 0; i < numFiles; i++)
                {
                    Whizzyfile whizzyfile = new Whizzyfile();
                    if (!listinscope.Any(item => item.Filepath == openFileDialog.FileNames[i]))
                    {
                        whizzyfile.Filepath = openFileDialog.FileNames[i];
                        whizzyfile.Filename = openFileDialog.SafeFileNames[i];
                        whizzyfile.fileID = listinscope.Count == 0 ? whizzyfile.fileID = i : whizzyfile.fileID = listinscope.Count;
                        whizzyfile.Filetype = Path.GetExtension(openFileDialog.FileNames[i]);
                        //whizzyfile.Filecomment = openFileDialog.FileNames[i];

                        listinscope.Add(whizzyfile);
                    }
                }
                //AddFilesToNewList(wfileList);


                foreach (Whizzyfile file in listinscope)
                {
                    if (_playlistListBox.Items.Count == 0)
                    {
                        _playlistListBox.Items.Add(file.Filename);
                        string[] row = { file.Filepath, Path.GetExtension(file.Filepath), "" };
                        _fileListView.Items.Add(file.Filename).SubItems.AddRange(row);
                    }
                    else
                    {
                        List<string> namecheck = new List<string>();
                        for (int i = 0; i < _playlistListBox.Items.Count; i++)
                        {
                            namecheck.Add(_playlistListBox.Items[i].ToString());
                        }

                        if (namecheck.Any(item => item[0].ToString() != file.Filename))
                            if (_playlistListBox.Items.Contains(file.Filename))
                            {
                            _playlistListBox.Items.Add(file.Filename);
                            string[] row = { file.Filepath, Path.GetExtension(file.Filepath), "" };
                            _fileListView.Items.Add(file.Filename).SubItems.AddRange(row);
                        }
                    }
                }
            }
            spl.whizzyfiles = AddListToPlaylist("session", AddFilesToNewList(listinscope));
        }
    }
}
