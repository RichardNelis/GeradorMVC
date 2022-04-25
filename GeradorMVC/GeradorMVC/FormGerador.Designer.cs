
namespace GeradorMVC
{
    partial class FormGerador
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
            this.cb_acesso = new System.Windows.Forms.ComboBox();
            this.lbl_controller = new System.Windows.Forms.Label();
            this.tb_controller = new System.Windows.Forms.TextBox();
            this.lbl_acesso = new System.Windows.Forms.Label();
            this.btn_gerar_codigo = new System.Windows.Forms.Button();
            this.lbl_pn_atributos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_sistema = new System.Windows.Forms.TextBox();
            this.tb_tabela = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dg_Atributos = new System.Windows.Forms.DataGridView();
            this.Coluna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeExibicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DataTable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Atributos)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_acesso
            // 
            this.cb_acesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_acesso.FormattingEnabled = true;
            this.cb_acesso.Items.AddRange(new object[] {
            "Contrib",
            "Pref"});
            this.cb_acesso.Location = new System.Drawing.Point(342, 32);
            this.cb_acesso.Name = "cb_acesso";
            this.cb_acesso.Size = new System.Drawing.Size(130, 23);
            this.cb_acesso.TabIndex = 1;
            // 
            // lbl_controller
            // 
            this.lbl_controller.AutoSize = true;
            this.lbl_controller.ForeColor = System.Drawing.Color.White;
            this.lbl_controller.Location = new System.Drawing.Point(13, 13);
            this.lbl_controller.Name = "lbl_controller";
            this.lbl_controller.Size = new System.Drawing.Size(60, 15);
            this.lbl_controller.TabIndex = 9;
            this.lbl_controller.Text = "Controller";
            // 
            // tb_controller
            // 
            this.tb_controller.Location = new System.Drawing.Point(13, 32);
            this.tb_controller.Name = "tb_controller";
            this.tb_controller.Size = new System.Drawing.Size(273, 23);
            this.tb_controller.TabIndex = 0;
            // 
            // lbl_acesso
            // 
            this.lbl_acesso.AutoSize = true;
            this.lbl_acesso.ForeColor = System.Drawing.Color.White;
            this.lbl_acesso.Location = new System.Drawing.Point(342, 14);
            this.lbl_acesso.Name = "lbl_acesso";
            this.lbl_acesso.Size = new System.Drawing.Size(44, 15);
            this.lbl_acesso.TabIndex = 11;
            this.lbl_acesso.Text = "Acesso";
            // 
            // btn_gerar_codigo
            // 
            this.btn_gerar_codigo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btn_gerar_codigo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_gerar_codigo.Location = new System.Drawing.Point(368, 343);
            this.btn_gerar_codigo.Name = "btn_gerar_codigo";
            this.btn_gerar_codigo.Size = new System.Drawing.Size(164, 23);
            this.btn_gerar_codigo.TabIndex = 5;
            this.btn_gerar_codigo.Text = "Gerar Código";
            this.btn_gerar_codigo.UseVisualStyleBackColor = false;
            this.btn_gerar_codigo.Click += new System.EventHandler(this.Btn_gerar_codigo_Click);
            // 
            // lbl_pn_atributos
            // 
            this.lbl_pn_atributos.AutoSize = true;
            this.lbl_pn_atributos.ForeColor = System.Drawing.Color.White;
            this.lbl_pn_atributos.Location = new System.Drawing.Point(14, 82);
            this.lbl_pn_atributos.Name = "lbl_pn_atributos";
            this.lbl_pn_atributos.Size = new System.Drawing.Size(56, 15);
            this.lbl_pn_atributos.TabIndex = 22;
            this.lbl_pn_atributos.Text = "Atributos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(541, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Sistema";
            // 
            // tb_sistema
            // 
            this.tb_sistema.Location = new System.Drawing.Point(541, 32);
            this.tb_sistema.Name = "tb_sistema";
            this.tb_sistema.Size = new System.Drawing.Size(130, 23);
            this.tb_sistema.TabIndex = 2;
            // 
            // tb_tabela
            // 
            this.tb_tabela.Location = new System.Drawing.Point(725, 32);
            this.tb_tabela.Name = "tb_tabela";
            this.tb_tabela.Size = new System.Drawing.Size(130, 23);
            this.tb_tabela.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(725, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 27;
            this.label2.Text = "Tabela";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label3.Location = new System.Drawing.Point(93, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "Não é necessário adicionar o atributo ID";
            // 
            // dg_Atributos
            // 
            this.dg_Atributos.AllowUserToOrderColumns = true;
            this.dg_Atributos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Atributos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Coluna,
            this.Nome,
            this.NomeExibicao,
            this.Tipo,
            this.DataTable});
            this.dg_Atributos.Location = new System.Drawing.Point(13, 100);
            this.dg_Atributos.Name = "dg_Atributos";
            this.dg_Atributos.RowTemplate.Height = 25;
            this.dg_Atributos.Size = new System.Drawing.Size(843, 235);
            this.dg_Atributos.TabIndex = 4;
            // 
            // Coluna
            // 
            this.Coluna.HeaderText = "Coluna";
            this.Coluna.Name = "Coluna";
            this.Coluna.Width = 150;
            // 
            // Nome
            // 
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.Width = 300;
            // 
            // NomeExibicao
            // 
            this.NomeExibicao.HeaderText = "Nome Exibição";
            this.NomeExibicao.Name = "NomeExibicao";
            this.NomeExibicao.Width = 150;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Items.AddRange(new object[] {
            "String",
            "int",
            "decimal",
            "DateTime"});
            this.Tipo.Name = "Tipo";
            this.Tipo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DataTable
            // 
            this.DataTable.FalseValue = "0";
            this.DataTable.HeaderText = "DataTable";
            this.DataTable.IndeterminateValue = "0";
            this.DataTable.Name = "DataTable";
            this.DataTable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataTable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DataTable.TrueValue = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(684, 371);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 15);
            this.label4.TabIndex = 29;
            this.label4.Text = "Desenvolvido por Richard Nelis";
            // 
            // FormGerador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(868, 395);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_tabela);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_sistema);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dg_Atributos);
            this.Controls.Add(this.lbl_pn_atributos);
            this.Controls.Add(this.btn_gerar_codigo);
            this.Controls.Add(this.lbl_acesso);
            this.Controls.Add(this.tb_controller);
            this.Controls.Add(this.lbl_controller);
            this.Controls.Add(this.cb_acesso);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGerador";
            this.Text = "Gerador Códigio - MVC";
            ((System.ComponentModel.ISupportInitialize)(this.dg_Atributos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cb_acesso;
        private System.Windows.Forms.Label lbl_controller;
        private System.Windows.Forms.TextBox tb_controller;
        private System.Windows.Forms.Label lbl_acesso;
        private System.Windows.Forms.Button btn_gerar_codigo;
        private System.Windows.Forms.Label lbl_pn_atributos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_sistema;
        private System.Windows.Forms.TextBox tb_tabela;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dg_Atributos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coluna;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeExibicao;
        private System.Windows.Forms.DataGridViewComboBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DataTable;
        private System.Windows.Forms.Label label4;
    }
}

