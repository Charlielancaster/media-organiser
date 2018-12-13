using Newtonsoft.Json;
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
        static private string playlists = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + @"\Playlists\";
        static private string categories = playlists + @"Categories\";
        static Funcs funcs = new Funcs();
        static DataFuncs datafuncs = new DataFuncs();
        protected Playlist spl = new Playlist();
        protected Playlist selectedPL = new Playlist();
        protected List<Category> allcategories = new List<Category>();
        protected List<Whizzyfile> listinscope = new List<Whizzyfile>();
        protected List<Playlist> allplaylists = new List<Playlist>();
        protected bool isSessionPL = true;


    public Form1()
        {
            InitializeComponent();
            allplaylists = funcs.loadPlaylists(_playlistListView, allplaylists);
            allcategories = datafuncs.loadCategories();
        }

        /* minor form functions */

        protected void clearlistview()
        {
            _fileListView.Items.Clear();
        }

        /* Button functionality */

        private void _fileListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Playlist playlist = !isSessionPL ? selectedPL : spl;
            if (_fileListView.SelectedItems.Count > 0)
            {
                for (int i = 0; i < _fileListView.SelectedItems.Count; i++)
                {
                    ListViewItem selectedItem = _fileListView.SelectedItems[i];
                    axWindowsMediaPlayer1.URL = selectedItem.SubItems[1].Text;
                    _playlistName.Text = _fileListView.Text;
                }
            }
        }

        private void _createPlaylist_Click(object sender, EventArgs e)
        {
            using (DialogBox dialogbox = new DialogBox())
            {
                if (dialogbox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    datafuncs.createPlaylist(spl, dialogbox.textboxdata);
                }
            }
            listinscope.Clear();
            _playlistListView.Items.Add(spl.playlistname);
            selectedPL = spl;
            allplaylists.Add(selectedPL);
            if (spl.whizzyfilelist != null && spl.whizzyfilelist.Count != 0) { spl.whizzyfilelist.Clear(); };
            if (_playlistListView.Items != null) { clearlistview(); }
            _playlistName.Text = selectedPL.playlistname;
            isSessionPL = false;
        }

        private void _saveToPlaylist_Click(object sender, EventArgs e)
        {
            var selecteditem = _playlistListView.SelectedItems;
            bool exists = false;

            if (!isSessionPL)
            {
                if (selecteditem[0] != null)
                {
                    exists = datafuncs.checkExists(selecteditem[0].Text);
                }
                else
                {
                    exists = datafuncs.checkExists(_playlistName.Text);
                }
            }

            if (exists)
            {
                selectedPL = datafuncs.loadPlaylist(playlists + _playlistListView.SelectedItems[0].Text + ".json");
                if (selectedPL.whizzyfilelist != null)
                {
                    foreach (Whizzyfile item in selectedPL.whizzyfilelist)
                    {
                        int count = 0;
                        if (item.Filepath == listinscope[count].Filepath)
                        {
                            listinscope.RemoveAt(count);
                        }
                        count++;
                    }
                    funcs.addListToExistingPlaylist(selectedPL, listinscope);
                }
                else
                {
                    funcs.addListToExistingPlaylist(selectedPL, listinscope);
                }

            datafuncs.saveFile(selectedPL, _playlistListView.SelectedItems[0].Text);
            }
            else
            {
                using (DialogBox dialogbox = new DialogBox())
                {
                    if (dialogbox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        spl.playlistname = dialogbox.Text;
                        datafuncs.createPlaylist(spl, dialogbox.textboxdata);
                        _playlistName.Text = spl.playlistname;
                    }
                }
                selectedPL = spl;
                if (spl.whizzyfilelist.Count != 0) { spl.whizzyfilelist.Clear(); };
            }
            isSessionPL = false;
            funcs.loadPlaylists(_playlistListView, allplaylists);
        }

        private void _cMediaButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Please select media to add.";
            openFileDialog.Filter = "Media files |*.aac; *.mp3; *.mp4; *.wav; *.wma; *.avi; *.flac;";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                int numFiles = openFileDialog.FileNames.Length;

                for (int i = 0; i < numFiles; i++)
                {
                    Whizzyfile whizzyfile = new Whizzyfile();
                    TagLib.File file = TagLib.File.Create(openFileDialog.FileNames[i]);
                    if (spl.whizzyfilelist != null)
                    {
                        if (spl != null && !spl.whizzyfilelist.Any(item => item.Filepath == openFileDialog.FileNames[i]))
                        {
                            whizzyfile.Filepath = openFileDialog.FileNames[i];
                            whizzyfile.Filename = openFileDialog.SafeFileNames[i];
                            whizzyfile.Filetype = Path.GetExtension(openFileDialog.FileNames[i]);
                            whizzyfile.Filecomment = file.Tag.Comment;

                            listinscope.Add(whizzyfile);
                        }
                    }
                    else
                    {
                        whizzyfile.Filepath = openFileDialog.FileNames[i];
                        whizzyfile.Filename = openFileDialog.SafeFileNames[i];
                        whizzyfile.Filetype = Path.GetExtension(openFileDialog.FileNames[i]);
                        whizzyfile.Filecomment = file.Tag.Comment;

                        listinscope.Add(whizzyfile);
                    }
            }

                foreach (Whizzyfile file in listinscope)
                {
                        if (_fileListView.Items.Count == 0)
                        {
                            string[] row = { file.Filepath, Path.GetExtension(file.Filepath), file.Filecomment };
                            _fileListView.Items.Add(file.Filename).SubItems.AddRange(row);
                        }
                        else
                        {
                            if (!_fileListView.Items.ToString().Contains(file.Filename))
                            {
                                string[] row = { file.Filepath, Path.GetExtension(file.Filepath), file.Filecomment };
                                _fileListView.Items.Add(file.Filename).SubItems.AddRange(row);
                            }
                        }
                    }

                if (isSessionPL)
                {
                    if (spl.whizzyfilelist == null)
                    {
                        spl.playlistname = "New Playlist";
                        spl.whizzyfilelist = listinscope;
                        spl.playlistcount = listinscope.Count;
                        _playlistListView.Items.Add(spl.playlistname);
                    }
                    else
                    {
                        spl = funcs.addListToExistingPlaylist(spl, listinscope);
                    }
                }
            }
        }

        private void _playlistListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _fileListView.Items.Clear();
            if (_playlistListView.SelectedItems.Count != 0)
            {
                Playlist mPlaylist = allplaylists.Find(item => item.playlistname == _playlistListView.SelectedItems[0].Text);
                if (mPlaylist != null && mPlaylist.whizzyfilelist != null)
                {
                    foreach (Whizzyfile wfl in mPlaylist.whizzyfilelist)
                    {
                        string[] row = { wfl.Filepath, wfl.Filetype, wfl.Filecomment };
                        _fileListView.Items.Add(wfl.Filename).SubItems.AddRange(row);
                    }
                }
                _playlistName.Text = _playlistListView.SelectedItems[0].Text;
                selectedPL.playlistname = _playlistName.Text;
                isSessionPL = false;
            }
            listinscope.Clear();
        }

        private void _deletePlaylist_Click(object sender, EventArgs e)
        {
            if (_playlistListView.SelectedItems.Count != 0)
            {
                DialogResult dialog = MessageBox.Show("Are you sure you wish to delete this playlist?",
                    "Delete playlist?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    File.Delete(playlists + _playlistListView.SelectedItems[0].SubItems[0].Text + ".json");
                    _playlistListView.SelectedItems[0].Remove();
                    if (_fileListView.Items != null) { _fileListView.Items.Clear(); }
                }
            }
            else
            {
                MessageBox.Show("Please select a playlist to delete",
                    "Delete playlist");
            }
        }

        private void _addCat_Click(object sender, EventArgs e)
        {
            using (DialogBox dialogbox = new DialogBox())
            {
                if (dialogbox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (dialogbox.textboxdata != null || dialogbox.textboxdata != "" || dialogbox.textboxdata != " ")
                    {
                        bool catexist = false;
                        foreach (Category c in allcategories)
                        {
                            if (c.catname == dialogbox.textboxdata)
                            {
                                catexist = true;
                                break;
                            }
                        }
                        if (!catexist)
                        {
                            allcategories.Add(datafuncs.createCategory(dialogbox.textboxdata));
                            datafuncs.updateCategories(allcategories);
                            DirectoryInfo d = new DirectoryInfo(categories);
                            FileInfo f = new FileInfo(d.FullName + "Categories.json");
                            if (File.Exists(f.FullName))
                            {
                                allcategories.AddRange(datafuncs.loadCategories());
                            }
                        }
                        else
                        {
                            MessageBox.Show("That category already exists");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a category name");
                    }
                }
            }
            datafuncs.loadCategories();
        }

        private void _editCategories_Click(object sender, EventArgs e)
        {
            using (CategoryViewer editcatbox = new CategoryViewer())
            {
                if (editcatbox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                }
            }
        }
    }
}
