namespace Chocola
{
    partial class ChocolaMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChocolaMainForm));
            this.spelBord = new System.Windows.Forms.PictureBox();
            this.startEnkel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.supersmal = new System.Windows.Forms.RadioButton();
            this.smal = new System.Windows.Forms.RadioButton();
            this.square = new System.Windows.Forms.RadioButton();
            this.full = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.speler1 = new System.Windows.Forms.ComboBox();
            this.speler2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.spelBord)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spelBord
            // 
            this.spelBord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spelBord.Location = new System.Drawing.Point(6, 12);
            this.spelBord.Name = "spelBord";
            this.spelBord.Size = new System.Drawing.Size(581, 226);
            this.spelBord.TabIndex = 0;
            this.spelBord.TabStop = false;
            // 
            // startEnkel
            // 
            this.startEnkel.Location = new System.Drawing.Point(6, 197);
            this.startEnkel.Name = "startEnkel";
            this.startEnkel.Size = new System.Drawing.Size(75, 23);
            this.startEnkel.TabIndex = 1;
            this.startEnkel.Text = "Start";
            this.startEnkel.UseVisualStyleBackColor = true;
            this.startEnkel.Click += new System.EventHandler(this.startEnkel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.supersmal);
            this.groupBox1.Controls.Add(this.smal);
            this.groupBox1.Controls.Add(this.square);
            this.groupBox1.Controls.Add(this.startEnkel);
            this.groupBox1.Controls.Add(this.full);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.speler1);
            this.groupBox1.Controls.Add(this.speler2);
            this.groupBox1.Location = new System.Drawing.Point(593, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 233);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enkel Spel";
            // 
            // supersmal
            // 
            this.supersmal.AutoSize = true;
            this.supersmal.Location = new System.Drawing.Point(6, 174);
            this.supersmal.Name = "supersmal";
            this.supersmal.Size = new System.Drawing.Size(112, 17);
            this.supersmal.TabIndex = 10;
            this.supersmal.Text = "Supersmal (2 x 20)";
            this.supersmal.UseVisualStyleBackColor = true;
            // 
            // smal
            // 
            this.smal.AutoSize = true;
            this.smal.Location = new System.Drawing.Point(6, 150);
            this.smal.Name = "smal";
            this.smal.Size = new System.Drawing.Size(86, 17);
            this.smal.TabIndex = 9;
            this.smal.Text = "Smal (3 x 20)";
            this.smal.UseVisualStyleBackColor = true;
            // 
            // square
            // 
            this.square.AutoSize = true;
            this.square.Location = new System.Drawing.Point(6, 127);
            this.square.Name = "square";
            this.square.Size = new System.Drawing.Size(96, 17);
            this.square.TabIndex = 8;
            this.square.Text = "Vierkant (5 x 5)";
            this.square.UseVisualStyleBackColor = true;
            // 
            // full
            // 
            this.full.AutoSize = true;
            this.full.Checked = true;
            this.full.Location = new System.Drawing.Point(6, 103);
            this.full.Name = "full";
            this.full.Size = new System.Drawing.Size(123, 17);
            this.full.TabIndex = 7;
            this.full.TabStop = true;
            this.full.Text = "Volledig veld (5 x 20)";
            this.full.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Speler 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Speler 1";
            // 
            // speler1
            // 
            this.speler1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speler1.FormattingEnabled = true;
            this.speler1.Location = new System.Drawing.Point(6, 32);
            this.speler1.Name = "speler1";
            this.speler1.Size = new System.Drawing.Size(121, 21);
            this.speler1.TabIndex = 3;
            // 
            // speler2
            // 
            this.speler2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speler2.FormattingEnabled = true;
            this.speler2.Location = new System.Drawing.Point(6, 76);
            this.speler2.Name = "speler2";
            this.speler2.Size = new System.Drawing.Size(121, 21);
            this.speler2.TabIndex = 4;
            // 
            // ChocolaMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 245);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.spelBord);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChocolaMainForm";
            this.Text = "Chocola!!";
            this.Load += new System.EventHandler(this.ChocolaMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spelBord)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox spelBord;
        private System.Windows.Forms.Button startEnkel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox speler1;
        private System.Windows.Forms.ComboBox speler2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton supersmal;
        private System.Windows.Forms.RadioButton smal;
        private System.Windows.Forms.RadioButton square;
        private System.Windows.Forms.RadioButton full;
    }
}

