namespace Banka.Forme
{
    partial class UcTransakcije
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
            this.cmbRacunFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter2 = new System.Windows.Forms.Label();
            this.cmbTipFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter3 = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.dgvTransakcije = new System.Windows.Forms.DataGridView();
            this.KodTransakcije = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipTransakcije = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Posiljaoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Primalac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iznos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valuta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vreme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpPodaci = new System.Windows.Forms.GroupBox();
            this.lblC0_0 = new System.Windows.Forms.Label();
            this.txtKod = new System.Windows.Forms.TextBox();
            this.lblC0_1 = new System.Windows.Forms.Label();
            this.cmbRacun = new System.Windows.Forms.ComboBox();
            this.lblC0_2 = new System.Windows.Forms.Label();
            this.cmbTip = new System.Windows.Forms.ComboBox();
            this.lblC0_3 = new System.Windows.Forms.Label();
            this.txtIznos = new System.Windows.Forms.TextBox();
            this.lblC0_4 = new System.Windows.Forms.Label();
            this.cmbValuta = new System.Windows.Forms.ComboBox();
            this.lblC1_0 = new System.Windows.Forms.Label();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.lblC1_1 = new System.Windows.Forms.Label();
            this.txtVreme = new System.Windows.Forms.TextBox();
            this.lblC1_2 = new System.Windows.Forms.Label();
            this.txtPrimalac = new System.Windows.Forms.TextBox();
            this.lblC1_3 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblC1_4 = new System.Windows.Forms.Label();
            this.txtReferenca = new System.Windows.Forms.TextBox();
            this.lblC2_0 = new System.Windows.Forms.Label();
            this.cmbPoticeSa = new System.Windows.Forms.ComboBox();
            this.lblC2_1 = new System.Windows.Forms.Label();
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.lblC2_2 = new System.Windows.Forms.Label();
            this.txtKomentar = new System.Windows.Forms.TextBox();
            this.btnNovi = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransakcije)).BeginInit();
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
            this.lblNaslov.Size = new System.Drawing.Size(179, 35);
            this.lblNaslov.TabIndex = 0;
            this.lblNaslov.Text = "TRANSAKCIJE";
            // 
            // panelFilter
            // 
            this.panelFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilter.Controls.Add(this.lblFilter1);
            this.panelFilter.Controls.Add(this.cmbRacunFilter);
            this.panelFilter.Controls.Add(this.lblFilter2);
            this.panelFilter.Controls.Add(this.cmbTipFilter);
            this.panelFilter.Controls.Add(this.lblFilter3);
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
            this.lblFilter1.Size = new System.Drawing.Size(40, 15);
            this.lblFilter1.TabIndex = 0;
            this.lblFilter1.Text = "Račun";
            // 
            // cmbRacunFilter
            // 
            this.cmbRacunFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRacunFilter.FormattingEnabled = true;
            this.cmbRacunFilter.Location = new System.Drawing.Point(84, 14);
            this.cmbRacunFilter.Name = "cmbRacunFilter";
            this.cmbRacunFilter.Size = new System.Drawing.Size(150, 23);
            this.cmbRacunFilter.TabIndex = 1;
            // 
            // lblFilter2
            // 
            this.lblFilter2.AutoSize = true;
            this.lblFilter2.Location = new System.Drawing.Point(260, 18);
            this.lblFilter2.Name = "lblFilter2";
            this.lblFilter2.Size = new System.Drawing.Size(24, 15);
            this.lblFilter2.TabIndex = 2;
            this.lblFilter2.Text = "Tip";
            // 
            // cmbTipFilter
            // 
            this.cmbTipFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipFilter.FormattingEnabled = true;
            this.cmbTipFilter.Items.AddRange(new object[] {
            "Svi",
            "Uplata",
            "Isplata",
            "Transfer",
            "Plaćanje računa",
            "Konverzija"});
            this.cmbTipFilter.Location = new System.Drawing.Point(330, 14);
            this.cmbTipFilter.Name = "cmbTipFilter";
            this.cmbTipFilter.Size = new System.Drawing.Size(160, 23);
            this.cmbTipFilter.TabIndex = 3;
            // 
            // lblFilter3
            // 
            this.lblFilter3.AutoSize = true;
            this.lblFilter3.Location = new System.Drawing.Point(516, 18);
            this.lblFilter3.Name = "lblFilter3";
            this.lblFilter3.Size = new System.Drawing.Size(39, 15);
            this.lblFilter3.TabIndex = 4;
            this.lblFilter3.Text = "Status";
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Items.AddRange(new object[] {
            "Svi",
            "Odobrena",
            "Odbijena"});
            this.cmbStatusFilter.Location = new System.Drawing.Point(586, 14);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(150, 23);
            this.cmbStatusFilter.TabIndex = 5;
            // 
            // dgvTransakcije
            // 
            this.dgvTransakcije.AllowUserToAddRows = false;
            this.dgvTransakcije.AllowUserToDeleteRows = false;
            this.dgvTransakcije.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransakcije.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransakcije.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransakcije.ColumnHeadersHeight = 32;
            this.dgvTransakcije.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KodTransakcije,
            this.TipTransakcije,
            this.Posiljaoc,
            this.Primalac,
            this.Iznos,
            this.Valuta,
            this.Status,
            this.Datum,
            this.Vreme});
            this.dgvTransakcije.Location = new System.Drawing.Point(25, 135);
            this.dgvTransakcije.Name = "dgvTransakcije";
            this.dgvTransakcije.ReadOnly = true;
            this.dgvTransakcije.RowHeadersVisible = false;
            this.dgvTransakcije.RowHeadersWidth = 57;
            this.dgvTransakcije.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransakcije.Size = new System.Drawing.Size(1050, 210);
            this.dgvTransakcije.TabIndex = 2;
            this.dgvTransakcije.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransakcije_CellClick);
            // 
            // KodTransakcije
            // 
            this.KodTransakcije.HeaderText = "KodTransakcije";
            this.KodTransakcije.Name = "KodTransakcije";
            this.KodTransakcije.ReadOnly = true;
            // 
            // TipTransakcije
            // 
            this.TipTransakcije.HeaderText = "TipTransakcije";
            this.TipTransakcije.Name = "TipTransakcije";
            this.TipTransakcije.ReadOnly = true;
            // 
            // Posiljaoc
            // 
            this.Posiljaoc.HeaderText = "Posiljaoc";
            this.Posiljaoc.Name = "Posiljaoc";
            this.Posiljaoc.ReadOnly = true;
            // 
            // Primalac
            // 
            this.Primalac.HeaderText = "Primalac";
            this.Primalac.Name = "Primalac";
            this.Primalac.ReadOnly = true;
            // 
            // Iznos
            // 
            this.Iznos.HeaderText = "Iznos";
            this.Iznos.Name = "Iznos";
            this.Iznos.ReadOnly = true;
            // 
            // Valuta
            // 
            this.Valuta.HeaderText = "Valuta";
            this.Valuta.Name = "Valuta";
            this.Valuta.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Datum
            // 
            this.Datum.HeaderText = "Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            // 
            // Vreme
            // 
            this.Vreme.HeaderText = "Vreme";
            this.Vreme.Name = "Vreme";
            this.Vreme.ReadOnly = true;
            // 
            // grpPodaci
            // 
            this.grpPodaci.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPodaci.Controls.Add(this.lblC0_0);
            this.grpPodaci.Controls.Add(this.txtKod);
            this.grpPodaci.Controls.Add(this.lblC0_1);
            this.grpPodaci.Controls.Add(this.cmbRacun);
            this.grpPodaci.Controls.Add(this.lblC0_2);
            this.grpPodaci.Controls.Add(this.cmbTip);
            this.grpPodaci.Controls.Add(this.lblC0_3);
            this.grpPodaci.Controls.Add(this.txtIznos);
            this.grpPodaci.Controls.Add(this.lblC0_4);
            this.grpPodaci.Controls.Add(this.cmbValuta);
            this.grpPodaci.Controls.Add(this.lblC1_0);
            this.grpPodaci.Controls.Add(this.dtpDatum);
            this.grpPodaci.Controls.Add(this.lblC1_1);
            this.grpPodaci.Controls.Add(this.txtVreme);
            this.grpPodaci.Controls.Add(this.lblC1_2);
            this.grpPodaci.Controls.Add(this.txtPrimalac);
            this.grpPodaci.Controls.Add(this.lblC1_3);
            this.grpPodaci.Controls.Add(this.cmbStatus);
            this.grpPodaci.Controls.Add(this.lblC1_4);
            this.grpPodaci.Controls.Add(this.txtReferenca);
            this.grpPodaci.Controls.Add(this.lblC2_0);
            this.grpPodaci.Controls.Add(this.cmbPoticeSa);
            this.grpPodaci.Controls.Add(this.lblC2_1);
            this.grpPodaci.Controls.Add(this.txtOpis);
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
            this.grpPodaci.Text = "Podaci o transakciji";
            // 
            // lblC0_0
            // 
            this.lblC0_0.AutoSize = true;
            this.lblC0_0.Location = new System.Drawing.Point(20, 38);
            this.lblC0_0.Name = "lblC0_0";
            this.lblC0_0.Size = new System.Drawing.Size(87, 15);
            this.lblC0_0.TabIndex = 0;
            this.lblC0_0.Text = "Kod transakcije";
            // 
            // txtKod
            // 
            this.txtKod.Location = new System.Drawing.Point(160, 34);
            this.txtKod.Name = "txtKod";
            this.txtKod.Size = new System.Drawing.Size(165, 23);
            this.txtKod.TabIndex = 1;
            // 
            // lblC0_1
            // 
            this.lblC0_1.AutoSize = true;
            this.lblC0_1.Location = new System.Drawing.Point(20, 74);
            this.lblC0_1.Name = "lblC0_1";
            this.lblC0_1.Size = new System.Drawing.Size(40, 15);
            this.lblC0_1.TabIndex = 2;
            this.lblC0_1.Text = "Račun";
            // 
            // cmbRacun
            // 
            this.cmbRacun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRacun.FormattingEnabled = true;
            this.cmbRacun.Location = new System.Drawing.Point(160, 70);
            this.cmbRacun.Name = "cmbRacun";
            this.cmbRacun.Size = new System.Drawing.Size(165, 23);
            this.cmbRacun.TabIndex = 3;
            // 
            // lblC0_2
            // 
            this.lblC0_2.AutoSize = true;
            this.lblC0_2.Location = new System.Drawing.Point(20, 110);
            this.lblC0_2.Name = "lblC0_2";
            this.lblC0_2.Size = new System.Drawing.Size(83, 15);
            this.lblC0_2.TabIndex = 4;
            this.lblC0_2.Text = "Tip transakcije";
            // 
            // cmbTip
            // 
            this.cmbTip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTip.FormattingEnabled = true;
            this.cmbTip.Items.AddRange(new object[] {
            "Uplata",
            "Isplata",
            "Transfer",
            "Plaćanje računa",
            "Konverzija"});
            this.cmbTip.Location = new System.Drawing.Point(160, 106);
            this.cmbTip.Name = "cmbTip";
            this.cmbTip.Size = new System.Drawing.Size(165, 23);
            this.cmbTip.TabIndex = 5;
            // 
            // lblC0_3
            // 
            this.lblC0_3.AutoSize = true;
            this.lblC0_3.Location = new System.Drawing.Point(20, 146);
            this.lblC0_3.Name = "lblC0_3";
            this.lblC0_3.Size = new System.Drawing.Size(34, 15);
            this.lblC0_3.TabIndex = 6;
            this.lblC0_3.Text = "Iznos";
            // 
            // txtIznos
            // 
            this.txtIznos.Location = new System.Drawing.Point(160, 142);
            this.txtIznos.Name = "txtIznos";
            this.txtIznos.Size = new System.Drawing.Size(165, 23);
            this.txtIznos.TabIndex = 7;
            // 
            // lblC0_4
            // 
            this.lblC0_4.AutoSize = true;
            this.lblC0_4.Location = new System.Drawing.Point(20, 182);
            this.lblC0_4.Name = "lblC0_4";
            this.lblC0_4.Size = new System.Drawing.Size(39, 15);
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
            this.cmbValuta.Size = new System.Drawing.Size(165, 23);
            this.cmbValuta.TabIndex = 9;
            // 
            // lblC1_0
            // 
            this.lblC1_0.AutoSize = true;
            this.lblC1_0.Location = new System.Drawing.Point(355, 38);
            this.lblC1_0.Name = "lblC1_0";
            this.lblC1_0.Size = new System.Drawing.Size(43, 15);
            this.lblC1_0.TabIndex = 10;
            this.lblC1_0.Text = "Datum";
            // 
            // dtpDatum
            // 
            this.dtpDatum.CustomFormat = "dd.MM.yyyy.";
            this.dtpDatum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatum.Location = new System.Drawing.Point(500, 34);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(155, 23);
            this.dtpDatum.TabIndex = 11;
            // 
            // lblC1_1
            // 
            this.lblC1_1.AutoSize = true;
            this.lblC1_1.Location = new System.Drawing.Point(355, 74);
            this.lblC1_1.Name = "lblC1_1";
            this.lblC1_1.Size = new System.Drawing.Size(41, 15);
            this.lblC1_1.TabIndex = 12;
            this.lblC1_1.Text = "Vreme";
            // 
            // txtVreme
            // 
            this.txtVreme.Location = new System.Drawing.Point(500, 70);
            this.txtVreme.Name = "txtVreme";
            this.txtVreme.Size = new System.Drawing.Size(155, 23);
            this.txtVreme.TabIndex = 13;
            // 
            // lblC1_2
            // 
            this.lblC1_2.AutoSize = true;
            this.lblC1_2.Location = new System.Drawing.Point(355, 110);
            this.lblC1_2.Name = "lblC1_2";
            this.lblC1_2.Size = new System.Drawing.Size(53, 15);
            this.lblC1_2.TabIndex = 14;
            this.lblC1_2.Text = "Primalac";
            // 
            // txtPrimalac
            // 
            this.txtPrimalac.Location = new System.Drawing.Point(500, 106);
            this.txtPrimalac.Name = "txtPrimalac";
            this.txtPrimalac.Size = new System.Drawing.Size(155, 23);
            this.txtPrimalac.TabIndex = 15;
            // 
            // lblC1_3
            // 
            this.lblC1_3.AutoSize = true;
            this.lblC1_3.Location = new System.Drawing.Point(355, 146);
            this.lblC1_3.Name = "lblC1_3";
            this.lblC1_3.Size = new System.Drawing.Size(39, 15);
            this.lblC1_3.TabIndex = 16;
            this.lblC1_3.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Odobrena",
            "Odbijena"});
            this.cmbStatus.Location = new System.Drawing.Point(500, 142);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(155, 23);
            this.cmbStatus.TabIndex = 17;
            // 
            // lblC1_4
            // 
            this.lblC1_4.AutoSize = true;
            this.lblC1_4.Location = new System.Drawing.Point(355, 182);
            this.lblC1_4.Name = "lblC1_4";
            this.lblC1_4.Size = new System.Drawing.Size(59, 15);
            this.lblC1_4.TabIndex = 18;
            this.lblC1_4.Text = "Referenca";
            // 
            // txtReferenca
            // 
            this.txtReferenca.Location = new System.Drawing.Point(500, 178);
            this.txtReferenca.Name = "txtReferenca";
            this.txtReferenca.Size = new System.Drawing.Size(155, 23);
            this.txtReferenca.TabIndex = 19;
            // 
            // lblC2_0
            // 
            this.lblC2_0.AutoSize = true;
            this.lblC2_0.Location = new System.Drawing.Point(690, 38);
            this.lblC2_0.Name = "lblC2_0";
            this.lblC2_0.Size = new System.Drawing.Size(93, 15);
            this.lblC2_0.TabIndex = 20;
            this.lblC2_0.Text = "Potiče sa računa";
            // 
            // cmbPoticeSa
            // 
            this.cmbPoticeSa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPoticeSa.FormattingEnabled = true;
            this.cmbPoticeSa.Location = new System.Drawing.Point(850, 34);
            this.cmbPoticeSa.Name = "cmbPoticeSa";
            this.cmbPoticeSa.Size = new System.Drawing.Size(155, 23);
            this.cmbPoticeSa.TabIndex = 21;
            // 
            // lblC2_1
            // 
            this.lblC2_1.AutoSize = true;
            this.lblC2_1.Location = new System.Drawing.Point(690, 74);
            this.lblC2_1.Name = "lblC2_1";
            this.lblC2_1.Size = new System.Drawing.Size(31, 15);
            this.lblC2_1.TabIndex = 22;
            this.lblC2_1.Text = "Opis";
            // 
            // txtOpis
            // 
            this.txtOpis.Location = new System.Drawing.Point(850, 70);
            this.txtOpis.Multiline = true;
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(155, 50);
            this.txtOpis.TabIndex = 23;
            // 
            // lblC2_2
            // 
            this.lblC2_2.AutoSize = true;
            this.lblC2_2.Location = new System.Drawing.Point(690, 132);
            this.lblC2_2.Name = "lblC2_2";
            this.lblC2_2.Size = new System.Drawing.Size(59, 15);
            this.lblC2_2.TabIndex = 24;
            this.lblC2_2.Text = "Komentar";
            // 
            // txtKomentar
            // 
            this.txtKomentar.Location = new System.Drawing.Point(850, 128);
            this.txtKomentar.Multiline = true;
            this.txtKomentar.Name = "txtKomentar";
            this.txtKomentar.Size = new System.Drawing.Size(155, 50);
            this.txtKomentar.TabIndex = 25;
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
            this.btnNovi.TabIndex = 26;
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
            this.btnIzmeni.TabIndex = 27;
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
            this.btnObrisi.TabIndex = 28;
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
            this.btnSacuvaj.TabIndex = 29;
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
            this.btnOdustani.TabIndex = 30;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            // 
            // UcTransakcije
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblNaslov);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.dgvTransakcije);
            this.Controls.Add(this.grpPodaci);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UcTransakcije";
            this.Size = new System.Drawing.Size(1100, 700);
            this.Load += new System.EventHandler(this.UcTransakcije_Load_1);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransakcije)).EndInit();
            this.grpPodaci.ResumeLayout(false);
            this.grpPodaci.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label lblFilter1;
        private System.Windows.Forms.ComboBox cmbRacunFilter;
        private System.Windows.Forms.Label lblFilter2;
        private System.Windows.Forms.ComboBox cmbTipFilter;
        private System.Windows.Forms.Label lblFilter3;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.DataGridView dgvTransakcije;
        private System.Windows.Forms.GroupBox grpPodaci;
        private System.Windows.Forms.Label lblC0_0;
        private System.Windows.Forms.TextBox txtKod;
        private System.Windows.Forms.Label lblC0_1;
        private System.Windows.Forms.ComboBox cmbRacun;
        private System.Windows.Forms.Label lblC0_2;
        private System.Windows.Forms.ComboBox cmbTip;
        private System.Windows.Forms.Label lblC0_3;
        private System.Windows.Forms.TextBox txtIznos;
        private System.Windows.Forms.Label lblC0_4;
        private System.Windows.Forms.ComboBox cmbValuta;
        private System.Windows.Forms.Label lblC1_0;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.Label lblC1_1;
        private System.Windows.Forms.TextBox txtVreme;
        private System.Windows.Forms.Label lblC1_2;
        private System.Windows.Forms.TextBox txtPrimalac;
        private System.Windows.Forms.Label lblC1_3;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblC1_4;
        private System.Windows.Forms.TextBox txtReferenca;
        private System.Windows.Forms.Label lblC2_0;
        private System.Windows.Forms.ComboBox cmbPoticeSa;
        private System.Windows.Forms.Label lblC2_1;
        private System.Windows.Forms.TextBox txtOpis;
        private System.Windows.Forms.Label lblC2_2;
        private System.Windows.Forms.TextBox txtKomentar;
        private System.Windows.Forms.Button btnNovi;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodTransakcije;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipTransakcije;
        private System.Windows.Forms.DataGridViewTextBoxColumn Posiljaoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Primalac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iznos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valuta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vreme;
    }
}
