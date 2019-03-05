namespace WCF.WindowsForms
{
    partial class Form
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
            this.buttonGetClients = new System.Windows.Forms.Button();
            this.panelButton = new System.Windows.Forms.Panel();
            this.buttonAsync = new System.Windows.Forms.Button();
            this.buttonGetItems = new System.Windows.Forms.Button();
            this.panelPresentation = new System.Windows.Forms.Panel();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.labelClient = new System.Windows.Forms.Label();
            this.panelButton.SuspendLayout();
            this.panelPresentation.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGetClients
            // 
            this.buttonGetClients.Location = new System.Drawing.Point(3, 6);
            this.buttonGetClients.Name = "buttonGetClients";
            this.buttonGetClients.Size = new System.Drawing.Size(92, 34);
            this.buttonGetClients.TabIndex = 0;
            this.buttonGetClients.Text = "Get clients";
            this.buttonGetClients.UseVisualStyleBackColor = true;
            this.buttonGetClients.Click += new System.EventHandler(this.buttonGetClients_Click);
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.labelClient);
            this.panelButton.Controls.Add(this.buttonAsync);
            this.panelButton.Controls.Add(this.buttonGetItems);
            this.panelButton.Controls.Add(this.buttonGetClients);
            this.panelButton.Location = new System.Drawing.Point(690, 9);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(98, 579);
            this.panelButton.TabIndex = 2;
            // 
            // buttonAsync
            // 
            this.buttonAsync.Location = new System.Drawing.Point(3, 86);
            this.buttonAsync.Name = "buttonAsync";
            this.buttonAsync.Size = new System.Drawing.Size(92, 34);
            this.buttonAsync.TabIndex = 3;
            this.buttonAsync.Text = "Get Async";
            this.buttonAsync.UseVisualStyleBackColor = true;
            this.buttonAsync.Click += new System.EventHandler(this.buttonAsync_ClickAsync);
            // 
            // buttonGetItems
            // 
            this.buttonGetItems.Location = new System.Drawing.Point(3, 46);
            this.buttonGetItems.Name = "buttonGetItems";
            this.buttonGetItems.Size = new System.Drawing.Size(92, 34);
            this.buttonGetItems.TabIndex = 1;
            this.buttonGetItems.Text = "Get items";
            this.buttonGetItems.UseVisualStyleBackColor = true;
            this.buttonGetItems.Click += new System.EventHandler(this.buttonGetItems_Click);
            // 
            // panelPresentation
            // 
            this.panelPresentation.Controls.Add(this.richTextBox);
            this.panelPresentation.Location = new System.Drawing.Point(13, 9);
            this.panelPresentation.Name = "panelPresentation";
            this.panelPresentation.Size = new System.Drawing.Size(671, 579);
            this.panelPresentation.TabIndex = 3;
            // 
            // richTextBox
            // 
            this.richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox.Location = new System.Drawing.Point(3, 3);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new System.Drawing.Size(665, 570);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(3, 560);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(77, 13);
            this.labelClient.TabIndex = 5;
            this.labelClient.Text = "Current clients:";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelPresentation);
            this.Controls.Add(this.panelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.ShowIcon = false;
            this.Text = "WCT Client";
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            this.panelPresentation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGetClients;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Panel panelPresentation;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button buttonGetItems;
        private System.Windows.Forms.Button buttonAsync;
        private System.Windows.Forms.Label labelClient;
    }
}

