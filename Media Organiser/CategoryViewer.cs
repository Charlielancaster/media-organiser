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
    public partial class CategoryViewer : Form
    {
        static DataFuncs datafuncs = new DataFuncs();
        static Funcs funcs = new Funcs();
        protected List<Category> allcategories = new List<Category>();
        public List<Category> retlist = new List<Category>();
        public bool editingcats = true;

        public CategoryViewer()
        {
            InitializeComponent();
            _categoryList.LabelEdit = true;
            allcategories.AddRange(datafuncs.loadCategories());
            foreach (Category c in allcategories)
            {
                string[] row = { c.catID.ToString() };
                _categoryList.Items.Add(c.catname).SubItems.AddRange(row);
            }
        }

        private void _categoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_categoryList.SelectedItems.Count != 0)
            {
                _categoryList.SelectedItems[0].BeginEdit();
            }
        }

        private void _categoryList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            Category sCategory = new Category();
            sCategory = allcategories.Find(item => item.catID.ToString() == _categoryList.SelectedItems[0].SubItems[1].Text);
            sCategory.catname = _categoryList.SelectedItems[0].Text;
            datafuncs.updateCategories(allcategories);
        }

        private void _delCat_Click(object sender, EventArgs e)
        {
            if (_categoryList.SelectedItems.Count != 0)
            {
                Category mcategory = new Category();
                mcategory = allcategories.Find(item => item.catID.ToString() == _categoryList.SelectedItems[0].SubItems[1].Text);
                allcategories.Remove(mcategory);
                datafuncs.updateCategories(allcategories);
                allcategories = datafuncs.loadCategories();
                _categoryList.Items.Clear();
                foreach (Category c in allcategories)
                {
                    string[] row = { c.catID.ToString() };
                    _categoryList.Items.Add(c.catname).SubItems.AddRange(row);
                }
            }
        }

        public void _selectCat_Click(object sender, EventArgs e)
        {
            _categoryList.MultiSelect = editingcats == false ? true : false;
            if (editingcats)
            {
                MessageBox.Show("Click on a Category to edit them");
            }
            else
            {
                retlist.Clear();
                if (_categoryList.SelectedItems.Count != 0)
                {
                    for (int i = 0; i < _categoryList.SelectedItems.Count; i++)
                    {
                        retlist.Add(allcategories.Find(item => item.catID.ToString() == _categoryList.SelectedItems[i].SubItems[1].Text));
                    }
                }
            }
        }
    }
}
