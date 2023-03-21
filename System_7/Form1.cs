using System.Diagnostics;

namespace System_7;
public partial class Form1 : Form
{
    private string? path1 = null, path2 = null, copyFileName = string.Empty, fileName;
    bool flag1 = true, flag2 = true;
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
                        if (copyFileName == clickedItem.Text)
                        {
                            copy.Enabled = false;
                            paste.Enabled = true;
                        }
                        else
                        {
                            copy.Enabled = true;
                            paste.Enabled = false;
                        }
                    }
                }
                else
                {
                    delete.Enabled = false;
                    copy.Enabled = false;
                    contextMenuStrip1.Show(Cursor.Position);
                    if (copyFileName != string.Empty)
                    {
                        paste.Enabled = true;
                    }
                    else
                    {
                        paste.Enabled = false;
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
                    
                    foreach (var item in Directory.GetFileSystemEntries(parentPath.FullName))
                        listView1.Items.Add(item);

                    if (flag1)
                        path1 = parentPath.FullName;
                    else
                        flag1 = true;
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
                    
                    foreach (var item in Directory.GetFileSystemEntries(parentPath.FullName))
                        listView2.Items.Add(item);
                    
                    if (flag2)
                        path2 = parentPath.FullName;
                    else
                        flag2 = true;
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
            copyFileName = listView1.SelectedItems[0].Text;
        }
        else if (btn == paste)
        {
            if (copyFileName != null && path1 != null)
            {
                try
                {
                    fileName = Path.GetFileName(copyFileName)!;
                    File.Copy(copyFileName, Path.Combine(path1, fileName), true);

                    paste.Enabled = false;
                    copyFileName = string.Empty;
                    copy.Enabled = true;
                    fileName = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                copyFileName = string.Empty;
                paste.Enabled = false;
                copy.Enabled = true;
                fileName = string.Empty;
            }
        }
    }

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
                    {
                        Process.Start("explorer.exe", listView1.SelectedItems[0].Text);
                        flag1 = false;
                    }
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
                    {
                        Process.Start("explorer.exe", listView2.SelectedItems[0].Text);
                        flag1 = false;
                    }
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

