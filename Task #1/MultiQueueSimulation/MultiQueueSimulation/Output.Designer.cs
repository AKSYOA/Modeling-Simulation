namespace MultiQueueSimulation
{
    partial class Output
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
            this.outputDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.averageWaitingTextBox = new System.Windows.Forms.TextBox();
            this.probabilityOfWaitTextBox = new System.Windows.Forms.TextBox();
            this.maxQueueLengthTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.idleProbabilityTextBox = new System.Windows.Forms.TextBox();
            this.avgServiceTimeTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.utilizationTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.serverComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.outputDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // outputDataGridView
            // 
            this.outputDataGridView.AllowUserToAddRows = false;
            this.outputDataGridView.AllowUserToDeleteRows = false;
            this.outputDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outputDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.outputDataGridView.Location = new System.Drawing.Point(12, 12);
            this.outputDataGridView.Name = "outputDataGridView";
            this.outputDataGridView.ReadOnly = true;
            this.outputDataGridView.Size = new System.Drawing.Size(1019, 344);
            this.outputDataGridView.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Customer No.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Random Digits for Arrival";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "InterArrival Time";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Arrival Time";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Random Digits for Service";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Time Service Begins";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Service Time";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Time Service End";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Server Index";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Time in Queue";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(12, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "System Performance Measures";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 418);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Average Waiting Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Probability of Wait";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Max Queue Length";
            // 
            // averageWaitingTextBox
            // 
            this.averageWaitingTextBox.Location = new System.Drawing.Point(16, 443);
            this.averageWaitingTextBox.Name = "averageWaitingTextBox";
            this.averageWaitingTextBox.ReadOnly = true;
            this.averageWaitingTextBox.Size = new System.Drawing.Size(100, 20);
            this.averageWaitingTextBox.TabIndex = 5;
            // 
            // probabilityOfWaitTextBox
            // 
            this.probabilityOfWaitTextBox.Location = new System.Drawing.Point(144, 443);
            this.probabilityOfWaitTextBox.Name = "probabilityOfWaitTextBox";
            this.probabilityOfWaitTextBox.ReadOnly = true;
            this.probabilityOfWaitTextBox.Size = new System.Drawing.Size(92, 20);
            this.probabilityOfWaitTextBox.TabIndex = 6;
            // 
            // maxQueueLengthTextBox
            // 
            this.maxQueueLengthTextBox.Location = new System.Drawing.Point(277, 443);
            this.maxQueueLengthTextBox.Name = "maxQueueLengthTextBox";
            this.maxQueueLengthTextBox.ReadOnly = true;
            this.maxQueueLengthTextBox.Size = new System.Drawing.Size(90, 20);
            this.maxQueueLengthTextBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label5.Location = new System.Drawing.Point(445, 372);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(218, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Server Performance Measures";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(446, 418);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Idle Probability";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(565, 418);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Avg Service Time";
            // 
            // idleProbabilityTextBox
            // 
            this.idleProbabilityTextBox.Location = new System.Drawing.Point(449, 443);
            this.idleProbabilityTextBox.Name = "idleProbabilityTextBox";
            this.idleProbabilityTextBox.ReadOnly = true;
            this.idleProbabilityTextBox.Size = new System.Drawing.Size(74, 20);
            this.idleProbabilityTextBox.TabIndex = 11;
            // 
            // avgServiceTimeTextBox
            // 
            this.avgServiceTimeTextBox.Location = new System.Drawing.Point(568, 443);
            this.avgServiceTimeTextBox.Name = "avgServiceTimeTextBox";
            this.avgServiceTimeTextBox.ReadOnly = true;
            this.avgServiceTimeTextBox.Size = new System.Drawing.Size(81, 20);
            this.avgServiceTimeTextBox.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(680, 418);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Utilization";
            // 
            // utilizationTextBox
            // 
            this.utilizationTextBox.Location = new System.Drawing.Point(683, 443);
            this.utilizationTextBox.Name = "utilizationTextBox";
            this.utilizationTextBox.ReadOnly = true;
            this.utilizationTextBox.Size = new System.Drawing.Size(75, 20);
            this.utilizationTextBox.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(680, 378);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Server";
            // 
            // serverComboBox
            // 
            this.serverComboBox.FormattingEnabled = true;
            this.serverComboBox.Location = new System.Drawing.Point(726, 374);
            this.serverComboBox.Name = "serverComboBox";
            this.serverComboBox.Size = new System.Drawing.Size(93, 21);
            this.serverComboBox.TabIndex = 16;
            this.serverComboBox.SelectedIndexChanged += new System.EventHandler(this.serverComboBox_SelectedIndexChanged);
            // 
            // Output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 474);
            this.Controls.Add(this.serverComboBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.utilizationTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.avgServiceTimeTextBox);
            this.Controls.Add(this.idleProbabilityTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maxQueueLengthTextBox);
            this.Controls.Add(this.probabilityOfWaitTextBox);
            this.Controls.Add(this.averageWaitingTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputDataGridView);
            this.Name = "Output";
            this.Text = "Output";
            this.Load += new System.EventHandler(this.Output_Load);
            ((System.ComponentModel.ISupportInitialize)(this.outputDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView outputDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox averageWaitingTextBox;
        private System.Windows.Forms.TextBox probabilityOfWaitTextBox;
        private System.Windows.Forms.TextBox maxQueueLengthTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox idleProbabilityTextBox;
        private System.Windows.Forms.TextBox avgServiceTimeTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox utilizationTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox serverComboBox;
    }
}