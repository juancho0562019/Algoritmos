namespace Cliente
{
    partial class FrmConsumo
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
            panel1 = new Panel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            btnConsulta = new Button();
            pgbProgreso = new ProgressBar();
            flowLayoutPanel2 = new FlowLayoutPanel();
            txtSalida = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            txtInput = new TextBox();
            panel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(flowLayoutPanel3);
            panel1.Controls.Add(flowLayoutPanel2);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(346, 386);
            panel1.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.Controls.Add(btnConsulta);
            flowLayoutPanel3.Controls.Add(pgbProgreso);
            flowLayoutPanel3.Location = new Point(0, 336);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(346, 50);
            flowLayoutPanel3.TabIndex = 1;
            // 
            // btnConsulta
            // 
            btnConsulta.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnConsulta.Cursor = Cursors.Hand;
            btnConsulta.Location = new Point(3, 3);
            btnConsulta.Name = "btnConsulta";
            btnConsulta.Size = new Size(117, 44);
            btnConsulta.TabIndex = 0;
            btnConsulta.Text = "Solucion";
            btnConsulta.UseVisualStyleBackColor = true;
            btnConsulta.Click += btnConsulta_Click;
            // 
            // pgbProgreso
            // 
            pgbProgreso.Location = new Point(126, 3);
            pgbProgreso.Name = "pgbProgreso";
            pgbProgreso.Size = new Size(217, 44);
            pgbProgreso.Style = ProgressBarStyle.Marquee;
            pgbProgreso.TabIndex = 1;
            pgbProgreso.Visible = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.Controls.Add(txtSalida);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(0, 33);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(346, 353);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // txtSalida
            // 
            txtSalida.Dock = DockStyle.Top;
            txtSalida.Location = new Point(3, 3);
            txtSalida.Multiline = true;
            txtSalida.Name = "txtSalida";
            txtSalida.Size = new Size(340, 295);
            txtSalida.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(txtInput);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(346, 33);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // txtInput
            // 
            txtInput.Dock = DockStyle.Top;
            txtInput.Location = new Point(3, 3);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(340, 27);
            txtInput.TabIndex = 1;
            // 
            // FrmConsumo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 386);
            Controls.Add(panel1);
            Name = "FrmConsumo";
            Text = "Consulta Algoritmo Patron Salida";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox txtSalida;
        private TextBox txtInput;
        private Button btnConsulta;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel2;
        private ProgressBar pgbProgreso;
    }
}
