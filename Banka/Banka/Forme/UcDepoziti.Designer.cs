namespace Banka.Forme
{
    partial class UcDepoziti
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.lblNaslov = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lblFilter1 = new System.Windows.Forms.Label();
            this.cmbKlijentFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter2 = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.dgvDepoziti = new System.Windows.Forms.DataGridView();
            this.grpPodaci = new System.Windows.Forms.GroupBox();
            this.lblC0_0 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblC0_1 = new System.Windows.Forms.Label();
            this.cmbKlijent = new System.Windows.Forms.ComboBox();
            this.lblC0_2 = new System.Windows.Forms.Label();
            this.cmbRacun = new System.Windows.Forms.ComboBox();
            this.lblC0_3 = new System.Windows.Forms.Label();
            this.txtIznos = new System.Windows.Forms.TextBox();
            this.lblC0_4 = new System.Windows.Forms.Label();
            this.cmbValuta = new System.Windows.Forms.ComboBox();
            this.lblC1_0 = new System.Windows.Forms.Label();
            this.txtKamatnaStopa = new System.Windows.Forms.TextBox();
            this.lblC1_1 = new System.Windows.Forms.Label();
            this.txtPeriodOrocenja = new System.Windows.Forms.TextBox();
            this.lblC1_2 = new System.Windows.Forms.Label();
            this.dtpDatumPocetka = new System.Windows.Forms.DateTimePicker();
            this.lblC1_3 = new System.Windows.Forms.Label();
            this.dtpDatumIsteka = new System.Windows.Forms.DateTimePicker();
            this.lblC2_0 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblC2_1 = new System.Windows.Forms.Label();
            this.txtOcekivanaKamata = new System.Windows.Forms.TextBox();
            this.lblC2_2 = new System.Windows.Forms.Label();
            this.txtKomentar = new System.Windows.Forms.TextBox();
            this.btnNovi = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepoziti)).BeginInit();
            this.grpPodaci.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNaslov
            // 
            this.lblNaslov.AutoSize = true;
            this.lblNaslov.Font = new System.Drawing.Font("Segoe UI", 18.26866F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNaslov.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(72)))), ((int)(((byte)(106)))));
            this.lblNaslov.Location = new System.Drawing.Point(25, 18);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.Size = new System.Drawing.Size(177, 47);
            this.lblNaslov.TabIndex = 0;
            this.lblNaslov.Text = "DEPOZITI";
            // 
            // panelFilter
            // 
            this.panelFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilter.Controls.Add(this.lblFilter1);
            this.panelFilter.Controls.Add(this.cmbKlijentFilter);
            this.panelFilter.Controls.Add(this.lblFilter2);
            this.panelFilter.Controls.Add(this.cmbStatusFilter);
            this.panelFilter.Location = new System.Drawing.Point(25, 68);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(1050, 55);
            this.panelFilter.TabIndex = 1;
            // 
            // lblFilter1
            // 
            this.lblFilter1.AutoSize = true;
            this.lblFilter1.Location = new System.Drawing.Point(14, 18);
            this.lblFilter1.Name = "lblFilter1";
            this.lblFilter1.Size = new System.Drawing.Size(57, 23);
            this.lblFilter1.TabIndex = 0;
            this.lblFilter1.Text = "Klijent";
            // 
            // cmbKlijentFilter
            // 
            this.cmbKlijentFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKlijentFilter.FormattingEnabled = true;
            this.cmbKlijentFilter.Location = new System.Drawing.Point(88, 14);
            this.cmbKlijentFilter.Name = "cmbKlijentFilter";
            this.cmbKlijentFilter.Size = new System.Drawing.Size(180, 31);
            this.cmbKlijentFilter.TabIndex = 1;
            // 
            // lblFilter2
            // 
            this.lblFilter2.AutoSize = true;
            this.lblFilter2.Location = new System.Drawing.Point(294, 18);
            this.lblFilter2.Name = "lblFilter2";
            this.lblFilter2.Size = new System.Drawing.Size(56, 23);
            this.lblFilter2.TabIndex = 2;
            this.lblFilter2.Text = "Status";
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Items.AddRange(new object[] {
            "Svi",
            "Aktivan",
            "Istekao",
            "Zatvoren"});
            this.cmbStatusFilter.Location = new System.Drawing.Point(364, 14);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(160, 31);
            this.cmbStatusFilter.TabIndex = 3;
            // 
            // dgvDepoziti
            // 
            this.dgvDepoziti.AllowUserToAddRows = false;
            this.dgvDepoziti.AllowUserToDeleteRows = false;
            this.dgvDepoziti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDepoziti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepoziti.BackgroundColor = System.Drawing.Color.White;
            this.dgvDepoziti.ColumnHeadersHeight = 32;
            this.dgvDepoziti.Location = new System.Drawing.Point(25, 135);
            this.dgvDepoziti.Name = "dgvDepoziti";
            this.dgvDepoziti.ReadOnly = true;
            this.dgvDepoziti.RowHeadersVisible = false;
            this.dgvDepoziti.RowHeadersWidth = 57;
            this.dgvDepoziti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepoziti.Size = new System.Drawing.Size(1050, 210);
            this.dgvDepoziti.TabIndex = 2;
            // 
            // grpPodaci
            // 
            this.grpPodaci.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPodaci.Controls.Add(this.lblC0_0);
            this.grpPodaci.Controls.Add(this.txtId);
            this.grpPodaci.Controls.Add(this.lblC0_1);
            this.grpPodaci.Controls.Add(this.cmbKlijent);
            this.grpPodaci.Controls.Add(this.lblC0_2);
            this.grpPodaci.Controls.Add(this.cmbRacun);
            this.grpPodaci.Controls.Add(this.lblC0_3);
            this.grpPodaci.Controls.Add(this.txtIznos);
            this.grpPodaci.Controls.Add(this.lblC0_4);
            this.grpPodaci.Controls.Add(this.cmbValuta);
            this.grpPodaci.Controls.Add(this.lblC1_0);
            this.grpPodaci.Controls.Add(this.txtKamatnaStopa);
            this.grpPodaci.Controls.Add(this.lblC1_1);
            this.grpPodaci.Controls.Add(this.txtPeriodOrocenja);
            this.grpPodaci.Controls.Add(this.lblC1_2);
            this.grpPodaci.Controls.Add(this.dtpDatumPocetka);
            this.grpPodaci.Controls.Add(this.lblC1_3);
            this.grpPodaci.Controls.Add(this.dtpDatumIsteka);
            this.grpPodaci.Controls.Add(this.lblC2_0);
            this.grpPodaci.Controls.Add(this.cmbStatus);
            this.grpPodaci.Controls.Add(this.lblC2_1);
            this.grpPodaci.Controls.Add(this.txtOcekivanaKamata);
            this.grpPodaci.Controls.Add(this.lblC2_2);
            this.grpPodaci.Controls.Add(this.txtKomentar);
            this.grpPodaci.Controls.Add(this.btnNovi);
            this.grpPodaci.Controls.Add(this.btnIzmeni);
            this.grpPodaci.Controls.Add(this.btnObrisi);
            this.grpPodaci.Controls.Add(this.btnSacuvaj);
            this.grpPodaci.Controls.Add(this.btnOdustani);
            this.grpPodaci.Location = new System.Drawing.Point(25, 360);
            this.grpPodaci.Name = "grpPodaci";
            this.grpPodaci.Size = new System.Drawing.Size(1050, 305);
            this.grpPodaci.TabIndex = 3;
            this.grpPodaci.TabStop = false;
            this.grpPodaci.Text = "Podaci o depozitu";
            // 
            // lblC0_0
            // 
            this.lblC0_0.AutoSize = true;
            this.lblC0_0.Location = new System.Drawing.Point(20, 38);
            this.lblC0_0.Name = "lblC0_0";
            this.lblC0_0.Size = new System.Drawing.Size(27, 23);
            this.lblC0_0.TabIndex = 0;
            this.lblC0_0.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(160, 34);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(165, 30);
            this.txtId.TabIndex = 1;
            // 
            // lblC0_1
            // 
            this.lblC0_1.AutoSize = true;
            this.lblC0_1.Location = new System.Drawing.Point(20, 74);
            this.lblC0_1.Name = "lblC0_1";
            this.lblC0_1.Size = new System.Drawing.Size(57, 23);
            this.lblC0_1.TabIndex = 2;
            this.lblC0_1.Text = "Klijent";
            // 
            // cmbKlijent
            // 
            this.cmbKlijent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKlijent.FormattingEnabled = true;
            this.cmbKlijent.Location = new System.Drawing.Point(160, 70);
            this.cmbKlijent.Name = "cmbKlijent";
            this.cmbKlijent.Size = new System.Drawing.Size(165, 31);
            this.cmbKlijent.TabIndex = 3;
            // 
            // lblC0_2
            // 
            this.lblC0_2.AutoSize = true;
            this.lblC0_2.Location = new System.Drawing.Point(20, 110);
            this.lblC0_2.Name = "lblC0_2";
            this.lblC0_2.Size = new System.Drawing.Size(57, 23);
            this.lblC0_2.TabIndex = 4;
            this.lblC0_2.Text = "Račun";
            // 
            // cmbRacun
            // 
            this.cmbRacun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRacun.FormattingEnabled = true;
            this.cmbRacun.Location = new System.Drawing.Point(160, 106);
            this.cmbRacun.Name = "cmbRacun";
            this.cmbRacun.Size = new System.Drawing.Size(165, 31);
            this.cmbRacun.TabIndex = 5;
            // 
            // lblC0_3
            // 
            this.lblC0_3.AutoSize = true;
            this.lblC0_3.Location = new System.Drawing.Point(20, 146);
            this.lblC0_3.Name = "lblC0_3";
            this.lblC0_3.Size = new System.Drawing.Size(50, 23);
            this.lblC0_3.TabIndex = 6;
            this.lblC0_3.Text = "Iznos";
            // 
            // txtIznos
            // 
            this.txtIznos.Location = new System.Drawing.Point(160, 142);
            this.txtIznos.Name = "txtIznos";
            this.txtIznos.Size = new System.Drawing.Size(165, 30);
            this.txtIznos.TabIndex = 7;
            // 
            // lblC0_4
            // 
            this.lblC0_4.AutoSize = true;
            this.lblC0_4.Location = new System.Drawing.Point(20, 182);
            this.lblC0_4.Name = "lblC0_4";
            this.lblC0_4.Size = new System.Drawing.Size(58, 23);
            this.lblC0_4.TabIndex = 8;
            this.lblC0_4.Text = "Valuta";
            // 
            // cmbValuta
            // 
            this.cmbValuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbValuta.FormattingEnabled = true;
            this.cmbValuta.Items.AddRange(new object[] {
            "RSD",
            "EUR",
            "USD",
            "CHF"});
            this.cmbValuta.Location = new System.Drawing.Point(160, 178);
            this.cmbValuta.Name = "cmbValuta";
            this.cmbValuta.Size = new System.Drawing.Size(165, 31);
            this.cmbValuta.TabIndex = 9;
            // 
            // lblC1_0
            // 
            this.lblC1_0.AutoSize = true;
            this.lblC1_0.Location = new System.Drawing.Point(355, 38);
            this.lblC1_0.Name = "lblC1_0";
            this.lblC1_0.Size = new System.Drawing.Size(125, 23);
            this.lblC1_0.TabIndex = 10;
            this.lblC1_0.Text = "Kamatna stopa";
            // 
            // txtKamatnaStopa
            // 
            this.txtKamatnaStopa.Location = new System.Drawing.Point(500, 34);
            this.txtKamatnaStopa.Name = "txtKamatnaStopa";
            this.txtKamatnaStopa.Size = new System.Drawing.Size(155, 30);
            this.txtKamatnaStopa.TabIndex = 11;
            // 
            // lblC1_1
            // 
            this.lblC1_1.AutoSize = true;
            this.lblC1_1.Location = new System.Drawing.Point(355, 74);
            this.lblC1_1.Name = "lblC1_1";
            this.lblC1_1.Size = new System.Drawing.Size(129, 23);
            this.lblC1_1.TabIndex = 12;
            this.lblC1_1.Text = "Period oročenja";
            // 
            // txtPeriodOrocenja
            // 
            this.txtPeriodOrocenja.Location = new System.Drawing.Point(500, 70);
            this.txtPeriodOrocenja.Name = "txtPeriodOrocenja";
            this.txtPeriodOrocenja.Size = new System.Drawing.Size(155, 30);
            this.txtPeriodOrocenja.TabIndex = 13;
            // 
            // lblC1_2
            // 
            this.lblC1_2.AutoSize = true;
            this.lblC1_2.Location = new System.Drawing.Point(355, 110);
            this.lblC1_2.Name = "lblC1_2";
            this.lblC1_2.Size = new System.Drawing.Size(127, 23);
            this.lblC1_2.TabIndex = 14;
            this.lblC1_2.Text = "Datum početka";
            // 
            // dtpDatumPocetka
            // 
            this.dtpDatumPocetka.CustomFormat = "dd.MM.yyyy.";
            this.dtpDatumPocetka.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumPocetka.Location = new System.Drawing.Point(500, 106);
            this.dtpDatumPocetka.Name = "dtpDatumPocetka";
            this.dtpDatumPocetka.Size = new System.Drawing.Size(155, 30);
            this.dtpDatumPocetka.TabIndex = 15;
            // 
            // lblC1_3
            // 
            this.lblC1_3.AutoSize = true;
            this.lblC1_3.Location = new System.Drawing.Point(355, 146);
            this.lblC1_3.Name = "lblC1_3";
            this.lblC1_3.Size = new System.Drawing.Size(110, 23);
            this.lblC1_3.TabIndex = 16;
            this.lblC1_3.Text = "Datum isteka";
            // 
            // dtpDatumIsteka
            // 
            this.dtpDatumIsteka.CustomFormat = "dd.MM.yyyy.";
            this.dtpDatumIsteka.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumIsteka.Location = new System.Drawing.Point(500, 142);
            this.dtpDatumIsteka.Name = "dtpDatumIsteka";
            this.dtpDatumIsteka.Size = new System.Drawing.Size(155, 30);
            this.dtpDatumIsteka.TabIndex = 17;
            // 
            // lblC2_0
            // 
            this.lblC2_0.AutoSize = true;
            this.lblC2_0.Location = new System.Drawing.Point(690, 38);
            this.lblC2_0.Name = "lblC2_0";
            this.lblC2_0.Size = new System.Drawing.Size(56, 23);
            this.lblC2_0.TabIndex = 18;
            this.lblC2_0.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Aktivan",
            "Istekao",
            "Zatvoren"});
            this.cmbStatus.Location = new System.Drawing.Point(850, 34);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(155, 31);
            this.cmbStatus.TabIndex = 19;
            // 
            // lblC2_1
            // 
            this.lblC2_1.AutoSize = true;
            this.lblC2_1.Location = new System.Drawing.Point(690, 74);
            this.lblC2_1.Name = "lblC2_1";
            this.lblC2_1.Size = new System.Drawing.Size(149, 23);
            this.lblC2_1.TabIndex = 20;
            this.lblC2_1.Text = "Očekivana kamata";
            // 
            // txtOcekivanaKamata
            // 
            this.txtOcekivanaKamata.Location = new System.Drawing.Point(850, 70);
            this.txtOcekivanaKamata.Name = "txtOcekivanaKamata";
            this.txtOcekivanaKamata.Size = new System.Drawing.Size(155, 30);
            this.txtOcekivanaKamata.TabIndex = 21;
            // 
            // lblC2_2
            // 
            this.lblC2_2.AutoSize = true;
            this.lblC2_2.Location = new System.Drawing.Point(690, 110);
            this.lblC2_2.Name = "lblC2_2";
            this.lblC2_2.Size = new System.Drawing.Size(85, 23);
            this.lblC2_2.TabIndex = 22;
            this.lblC2_2.Text = "Komentar";
            // 
            // txtKomentar
            // 
            this.txtKomentar.Location = new System.Drawing.Point(850, 106);
            this.txtKomentar.Multiline = true;
            this.txtKomentar.Name = "txtKomentar";
            this.txtKomentar.Size = new System.Drawing.Size(155, 58);
            this.txtKomentar.TabIndex = 23;
            // 
            // btnNovi
            // 
            this.btnNovi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovi.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnNovi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovi.Location = new System.Drawing.Point(20, 255);
            this.btnNovi.Name = "btnNovi";
            this.btnNovi.Size = new System.Drawing.Size(90, 32);
            this.btnNovi.TabIndex = 24;
            this.btnNovi.Text = "Novi";
            this.btnNovi.UseVisualStyleBackColor = true;
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIzmeni.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnIzmeni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzmeni.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzmeni.Location = new System.Drawing.Point(120, 255);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(90, 32);
            this.btnIzmeni.TabIndex = 25;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            // 
            // btnObrisi
            // 
            this.btnObrisi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObrisi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnObrisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObrisi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnObrisi.Location = new System.Drawing.Point(220, 255);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(90, 32);
            this.btnObrisi.TabIndex = 26;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = true;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(72)))), ((int)(((byte)(106)))));
            this.btnSacuvaj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSacuvaj.FlatAppearance.BorderSize = 0;
            this.btnSacuvaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSacuvaj.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSacuvaj.ForeColor = System.Drawing.Color.White;
            this.btnSacuvaj.Location = new System.Drawing.Point(820, 255);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(90, 32);
            this.btnSacuvaj.TabIndex = 27;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = false;
            // 
            // btnOdustani
            // 
            this.btnOdustani.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOdustani.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnOdustani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdustani.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdustani.Location = new System.Drawing.Point(920, 255);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(90, 32);
            this.btnOdustani.TabIndex = 28;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            // 
            // UcDepoziti
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblNaslov);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.dgvDepoziti);
            this.Controls.Add(this.grpPodaci);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UcDepoziti";
            this.Size = new System.Drawing.Size(1100, 700);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepoziti)).EndInit();
            this.grpPodaci.ResumeLayout(false);
            this.grpPodaci.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label lblFilter1;
        private System.Windows.Forms.ComboBox cmbKlijentFilter;
        private System.Windows.Forms.Label lblFilter2;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.DataGridView dgvDepoziti;
        private System.Windows.Forms.GroupBox grpPodaci;
        private System.Windows.Forms.Label lblC0_0;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblC0_1;
        private System.Windows.Forms.ComboBox cmbKlijent;
        private System.Windows.Forms.Label lblC0_2;
        private System.Windows.Forms.ComboBox cmbRacun;
        private System.Windows.Forms.Label lblC0_3;
        private System.Windows.Forms.TextBox txtIznos;
        private System.Windows.Forms.Label lblC0_4;
        private System.Windows.Forms.ComboBox cmbValuta;
        private System.Windows.Forms.Label lblC1_0;
        private System.Windows.Forms.TextBox txtKamatnaStopa;
        private System.Windows.Forms.Label lblC1_1;
        private System.Windows.Forms.TextBox txtPeriodOrocenja;
        private System.Windows.Forms.Label lblC1_2;
        private System.Windows.Forms.DateTimePicker dtpDatumPocetka;
        private System.Windows.Forms.Label lblC1_3;
        private System.Windows.Forms.DateTimePicker dtpDatumIsteka;
        private System.Windows.Forms.Label lblC2_0;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblC2_1;
        private System.Windows.Forms.TextBox txtOcekivanaKamata;
        private System.Windows.Forms.Label lblC2_2;
        private System.Windows.Forms.TextBox txtKomentar;
        private System.Windows.Forms.Button btnNovi;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnOdustani;
    }
}
