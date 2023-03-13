namespace System_7
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            button2 = new Button();
            listView1 = new ListView();
            listView2 = new ListView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            delete = new ToolStripMenuItem();
            copy = new ToolStripMenuItem();
            paste = new ToolStripMenuItem();
            contextMenuStrip2 = new ContextMenuStrip(components);
            delete1 = new ToolStripMenuItem();
            copy1 = new ToolStripMenuItem();
            paste1 = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(6, 383);
            button1.Name = "button1";
            button1.Size = new Size(390, 33);
            button1.TabIndex = 0;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button_Click;
            // 
            // button2
            // 
            button2.Location = new Point(402, 383);
            button2.Name = "button2";
            button2.Size = new Size(392, 33);
            button2.TabIndex = 1;
            button2.Text = "Back";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(6, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(390, 365);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.DoubleClick += listView_DoubleClick;
            listView1.MouseDown += listView_MouseDown;
            // 
            // listView2
            // 
            listView2.Location = new Point(402, 12);
            listView2.Name = "listView2";
            listView2.Size = new Size(392, 365);
            listView2.TabIndex = 3;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.DoubleClick += listView_DoubleClick;
            listView2.MouseDown += listView_MouseDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { delete, copy, paste });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RenderMode = ToolStripRenderMode.System;
            contextMenuStrip1.Size = new Size(118, 70);
            // 
            // delete
            // 
            delete.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            delete.Name = "delete";
            delete.Size = new Size(117, 22);
            delete.Text = "Delete";
            delete.Click += ContextMenu_Click;
            // 
            // copy
            // 
            copy.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            copy.Name = "copy";
            copy.Size = new Size(117, 22);
            copy.Text = "Copy";
            copy.Click += ContextMenu_Click;
            // 
            // paste
            // 
            paste.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            paste.Name = "paste";
            paste.Size = new Size(117, 22);
            paste.Text = "Paste";
            paste.Click += ContextMenu_Click;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { delete1, copy1, paste1 });
            contextMenuStrip2.Name = "contextMenuStrip1";
            contextMenuStrip2.RenderMode = ToolStripRenderMode.System;
            contextMenuStrip2.Size = new Size(181, 92);
            // 
            // toolStripMenuItem1
            // 
            delete1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            delete1.Name = "toolStripMenuItem1";
            delete1.Size = new Size(180, 22);
            delete1.Text = "Delete";
            delete1.Click += ContextMenu_Click;
            // 
            // toolStripMenuItem2
            // 
            copy1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            copy1.Name = "toolStripMenuItem2";
            copy1.Size = new Size(180, 22);
            copy1.Text = "Copy";
            copy1.Click += ContextMenu_Click;
            // 
            // toolStripMenuItem3
            // 
            paste1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            paste1.Name = "toolStripMenuItem3";
            paste1.Size = new Size(180, 22);
            paste1.Text = "Paste";
            paste1.Click += ContextMenu_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 417);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            contextMenuStrip1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private ListView listView1;
        private ListView listView2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem delete;
        private ToolStripMenuItem copy;
        private ToolStripMenuItem paste;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem delete1;
        private ToolStripMenuItem copy1;
        private ToolStripMenuItem paste1;
    }
}