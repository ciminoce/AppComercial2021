
namespace AppComercial2021.Windows
{
    partial class FrmLocalidadEdit
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
            this.components = new System.ComponentModel.Container();
            this.TareaLabel = new System.Windows.Forms.Label();
            this.ProvinciasComboBox = new System.Windows.Forms.ComboBox();
            this.LocalidadTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // TareaLabel
            // 
            this.TareaLabel.BackColor = System.Drawing.Color.Teal;
            this.TareaLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TareaLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TareaLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.TareaLabel.Location = new System.Drawing.Point(0, 0);
            this.TareaLabel.Name = "TareaLabel";
            this.TareaLabel.Size = new System.Drawing.Size(486, 30);
            this.TareaLabel.TabIndex = 5;
            this.TareaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProvinciasComboBox
            // 
            this.ProvinciasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProvinciasComboBox.FormattingEnabled = true;
            this.ProvinciasComboBox.Location = new System.Drawing.Point(115, 56);
            this.ProvinciasComboBox.Name = "ProvinciasComboBox";
            this.ProvinciasComboBox.Size = new System.Drawing.Size(297, 21);
            this.ProvinciasComboBox.TabIndex = 16;
            // 
            // LocalidadTextBox
            // 
            this.LocalidadTextBox.Location = new System.Drawing.Point(115, 86);
            this.LocalidadTextBox.MaxLength = 50;
            this.LocalidadTextBox.Name = "LocalidadTextBox";
            this.LocalidadTextBox.Size = new System.Drawing.Size(297, 20);
            this.LocalidadTextBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Localidad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Provincia:";
            // 
            // OkButton
            // 
            this.OkButton.Image = global::AppComercial2021.Windows.Properties.Resources.Aceptar;
            this.OkButton.Location = new System.Drawing.Point(41, 154);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(110, 56);
            this.OkButton.TabIndex = 17;
            this.OkButton.Text = "OK";
            this.OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Image = global::AppComercial2021.Windows.Properties.Resources.Cancelar;
            this.CancelarButton.Location = new System.Drawing.Point(302, 154);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(110, 56);
            this.CancelarButton.TabIndex = 17;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmLocalidadEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 243);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.ProvinciasComboBox);
            this.Controls.Add(this.LocalidadTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TareaLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLocalidadEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLocalidadEdit";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox ProvinciasComboBox;
        private System.Windows.Forms.TextBox LocalidadTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Label TareaLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}