namespace AutoChromeProfile
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtProfilesFolder = new System.Windows.Forms.TextBox();
            this.btnSelectProfilesFolder = new System.Windows.Forms.Button();
            this.listViewNotRun = new System.Windows.Forms.ListView();
            this.columnHeaderProfile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewRun = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSelectProfile = new System.Windows.Forms.Button();
            this.btnRemoveProfile = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPostLink = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNAT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumberGroup = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTimeWaitPreview = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profile Folder:";
            // 
            // txtProfilesFolder
            // 
            this.txtProfilesFolder.Location = new System.Drawing.Point(117, 12);
            this.txtProfilesFolder.Name = "txtProfilesFolder";
            this.txtProfilesFolder.ReadOnly = true;
            this.txtProfilesFolder.Size = new System.Drawing.Size(321, 20);
            this.txtProfilesFolder.TabIndex = 1;
            // 
            // btnSelectProfilesFolder
            // 
            this.btnSelectProfilesFolder.Location = new System.Drawing.Point(444, 11);
            this.btnSelectProfilesFolder.Name = "btnSelectProfilesFolder";
            this.btnSelectProfilesFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelectProfilesFolder.TabIndex = 2;
            this.btnSelectProfilesFolder.Text = "Select";
            this.btnSelectProfilesFolder.UseVisualStyleBackColor = true;
            this.btnSelectProfilesFolder.Click += new System.EventHandler(this.btnSelectProfilesFolder_Click);
            // 
            // listViewNotRun
            // 
            this.listViewNotRun.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderProfile});
            this.listViewNotRun.HideSelection = false;
            this.listViewNotRun.Location = new System.Drawing.Point(12, 38);
            this.listViewNotRun.Name = "listViewNotRun";
            this.listViewNotRun.Size = new System.Drawing.Size(111, 287);
            this.listViewNotRun.TabIndex = 3;
            this.listViewNotRun.UseCompatibleStateImageBehavior = false;
            this.listViewNotRun.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderProfile
            // 
            this.columnHeaderProfile.Text = "Profile";
            this.columnHeaderProfile.Width = 100;
            // 
            // listViewRun
            // 
            this.listViewRun.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewRun.HideSelection = false;
            this.listViewRun.Location = new System.Drawing.Point(210, 38);
            this.listViewRun.Name = "listViewRun";
            this.listViewRun.Size = new System.Drawing.Size(228, 287);
            this.listViewRun.TabIndex = 3;
            this.listViewRun.UseCompatibleStateImageBehavior = false;
            this.listViewRun.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Profile";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 100;
            // 
            // btnSelectProfile
            // 
            this.btnSelectProfile.Location = new System.Drawing.Point(129, 107);
            this.btnSelectProfile.Name = "btnSelectProfile";
            this.btnSelectProfile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectProfile.TabIndex = 2;
            this.btnSelectProfile.Text = ">>>";
            this.btnSelectProfile.UseVisualStyleBackColor = true;
            this.btnSelectProfile.Click += new System.EventHandler(this.btnSelectProfile_Click);
            // 
            // btnRemoveProfile
            // 
            this.btnRemoveProfile.Location = new System.Drawing.Point(129, 144);
            this.btnRemoveProfile.Name = "btnRemoveProfile";
            this.btnRemoveProfile.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveProfile.TabIndex = 2;
            this.btnRemoveProfile.Text = "<<<";
            this.btnRemoveProfile.UseVisualStyleBackColor = true;
            this.btnRemoveProfile.Click += new System.EventHandler(this.btnRemoveProfile_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(444, 40);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 395);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(100, 331);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(262, 331);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAll.TabIndex = 2;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Post link:";
            // 
            // txtPostLink
            // 
            this.txtPostLink.Location = new System.Drawing.Point(65, 371);
            this.txtPostLink.Name = "txtPostLink";
            this.txtPostLink.Size = new System.Drawing.Size(188, 20);
            this.txtPostLink.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 375);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Number at time:";
            // 
            // txtNAT
            // 
            this.txtNAT.Location = new System.Drawing.Point(346, 371);
            this.txtNAT.Name = "txtNAT";
            this.txtNAT.Size = new System.Drawing.Size(92, 20);
            this.txtNAT.TabIndex = 1;
            this.txtNAT.Text = "5";
            this.txtNAT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimeWaitPreview_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Number of group select";
            // 
            // txtNumberGroup
            // 
            this.txtNumberGroup.Location = new System.Drawing.Point(382, 415);
            this.txtNumberGroup.Name = "txtNumberGroup";
            this.txtNumberGroup.Size = new System.Drawing.Size(56, 20);
            this.txtNumberGroup.TabIndex = 1;
            this.txtNumberGroup.Text = "5";
            this.txtNumberGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimeWaitPreview_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 419);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Time wait preview: (second)";
            // 
            // txtTimeWaitPreview
            // 
            this.txtTimeWaitPreview.Location = new System.Drawing.Point(157, 415);
            this.txtTimeWaitPreview.Name = "txtTimeWaitPreview";
            this.txtTimeWaitPreview.Size = new System.Drawing.Size(96, 20);
            this.txtTimeWaitPreview.TabIndex = 5;
            this.txtTimeWaitPreview.Text = "30";
            this.txtTimeWaitPreview.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTimeWaitPreview.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimeWaitPreview_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 450);
            this.Controls.Add(this.txtTimeWaitPreview);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listViewRun);
            this.Controls.Add(this.listViewNotRun);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnRemoveProfile);
            this.Controls.Add(this.btnSelectProfile);
            this.Controls.Add(this.btnSelectProfilesFolder);
            this.Controls.Add(this.txtNumberGroup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNAT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPostLink);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProfilesFolder);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoChromeProfile";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProfilesFolder;
        private System.Windows.Forms.Button btnSelectProfilesFolder;
        private System.Windows.Forms.ListView listViewNotRun;
        private System.Windows.Forms.ListView listViewRun;
        private System.Windows.Forms.Button btnSelectProfile;
        private System.Windows.Forms.Button btnRemoveProfile;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPostLink;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNAT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumberGroup;
        private System.Windows.Forms.ColumnHeader columnHeaderProfile;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTimeWaitPreview;
    }
}

