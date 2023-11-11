namespace APPingNew
{
    partial class MainForm
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
            this.btnExpand = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPrintPings = new System.Windows.Forms.RichTextBox();
            this.lblDo = new System.Windows.Forms.Label();
            this.lblOd = new System.Windows.Forms.Label();
            this.txtLastIPAddress = new System.Windows.Forms.TextBox();
            this.txtFirstIPAddress = new System.Windows.Forms.TextBox();
            this.btnPing = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExpand
            // 
            this.btnExpand.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpand.Location = new System.Drawing.Point(469, 12);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(23, 23);
            this.btnExpand.TabIndex = 16;
            this.btnExpand.Text = "±";
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(372, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPrintPings
            // 
            this.txtPrintPings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrintPings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrintPings.Location = new System.Drawing.Point(12, 43);
            this.txtPrintPings.MinimumSize = new System.Drawing.Size(356, 570);
            this.txtPrintPings.Name = "txtPrintPings";
            this.txtPrintPings.ReadOnly = true;
            this.txtPrintPings.Size = new System.Drawing.Size(480, 601);
            this.txtPrintPings.TabIndex = 14;
            this.txtPrintPings.Text = "";
            this.txtPrintPings.WordWrap = false;
            this.txtPrintPings.TextChanged += new System.EventHandler(this.txtPrintPings_TextChanged);
            // 
            // lblDo
            // 
            this.lblDo.AutoSize = true;
            this.lblDo.Location = new System.Drawing.Point(140, 17);
            this.lblDo.Name = "lblDo";
            this.lblDo.Size = new System.Drawing.Size(21, 13);
            this.lblDo.TabIndex = 13;
            this.lblDo.Text = "Do";
            // 
            // lblOd
            // 
            this.lblOd.AutoSize = true;
            this.lblOd.Location = new System.Drawing.Point(16, 17);
            this.lblOd.Name = "lblOd";
            this.lblOd.Size = new System.Drawing.Size(21, 13);
            this.lblOd.TabIndex = 12;
            this.lblOd.Text = "Od";
            // 
            // txtLastIPAddress
            // 
            this.txtLastIPAddress.Location = new System.Drawing.Point(167, 14);
            this.txtLastIPAddress.Name = "txtLastIPAddress";
            this.txtLastIPAddress.Size = new System.Drawing.Size(84, 20);
            this.txtLastIPAddress.TabIndex = 11;
            this.txtLastIPAddress.Text = "192.168.1.10";
            // 
            // txtFirstIPAddress
            // 
            this.txtFirstIPAddress.Location = new System.Drawing.Point(43, 14);
            this.txtFirstIPAddress.Name = "txtFirstIPAddress";
            this.txtFirstIPAddress.Size = new System.Drawing.Size(82, 20);
            this.txtFirstIPAddress.TabIndex = 10;
            this.txtFirstIPAddress.Text = "192.168.1.1";
            // 
            // btnPing
            // 
            this.btnPing.Location = new System.Drawing.Point(291, 12);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(75, 23);
            this.btnPing.TabIndex = 9;
            this.btnPing.Text = "Ping";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 656);
            this.Controls.Add(this.btnExpand);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPrintPings);
            this.Controls.Add(this.lblDo);
            this.Controls.Add(this.lblOd);
            this.Controls.Add(this.txtLastIPAddress);
            this.Controls.Add(this.txtFirstIPAddress);
            this.Controls.Add(this.btnPing);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(520, 695);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Access Point Ping";
            this.Load += new System.EventHandler(this.APPing_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RichTextBox txtPrintPings;
        private System.Windows.Forms.Label lblDo;
        private System.Windows.Forms.Label lblOd;
        private System.Windows.Forms.TextBox txtLastIPAddress;
        private System.Windows.Forms.TextBox txtFirstIPAddress;
        private System.Windows.Forms.Button btnPing;
    }
}

