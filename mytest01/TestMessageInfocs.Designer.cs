namespace mytest01
{
	partial class TestMessageInfocs
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.modifyGrop = new System.Windows.Forms.GroupBox();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.paramTxt = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SQLTxt = new System.Windows.Forms.TextBox();
			this.button9 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.sqlTestBtn04 = new System.Windows.Forms.Button();
			this.modifySet = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.modifyGrop.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(6, 20);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "新建窗口";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(6, 49);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "修改窗口";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(6, 78);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "查看窗口";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// modifyGrop
			// 
			this.modifyGrop.Controls.Add(this.button1);
			this.modifyGrop.Controls.Add(this.button3);
			this.modifyGrop.Controls.Add(this.button2);
			this.modifyGrop.Controls.Add(this.button5);
			this.modifyGrop.Controls.Add(this.button4);
			this.modifyGrop.Location = new System.Drawing.Point(12, 12);
			this.modifyGrop.Name = "modifyGrop";
			this.modifyGrop.Size = new System.Drawing.Size(93, 223);
			this.modifyGrop.TabIndex = 3;
			this.modifyGrop.TabStop = false;
			this.modifyGrop.Text = "信息修改功能";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(6, 122);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 5;
			this.button5.Text = "消息管理";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(6, 151);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 4;
			this.button4.Text = "消息展示";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(125, 28);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 6;
			this.button6.Text = "释放窗口";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(125, 73);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 23);
			this.button7.TabIndex = 7;
			this.button7.Text = "清洗装载";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(518, 7);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(127, 23);
			this.button8.TabIndex = 8;
			this.button8.Text = "流程确认窗口";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// paramTxt
			// 
			this.paramTxt.Location = new System.Drawing.Point(215, 30);
			this.paramTxt.Multiline = true;
			this.paramTxt.Name = "paramTxt";
			this.paramTxt.Size = new System.Drawing.Size(430, 82);
			this.paramTxt.TabIndex = 9;
			this.paramTxt.Text = "BCB0000000001,BCV0000003030,BCZ0000000068";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(215, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 10;
			this.label1.Text = "流程参数";
			// 
			// SQLTxt
			// 
			this.SQLTxt.Location = new System.Drawing.Point(104, 341);
			this.SQLTxt.Multiline = true;
			this.SQLTxt.Name = "SQLTxt";
			this.SQLTxt.Size = new System.Drawing.Size(456, 99);
			this.SQLTxt.TabIndex = 11;
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(104, 310);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(75, 23);
			this.button9.TabIndex = 12;
			this.button9.Text = "SQL Test1";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(186, 309);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(75, 23);
			this.button10.TabIndex = 13;
			this.button10.Text = "SQL Test2";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(267, 309);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(75, 23);
			this.button11.TabIndex = 14;
			this.button11.Text = "SQL Test3";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// sqlTestBtn04
			// 
			this.sqlTestBtn04.Location = new System.Drawing.Point(349, 310);
			this.sqlTestBtn04.Name = "sqlTestBtn04";
			this.sqlTestBtn04.Size = new System.Drawing.Size(75, 23);
			this.sqlTestBtn04.TabIndex = 15;
			this.sqlTestBtn04.Text = "SQL Test4";
			this.sqlTestBtn04.UseVisualStyleBackColor = true;
			this.sqlTestBtn04.Click += new System.EventHandler(this.sqlTestBtn04_Click);
			// 
			// modifySet
			// 
			this.modifySet.Location = new System.Drawing.Point(18, 265);
			this.modifySet.Name = "modifySet";
			this.modifySet.Size = new System.Drawing.Size(161, 23);
			this.modifySet.TabIndex = 16;
			this.modifySet.Text = "修改特殊器械包";
			this.modifySet.UseVisualStyleBackColor = true;
			this.modifySet.Click += new System.EventHandler(this.modifySet_Click);
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(217, 265);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(125, 23);
			this.button12.TabIndex = 17;
			this.button12.Text = "存储过程测试";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// TestMessageInfocs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(675, 452);
			this.Controls.Add(this.button12);
			this.Controls.Add(this.modifySet);
			this.Controls.Add(this.sqlTestBtn04);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.SQLTxt);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.paramTxt);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.modifyGrop);
			this.Name = "TestMessageInfocs";
			this.Text = "TestMessageInfocs";
			this.modifyGrop.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.GroupBox modifyGrop;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.TextBox paramTxt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox SQLTxt;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button sqlTestBtn04;
		private System.Windows.Forms.Button modifySet;
		private System.Windows.Forms.Button button12;
	}
}