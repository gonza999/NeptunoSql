namespace NeptunoSql.Windows
{
    partial class FrmPago
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtImporteTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVenta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImportePagado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVuelto = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Importe a Pagar : ";
            // 
            // txtImporteTotal
            // 
            this.txtImporteTotal.Enabled = false;
            this.txtImporteTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteTotal.Location = new System.Drawing.Point(248, 17);
            this.txtImporteTotal.Name = "txtImporteTotal";
            this.txtImporteTotal.Size = new System.Drawing.Size(149, 20);
            this.txtImporteTotal.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(146, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Venta Nro : ";
            // 
            // txtVenta
            // 
            this.txtVenta.Enabled = false;
            this.txtVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVenta.Location = new System.Drawing.Point(248, 43);
            this.txtVenta.Name = "txtVenta";
            this.txtVenta.Size = new System.Drawing.Size(149, 20);
            this.txtVenta.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ingrese el Importe Pagado :";
            // 
            // txtImportePagado
            // 
            this.txtImportePagado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImportePagado.Location = new System.Drawing.Point(248, 69);
            this.txtImportePagado.Name = "txtImportePagado";
            this.txtImportePagado.Size = new System.Drawing.Size(149, 20);
            this.txtImportePagado.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(146, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Su Vuelto :";
            // 
            // txtVuelto
            // 
            this.txtVuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVuelto.Location = new System.Drawing.Point(248, 95);
            this.txtVuelto.Name = "txtVuelto";
            this.txtVuelto.Size = new System.Drawing.Size(149, 20);
            this.txtVuelto.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Image = global::NeptunoSql.Windows.Properties.Resources.Aceptar;
            this.btnOk.Location = new System.Drawing.Point(126, 145);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(234, 54);
            this.btnOk.TabIndex = 24;
            this.btnOk.Text = "OK";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 233);
            this.ControlBox = false;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtVuelto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtImportePagado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVenta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtImporteTotal);
            this.Controls.Add(this.label1);
            this.Name = "FrmPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago de Venta";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImporteTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImportePagado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVuelto;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}