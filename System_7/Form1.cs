using System.Diagnostics;
using System.Text;

namespace System_7;
public partial class Form1 : Form
{
    private string? path1 = null, path2 = null, copyFileName = string.Empty, fileName;

    public Form1()
    {
        InitializeComponent();

        listView1.View = View.List;
        listView2.View = View.List;
        listView1.MultiSelect = false;
        listView2.MultiSelect = false;

        DriveInfo[] allDrives = DriveInfo.GetDrives();

        foreach (DriveInfo drive in allDrives)
            listView1.Items.Add(drive.Name);

        foreach (DriveInfo drive in allDrives)
            listView2.Items.Add(drive.Name);

        paste.Enabled = false;
        paste1.Enabled = false;
    }

    private void listView_MouseDown(object sender, MouseEventArgs e)
    {
        ListView? list = sender as ListView;

        if (e?.Button == MouseButtons.Right)
        {
            if (list == listView1)
            {
                ListViewItem clickedItem = listView1.GetItemAt(e.X, e.Y);
                if (clickedItem != null)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                    var f = (File.GetAttributes(clickedItem!.Text) & FileAttributes.System);
                    if (f != 0)
                    {
                        delete.Enabled = false;
                        copy.Enabled = false;
                    }
                    else
                    {
                        delete.Enabled = true;
                        copy.Enabled = true;
                    }
                }
            }
            else if (list == listView2)
            {
                ListViewItem clickedItem = listView2.GetItemAt(e.X, e.Y);
                if (clickedItem != null)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                    var f = (File.GetAttributes(clickedItem!.Text) & FileAttributes.System);
                    if (f != 0)
                        delete.Enabled = false;
                    else
                        delete.Enabled = true;
                }
            }
        }
    }

    private void button_Click(object sender, EventArgs e)
    {
        Button? btn = sender as Button;
        if (btn == button1)
        {
            if (path1 != null)
            {
                DirectoryInfo? parentPath = Directory.GetParent(path1!);
                if (parentPath != null)
                {
                    listView1.Items.Clear();
                    path1 = parentPath.FullName;

                    foreach (var item in Directory.GetFileSystemEntries(parentPath.FullName))
                        listView1.Items.Add(item);
                }
                else
                {
                    DriveInfo[] allDrives = DriveInfo.GetDrives();

                    listView1.Items.Clear();
                    foreach (DriveInfo drive in allDrives)
                        listView1.Items.Add(drive.Name);
                }
            }
        }
        else if (btn == button2)
        {
            if (path2 != null)
            {
                DirectoryInfo? parentPath = Directory.GetParent(path2!);
                if (parentPath != null)
                {
                    listView2.Items.Clear();
                    path2 = parentPath.FullName;

                    foreach (var item in Directory.GetFileSystemEntries(parentPath.FullName))
                        listView2.Items.Add(item);
                }
                else
                {
                    DriveInfo[] allDrives = DriveInfo.GetDrives();

                    listView2.Items.Clear();
                    foreach (DriveInfo drive in allDrives)
                        listView2.Items.Add(drive.Name);
                }
            }
        }
    }

    private void ContextMenu_Click(object sender, EventArgs e)
    {
        ToolStripMenuItem? btn = sender as ToolStripMenuItem;

        if (btn == delete)
        {
            if (path1 is not null)
            {
                var f = (File.GetAttributes(listView1.SelectedItems[0].Text) & FileAttributes.System);
                if (f == 0)
                {
                    File.Delete(listView1.SelectedItems[0].Text);

                    listView1.Items.Clear();

                    foreach (var item in Directory.GetFileSystemEntries(path1!))
                        listView1.Items.Add(item);
                }
                else
                    MessageBox.Show("It is system file you doen't delete it..(");
            }
        }
        else if (btn == delete1)
        {
            if (path2 is not null)
            {
                File.Delete(listView2.SelectedItems[0].Text);

                listView1.Items.Clear();

                foreach (var item in Directory.GetFileSystemEntries(path2!))
                    listView1.Items.Add(item);
            }
        }
        else if (btn == copy)
        {
            var f = (File.GetAttributes(listView1.SelectedItems[0].Text) & FileAttributes.System);
            if (path1 != null && listView1.SelectedItems[0].Text != null && f == 0)
            {
                fileName = listView1.SelectedItems[0].Text;
                if (fileName != null)
                {
                    copy.Enabled = false;
                    paste.Enabled = true;
                }
                else
                {
                    copyFileName = string.Empty;
                    copy.Enabled = true;
                    paste.Enabled = false;
                }
            }
            else
                copy.Enabled = false;
        }
    }

    //    if (path1 is not null && copyFileName != string.Empty && copyFileName != null)
    //    {
    //      copy.Enabled = true;
    //      File.Copy(listView1.SelectedItems[0].Text, Path.Combine(path1, copyFileName), true);
    //      copyFileName = string.Empty;
    //    }
    //    else
    //      copy.Enabled = false;

    private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        ListView? list = sender as ListView;
        if (e.Button == MouseButtons.Left)
        {
            if (list == listView1)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    path1 = listView1.SelectedItems[0].Text;
                    if (Path.HasExtension(listView1.SelectedItems[0].Text))
                        Process.Start("explorer.exe", listView1.SelectedItems[0].Text);
                    else
                    {
                        listView1.Items.Clear();
                        string[] files = Directory.GetFileSystemEntries(path1);
                        foreach (var item in files)
                            listView1.Items.Add(item);
                    }
                }
            }
            else if (list == listView2)
            {
                if (listView2.SelectedItems.Count > 0)
                {
                    path2 = listView2.SelectedItems[0].Text;
                    if (Path.HasExtension(listView2.SelectedItems[0].Text))
                        Process.Start("explorer.exe", listView2.SelectedItems[0].Text);
                    else
                    {
                        listView2.Items.Clear();
                        string[] files = Directory.GetFileSystemEntries(path2);
                        foreach (var item in files)
                            listView2.Items.Add(item);
                    }
                }
            }
        }
    }
}

