﻿using Newtonsoft.Json;
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

        private void _playlistListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _fileListView.Items.Clear();
            if (_playlistListView.SelectedItems.Count != 0)
            {
                Playlist mPlaylist = allplaylists.Find(item => item.playlistname == _playlistListView.SelectedItems[0].Text);
                funcs.populateListView(_fileListView, mPlaylist);
                _playlistName.Text = _playlistListView.SelectedItems[0].Text;
                selectedPL = mPlaylist;
                isSessionPL = false;
            }
            listinscope.Clear();
        }

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
                dialogbox.textboxdata = "";
                if (dialogbox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    spl.playlistname = dialogbox.textboxdata;
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
                        if (listinscope.Count != 0)
                        {
                            int count = 0;
                            if (item.Filepath == listinscope[count].Filepath)
                            {
                                listinscope.RemoveAt(count);
                            }
                            count++;
                        }
                    }
                    funcs.addListToExistingPlaylist(selectedPL, listinscope);
                }
                else
                {
                    funcs.addListToExistingPlaylist(selectedPL, listinscope);
                }

                datafuncs.savePlaylist(selectedPL, _playlistListView.SelectedItems[0].Text);
                allplaylists.Add(selectedPL);
            }
            else
            {
                using (DialogBox dialogbox = new DialogBox())
                {
                    dialogbox.textboxdata = "";
                    if (dialogbox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        spl.playlistname = dialogbox.textboxdata;
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
                    string listcategories = "";
                    if (file.Filecomment == null) { file.Filecomment = " "; }
                    if (file.FileGenres != null)
                    {
                        int count = 1;
                        foreach (Category c in file.FileGenres)
                        {
                            listcategories += count < file.FileGenres.Count ? c.catname + ", " : c.catname;
                            count++;
                        }
                    }
                    if (_fileListView.Items.Count == 0)
                    {
                        string[] row = { file.Filepath, Path.GetExtension(file.Filepath), file.Filecomment, listcategories, file.imagepath };
                        _fileListView.Items.Add(file.Filename).SubItems.AddRange(row);
                    }
                    else
                    {
                        if (!_fileListView.Items.ToString().Contains(file.Filename))
                        {
                            string[] row = { file.Filepath, Path.GetExtension(file.Filepath), file.Filecomment, listcategories, file.imagepath };
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
                else
                {
                    selectedPL = funcs.addListToExistingPlaylist(selectedPL, listinscope);
                }
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

        private void _commentEdit_Click(object sender, EventArgs e)
        {
            if (_fileListView.SelectedItems.Count != 0)
            {
                Whizzyfile sfile = selectedPL.whizzyfilelist.Find(item => item.Filepath == _fileListView.SelectedItems[0].SubItems[1].Text);
                using (DialogBox dialogbox = new DialogBox())
                {
                    dialogbox.boxTitle = "Edit Comment";
                    dialogbox.labelText = "Add or edit your comment here";
                    if (sfile.Filecomment != null)
                    {
                        dialogbox.textboxdata = null;
                        dialogbox.textboxdata = sfile.Filecomment;
                    }
                    if (dialogbox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (!isSessionPL)
                        {
                            sfile.Filecomment = dialogbox.textboxdata;
                            datafuncs.savePlaylist(selectedPL, selectedPL.playlistname);
                            _fileListView.Items.Clear();
                            funcs.populateListView(_fileListView, selectedPL);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a file edit",
                    "Select file");
            }
        }

        private void _assignCategories_Click(object sender, EventArgs e)
        {
            if (_fileListView.SelectedItems.Count != 0)
            {
                using (CategoryViewer editcatbox = new CategoryViewer())
                {
                    editcatbox.editingcats = false;
                    if (editcatbox.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                    {
                        Whizzyfile sfile = selectedPL.whizzyfilelist.Find(item => item.Filepath == _fileListView.SelectedItems[0].SubItems[1].Text);
                        foreach (Category g in sfile.FileGenres)
                        {
                            if (sfile.FileGenres.Any(item => item.catname == g.catname))
                            {
                                Category dfile = new Category();
                                dfile = sfile.FileGenres.Find(item => item.catname == g.catname);
                                editcatbox.retlist.Remove(dfile);
                            }
                        }
                        sfile.FileGenres.AddRange(editcatbox.retlist);
                    }
                }
                funcs.populateListView(_fileListView, selectedPL);
            }
            else
            {
                MessageBox.Show("Please select a file to assign Categories to");
            }
        }

        private void _assignImage_Click(object sender, EventArgs e)
        {
            if (_fileListView.SelectedItems.Count != 0)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Please select image to add.";
                openFileDialog.Filter = "Media files |*.jpg; *.jpeg; *.png; *.svg; *.bmp;";

                if (_fileListView.SelectedItems.Count == 1)
                {
                    Whizzyfile sfile = selectedPL.whizzyfilelist.Find(item => item.Filepath == _fileListView.SelectedItems[0].SubItems[1].Text);

                    if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        int numFiles = openFileDialog.FileNames.Length;

                        for (int i = 0; i < numFiles; i++)
                        {
                            sfile.imagepath = openFileDialog.FileName;
                        }

                        datafuncs.savePlaylist(selectedPL, selectedPL.playlistname);
                        _fileListView.Items.Clear();
                        funcs.populateListView(_fileListView, selectedPL);
                    }
                } else
                {
                    List<Whizzyfile> selectlist = new List<Whizzyfile>();
                    foreach (Whizzyfile f in selectedPL)
                    {
                        for (int i = 0; i < _fileListView.SelectedItems.Count; i++)
                        {
                            if (f.Filepath == _fileListView.SelectedItems[i].SubItems[1].Text)
                            {
                                f.imagepath = openFileDialog.FileName;
                            }
                        }
                    }
                    datafuncs.savePlaylist(selectedPL, selectedPL.playlistname);
                    _fileListView.Items.Clear();
                    funcs.populateListView(_fileListView, selectedPL);
                }
            }
            else
            {
                MessageBox.Show("Please select a file edit",
                    "Select file");
            }
        }

        private void _removeImg_Click(object sender, EventArgs e)
        {
            if (_fileListView.SelectedItems.Count != 0)
            {

                if (_fileListView.SelectedItems.Count == 1)
                {
                    Whizzyfile sfile = selectedPL.whizzyfilelist.Find(item => item.Filepath == _fileListView.SelectedItems[0].SubItems[1].Text);

                    sfile.imagepath = "";
                    datafuncs.savePlaylist(selectedPL, selectedPL.playlistname);
                    _fileListView.Items.Clear();
                    funcs.populateListView(_fileListView, selectedPL);
                }
                else
                {
                    List<Whizzyfile> selectlist = new List<Whizzyfile>();
                    foreach (Whizzyfile f in selectedPL)
                    {
                        for (int i = 0; i < _fileListView.SelectedItems.Count; i++)
                        {
                            if (f.Filepath == _fileListView.SelectedItems[i].SubItems[1].Text)
                            {
                                f.imagepath = "";
                            }
                        }
                    }
                    datafuncs.savePlaylist(selectedPL, selectedPL.playlistname);
                    _fileListView.Items.Clear();
                    funcs.populateListView(_fileListView, selectedPL);
                }
            }
            else
            {
                MessageBox.Show("Please select a file edit",
                    "Select file");
            }
        }
    }
}
