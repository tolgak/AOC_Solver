namespace AOC_Solver
{
  partial class frmMain
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
      this.txtLog = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnDownload = new System.Windows.Forms.Button();
      this.txtInput = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnSolve = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.spinDay = new System.Windows.Forms.NumericUpDown();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.spinPart = new System.Windows.Forms.NumericUpDown();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.txtSolution = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.spinDay)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.spinPart)).BeginInit();
      this.SuspendLayout();
      // 
      // txtLog
      // 
      this.txtLog.BackColor = System.Drawing.Color.Black;
      this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.txtLog.ForeColor = System.Drawing.Color.Lime;
      this.txtLog.Location = new System.Drawing.Point(2, 249);
      this.txtLog.Multiline = true;
      this.txtLog.Name = "txtLog";
      this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtLog.Size = new System.Drawing.Size(842, 265);
      this.txtLog.TabIndex = 6;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(16, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(50, 20);
      this.label1.TabIndex = 1;
      this.label1.Text = "Solver";
      // 
      // btnDownload
      // 
      this.btnDownload.Location = new System.Drawing.Point(582, 13);
      this.btnDownload.Name = "btnDownload";
      this.btnDownload.Size = new System.Drawing.Size(94, 29);
      this.btnDownload.TabIndex = 3;
      this.btnDownload.TabStop = false;
      this.btnDownload.Text = "download";
      this.btnDownload.UseVisualStyleBackColor = true;
      this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
      // 
      // txtInput
      // 
      this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtInput.Location = new System.Drawing.Point(90, 86);
      this.txtInput.Multiline = true;
      this.txtInput.Name = "txtInput";
      this.txtInput.PlaceholderText = "Paste input here";
      this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtInput.Size = new System.Drawing.Size(476, 106);
      this.txtInput.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(16, 88);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(43, 20);
      this.label2.TabIndex = 4;
      this.label2.Text = "Input";
      // 
      // btnSolve
      // 
      this.btnSolve.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnSolve.Location = new System.Drawing.Point(582, 163);
      this.btnSolve.Name = "btnSolve";
      this.btnSolve.Size = new System.Drawing.Size(94, 29);
      this.btnSolve.TabIndex = 4;
      this.btnSolve.Text = "Solve";
      this.btnSolve.UseVisualStyleBackColor = true;
      this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(16, 55);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(48, 20);
      this.label3.TabIndex = 7;
      this.label3.Text = "Day #";
      // 
      // spinDay
      // 
      this.spinDay.Location = new System.Drawing.Point(90, 53);
      this.spinDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
      this.spinDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.spinDay.Name = "spinDay";
      this.spinDay.Size = new System.Drawing.Size(77, 27);
      this.spinDay.TabIndex = 1;
      this.spinDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // comboBox1
      // 
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(90, 19);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(235, 28);
      this.comboBox1.TabIndex = 0;
      // 
      // spinPart
      // 
      this.spinPart.Location = new System.Drawing.Point(248, 53);
      this.spinPart.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
      this.spinPart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.spinPart.Name = "spinPart";
      this.spinPart.Size = new System.Drawing.Size(77, 27);
      this.spinPart.TabIndex = 2;
      this.spinPart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(185, 55);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(47, 20);
      this.label4.TabIndex = 11;
      this.label4.Text = "Part #";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(16, 209);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(64, 20);
      this.label5.TabIndex = 13;
      this.label5.Text = "Solution";
      // 
      // txtSolution
      // 
      this.txtSolution.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtSolution.Location = new System.Drawing.Point(90, 204);
      this.txtSolution.Name = "txtSolution";
      this.txtSolution.Size = new System.Drawing.Size(125, 27);
      this.txtSolution.TabIndex = 5;
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(846, 516);
      this.Controls.Add(this.txtSolution);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.spinPart);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.comboBox1);
      this.Controls.Add(this.spinDay);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.btnSolve);
      this.Controls.Add(this.txtInput);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnDownload);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtLog);
      this.Name = "frmMain";
      this.Padding = new System.Windows.Forms.Padding(2);
      this.Text = "AOC";
      ((System.ComponentModel.ISupportInitialize)(this.spinDay)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.spinPart)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private TextBox txtLog;
    private Label label1;
    private Button btnDownload;
    private TextBox txtInput;
    private Label label2;
    private Button btnSolve;
    private Label label3;
    private NumericUpDown spinDay;
    private ComboBox comboBox1;
    private NumericUpDown spinPart;
    private Label label4;
    private Label label5;
    private TextBox txtSolution;
  }
}