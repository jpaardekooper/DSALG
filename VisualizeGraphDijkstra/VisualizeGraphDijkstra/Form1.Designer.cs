namespace VisualizeGraphDijkstra
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.graphone = new System.Windows.Forms.Button();
            this.graphtwo = new System.Windows.Forms.Button();
            this.graphthree = new System.Windows.Forms.Button();
            this.randomData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(0, 422);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(815, 226);
            this.textBox1.TabIndex = 0;
            // 
            // graphone
            // 
            this.graphone.Location = new System.Drawing.Point(646, 30);
            this.graphone.Name = "graphone";
            this.graphone.Size = new System.Drawing.Size(138, 23);
            this.graphone.TabIndex = 1;
            this.graphone.Text = "Show Graph 1";
            this.graphone.UseVisualStyleBackColor = true;
            this.graphone.Click += new System.EventHandler(this.button1_Click);
            // 
            // graphtwo
            // 
            this.graphtwo.Location = new System.Drawing.Point(646, 90);
            this.graphtwo.Name = "graphtwo";
            this.graphtwo.Size = new System.Drawing.Size(138, 23);
            this.graphtwo.TabIndex = 2;
            this.graphtwo.Text = "Show Graph 2";
            this.graphtwo.UseVisualStyleBackColor = true;
            this.graphtwo.Click += new System.EventHandler(this.graphtwo_Click);
            // 
            // graphthree
            // 
            this.graphthree.Location = new System.Drawing.Point(646, 149);
            this.graphthree.Name = "graphthree";
            this.graphthree.Size = new System.Drawing.Size(138, 23);
            this.graphthree.TabIndex = 3;
            this.graphthree.Text = "Show Graph 3";
            this.graphthree.UseVisualStyleBackColor = true;
            this.graphthree.Click += new System.EventHandler(this.graphthree_Click);
            // 
            // randomData
            // 
            this.randomData.Location = new System.Drawing.Point(646, 204);
            this.randomData.Name = "randomData";
            this.randomData.Size = new System.Drawing.Size(138, 23);
            this.randomData.TabIndex = 4;
            this.randomData.Text = "Show random graph";
            this.randomData.UseVisualStyleBackColor = true;
            this.randomData.Click += new System.EventHandler(this.randomData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 648);
            this.Controls.Add(this.randomData);
            this.Controls.Add(this.graphthree);
            this.Controls.Add(this.graphtwo);
            this.Controls.Add(this.graphone);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button graphone;
        private System.Windows.Forms.Button graphtwo;
        private System.Windows.Forms.Button graphthree;
        private System.Windows.Forms.Button randomData;
    }
}

