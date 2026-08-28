namespace Banka.Forme
{
    partial class UcKamate
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
            this.cmbPredmetFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter2 = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.dgvKamate = new System.Windows.Forms.DataGridView();
            this.grpPodaci = new System.Windows.Forms.GroupBox();
            this.lblC0_0 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblC0_1 = new System.Windows.Forms.Label();
            this.cmbPredmet = new System.Windows.Forms.ComboBox();
            this.lblC0_2 = new System.Windows.Forms.Label();
            this.cmbKonkretanPredmet = new System.Windows.Forms.ComboBox();
            this.lblC1_0 = new System.Windows.Forms.Label();
            this.cmbTipKamate = new System.Windows.Forms.ComboBox();
            this.lblC1_1 = new System.Windows.Forms.Label();
            this.txtIznosKamate = new System.Windows.Forms.TextBox();
            this.lblC1_2 = new System.Windows.Forms.Label();
            this.txtPeriodObracuna = new System.Windows.Forms.TextBox();
            this.lblC2_0 = new System.Windows.Forms.Label();
            this.dtpDatumObracuna = new System.Windows.Forms.DateTimePicker();
            this.lblC2_1 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnNovi = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPredmet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKonkretanPredmet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipKamate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIznos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKamate)).BeginInit();
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
            this.lblNaslov.Size = new System.Drawing.Size(165, 47);
            this.lblNaslov.TabIndex = 0;
            this.lblNaslov.Text = "KAMATE";
            // 
            // panelFilter
            // 
            this.panelFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilter.Controls.Add(this.lblFilter1);
            this.panelFilter.Controls.Add(this.cmbPredmetFilter);
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
            this.lblFilter1.Size = new System.Drawing.Size(75, 23);
            this.lblFilter1.TabIndex = 0;
            this.lblFilter1.Text = "Predmet";
            // 
            // cmbPredmetFilter
            // 
            this.cmbPredmetFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPredmetFilter.FormattingEnabled = true;
            this.cmbPredmetFilter.Items.AddRange(new object[] {
            "Svi",
            "Račun",
            "Kredit",
            "Depozit"});
            this.cmbPredmetFilter.Location = new System.Drawing.Point(88, 14);
            this.cmbPredmetFilter.Name = "cmbPredmetFilter";
            this.cmbPredmetFilter.Size = new System.Drawing.Size(180, 31);
            this.cmbPredmetFilter.TabIndex = 1;
            this.cmbPredmetFilter.SelectedIndexChanged += new System.EventHandler(this.cmbPredmetFilter_SelectedIndexChanged);
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
            "Obračunato",
            "Isplaćeno",
            "Kapitalizovano"});
            this.cmbStatusFilter.Location = new System.Drawing.Point(364, 14);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(160, 31);
            this.cmbStatusFilter.TabIndex = 3;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cmbStatusFilter_SelectedIndexChanged);
            // 
            // dgvKamate
            // 
            this.dgvKamate.AllowUserToAddRows = false;
            this.dgvKamate.AllowUserToDeleteRows = false;
            this.dgvKamate.AllowUserToResizeColumns = false;
            this.dgvKamate.AllowUserToResizeRows = false;
            this.dgvKamate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKamate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKamate.BackgroundColor = System.Drawing.Color.White;
            this.dgvKamate.ColumnHeadersHeight = 32;
            this.dgvKamate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colPredmet,
            this.colKonkretanPredmet,
            this.colTipKamate,
            this.colIznos,
            this.colPeriod,
            this.colDatum,
            this.colStatus});
            this.dgvKamate.Location = new System.Drawing.Point(25, 135);
            this.dgvKamate.Name = "dgvKamate";
            this.dgvKamate.ReadOnly = true;
            this.dgvKamate.RowHeadersVisible = false;
            this.dgvKamate.RowHeadersWidth = 57;
            this.dgvKamate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKamate.Size = new System.Drawing.Size(1050, 210);
            this.dgvKamate.TabIndex = 2;
            this.dgvKamate.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKamate_CellClick);
            // 
            // grpPodaci
            // 
            this.grpPodaci.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPodaci.Controls.Add(this.lblC0_0);
            this.grpPodaci.Controls.Add(this.txtId);
            this.grpPodaci.Controls.Add(this.lblC0_1);
            this.grpPodaci.Controls.Add(this.cmbPredmet);
            this.grpPodaci.Controls.Add(this.lblC0_2);
            this.grpPodaci.Controls.Add(this.cmbKonkretanPredmet);
            this.grpPodaci.Controls.Add(this.lblC1_0);
            this.grpPodaci.Controls.Add(this.cmbTipKamate);
            this.grpPodaci.Controls.Add(this.lblC1_1);
            this.grpPodaci.Controls.Add(this.txtIznosKamate);
            this.grpPodaci.Controls.Add(this.lblC1_2);
            this.grpPodaci.Controls.Add(this.txtPeriodObracuna);
            this.grpPodaci.Controls.Add(this.lblC2_0);
            this.grpPodaci.Controls.Add(this.dtpDatumObracuna);
            this.grpPodaci.Controls.Add(this.lblC2_1);
            this.grpPodaci.Controls.Add(this.cmbStatus);
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
            this.grpPodaci.Text = "Podaci o kamati";
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
            this.txtId.Location = new System.Drawing.Point(180, 34);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(165, 30);
            this.txtId.TabIndex = 1;
            // 
            // lblC0_1
            // 
            this.lblC0_1.AutoSize = true;
            this.lblC0_1.Location = new System.Drawing.Point(20, 74);
            this.lblC0_1.Name = "lblC0_1";
            this.lblC0_1.Size = new System.Drawing.Size(152, 23);
            this.lblC0_1.TabIndex = 2;
            this.lblC0_1.Text = "Predmet obračuna";
            // 
            // cmbPredmet
            // 
            this.cmbPredmet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPredmet.FormattingEnabled = true;
            this.cmbPredmet.Items.AddRange(new object[] {
            "Račun",
            "Kredit",
            "Depozit"});
            this.cmbPredmet.Location = new System.Drawing.Point(180, 70);
            this.cmbPredmet.Name = "cmbPredmet";
            this.cmbPredmet.Size = new System.Drawing.Size(165, 31);
            this.cmbPredmet.TabIndex = 3;
            this.cmbPredmet.SelectedIndexChanged += new System.EventHandler(this.cmbPredmet_SelectedIndexChanged);
            // 
            // lblC0_2
            // 
            this.lblC0_2.AutoSize = true;
            this.lblC0_2.Location = new System.Drawing.Point(20, 110);
            this.lblC0_2.Name = "lblC0_2";
            this.lblC0_2.Size = new System.Drawing.Size(158, 23);
            this.lblC0_2.TabIndex = 4;
            this.lblC0_2.Text = "Konkretan predmet";
            // 
            // cmbKonkretanPredmet
            // 
            this.cmbKonkretanPredmet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKonkretanPredmet.FormattingEnabled = true;
            this.cmbKonkretanPredmet.Location = new System.Drawing.Point(180, 106);
            this.cmbKonkretanPredmet.Name = "cmbKonkretanPredmet";
            this.cmbKonkretanPredmet.Size = new System.Drawing.Size(165, 31);
            this.cmbKonkretanPredmet.TabIndex = 5;
            // 
            // lblC1_0
            // 
            this.lblC1_0.AutoSize = true;
            this.lblC1_0.Location = new System.Drawing.Point(375, 38);
            this.lblC1_0.Name = "lblC1_0";
            this.lblC1_0.Size = new System.Drawing.Size(94, 23);
            this.lblC1_0.TabIndex = 6;
            this.lblC1_0.Text = "Tip kamate";
            // 
            // cmbTipKamate
            // 
            this.cmbTipKamate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipKamate.FormattingEnabled = true;
            this.cmbTipKamate.Items.AddRange(new object[] {
            "Redovna kamata",
            "Štedna kamata",
            "Kamata na prekoračenje",
            "Kreditna kamata",
            "Zatezna kamata"});
            this.cmbTipKamate.Location = new System.Drawing.Point(510, 34);
            this.cmbTipKamate.Name = "cmbTipKamate";
            this.cmbTipKamate.Size = new System.Drawing.Size(155, 31);
            this.cmbTipKamate.TabIndex = 7;
            // 
            // lblC1_1
            // 
            this.lblC1_1.AutoSize = true;
            this.lblC1_1.Location = new System.Drawing.Point(375, 74);
            this.lblC1_1.Name = "lblC1_1";
            this.lblC1_1.Size = new System.Drawing.Size(111, 23);
            this.lblC1_1.TabIndex = 8;
            this.lblC1_1.Text = "Iznos kamate";
            // 
            // txtIznosKamate
            // 
            this.txtIznosKamate.Location = new System.Drawing.Point(510, 70);
            this.txtIznosKamate.Name = "txtIznosKamate";
            this.txtIznosKamate.Size = new System.Drawing.Size(155, 30);
            this.txtIznosKamate.TabIndex = 9;
            // 
            // lblC1_2
            // 
            this.lblC1_2.AutoSize = true;
            this.lblC1_2.Location = new System.Drawing.Point(375, 110);
            this.lblC1_2.Name = "lblC1_2";
            this.lblC1_2.Size = new System.Drawing.Size(135, 23);
            this.lblC1_2.TabIndex = 10;
            this.lblC1_2.Text = "Period obračuna";
            // 
            // txtPeriodObracuna
            // 
            this.txtPeriodObracuna.Location = new System.Drawing.Point(510, 106);
            this.txtPeriodObracuna.Name = "txtPeriodObracuna";
            this.txtPeriodObracuna.Size = new System.Drawing.Size(155, 30);
            this.txtPeriodObracuna.TabIndex = 11;
            // 
            // lblC2_0
            // 
            this.lblC2_0.AutoSize = true;
            this.lblC2_0.Location = new System.Drawing.Point(710, 38);
            this.lblC2_0.Name = "lblC2_0";
            this.lblC2_0.Size = new System.Drawing.Size(139, 23);
            this.lblC2_0.TabIndex = 12;
            this.lblC2_0.Text = "Datum obračuna";
            // 
            // dtpDatumObracuna
            // 
            this.dtpDatumObracuna.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDatumObracuna.CustomFormat = "dd.MM.yyyy.";
            this.dtpDatumObracuna.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumObracuna.Location = new System.Drawing.Point(870, 34);
            this.dtpDatumObracuna.Name = "dtpDatumObracuna";
            this.dtpDatumObracuna.Size = new System.Drawing.Size(155, 30);
            this.dtpDatumObracuna.TabIndex = 13;
            // 
            // lblC2_1
            // 
            this.lblC2_1.AutoSize = true;
            this.lblC2_1.Location = new System.Drawing.Point(710, 74);
            this.lblC2_1.Name = "lblC2_1";
            this.lblC2_1.Size = new System.Drawing.Size(56, 23);
            this.lblC2_1.TabIndex = 14;
            this.lblC2_1.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Obračunato",
            "Isplaćeno",
            "Kapitalizovano"});
            this.cmbStatus.Location = new System.Drawing.Point(870, 70);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(155, 31);
            this.cmbStatus.TabIndex = 15;
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
            this.btnNovi.TabIndex = 16;
            this.btnNovi.Text = "Novi";
            this.btnNovi.UseVisualStyleBackColor = true;
            this.btnNovi.Click += new System.EventHandler(this.btnNovi_Click);
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
            this.btnIzmeni.TabIndex = 17;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
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
            this.btnObrisi.TabIndex = 18;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSacuvaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(72)))), ((int)(((byte)(106)))));
            this.btnSacuvaj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSacuvaj.FlatAppearance.BorderSize = 0;
            this.btnSacuvaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSacuvaj.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSacuvaj.ForeColor = System.Drawing.Color.White;
            this.btnSacuvaj.Location = new System.Drawing.Point(840, 255);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(90, 32);
            this.btnSacuvaj.TabIndex = 19;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = false;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOdustani.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOdustani.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnOdustani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdustani.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdustani.Location = new System.Drawing.Point(940, 255);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(90, 32);
            this.btnOdustani.TabIndex = 20;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // colId
            // 
            this.colId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colId.FillWeight = 265.1934F;
            this.colId.HeaderText = "ID";
            this.colId.MinimumWidth = 7;
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 60;
            // 
            // colPredmet
            // 
            this.colPredmet.FillWeight = 76.40095F;
            this.colPredmet.HeaderText = "Predmet";
            this.colPredmet.MinimumWidth = 7;
            this.colPredmet.Name = "colPredmet";
            this.colPredmet.ReadOnly = true;
            // 
            // colKonkretanPredmet
            // 
            this.colKonkretanPredmet.FillWeight = 76.40095F;
            this.colKonkretanPredmet.HeaderText = "Konkretan predmet";
            this.colKonkretanPredmet.MinimumWidth = 7;
            this.colKonkretanPredmet.Name = "colKonkretanPredmet";
            this.colKonkretanPredmet.ReadOnly = true;
            // 
            // colTipKamate
            // 
            this.colTipKamate.FillWeight = 76.40095F;
            this.colTipKamate.HeaderText = "Tip kamate";
            this.colTipKamate.MinimumWidth = 7;
            this.colTipKamate.Name = "colTipKamate";
            this.colTipKamate.ReadOnly = true;
            // 
            // colIznos
            // 
            this.colIznos.FillWeight = 76.40095F;
            this.colIznos.HeaderText = "Iznos kamate";
            this.colIznos.MinimumWidth = 7;
            this.colIznos.Name = "colIznos";
            this.colIznos.ReadOnly = true;
            // 
            // colPeriod
            // 
            this.colPeriod.FillWeight = 76.40095F;
            this.colPeriod.HeaderText = "Period obračuna";
            this.colPeriod.MinimumWidth = 7;
            this.colPeriod.Name = "colPeriod";
            this.colPeriod.ReadOnly = true;
            // 
            // colDatum
            // 
            this.colDatum.FillWeight = 76.40095F;
            this.colDatum.HeaderText = "Datum obračuna";
            this.colDatum.MinimumWidth = 7;
            this.colDatum.Name = "colDatum";
            this.colDatum.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.FillWeight = 76.40095F;
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 7;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // UcKamate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblNaslov);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.dgvKamate);
            this.Controls.Add(this.grpPodaci);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UcKamate";
            this.Size = new System.Drawing.Size(1100, 700);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKamate)).EndInit();
            this.grpPodaci.ResumeLayout(false);
            this.grpPodaci.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label lblFilter1;
        private System.Windows.Forms.ComboBox cmbPredmetFilter;
        private System.Windows.Forms.Label lblFilter2;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.DataGridView dgvKamate;
        private System.Windows.Forms.GroupBox grpPodaci;
        private System.Windows.Forms.Label lblC0_0;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblC0_1;
        private System.Windows.Forms.ComboBox cmbPredmet;
        private System.Windows.Forms.Label lblC0_2;
        private System.Windows.Forms.ComboBox cmbKonkretanPredmet;
        private System.Windows.Forms.Label lblC1_0;
        private System.Windows.Forms.ComboBox cmbTipKamate;
        private System.Windows.Forms.Label lblC1_1;
        private System.Windows.Forms.TextBox txtIznosKamate;
        private System.Windows.Forms.Label lblC1_2;
        private System.Windows.Forms.TextBox txtPeriodObracuna;
        private System.Windows.Forms.Label lblC2_0;
        private System.Windows.Forms.DateTimePicker dtpDatumObracuna;
        private System.Windows.Forms.Label lblC2_1;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnNovi;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPredmet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKonkretanPredmet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipKamate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIznos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}
