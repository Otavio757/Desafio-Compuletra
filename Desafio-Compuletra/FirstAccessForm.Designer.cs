namespace Desafio_Compuletra
{
    partial class FirstAccessForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonBrazilianPattern = new System.Windows.Forms.RadioButton();
            this.ButtonCustomPattern = new System.Windows.Forms.RadioButton();
            this.CustomPattern = new System.Windows.Forms.TextBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.MachineCapacity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 24F);
            this.label1.Location = new System.Drawing.Point(142, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Primeiro Acesso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 18F);
            this.label2.Location = new System.Drawing.Point(30, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(466, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Qual padrão de moedas você deseja utilizar?";
            // 
            // ButtonBrazilianPattern
            // 
            this.ButtonBrazilianPattern.AutoSize = true;
            this.ButtonBrazilianPattern.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonBrazilianPattern.Location = new System.Drawing.Point(38, 240);
            this.ButtonBrazilianPattern.Name = "ButtonBrazilianPattern";
            this.ButtonBrazilianPattern.Size = new System.Drawing.Size(458, 29);
            this.ButtonBrazilianPattern.TabIndex = 2;
            this.ButtonBrazilianPattern.TabStop = true;
            this.ButtonBrazilianPattern.Text = "Padrão Brasileiro: 1, 5, 10, 25, 50 e 100 centavos (1 real)";
            this.ButtonBrazilianPattern.UseVisualStyleBackColor = true;
            this.ButtonBrazilianPattern.CheckedChanged += new System.EventHandler(this.ButtonBrazilianPattern_CheckedChanged);
            // 
            // ButtonCustomPattern
            // 
            this.ButtonCustomPattern.AutoSize = true;
            this.ButtonCustomPattern.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCustomPattern.Location = new System.Drawing.Point(38, 275);
            this.ButtonCustomPattern.Name = "ButtonCustomPattern";
            this.ButtonCustomPattern.Size = new System.Drawing.Size(204, 29);
            this.ButtonCustomPattern.TabIndex = 3;
            this.ButtonCustomPattern.TabStop = true;
            this.ButtonCustomPattern.Text = "Padrão Personalizado:";
            this.ButtonCustomPattern.UseVisualStyleBackColor = true;
            this.ButtonCustomPattern.CheckedChanged += new System.EventHandler(this.ButtonCustomPattern_CheckedChanged);
            // 
            // CustomPattern
            // 
            this.CustomPattern.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            this.CustomPattern.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CustomPattern.Location = new System.Drawing.Point(38, 310);
            this.CustomPattern.Name = "CustomPattern";
            this.CustomPattern.Size = new System.Drawing.Size(449, 32);
            this.CustomPattern.TabIndex = 4;
            this.CustomPattern.Text = "Digite os valores em centavos, separados por virgula";
            this.CustomPattern.Visible = false;
            this.CustomPattern.Enter += new System.EventHandler(this.CustomPattern_Enter);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            this.ButtonSave.Location = new System.Drawing.Point(200, 364);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(109, 37);
            this.ButtonSave.TabIndex = 5;
            this.ButtonSave.Text = "Salvar";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 18F);
            this.label3.Location = new System.Drawing.Point(72, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(359, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Qual é a capacidade da máquina?";
            // 
            // MachineCapacity
            // 
            this.MachineCapacity.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            this.MachineCapacity.ForeColor = System.Drawing.SystemColors.WindowText;
            this.MachineCapacity.Location = new System.Drawing.Point(177, 129);
            this.MachineCapacity.Name = "MachineCapacity";
            this.MachineCapacity.Size = new System.Drawing.Size(62, 32);
            this.MachineCapacity.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 18F);
            this.label4.Location = new System.Drawing.Point(245, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "moedas";
            // 
            // FirstAccessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 415);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MachineCapacity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.CustomPattern);
            this.Controls.Add(this.ButtonCustomPattern);
            this.Controls.Add(this.ButtonBrazilianPattern);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FirstAccessForm";
            this.Text = "FirstAccessForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton ButtonBrazilianPattern;
        private System.Windows.Forms.RadioButton ButtonCustomPattern;
        private System.Windows.Forms.TextBox CustomPattern;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MachineCapacity;
        private System.Windows.Forms.Label label4;
    }
}