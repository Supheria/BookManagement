using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    public static class ResizeForm
    {
        public static void SetTag(Control parent)
        {
            parent.Tag = parent.Width + " " + parent.Height + " " + parent.Left + " " + parent.Top + " " + parent.Font.Size;
            foreach (Control child in parent.Controls)
            {
                child.Tag = child.Width + " " + child.Height + " " + child.Left + " " + child.Top + " " + child.Font.Size;
                if (child.Controls.Count > 0)
                {
                    SetTag(child);
                }
            }
        }
        public static void ResizeControls(float newWidth, float newHeight, Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child.Tag != null)
                {
                    string[] tagContent = child.Tag.ToString().Split(" ");
                    child.Width = (int)(float.Parse(tagContent[0]) * newWidth);
                    child.Height = (int)(float.Parse(tagContent[1]) * newHeight);
                    child.Left = (int)(float.Parse(tagContent[2]) * newWidth);
                    child.Top = (int)(float.Parse(tagContent[3]) * newHeight);
                    var fontSize = float.Parse(tagContent[4]) * newHeight;
                    child.Font = new Font(child.Font.Name, fontSize, child.Font.Style, child.Font.Unit);
                    if (child.Controls.Count > 0)
                    {
                        ResizeControls(newWidth, newHeight, child);
                    }
                }
            }
        }
    }
}
