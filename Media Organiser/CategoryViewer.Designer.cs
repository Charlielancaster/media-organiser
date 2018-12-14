namespace Media_Organiser
{
    partial class CategoryViewer
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
            this._selectCat = new System.Windows.Forms.Button();
            this._delCat = new System.Windows.Forms.Button();
            this._categoryList = new System.Windows.Forms.ListView();
            this._category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._catID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // _selectCat
            // 
            this._selectCat.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this._selectCat.Location = new System.Drawing.Point(12, 415);
            this._selectCat.Name = "_selectCat";
            this._selectCat.Size = new System.Drawing.Size(138, 23);
            this._selectCat.TabIndex = 21;
            this._selectCat.Text = "Select Category";
            this._selectCat.UseVisualStyleBackColor = true;
            this._selectCat.Click += new System.EventHandler(this._selectCat_Click);
            // 
            // _delCat
            // 
            this._delCat.Location = new System.Drawing.Point(234, 415);
            this._delCat.Name = "_delCat";
            this._delCat.Size = new System.Drawing.Size(138, 23);
            this._delCat.TabIndex = 22;
            this._delCat.Text = "Delete Category";
            this._delCat.UseVisualStyleBackColor = true;
            this._delCat.Click += new System.EventHandler(this._delCat_Click);
            // 
            // _categoryList
            // 
            this._categoryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._category,
            this._catID});
            this._categoryList.Dock = System.Windows.Forms.DockStyle.Top;
            this._categoryList.Location = new System.Drawing.Point(0, 0);
            this._categoryList.Name = "_categoryList";
            this._categoryList.Size = new System.Drawing.Size(384, 353);
            this._categoryList.TabIndex = 23;
            this._categoryList.UseCompatibleStateImageBehavior = false;
            this._categoryList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this._categoryList_AfterLabelEdit);
            this._categoryList.SelectedIndexChanged += new System.EventHandler(this._categoryList_SelectedIndexChanged);
            // 
            // _category
            // 
            this._category.Text = "Category";
            // 
            // _catID
            // 
            this._catID.Text = "";
            this._catID.Width = 0;
            // 
            // CategoryViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(384, 450);
            this.Controls.Add(this._categoryList);
            this.Controls.Add(this._delCat);
            this.Controls.Add(this._selectCat);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoryViewer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CategoryViewer";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _selectCat;
        private System.Windows.Forms.Button _delCat;
        private System.Windows.Forms.ListView _categoryList;
        private System.Windows.Forms.ColumnHeader _category;
        private System.Windows.Forms.ColumnHeader _catID;
    }
}