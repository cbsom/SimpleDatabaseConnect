﻿namespace SimpleDatabaseConnect
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.tbError = new System.Windows.Forms.TextBox();
            this.rbOdbc = new System.Windows.Forms.RadioButton();
            this.rbSqlServer = new System.Windows.Forms.RadioButton();
            this.rbOleDb = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fastColoredTextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMessage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection String";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Location = new System.Drawing.Point(15, 313);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1370, 357);
            this.dataGridView1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.Image = global::SimpleDatabaseConnect.Properties.Resources.ic_menu_send;
            this.button1.Location = new System.Drawing.Point(1313, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 54);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbError
            // 
            this.tbError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbError.BackColor = System.Drawing.Color.Snow;
            this.tbError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbError.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbError.Location = new System.Drawing.Point(15, 313);
            this.tbError.Multiline = true;
            this.tbError.Name = "tbError";
            this.tbError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbError.Size = new System.Drawing.Size(1368, 357);
            this.tbError.TabIndex = 7;
            this.tbError.Visible = false;            
            // 
            // rbOdbc
            // 
            this.rbOdbc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbOdbc.AutoSize = true;
            this.rbOdbc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbOdbc.FlatAppearance.BorderSize = 4;
            this.rbOdbc.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green;
            this.rbOdbc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbOdbc.Location = new System.Drawing.Point(9, 8);
            this.rbOdbc.Name = "rbOdbc";
            this.rbOdbc.Size = new System.Drawing.Size(64, 22);
            this.rbOdbc.TabIndex = 0;
            this.rbOdbc.Text = "Odbc";
            this.rbOdbc.UseVisualStyleBackColor = true;
            // 
            // rbSqlServer
            // 
            this.rbSqlServer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbSqlServer.AutoSize = true;
            this.rbSqlServer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbSqlServer.FlatAppearance.BorderSize = 4;
            this.rbSqlServer.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green;
            this.rbSqlServer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbSqlServer.Location = new System.Drawing.Point(155, 7);
            this.rbSqlServer.Name = "rbSqlServer";
            this.rbSqlServer.Size = new System.Drawing.Size(105, 22);
            this.rbSqlServer.TabIndex = 6;
            this.rbSqlServer.TabStop = true;
            this.rbSqlServer.Text = "SQL Server";
            this.rbSqlServer.UseVisualStyleBackColor = true;
            // 
            // rbOleDb
            // 
            this.rbOleDb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbOleDb.AutoSize = true;
            this.rbOleDb.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbOleDb.FlatAppearance.BorderSize = 4;
            this.rbOleDb.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green;
            this.rbOleDb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbOleDb.Location = new System.Drawing.Point(79, 8);
            this.rbOleDb.Name = "rbOleDb";
            this.rbOleDb.Size = new System.Drawing.Size(70, 22);
            this.rbOleDb.TabIndex = 1;
            this.rbOleDb.Text = "OleDb";
            this.rbOleDb.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SimpleDatabaseConnect.Properties.Settings.Default, "conString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBox1.Location = new System.Drawing.Point(137, 38);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1167, 26);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = global::SimpleDatabaseConnect.Properties.Settings.Default.conString;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.rbSqlServer);
            this.panel1.Controls.Add(this.rbOdbc);
            this.panel1.Controls.Add(this.rbOleDb);
            this.panel1.Location = new System.Drawing.Point(137, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 34);
            this.panel1.TabIndex = 1;
            // 
            // fastColoredTextBox1
            // 
            this.fastColoredTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fastColoredTextBox1.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox1.AutoIndentCharsPatterns = "";
            this.fastColoredTextBox1.AutoScrollMinSize = new System.Drawing.Size(33, 20);
            this.fastColoredTextBox1.BackBrush = null;
            this.fastColoredTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fastColoredTextBox1.CharHeight = 20;
            this.fastColoredTextBox1.CharWidth = 11;
            this.fastColoredTextBox1.CommentPrefix = "--";
            this.fastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SimpleDatabaseConnect.Properties.Settings.Default, "SQL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox1.Font = new System.Drawing.Font("Courier New", 11F);
            this.fastColoredTextBox1.IsReplaceMode = false;
            this.fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.SQL;
            this.fastColoredTextBox1.LeftBracket = '(';
            this.fastColoredTextBox1.Location = new System.Drawing.Point(15, 79);
            this.fastColoredTextBox1.Name = "fastColoredTextBox1";
            this.fastColoredTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox1.RightBracket = ')';
            this.fastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox1.ServiceColors")));
            this.fastColoredTextBox1.Size = new System.Drawing.Size(1368, 227);
            this.fastColoredTextBox1.TabIndex = 0;
            this.fastColoredTextBox1.Text = global::SimpleDatabaseConnect.Properties.Settings.Default.SQL;
            this.fastColoredTextBox1.Zoom = 100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Connection Type ";
            // 
            // tbMessage
            // 
            this.tbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMessage.BackColor = System.Drawing.Color.Snow;
            this.tbMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMessage.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.tbMessage.Location = new System.Drawing.Point(15, 313);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMessage.Size = new System.Drawing.Size(1368, 357);
            this.tbMessage.TabIndex = 8;
            this.tbMessage.Visible = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 702);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.tbError);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fastColoredTextBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Database Conect";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbOleDb;
        private System.Windows.Forms.RadioButton rbSqlServer;
        private System.Windows.Forms.TextBox tbError;
        private System.Windows.Forms.RadioButton rbOdbc;
        private System.Windows.Forms.Panel panel1;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMessage;
    }
}

