namespace Desafio_Compuletra
{
    partial class MainForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonChange = new System.Windows.Forms.Button();
            this.ButtonWithdraw = new System.Windows.Forms.Button();
            this.ButtonDeposit = new System.Windows.Forms.Button();
            this.Input = new System.Windows.Forms.TextBox();
            this.Summary = new System.Windows.Forms.Label();
            this.ButtonStatus = new System.Windows.Forms.Button();
            this.ButtonSubmit = new System.Windows.Forms.Button();
            this.ButtonHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 24F);
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Máquina de Moedas";
            // 
            // ButtonChange
            // 
            this.ButtonChange.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            this.ButtonChange.Location = new System.Drawing.Point(180, 129);
            this.ButtonChange.Name = "ButtonChange";
            this.ButtonChange.Size = new System.Drawing.Size(126, 49);
            this.ButtonChange.TabIndex = 6;
            this.ButtonChange.Text = "Gerar Troco";
            this.ButtonChange.UseVisualStyleBackColor = true;
            this.ButtonChange.Click += new System.EventHandler(this.ButtonChange_Click);
            // 
            // ButtonWithdraw
            // 
            this.ButtonWithdraw.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            this.ButtonWithdraw.Location = new System.Drawing.Point(43, 189);
            this.ButtonWithdraw.Name = "ButtonWithdraw";
            this.ButtonWithdraw.Size = new System.Drawing.Size(126, 49);
            this.ButtonWithdraw.TabIndex = 7;
            this.ButtonWithdraw.Text = "Sacar";
            this.ButtonWithdraw.UseVisualStyleBackColor = true;
            this.ButtonWithdraw.Click += new System.EventHandler(this.ButtonWithdraw_Click);
            // 
            // ButtonDeposit
            // 
            this.ButtonDeposit.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            this.ButtonDeposit.Location = new System.Drawing.Point(43, 129);
            this.ButtonDeposit.Name = "ButtonDeposit";
            this.ButtonDeposit.Size = new System.Drawing.Size(126, 49);
            this.ButtonDeposit.TabIndex = 8;
            this.ButtonDeposit.Text = "Depositar";
            this.ButtonDeposit.UseVisualStyleBackColor = true;
            this.ButtonDeposit.Click += new System.EventHandler(this.ButtonDeposit_Click);
            // 
            // Input
            // 
            this.Input.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            this.Input.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Input.Location = new System.Drawing.Point(382, 22);
            this.Input.Multiline = true;
            this.Input.Name = "Input";
            this.Input.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Input.Size = new System.Drawing.Size(441, 216);
            this.Input.TabIndex = 10;
            this.Input.Visible = false;
            this.Input.Enter += new System.EventHandler(this.Input_Enter);
            // 
            // Summary
            // 
            this.Summary.AutoSize = true;
            this.Summary.Font = new System.Drawing.Font("Segoe UI Light", 18F);
            this.Summary.Location = new System.Drawing.Point(9, 72);
            this.Summary.Name = "Summary";
            this.Summary.Size = new System.Drawing.Size(315, 32);
            this.Summary.TabIndex = 11;
            this.Summary.Text = "Saldo: $42,00  42/100 moedas";
            // 
            // ButtonStatus
            // 
            this.ButtonStatus.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            this.ButtonStatus.Location = new System.Drawing.Point(180, 189);
            this.ButtonStatus.Name = "ButtonStatus";
            this.ButtonStatus.Size = new System.Drawing.Size(126, 49);
            this.ButtonStatus.TabIndex = 14;
            this.ButtonStatus.Text = "Status";
            this.ButtonStatus.UseVisualStyleBackColor = true;
            this.ButtonStatus.Click += new System.EventHandler(this.ButtonStatus_Click);
            // 
            // ButtonSubmit
            // 
            this.ButtonSubmit.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            this.ButtonSubmit.Location = new System.Drawing.Point(439, 251);
            this.ButtonSubmit.Name = "ButtonSubmit";
            this.ButtonSubmit.Size = new System.Drawing.Size(158, 49);
            this.ButtonSubmit.TabIndex = 15;
            this.ButtonSubmit.Text = "Enviar";
            this.ButtonSubmit.UseVisualStyleBackColor = true;
            this.ButtonSubmit.Visible = false;
            // 
            // ButtonHelp
            // 
            this.ButtonHelp.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            this.ButtonHelp.Location = new System.Drawing.Point(608, 251);
            this.ButtonHelp.Name = "ButtonHelp";
            this.ButtonHelp.Size = new System.Drawing.Size(158, 49);
            this.ButtonHelp.TabIndex = 16;
            this.ButtonHelp.Text = "Ajuda";
            this.ButtonHelp.UseVisualStyleBackColor = true;
            this.ButtonHelp.Visible = false;
            this.ButtonHelp.Click += new System.EventHandler(this.ButtonHelp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 312);
            this.Controls.Add(this.ButtonHelp);
            this.Controls.Add(this.ButtonSubmit);
            this.Controls.Add(this.ButtonStatus);
            this.Controls.Add(this.Summary);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.ButtonDeposit);
            this.Controls.Add(this.ButtonWithdraw);
            this.Controls.Add(this.ButtonChange);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonChange;
        private System.Windows.Forms.Button ButtonWithdraw;
        private System.Windows.Forms.Button ButtonDeposit;
        private System.Windows.Forms.TextBox Input;
        private System.Windows.Forms.Label Summary;
        private System.Windows.Forms.Button ButtonStatus;
        private System.Windows.Forms.Button ButtonSubmit;
        private System.Windows.Forms.Button ButtonHelp;
    }
}

