
namespace GamblingMachine
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.box3 = new System.Windows.Forms.PictureBox();
            this.box2 = new System.Windows.Forms.PictureBox();
            this.box1 = new System.Windows.Forms.PictureBox();
            this.machine = new System.Windows.Forms.PictureBox();
            this.current_points = new System.Windows.Forms.Label();
            this.added_points = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.Label();
            this.Info = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.oGrzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Instruction = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.box3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.machine)).BeginInit();
            this.Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // box3
            // 
            this.box3.Image = global::GamblingMachine.Properties.Resources.seven;
            this.box3.Location = new System.Drawing.Point(552, 229);
            this.box3.Name = "box3";
            this.box3.Size = new System.Drawing.Size(107, 106);
            this.box3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.box3.TabIndex = 5;
            this.box3.TabStop = false;
            // 
            // box2
            // 
            this.box2.Image = global::GamblingMachine.Properties.Resources.seven;
            this.box2.Location = new System.Drawing.Point(391, 229);
            this.box2.Name = "box2";
            this.box2.Size = new System.Drawing.Size(107, 106);
            this.box2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.box2.TabIndex = 4;
            this.box2.TabStop = false;
            // 
            // box1
            // 
            this.box1.Image = global::GamblingMachine.Properties.Resources.seven;
            this.box1.Location = new System.Drawing.Point(235, 229);
            this.box1.Name = "box1";
            this.box1.Size = new System.Drawing.Size(107, 106);
            this.box1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.box1.TabIndex = 1;
            this.box1.TabStop = false;
            // 
            // machine
            // 
            this.machine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.machine.Image = global::GamblingMachine.Properties.Resources.gambling_bg;
            this.machine.Location = new System.Drawing.Point(0, 0);
            this.machine.Name = "machine";
            this.machine.Size = new System.Drawing.Size(895, 546);
            this.machine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.machine.TabIndex = 0;
            this.machine.TabStop = false;
            this.Instruction.SetToolTip(this.machine, "Kliknij, aby zagrać");
            this.machine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.machine_Click);
            // 
            // current_points
            // 
            this.current_points.AutoSize = true;
            this.current_points.BackColor = System.Drawing.Color.White;
            this.current_points.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.current_points.ForeColor = System.Drawing.Color.White;
            this.current_points.Location = new System.Drawing.Point(583, 12);
            this.current_points.Name = "current_points";
            this.current_points.Size = new System.Drawing.Size(76, 26);
            this.current_points.TabIndex = 6;
            this.current_points.Text = "label1";
            // 
            // added_points
            // 
            this.added_points.AutoSize = true;
            this.added_points.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.added_points.Location = new System.Drawing.Point(642, 22);
            this.added_points.Name = "added_points";
            this.added_points.Size = new System.Drawing.Size(46, 17);
            this.added_points.TabIndex = 7;
            this.added_points.Text = "label1";
            this.added_points.Visible = false;
            // 
            // message
            // 
            this.message.BackColor = System.Drawing.Color.White;
            this.message.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.message.ForeColor = System.Drawing.Color.White;
            this.message.Location = new System.Drawing.Point(0, 515);
            this.message.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(895, 31);
            this.message.TabIndex = 8;
            this.message.Text = "label1";
            this.message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Info
            // 
            this.Info.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oGrzeToolStripMenuItem});
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(105, 26);
            // 
            // oGrzeToolStripMenuItem
            // 
            this.oGrzeToolStripMenuItem.Name = "oGrzeToolStripMenuItem";
            this.oGrzeToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.oGrzeToolStripMenuItem.Text = "Autor";
            this.oGrzeToolStripMenuItem.Click += new System.EventHandler(this.oGrzeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(895, 546);
            this.ContextMenuStrip = this.Info;
            this.Controls.Add(this.message);
            this.Controls.Add(this.added_points);
            this.Controls.Add(this.current_points);
            this.Controls.Add(this.box3);
            this.Controls.Add(this.box2);
            this.Controls.Add(this.box1);
            this.Controls.Add(this.machine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Midnight Casino";
            ((System.ComponentModel.ISupportInitialize)(this.box3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.machine)).EndInit();
            this.Info.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox machine;
        private System.Windows.Forms.PictureBox box1;
        private System.Windows.Forms.PictureBox box2;
        private System.Windows.Forms.PictureBox box3;
        private System.Windows.Forms.Label current_points;
        private System.Windows.Forms.Label added_points;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.ContextMenuStrip Info;
        private System.Windows.Forms.ToolStripMenuItem oGrzeToolStripMenuItem;
        private System.Windows.Forms.ToolTip Instruction;
    }
}

