
namespace Assignment1
{
    partial class addPersonForm
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
            this.personRelationship = new System.Windows.Forms.RichTextBox();
            this.personName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addPersonButton = new System.Windows.Forms.Button();
            this.personPicturebox = new System.Windows.Forms.PictureBox();
            this.personListbox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.personPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add a person";
            // 
            // personRelationship
            // 
            this.personRelationship.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personRelationship.Location = new System.Drawing.Point(12, 142);
            this.personRelationship.Name = "personRelationship";
            this.personRelationship.Size = new System.Drawing.Size(301, 115);
            this.personRelationship.TabIndex = 1;
            this.personRelationship.Text = "";
            // 
            // personName
            // 
            this.personName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personName.Location = new System.Drawing.Point(12, 72);
            this.personName.Name = "personName";
            this.personName.Size = new System.Drawing.Size(301, 29);
            this.personName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Relationship";
            // 
            // addPersonButton
            // 
            this.addPersonButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPersonButton.Location = new System.Drawing.Point(261, 275);
            this.addPersonButton.Name = "addPersonButton";
            this.addPersonButton.Size = new System.Drawing.Size(129, 34);
            this.addPersonButton.TabIndex = 2;
            this.addPersonButton.Text = "add";
            this.addPersonButton.UseVisualStyleBackColor = true;
            this.addPersonButton.Click += new System.EventHandler(this.addPersonButton_Click);
            // 
            // personPicturebox
            // 
            this.personPicturebox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.personPicturebox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.personPicturebox.InitialImage = null;
            this.personPicturebox.Location = new System.Drawing.Point(342, 45);
            this.personPicturebox.Name = "personPicturebox";
            this.personPicturebox.Size = new System.Drawing.Size(284, 212);
            this.personPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.personPicturebox.TabIndex = 7;
            this.personPicturebox.TabStop = false;
            this.personPicturebox.Click += new System.EventHandler(this.personPicturebox_Click);
            // 
            // personListbox
            // 
            this.personListbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personListbox.FormattingEnabled = true;
            this.personListbox.ItemHeight = 24;
            this.personListbox.Location = new System.Drawing.Point(12, 324);
            this.personListbox.Name = "personListbox";
            this.personListbox.Size = new System.Drawing.Size(615, 148);
            this.personListbox.TabIndex = 3;
            this.personListbox.SelectedIndexChanged += new System.EventHandler(this.personListbox_SelectedIndexChanged);
            // 
            // addPersonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 479);
            this.Controls.Add(this.personListbox);
            this.Controls.Add(this.personPicturebox);
            this.Controls.Add(this.addPersonButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.personName);
            this.Controls.Add(this.personRelationship);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "addPersonForm";
            this.Text = "addPersonForm";
            ((System.ComponentModel.ISupportInitialize)(this.personPicturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox personRelationship;
        private System.Windows.Forms.TextBox personName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addPersonButton;
        private System.Windows.Forms.PictureBox personPicturebox;
        private System.Windows.Forms.ListBox personListbox;
    }
}