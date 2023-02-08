using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.ListViewItem;

namespace BookManagement
{
    public class ListViewCombo
    {
        ListView mListview;
        ComboBox mComboBox;
        int mBindingColum = 0;
        ListViewSubItem mSelectedSubItem;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listView">基础控件</param>
        /// <param name="comboBox">绑定控件</param>
        /// <param name="bindingColum">绑定的列</param>
        public ListViewCombo(
            ListView listView,
            ComboBox comboBox,
            int bindingColum
            )
        {
            mListview = listView;
            mComboBox = comboBox;
            mBindingColum = bindingColum;
            BindEvent();
        }
        public void Lacation(int x, int y)
        {
            // 选中的行
            ListViewItem item = mListview.GetItemAt(x, y);
            if (item == null)
            {
                return;
            }
            // 选中的行的子项
            mSelectedSubItem = item.GetSubItemAt(x, y);
            if (mSelectedSubItem == null)
            {
                return;
            }
            // 选中的子项所在的列
            int clickedColum = item.SubItems.IndexOf(mSelectedSubItem);
            if (clickedColum != mBindingColum)
            {
                return;
            }
            int padding = 2;
            Rectangle rect = mSelectedSubItem.Bounds;
            rect.X += mListview.Left + padding;
            rect.Y += mListview.Top + padding;
            rect.Width = mListview.Columns[clickedColum].Width + padding;

            mComboBox.Bounds = rect;
            mComboBox.Text = mSelectedSubItem.Text;
            mComboBox.Visible = true;
            mComboBox.BringToFront();
            mComboBox.Focus();
        }

        private void BindEvent()
        {
            mComboBox.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);
            mComboBox.Leave += new EventHandler(comboBox_Leave);
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSelectedSubItem.Text = mComboBox.Text;
            mComboBox.Visible = false;
        }

        private void comboBox_Leave(object sender, EventArgs e)
        {
            mSelectedSubItem.Text = mComboBox.Text;
            mComboBox.Visible = false;
        }
    }
}
