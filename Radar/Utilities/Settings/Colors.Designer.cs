namespace Radar.Utilities.Settings
{
	partial class Colors
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
			this.GoLbl = new System.Windows.Forms.Label();
			this.GoBtn = new System.Windows.Forms.Button();
			this.PetsBtn = new System.Windows.Forms.Button();
			this.PetsLbl = new System.Windows.Forms.Label();
			this.PetsDeadBtn = new System.Windows.Forms.Button();
			this.PetsDeadLbl = new System.Windows.Forms.Label();
			this.PlayersDeadBtn = new System.Windows.Forms.Button();
			this.PlayersDeadLbl = new System.Windows.Forms.Label();
			this.PlayersOppBtn = new System.Windows.Forms.Button();
			this.PlayersOppLbl = new System.Windows.Forms.Label();
			this.PlayersSameBtn = new System.Windows.Forms.Button();
			this.PlayersSameLbl = new System.Windows.Forms.Label();
			this.MeBtn = new System.Windows.Forms.Button();
			this.MeLbl = new System.Windows.Forms.Label();
			this.RadarBtn = new System.Windows.Forms.Button();
			this.RadarLbl = new System.Windows.Forms.Label();
			this.TargetBtn = new System.Windows.Forms.Button();
			this.TargetLbl = new System.Windows.Forms.Label();
			this.TargetDeadBtn = new System.Windows.Forms.Button();
			this.TargetDeadLbl = new System.Windows.Forms.Label();
			this.UnitsBtn = new System.Windows.Forms.Button();
			this.UnitLbl = new System.Windows.Forms.Label();
			this.UnitsDeadBtn = new System.Windows.Forms.Button();
			this.UnitsDeadLbl = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// GoLbl
			// 
			this.GoLbl.AutoSize = true;
			this.GoLbl.Location = new System.Drawing.Point(12, 18);
			this.GoLbl.Name = "GoLbl";
			this.GoLbl.Size = new System.Drawing.Size(77, 13);
			this.GoLbl.TabIndex = 0;
			this.GoLbl.Text = "Game Objects:";
			// 
			// GoBtn
			// 
			this.GoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.GoBtn.Location = new System.Drawing.Point(95, 12);
			this.GoBtn.Name = "GoBtn";
			this.GoBtn.Size = new System.Drawing.Size(25, 25);
			this.GoBtn.TabIndex = 1;
			this.GoBtn.UseVisualStyleBackColor = true;
			this.GoBtn.BackColor = Properties.Colors.Default.GameObject;
			this.GoBtn.Click += LoadColorDialog;
			// 
			// PetsBtn
			// 
			this.PetsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PetsBtn.Location = new System.Drawing.Point(95, 74);
			this.PetsBtn.Name = "PetsBtn";
			this.PetsBtn.Size = new System.Drawing.Size(25, 25);
			this.PetsBtn.TabIndex = 3;
			this.PetsBtn.UseVisualStyleBackColor = true;
			this.PetsBtn.BackColor = Properties.Colors.Default.Pet;
			this.PetsBtn.Click += LoadColorDialog;
			// 
			// PetsLbl
			// 
			this.PetsLbl.AutoSize = true;
			this.PetsLbl.Location = new System.Drawing.Point(12, 80);
			this.PetsLbl.Name = "PetsLbl";
			this.PetsLbl.Size = new System.Drawing.Size(31, 13);
			this.PetsLbl.TabIndex = 2;
			this.PetsLbl.Text = "Pets:";
			// 
			// PetsDeadBtn
			// 
			this.PetsDeadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PetsDeadBtn.Location = new System.Drawing.Point(95, 105);
			this.PetsDeadBtn.Name = "PetsDeadBtn";
			this.PetsDeadBtn.Size = new System.Drawing.Size(25, 25);
			this.PetsDeadBtn.TabIndex = 5;
			this.PetsDeadBtn.UseVisualStyleBackColor = true;
			this.PetsDeadBtn.BackColor = Properties.Colors.Default.PetDead;
			this.PetsDeadBtn.Click += LoadColorDialog;
			// 
			// PetsDeadLbl
			// 
			this.PetsDeadLbl.AutoSize = true;
			this.PetsDeadLbl.Location = new System.Drawing.Point(12, 111);
			this.PetsDeadLbl.Name = "PetsDeadLbl";
			this.PetsDeadLbl.Size = new System.Drawing.Size(66, 13);
			this.PetsDeadLbl.TabIndex = 4;
			this.PetsDeadLbl.Text = "Pets (Dead):";
			// 
			// PlayersDeadBtn
			// 
			this.PlayersDeadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PlayersDeadBtn.Location = new System.Drawing.Point(95, 136);
			this.PlayersDeadBtn.Name = "PlayersDeadBtn";
			this.PlayersDeadBtn.Size = new System.Drawing.Size(25, 25);
			this.PlayersDeadBtn.TabIndex = 7;
			this.PlayersDeadBtn.UseVisualStyleBackColor = true;
			this.PlayersDeadBtn.BackColor = Properties.Colors.Default.PlayerDead;
			this.PlayersDeadBtn.Click += LoadColorDialog;
			// 
			// PlayersDeadLbl
			// 
			this.PlayersDeadLbl.AutoSize = true;
			this.PlayersDeadLbl.Location = new System.Drawing.Point(12, 142);
			this.PlayersDeadLbl.Name = "PlayersDeadLbl";
			this.PlayersDeadLbl.Size = new System.Drawing.Size(79, 13);
			this.PlayersDeadLbl.TabIndex = 6;
			this.PlayersDeadLbl.Text = "Players (Dead):";
			// 
			// PlayersOppBtn
			// 
			this.PlayersOppBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PlayersOppBtn.Location = new System.Drawing.Point(95, 167);
			this.PlayersOppBtn.Name = "PlayersOppBtn";
			this.PlayersOppBtn.Size = new System.Drawing.Size(25, 25);
			this.PlayersOppBtn.TabIndex = 9;
			this.PlayersOppBtn.UseVisualStyleBackColor = true;
			this.PlayersOppBtn.BackColor = Properties.Colors.Default.PlayerOpposing;
			this.PlayersOppBtn.Click += LoadColorDialog;
			// 
			// PlayersOppLbl
			// 
			this.PlayersOppLbl.AutoSize = true;
			this.PlayersOppLbl.Location = new System.Drawing.Point(12, 173);
			this.PlayersOppLbl.Name = "PlayersOppLbl";
			this.PlayersOppLbl.Size = new System.Drawing.Size(73, 13);
			this.PlayersOppLbl.TabIndex = 8;
			this.PlayersOppLbl.Text = "Players (Opp):";
			// 
			// PlayersSameBtn
			// 
			this.PlayersSameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PlayersSameBtn.Location = new System.Drawing.Point(237, 12);
			this.PlayersSameBtn.Name = "PlayersSameBtn";
			this.PlayersSameBtn.Size = new System.Drawing.Size(25, 25);
			this.PlayersSameBtn.TabIndex = 11;
			this.PlayersSameBtn.UseVisualStyleBackColor = true;
			this.PlayersSameBtn.BackColor = Properties.Colors.Default.PlayerSame;
			this.PlayersSameBtn.Click += LoadColorDialog;
			// 
			// PlayersSameLbl
			// 
			this.PlayersSameLbl.AutoSize = true;
			this.PlayersSameLbl.Location = new System.Drawing.Point(154, 18);
			this.PlayersSameLbl.Name = "PlayersSameLbl";
			this.PlayersSameLbl.Size = new System.Drawing.Size(69, 13);
			this.PlayersSameLbl.TabIndex = 10;
			this.PlayersSameLbl.Text = "Players (Ally):";
			// 
			// MeBtn
			// 
			this.MeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.MeBtn.Location = new System.Drawing.Point(95, 43);
			this.MeBtn.Name = "MeBtn";
			this.MeBtn.Size = new System.Drawing.Size(25, 25);
			this.MeBtn.TabIndex = 13;
			this.MeBtn.UseVisualStyleBackColor = true;
			this.MeBtn.BackColor = Properties.Colors.Default.PlayerMe;
			this.MeBtn.Click += LoadColorDialog;
			// 
			// MeLbl
			// 
			this.MeLbl.AutoSize = true;
			this.MeLbl.Location = new System.Drawing.Point(12, 49);
			this.MeLbl.Name = "MeLbl";
			this.MeLbl.Size = new System.Drawing.Size(25, 13);
			this.MeLbl.TabIndex = 12;
			this.MeLbl.Text = "Me:";
			// 
			// RadarBtn
			// 
			this.RadarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.RadarBtn.Location = new System.Drawing.Point(237, 43);
			this.RadarBtn.Name = "RadarBtn";
			this.RadarBtn.Size = new System.Drawing.Size(25, 25);
			this.RadarBtn.TabIndex = 15;
			this.RadarBtn.UseVisualStyleBackColor = true;
			this.RadarBtn.BackColor = Properties.Colors.Default.Radar;
			this.RadarBtn.Click += LoadColorDialog;
			// 
			// RadarLbl
			// 
			this.RadarLbl.AutoSize = true;
			this.RadarLbl.Location = new System.Drawing.Point(154, 49);
			this.RadarLbl.Name = "RadarLbl";
			this.RadarLbl.Size = new System.Drawing.Size(55, 13);
			this.RadarLbl.TabIndex = 14;
			this.RadarLbl.Text = "Radar Bg:";
			// 
			// TargetBtn
			// 
			this.TargetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.TargetBtn.Location = new System.Drawing.Point(237, 74);
			this.TargetBtn.Name = "TargetBtn";
			this.TargetBtn.Size = new System.Drawing.Size(25, 25);
			this.TargetBtn.TabIndex = 17;
			this.TargetBtn.UseVisualStyleBackColor = true;
			this.TargetBtn.BackColor = Properties.Colors.Default.Target;
			this.TargetBtn.Click += LoadColorDialog;
			// 
			// TargetLbl
			// 
			this.TargetLbl.AutoSize = true;
			this.TargetLbl.Location = new System.Drawing.Point(154, 80);
			this.TargetLbl.Name = "TargetLbl";
			this.TargetLbl.Size = new System.Drawing.Size(41, 13);
			this.TargetLbl.TabIndex = 16;
			this.TargetLbl.Text = "Target:";
			// 
			// TargetDeadBtn
			// 
			this.TargetDeadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.TargetDeadBtn.Location = new System.Drawing.Point(237, 105);
			this.TargetDeadBtn.Name = "TargetDeadBtn";
			this.TargetDeadBtn.Size = new System.Drawing.Size(25, 25);
			this.TargetDeadBtn.TabIndex = 19;
			this.TargetDeadBtn.UseVisualStyleBackColor = true;
			this.TargetDeadBtn.BackColor = Properties.Colors.Default.TargetDead;
			this.TargetDeadBtn.Click += LoadColorDialog;
			// 
			// TargetDeadLbl
			// 
			this.TargetDeadLbl.AutoSize = true;
			this.TargetDeadLbl.Location = new System.Drawing.Point(154, 111);
			this.TargetDeadLbl.Name = "TargetDeadLbl";
			this.TargetDeadLbl.Size = new System.Drawing.Size(76, 13);
			this.TargetDeadLbl.TabIndex = 18;
			this.TargetDeadLbl.Text = "Target (Dead):";
			// 
			// UnitsBtn
			// 
			this.UnitsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.UnitsBtn.Location = new System.Drawing.Point(237, 136);
			this.UnitsBtn.Name = "UnitsBtn";
			this.UnitsBtn.Size = new System.Drawing.Size(25, 25);
			this.UnitsBtn.TabIndex = 21;
			this.UnitsBtn.UseVisualStyleBackColor = true;
			this.UnitsBtn.BackColor = Properties.Colors.Default.Unit;
			this.UnitsBtn.Click += LoadColorDialog;
			// 
			// UnitLbl
			// 
			this.UnitLbl.AutoSize = true;
			this.UnitLbl.Location = new System.Drawing.Point(154, 142);
			this.UnitLbl.Name = "UnitLbl";
			this.UnitLbl.Size = new System.Drawing.Size(34, 13);
			this.UnitLbl.TabIndex = 20;
			this.UnitLbl.Text = "Units:";
			// 
			// UnitsDeadBtn
			// 
			this.UnitsDeadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.UnitsDeadBtn.Location = new System.Drawing.Point(237, 167);
			this.UnitsDeadBtn.Name = "UnitsDeadBtn";
			this.UnitsDeadBtn.Size = new System.Drawing.Size(25, 25);
			this.UnitsDeadBtn.TabIndex = 23;
			this.UnitsDeadBtn.UseVisualStyleBackColor = true;
			this.UnitsDeadBtn.BackColor = Properties.Colors.Default.UnitDead;
			this.UnitsDeadBtn.Click += LoadColorDialog;
			// 
			// UnitsDeadLbl
			// 
			this.UnitsDeadLbl.AutoSize = true;
			this.UnitsDeadLbl.Location = new System.Drawing.Point(154, 173);
			this.UnitsDeadLbl.Name = "UnitsDeadLbl";
			this.UnitsDeadLbl.Size = new System.Drawing.Size(69, 13);
			this.UnitsDeadLbl.TabIndex = 22;
			this.UnitsDeadLbl.Text = "Units (Dead):";
			// 
			// Colors
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(278, 204);
			this.Controls.Add(this.UnitsDeadBtn);
			this.Controls.Add(this.UnitsDeadLbl);
			this.Controls.Add(this.UnitsBtn);
			this.Controls.Add(this.UnitLbl);
			this.Controls.Add(this.TargetDeadBtn);
			this.Controls.Add(this.TargetDeadLbl);
			this.Controls.Add(this.TargetBtn);
			this.Controls.Add(this.TargetLbl);
			this.Controls.Add(this.RadarBtn);
			this.Controls.Add(this.RadarLbl);
			this.Controls.Add(this.MeBtn);
			this.Controls.Add(this.MeLbl);
			this.Controls.Add(this.PlayersSameBtn);
			this.Controls.Add(this.PlayersSameLbl);
			this.Controls.Add(this.PlayersOppBtn);
			this.Controls.Add(this.PlayersOppLbl);
			this.Controls.Add(this.PlayersDeadBtn);
			this.Controls.Add(this.PlayersDeadLbl);
			this.Controls.Add(this.PetsDeadBtn);
			this.Controls.Add(this.PetsDeadLbl);
			this.Controls.Add(this.PetsBtn);
			this.Controls.Add(this.PetsLbl);
			this.Controls.Add(this.GoBtn);
			this.Controls.Add(this.GoLbl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Colors";
			this.Text = "Colors";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label GoLbl;
		private System.Windows.Forms.Button GoBtn;
		private System.Windows.Forms.Button PetsBtn;
		private System.Windows.Forms.Label PetsLbl;
		private System.Windows.Forms.Button PetsDeadBtn;
		private System.Windows.Forms.Label PetsDeadLbl;
		private System.Windows.Forms.Button PlayersDeadBtn;
		private System.Windows.Forms.Label PlayersDeadLbl;
		private System.Windows.Forms.Button PlayersOppBtn;
		private System.Windows.Forms.Label PlayersOppLbl;
		private System.Windows.Forms.Button PlayersSameBtn;
		private System.Windows.Forms.Label PlayersSameLbl;
		private System.Windows.Forms.Button MeBtn;
		private System.Windows.Forms.Label MeLbl;
		private System.Windows.Forms.Button RadarBtn;
		private System.Windows.Forms.Label RadarLbl;
		private System.Windows.Forms.Button TargetBtn;
		private System.Windows.Forms.Label TargetLbl;
		private System.Windows.Forms.Button TargetDeadBtn;
		private System.Windows.Forms.Label TargetDeadLbl;
		private System.Windows.Forms.Button UnitsBtn;
		private System.Windows.Forms.Label UnitLbl;
		private System.Windows.Forms.Button UnitsDeadBtn;
		private System.Windows.Forms.Label UnitsDeadLbl;
	}
}