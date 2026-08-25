namespace Banka.Forme
{
    partial class UcRacuni
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
            this.components = new System.ComponentModel.Container();
            this.lblNaslov = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lblFilter1 = new System.Windows.Forms.Label();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.lblFilter2 = new System.Windows.Forms.Label();
            this.cmbTipFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter3 = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.dgvRacuni = new System.Windows.Forms.DataGridView();
            this.BrojRacuna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipRacuna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusRacuna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valuta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Klijent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpPodaci = new System.Windows.Forms.GroupBox();
            this.txtValuta = new System.Windows.Forms.TextBox();
            this.txtKlijent = new System.Windows.Forms.TextBox();
            this.lblL0 = new System.Windows.Forms.Label();
            this.txtBrojRacuna = new System.Windows.Forms.TextBox();
            this.lblL1 = new System.Windows.Forms.Label();
            this.lblL2 = new System.Windows.Forms.Label();
            this.cmbTipRacuna = new System.Windows.Forms.ComboBox();
            this.lblL3 = new System.Windows.Forms.Label();
            this.lblL4 = new System.Windows.Forms.Label();
            this.txtTrenutnoStanje = new System.Windows.Forms.TextBox();
            this.lblM0 = new System.Windows.Forms.Label();
            this.dtpDatumOtvaranja = new System.Windows.Forms.DateTimePicker();
            this.lblM1 = new System.Windows.Forms.Label();
            this.cmbStatusRacuna = new System.Windows.Forms.ComboBox();
            this.lblM2 = new System.Windows.Forms.Label();
            this.txtKamatnaStopa = new System.Windows.Forms.TextBox();
            this.lblM3 = new System.Windows.Forms.Label();
            this.txtDozvoljeniMinus = new System.Windows.Forms.TextBox();
            this.lblM4 = new System.Windows.Forms.Label();
            this.txtKomentar = new System.Windows.Forms.TextBox();
            this.tabTipRacuna = new System.Windows.Forms.TabControl();
            this.tabTekuci = new System.Windows.Forms.TabPage();
            this.chkPlatneKartice = new System.Windows.Forms.CheckBox();
            this.lblT1 = new System.Windows.Forms.Label();
            this.txtMesecniLimit = new System.Windows.Forms.TextBox();
            this.lblT2 = new System.Windows.Forms.Label();
            this.txtPaketiUsluga = new System.Windows.Forms.TextBox();
            this.tabStedni = new System.Windows.Forms.TabPage();
            this.lblS1 = new System.Windows.Forms.Label();
            this.txtMinimalniIznos = new System.Windows.Forms.TextBox();
            this.lblS2 = new System.Windows.Forms.Label();
            this.txtUsloviPodizanja = new System.Windows.Forms.TextBox();
            this.lblS3 = new System.Windows.Forms.Label();
            this.txtFrekvencija = new System.Windows.Forms.TextBox();
            this.lblS4 = new System.Windows.Forms.Label();
            this.txtBonusi = new System.Windows.Forms.TextBox();
            this.tabDevizni = new System.Windows.Forms.TabPage();
            this.lblD1 = new System.Windows.Forms.Label();
            this.txtDozvoljeneValute = new System.Windows.Forms.TextBox();
            this.lblD2 = new System.Windows.Forms.Label();
            this.txtNamenaDevizni = new System.Windows.Forms.TextBox();
            this.lblD3 = new System.Windows.Forms.Label();
            this.txtKursnaRazlika = new System.Windows.Forms.TextBox();
            this.lblD4 = new System.Windows.Forms.Label();
            this.txtOgranicenja = new System.Windows.Forms.TextBox();
            this.tabZiro = new System.Windows.Forms.TabPage();
            this.lblZ1 = new System.Windows.Forms.Label();
            this.txtNamenaZiro = new System.Windows.Forms.TextBox();
            this.chkEBankarstvo = new System.Windows.Forms.CheckBox();
            this.lblZ2 = new System.Windows.Forms.Label();
            this.txtLimitMasovnih = new System.Windows.Forms.TextBox();
            this.lblZ3 = new System.Windows.Forms.Label();
            this.txtIntegracija = new System.Windows.Forms.TextBox();
            this.btnNovi = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRacuni)).BeginInit();
            this.grpPodaci.SuspendLayout();
            this.tabTipRacuna.SuspendLayout();
            this.tabTekuci.SuspendLayout();
            this.tabStedni.SuspendLayout();
            this.tabDevizni.SuspendLayout();
            this.tabZiro.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNaslov
            // 
            this.lblNaslov.AutoSize = true;
            this.lblNaslov.Font = new System.Drawing.Font("Segoe UI", 18.26866F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNaslov.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(72)))), ((int)(((byte)(106)))));
            this.lblNaslov.Location = new System.Drawing.Point(25, 18);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.Size = new System.Drawing.Size(135, 42);
            this.lblNaslov.TabIndex = 0;
            this.lblNaslov.Text = "RAČUNI";
            // 
            // panelFilter
            // 
            this.panelFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilter.Controls.Add(this.lblFilter1);
            this.panelFilter.Controls.Add(this.txtPretraga);
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
            this.lblFilter1.Size = new System.Drawing.Size(65, 20);
            this.lblFilter1.TabIndex = 0;
            this.lblFilter1.Text = "Pretraga";
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(90, 14);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(230, 27);
            this.txtPretraga.TabIndex = 1;
            this.txtPretraga.TextChanged += new System.EventHandler(this.txtPretraga_TextChanged);
            // 
            // lblFilter2
            // 
            this.lblFilter2.AutoSize = true;
            this.lblFilter2.Location = new System.Drawing.Point(350, 18);
            this.lblFilter2.Name = "lblFilter2";
            this.lblFilter2.Size = new System.Drawing.Size(78, 20);
            this.lblFilter2.TabIndex = 2;
            this.lblFilter2.Text = "Tip računa";
            // 
            // cmbTipFilter
            // 
            this.cmbTipFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipFilter.FormattingEnabled = true;
            this.cmbTipFilter.Items.AddRange(new object[] {
            "Svi",
            "Tekući",
            "Štedni",
            "Devizni",
            "Žiro"});
            this.cmbTipFilter.Location = new System.Drawing.Point(435, 14);
            this.cmbTipFilter.Name = "cmbTipFilter";
            this.cmbTipFilter.Size = new System.Drawing.Size(180, 28);
            this.cmbTipFilter.TabIndex = 3;
            this.cmbTipFilter.SelectedIndexChanged += new System.EventHandler(this.cmbTipFilter_SelectedIndexChanged);
            // 
            // lblFilter3
            // 
            this.lblFilter3.AutoSize = true;
            this.lblFilter3.Location = new System.Drawing.Point(645, 18);
            this.lblFilter3.Name = "lblFilter3";
            this.lblFilter3.Size = new System.Drawing.Size(49, 20);
            this.lblFilter3.TabIndex = 4;
            this.lblFilter3.Text = "Status";
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Items.AddRange(new object[] {
            "Svi",
            "Aktivan",
            "Neaktivan",
            "Blokiran"});
            this.cmbStatusFilter.Location = new System.Drawing.Point(705, 14);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(180, 28);
            this.cmbStatusFilter.TabIndex = 5;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cmbStatusFilter_SelectedIndexChanged);
            // 
            // dgvRacuni
            // 
            this.dgvRacuni.AllowUserToAddRows = false;
            this.dgvRacuni.AllowUserToDeleteRows = false;
            this.dgvRacuni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRacuni.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRacuni.BackgroundColor = System.Drawing.Color.White;
            this.dgvRacuni.ColumnHeadersHeight = 32;
            this.dgvRacuni.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BrojRacuna,
            this.TipRacuna,
            this.StatusRacuna,
            this.Valuta,
            this.Klijent});
            this.dgvRacuni.Location = new System.Drawing.Point(25, 135);
            this.dgvRacuni.Name = "dgvRacuni";
            this.dgvRacuni.ReadOnly = true;
            this.dgvRacuni.RowHeadersVisible = false;
            this.dgvRacuni.RowHeadersWidth = 57;
            this.dgvRacuni.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRacuni.Size = new System.Drawing.Size(1050, 205);
            this.dgvRacuni.TabIndex = 2;
            this.dgvRacuni.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRacuni_CellContentClick);
            // 
            // BrojRacuna
            // 
            this.BrojRacuna.HeaderText = "Broj Racuna";
            this.BrojRacuna.MinimumWidth = 6;
            this.BrojRacuna.Name = "BrojRacuna";
            this.BrojRacuna.ReadOnly = true;
            // 
            // TipRacuna
            // 
            this.TipRacuna.HeaderText = "Tip Racuna";
            this.TipRacuna.MinimumWidth = 6;
            this.TipRacuna.Name = "TipRacuna";
            this.TipRacuna.ReadOnly = true;
            // 
            // StatusRacuna
            // 
            this.StatusRacuna.HeaderText = "Status";
            this.StatusRacuna.MinimumWidth = 6;
            this.StatusRacuna.Name = "StatusRacuna";
            this.StatusRacuna.ReadOnly = true;
            // 
            // Valuta
            // 
            this.Valuta.HeaderText = "Valuta";
            this.Valuta.MinimumWidth = 6;
            this.Valuta.Name = "Valuta";
            this.Valuta.ReadOnly = true;
            // 
            // Klijent
            // 
            this.Klijent.HeaderText = "Klijent";
            this.Klijent.MinimumWidth = 6;
            this.Klijent.Name = "Klijent";
            this.Klijent.ReadOnly = true;
            // 
            // grpPodaci
            // 
            this.grpPodaci.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPodaci.Controls.Add(this.txtValuta);
            this.grpPodaci.Controls.Add(this.txtKlijent);
            this.grpPodaci.Controls.Add(this.lblL0);
            this.grpPodaci.Controls.Add(this.txtBrojRacuna);
            this.grpPodaci.Controls.Add(this.lblL1);
            this.grpPodaci.Controls.Add(this.lblL2);
            this.grpPodaci.Controls.Add(this.cmbTipRacuna);
            this.grpPodaci.Controls.Add(this.lblL3);
            this.grpPodaci.Controls.Add(this.lblL4);
            this.grpPodaci.Controls.Add(this.txtTrenutnoStanje);
            this.grpPodaci.Controls.Add(this.lblM0);
            this.grpPodaci.Controls.Add(this.dtpDatumOtvaranja);
            this.grpPodaci.Controls.Add(this.lblM1);
            this.grpPodaci.Controls.Add(this.cmbStatusRacuna);
            this.grpPodaci.Controls.Add(this.lblM2);
            this.grpPodaci.Controls.Add(this.txtKamatnaStopa);
            this.grpPodaci.Controls.Add(this.lblM3);
            this.grpPodaci.Controls.Add(this.txtDozvoljeniMinus);
            this.grpPodaci.Controls.Add(this.lblM4);
            this.grpPodaci.Controls.Add(this.txtKomentar);
            this.grpPodaci.Controls.Add(this.tabTipRacuna);
            this.grpPodaci.Controls.Add(this.btnNovi);
            this.grpPodaci.Controls.Add(this.btnIzmeni);
            this.grpPodaci.Controls.Add(this.btnObrisi);
            this.grpPodaci.Controls.Add(this.btnSacuvaj);
            this.grpPodaci.Controls.Add(this.btnOdustani);
            this.grpPodaci.Location = new System.Drawing.Point(25, 355);
            this.grpPodaci.Name = "grpPodaci";
            this.grpPodaci.Size = new System.Drawing.Size(1050, 310);
            this.grpPodaci.TabIndex = 3;
            this.grpPodaci.TabStop = false;
            this.grpPodaci.Text = "Podaci o računu";
            // 
            // txtValuta
            // 
            this.txtValuta.Location = new System.Drawing.Point(145, 140);
            this.txtValuta.Name = "txtValuta";
            this.txtValuta.Size = new System.Drawing.Size(170, 27);
            this.txtValuta.TabIndex = 27;
            // 
            // txtKlijent
            // 
            this.txtKlijent.Location = new System.Drawing.Point(145, 67);
            this.txtKlijent.Name = "txtKlijent";
            this.txtKlijent.Size = new System.Drawing.Size(170, 27);
            this.txtKlijent.TabIndex = 26;
            // 
            // lblL0
            // 
            this.lblL0.AutoSize = true;
            this.lblL0.Location = new System.Drawing.Point(20, 38);
            this.lblL0.Name = "lblL0";
            this.lblL0.Size = new System.Drawing.Size(84, 20);
            this.lblL0.TabIndex = 0;
            this.lblL0.Text = "Broj računa";
            // 
            // txtBrojRacuna
            // 
            this.txtBrojRacuna.Location = new System.Drawing.Point(145, 34);
            this.txtBrojRacuna.Name = "txtBrojRacuna";
            this.txtBrojRacuna.Size = new System.Drawing.Size(170, 27);
            this.txtBrojRacuna.TabIndex = 1;
            // 
            // lblL1
            // 
            this.lblL1.AutoSize = true;
            this.lblL1.Location = new System.Drawing.Point(20, 72);
            this.lblL1.Name = "lblL1";
            this.lblL1.Size = new System.Drawing.Size(51, 20);
            this.lblL1.TabIndex = 2;
            this.lblL1.Text = "Klijent";
            // 
            // lblL2
            // 
            this.lblL2.AutoSize = true;
            this.lblL2.Location = new System.Drawing.Point(20, 106);
            this.lblL2.Name = "lblL2";
            this.lblL2.Size = new System.Drawing.Size(78, 20);
            this.lblL2.TabIndex = 4;
            this.lblL2.Text = "Tip računa";
            // 
            // cmbTipRacuna
            // 
            this.cmbTipRacuna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipRacuna.FormattingEnabled = true;
            this.cmbTipRacuna.Items.AddRange(new object[] {
            "Tekući",
            "Štedni",
            "Devizni",
            "Žiro"});
            this.cmbTipRacuna.Location = new System.Drawing.Point(145, 102);
            this.cmbTipRacuna.Name = "cmbTipRacuna";
            this.cmbTipRacuna.Size = new System.Drawing.Size(170, 28);
            this.cmbTipRacuna.TabIndex = 5;
            this.cmbTipRacuna.SelectedIndexChanged += new System.EventHandler(this.cmbTipRacuna_SelectedIndexChanged);
            this.cmbTipRacuna.TabIndexChanged += new System.EventHandler(this.cmbTipRacuna_TabIndexChanged);
            // 
            // lblL3
            // 
            this.lblL3.AutoSize = true;
            this.lblL3.Location = new System.Drawing.Point(20, 140);
            this.lblL3.Name = "lblL3";
            this.lblL3.Size = new System.Drawing.Size(50, 20);
            this.lblL3.TabIndex = 6;
            this.lblL3.Text = "Valuta";
            // 
            // lblL4
            // 
            this.lblL4.AutoSize = true;
            this.lblL4.Location = new System.Drawing.Point(20, 174);
            this.lblL4.Name = "lblL4";
            this.lblL4.Size = new System.Drawing.Size(110, 20);
            this.lblL4.TabIndex = 8;
            this.lblL4.Text = "Trenutno stanje";
            // 
            // txtTrenutnoStanje
            // 
            this.txtTrenutnoStanje.Location = new System.Drawing.Point(145, 170);
            this.txtTrenutnoStanje.Name = "txtTrenutnoStanje";
            this.txtTrenutnoStanje.Size = new System.Drawing.Size(170, 27);
            this.txtTrenutnoStanje.TabIndex = 9;
            // 
            // lblM0
            // 
            this.lblM0.AutoSize = true;
            this.lblM0.Location = new System.Drawing.Point(335, 38);
            this.lblM0.Name = "lblM0";
            this.lblM0.Size = new System.Drawing.Size(120, 20);
            this.lblM0.TabIndex = 10;
            this.lblM0.Text = "Datum otvaranja";
            // 
            // dtpDatumOtvaranja
            // 
            this.dtpDatumOtvaranja.CustomFormat = "dd.MM.yyyy.";
            this.dtpDatumOtvaranja.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumOtvaranja.Location = new System.Drawing.Point(465, 34);
            this.dtpDatumOtvaranja.Name = "dtpDatumOtvaranja";
            this.dtpDatumOtvaranja.Size = new System.Drawing.Size(170, 27);
            this.dtpDatumOtvaranja.TabIndex = 11;
            // 
            // lblM1
            // 
            this.lblM1.AutoSize = true;
            this.lblM1.Location = new System.Drawing.Point(335, 72);
            this.lblM1.Name = "lblM1";
            this.lblM1.Size = new System.Drawing.Size(97, 20);
            this.lblM1.TabIndex = 12;
            this.lblM1.Text = "Status računa";
            // 
            // cmbStatusRacuna
            // 
            this.cmbStatusRacuna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusRacuna.FormattingEnabled = true;
            this.cmbStatusRacuna.Items.AddRange(new object[] {
            "Aktivan",
            "Neaktivan",
            "Blokiran"});
            this.cmbStatusRacuna.Location = new System.Drawing.Point(465, 68);
            this.cmbStatusRacuna.Name = "cmbStatusRacuna";
            this.cmbStatusRacuna.Size = new System.Drawing.Size(170, 28);
            this.cmbStatusRacuna.TabIndex = 13;
            // 
            // lblM2
            // 
            this.lblM2.AutoSize = true;
            this.lblM2.Location = new System.Drawing.Point(335, 106);
            this.lblM2.Name = "lblM2";
            this.lblM2.Size = new System.Drawing.Size(109, 20);
            this.lblM2.TabIndex = 14;
            this.lblM2.Text = "Kamatna stopa";
            // 
            // txtKamatnaStopa
            // 
            this.txtKamatnaStopa.Location = new System.Drawing.Point(465, 102);
            this.txtKamatnaStopa.Name = "txtKamatnaStopa";
            this.txtKamatnaStopa.Size = new System.Drawing.Size(170, 27);
            this.txtKamatnaStopa.TabIndex = 15;
            // 
            // lblM3
            // 
            this.lblM3.AutoSize = true;
            this.lblM3.Location = new System.Drawing.Point(335, 140);
            this.lblM3.Name = "lblM3";
            this.lblM3.Size = new System.Drawing.Size(123, 20);
            this.lblM3.TabIndex = 16;
            this.lblM3.Text = "Dozvoljeni minus";
            // 
            // txtDozvoljeniMinus
            // 
            this.txtDozvoljeniMinus.Location = new System.Drawing.Point(465, 136);
            this.txtDozvoljeniMinus.Name = "txtDozvoljeniMinus";
            this.txtDozvoljeniMinus.Size = new System.Drawing.Size(170, 27);
            this.txtDozvoljeniMinus.TabIndex = 17;
            // 
            // lblM4
            // 
            this.lblM4.AutoSize = true;
            this.lblM4.Location = new System.Drawing.Point(335, 174);
            this.lblM4.Name = "lblM4";
            this.lblM4.Size = new System.Drawing.Size(74, 20);
            this.lblM4.TabIndex = 18;
            this.lblM4.Text = "Komentar";
            // 
            // txtKomentar
            // 
            this.txtKomentar.Location = new System.Drawing.Point(465, 170);
            this.txtKomentar.Multiline = true;
            this.txtKomentar.Name = "txtKomentar";
            this.txtKomentar.Size = new System.Drawing.Size(170, 48);
            this.txtKomentar.TabIndex = 19;
            // 
            // tabTipRacuna
            // 
            this.tabTipRacuna.Controls.Add(this.tabTekuci);
            this.tabTipRacuna.Controls.Add(this.tabStedni);
            this.tabTipRacuna.Controls.Add(this.tabDevizni);
            this.tabTipRacuna.Controls.Add(this.tabZiro);
            this.tabTipRacuna.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTipRacuna.Location = new System.Drawing.Point(660, 30);
            this.tabTipRacuna.Name = "tabTipRacuna";
            this.tabTipRacuna.SelectedIndex = 0;
            this.tabTipRacuna.Size = new System.Drawing.Size(365, 205);
            this.tabTipRacuna.TabIndex = 20;
            // 
            // tabTekuci
            // 
            this.tabTekuci.Controls.Add(this.chkPlatneKartice);
            this.tabTekuci.Controls.Add(this.lblT1);
            this.tabTekuci.Controls.Add(this.txtMesecniLimit);
            this.tabTekuci.Controls.Add(this.lblT2);
            this.tabTekuci.Controls.Add(this.txtPaketiUsluga);
            this.tabTekuci.Location = new System.Drawing.Point(4, 29);
            this.tabTekuci.Name = "tabTekuci";
            this.tabTekuci.Size = new System.Drawing.Size(357, 172);
            this.tabTekuci.TabIndex = 0;
            this.tabTekuci.Text = "Tekući";
            this.tabTekuci.UseVisualStyleBackColor = true;
            // 
            // chkPlatneKartice
            // 
            this.chkPlatneKartice.AutoSize = true;
            this.chkPlatneKartice.Location = new System.Drawing.Point(15, 18);
            this.chkPlatneKartice.Name = "chkPlatneKartice";
            this.chkPlatneKartice.Size = new System.Drawing.Size(212, 24);
            this.chkPlatneKartice.TabIndex = 0;
            this.chkPlatneKartice.Text = "Platne kartice omogućene";
            this.chkPlatneKartice.UseVisualStyleBackColor = true;
            // 
            // lblT1
            // 
            this.lblT1.AutoSize = true;
            this.lblT1.Location = new System.Drawing.Point(15, 58);
            this.lblT1.Name = "lblT1";
            this.lblT1.Size = new System.Drawing.Size(181, 20);
            this.lblT1.TabIndex = 1;
            this.lblT1.Text = "Mesečni limit transakcija";
            // 
            // txtMesecniLimit
            // 
            this.txtMesecniLimit.Location = new System.Drawing.Point(201, 54);
            this.txtMesecniLimit.Name = "txtMesecniLimit";
            this.txtMesecniLimit.Size = new System.Drawing.Size(145, 27);
            this.txtMesecniLimit.TabIndex = 2;
            // 
            // lblT2
            // 
            this.lblT2.AutoSize = true;
            this.lblT2.Location = new System.Drawing.Point(15, 94);
            this.lblT2.Name = "lblT2";
            this.lblT2.Size = new System.Drawing.Size(168, 20);
            this.lblT2.TabIndex = 3;
            this.lblT2.Text = "Povezani paketi usluga";
            // 
            // txtPaketiUsluga
            // 
            this.txtPaketiUsluga.Location = new System.Drawing.Point(201, 90);
            this.txtPaketiUsluga.Name = "txtPaketiUsluga";
            this.txtPaketiUsluga.Size = new System.Drawing.Size(145, 27);
            this.txtPaketiUsluga.TabIndex = 4;
            // 
            // tabStedni
            // 
            this.tabStedni.Controls.Add(this.lblS1);
            this.tabStedni.Controls.Add(this.txtMinimalniIznos);
            this.tabStedni.Controls.Add(this.lblS2);
            this.tabStedni.Controls.Add(this.txtUsloviPodizanja);
            this.tabStedni.Controls.Add(this.lblS3);
            this.tabStedni.Controls.Add(this.txtFrekvencija);
            this.tabStedni.Controls.Add(this.lblS4);
            this.tabStedni.Controls.Add(this.txtBonusi);
            this.tabStedni.Location = new System.Drawing.Point(4, 29);
            this.tabStedni.Name = "tabStedni";
            this.tabStedni.Size = new System.Drawing.Size(357, 172);
            this.tabStedni.TabIndex = 1;
            this.tabStedni.Text = "Štedni";
            this.tabStedni.UseVisualStyleBackColor = true;
            // 
            // lblS1
            // 
            this.lblS1.AutoSize = true;
            this.lblS1.Location = new System.Drawing.Point(15, 20);
            this.lblS1.Name = "lblS1";
            this.lblS1.Size = new System.Drawing.Size(119, 20);
            this.lblS1.TabIndex = 0;
            this.lblS1.Text = "Minimalni iznos";
            // 
            // txtMinimalniIznos
            // 
            this.txtMinimalniIznos.Location = new System.Drawing.Point(155, 16);
            this.txtMinimalniIznos.Name = "txtMinimalniIznos";
            this.txtMinimalniIznos.Size = new System.Drawing.Size(165, 27);
            this.txtMinimalniIznos.TabIndex = 1;
            // 
            // lblS2
            // 
            this.lblS2.AutoSize = true;
            this.lblS2.Location = new System.Drawing.Point(15, 54);
            this.lblS2.Name = "lblS2";
            this.lblS2.Size = new System.Drawing.Size(123, 20);
            this.lblS2.TabIndex = 2;
            this.lblS2.Text = "Uslovi podizanja";
            // 
            // txtUsloviPodizanja
            // 
            this.txtUsloviPodizanja.Location = new System.Drawing.Point(155, 50);
            this.txtUsloviPodizanja.Name = "txtUsloviPodizanja";
            this.txtUsloviPodizanja.Size = new System.Drawing.Size(165, 27);
            this.txtUsloviPodizanja.TabIndex = 3;
            // 
            // lblS3
            // 
            this.lblS3.AutoSize = true;
            this.lblS3.Location = new System.Drawing.Point(15, 88);
            this.lblS3.Name = "lblS3";
            this.lblS3.Size = new System.Drawing.Size(156, 20);
            this.lblS3.TabIndex = 4;
            this.lblS3.Text = "Kapitalizacija kamate";
            // 
            // txtFrekvencija
            // 
            this.txtFrekvencija.Location = new System.Drawing.Point(155, 84);
            this.txtFrekvencija.Name = "txtFrekvencija";
            this.txtFrekvencija.Size = new System.Drawing.Size(165, 27);
            this.txtFrekvencija.TabIndex = 5;
            // 
            // lblS4
            // 
            this.lblS4.AutoSize = true;
            this.lblS4.Location = new System.Drawing.Point(15, 122);
            this.lblS4.Name = "lblS4";
            this.lblS4.Size = new System.Drawing.Size(57, 20);
            this.lblS4.TabIndex = 6;
            this.lblS4.Text = "Bonusi";
            // 
            // txtBonusi
            // 
            this.txtBonusi.Location = new System.Drawing.Point(155, 118);
            this.txtBonusi.Multiline = true;
            this.txtBonusi.Name = "txtBonusi";
            this.txtBonusi.Size = new System.Drawing.Size(165, 45);
            this.txtBonusi.TabIndex = 7;
            // 
            // tabDevizni
            // 
            this.tabDevizni.Controls.Add(this.lblD1);
            this.tabDevizni.Controls.Add(this.txtDozvoljeneValute);
            this.tabDevizni.Controls.Add(this.lblD2);
            this.tabDevizni.Controls.Add(this.txtNamenaDevizni);
            this.tabDevizni.Controls.Add(this.lblD3);
            this.tabDevizni.Controls.Add(this.txtKursnaRazlika);
            this.tabDevizni.Controls.Add(this.lblD4);
            this.tabDevizni.Controls.Add(this.txtOgranicenja);
            this.tabDevizni.Location = new System.Drawing.Point(4, 29);
            this.tabDevizni.Name = "tabDevizni";
            this.tabDevizni.Size = new System.Drawing.Size(357, 172);
            this.tabDevizni.TabIndex = 2;
            this.tabDevizni.Text = "Devizni";
            this.tabDevizni.UseVisualStyleBackColor = true;
            // 
            // lblD1
            // 
            this.lblD1.AutoSize = true;
            this.lblD1.Location = new System.Drawing.Point(15, 20);
            this.lblD1.Name = "lblD1";
            this.lblD1.Size = new System.Drawing.Size(133, 20);
            this.lblD1.TabIndex = 0;
            this.lblD1.Text = "Dozvoljene valute";
            // 
            // txtDozvoljeneValute
            // 
            this.txtDozvoljeneValute.Location = new System.Drawing.Point(155, 16);
            this.txtDozvoljeneValute.Name = "txtDozvoljeneValute";
            this.txtDozvoljeneValute.Size = new System.Drawing.Size(165, 27);
            this.txtDozvoljeneValute.TabIndex = 1;
            // 
            // lblD2
            // 
            this.lblD2.AutoSize = true;
            this.lblD2.Location = new System.Drawing.Point(15, 54);
            this.lblD2.Name = "lblD2";
            this.lblD2.Size = new System.Drawing.Size(68, 20);
            this.lblD2.TabIndex = 2;
            this.lblD2.Text = "Namena";
            // 
            // txtNamenaDevizni
            // 
            this.txtNamenaDevizni.Location = new System.Drawing.Point(155, 50);
            this.txtNamenaDevizni.Name = "txtNamenaDevizni";
            this.txtNamenaDevizni.Size = new System.Drawing.Size(165, 27);
            this.txtNamenaDevizni.TabIndex = 3;
            // 
            // lblD3
            // 
            this.lblD3.AutoSize = true;
            this.lblD3.Location = new System.Drawing.Point(15, 88);
            this.lblD3.Name = "lblD3";
            this.lblD3.Size = new System.Drawing.Size(107, 20);
            this.lblD3.TabIndex = 4;
            this.lblD3.Text = "Kursna razlika";
            // 
            // txtKursnaRazlika
            // 
            this.txtKursnaRazlika.Location = new System.Drawing.Point(155, 84);
            this.txtKursnaRazlika.Name = "txtKursnaRazlika";
            this.txtKursnaRazlika.Size = new System.Drawing.Size(165, 27);
            this.txtKursnaRazlika.TabIndex = 5;
            // 
            // lblD4
            // 
            this.lblD4.AutoSize = true;
            this.lblD4.Location = new System.Drawing.Point(15, 122);
            this.lblD4.Name = "lblD4";
            this.lblD4.Size = new System.Drawing.Size(92, 20);
            this.lblD4.TabIndex = 6;
            this.lblD4.Text = "Ograničenja";
            // 
            // txtOgranicenja
            // 
            this.txtOgranicenja.Location = new System.Drawing.Point(155, 118);
            this.txtOgranicenja.Multiline = true;
            this.txtOgranicenja.Name = "txtOgranicenja";
            this.txtOgranicenja.Size = new System.Drawing.Size(165, 45);
            this.txtOgranicenja.TabIndex = 7;
            // 
            // tabZiro
            // 
            this.tabZiro.Controls.Add(this.lblZ1);
            this.tabZiro.Controls.Add(this.txtNamenaZiro);
            this.tabZiro.Controls.Add(this.chkEBankarstvo);
            this.tabZiro.Controls.Add(this.lblZ2);
            this.tabZiro.Controls.Add(this.txtLimitMasovnih);
            this.tabZiro.Controls.Add(this.lblZ3);
            this.tabZiro.Controls.Add(this.txtIntegracija);
            this.tabZiro.Location = new System.Drawing.Point(4, 29);
            this.tabZiro.Name = "tabZiro";
            this.tabZiro.Size = new System.Drawing.Size(357, 172);
            this.tabZiro.TabIndex = 3;
            this.tabZiro.Text = "Žiro";
            this.tabZiro.UseVisualStyleBackColor = true;
            // 
            // lblZ1
            // 
            this.lblZ1.AutoSize = true;
            this.lblZ1.Location = new System.Drawing.Point(15, 20);
            this.lblZ1.Name = "lblZ1";
            this.lblZ1.Size = new System.Drawing.Size(68, 20);
            this.lblZ1.TabIndex = 0;
            this.lblZ1.Text = "Namena";
            // 
            // txtNamenaZiro
            // 
            this.txtNamenaZiro.Location = new System.Drawing.Point(155, 16);
            this.txtNamenaZiro.Name = "txtNamenaZiro";
            this.txtNamenaZiro.Size = new System.Drawing.Size(165, 27);
            this.txtNamenaZiro.TabIndex = 1;
            // 
            // chkEBankarstvo
            // 
            this.chkEBankarstvo.AutoSize = true;
            this.chkEBankarstvo.Location = new System.Drawing.Point(15, 54);
            this.chkEBankarstvo.Name = "chkEBankarstvo";
            this.chkEBankarstvo.Size = new System.Drawing.Size(184, 24);
            this.chkEBankarstvo.TabIndex = 2;
            this.chkEBankarstvo.Text = "E-bankarstvo za firme";
            this.chkEBankarstvo.UseVisualStyleBackColor = true;
            // 
            // lblZ2
            // 
            this.lblZ2.AutoSize = true;
            this.lblZ2.Location = new System.Drawing.Point(15, 88);
            this.lblZ2.Name = "lblZ2";
            this.lblZ2.Size = new System.Drawing.Size(178, 20);
            this.lblZ2.TabIndex = 3;
            this.lblZ2.Text = "Limit masovnih plaćanja";
            // 
            // txtLimitMasovnih
            // 
            this.txtLimitMasovnih.Location = new System.Drawing.Point(175, 84);
            this.txtLimitMasovnih.Name = "txtLimitMasovnih";
            this.txtLimitMasovnih.Size = new System.Drawing.Size(145, 27);
            this.txtLimitMasovnih.TabIndex = 4;
            // 
            // lblZ3
            // 
            this.lblZ3.AutoSize = true;
            this.lblZ3.Location = new System.Drawing.Point(15, 122);
            this.lblZ3.Name = "lblZ3";
            this.lblZ3.Size = new System.Drawing.Size(83, 20);
            this.lblZ3.TabIndex = 5;
            this.lblZ3.Text = "Integracija";
            // 
            // txtIntegracija
            // 
            this.txtIntegracija.Location = new System.Drawing.Point(155, 118);
            this.txtIntegracija.Multiline = true;
            this.txtIntegracija.Name = "txtIntegracija";
            this.txtIntegracija.Size = new System.Drawing.Size(165, 45);
            this.txtIntegracija.TabIndex = 6;
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
            this.btnNovi.TabIndex = 21;
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
            this.btnIzmeni.TabIndex = 22;
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
            this.btnObrisi.TabIndex = 23;
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
            this.btnSacuvaj.TabIndex = 24;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = false;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
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
            this.btnOdustani.TabIndex = 25;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(200, 100);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // UcRacuni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblNaslov);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.dgvRacuni);
            this.Controls.Add(this.grpPodaci);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UcRacuni";
            this.Size = new System.Drawing.Size(1100, 700);
            this.Load += new System.EventHandler(this.UcRacuni_Load_1);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRacuni)).EndInit();
            this.grpPodaci.ResumeLayout(false);
            this.grpPodaci.PerformLayout();
            this.tabTipRacuna.ResumeLayout(false);
            this.tabTekuci.ResumeLayout(false);
            this.tabTekuci.PerformLayout();
            this.tabStedni.ResumeLayout(false);
            this.tabStedni.PerformLayout();
            this.tabDevizni.ResumeLayout(false);
            this.tabDevizni.PerformLayout();
            this.tabZiro.ResumeLayout(false);
            this.tabZiro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label lblFilter1;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.Label lblFilter2;
        private System.Windows.Forms.ComboBox cmbTipFilter;
        private System.Windows.Forms.Label lblFilter3;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.DataGridView dgvRacuni;
        private System.Windows.Forms.GroupBox grpPodaci;
        private System.Windows.Forms.Label lblL0;
        private System.Windows.Forms.TextBox txtBrojRacuna;
        private System.Windows.Forms.Label lblL1;
        private System.Windows.Forms.ComboBox cmbKlijent;
        private System.Windows.Forms.Label lblL2;
        private System.Windows.Forms.ComboBox cmbTipRacuna;
        private System.Windows.Forms.Label lblL3;
        private System.Windows.Forms.Label lblL4;
        private System.Windows.Forms.TextBox txtTrenutnoStanje;
        private System.Windows.Forms.Label lblM0;
        private System.Windows.Forms.DateTimePicker dtpDatumOtvaranja;
        private System.Windows.Forms.Label lblM1;
        private System.Windows.Forms.ComboBox cmbStatusRacuna;
        private System.Windows.Forms.Label lblM2;
        private System.Windows.Forms.TextBox txtKamatnaStopa;
        private System.Windows.Forms.Label lblM3;
        private System.Windows.Forms.TextBox txtDozvoljeniMinus;
        private System.Windows.Forms.Label lblM4;
        private System.Windows.Forms.TextBox txtKomentar;
        private System.Windows.Forms.TabControl tabTipRacuna;
        private System.Windows.Forms.TabPage tabTekuci;
        private System.Windows.Forms.TabPage tabStedni;
        private System.Windows.Forms.TabPage tabDevizni;
        private System.Windows.Forms.TabPage tabZiro;
        private System.Windows.Forms.CheckBox chkPlatneKartice;
        private System.Windows.Forms.Label lblT1;
        private System.Windows.Forms.TextBox txtMesecniLimit;
        private System.Windows.Forms.Label lblT2;
        private System.Windows.Forms.TextBox txtPaketiUsluga;
        private System.Windows.Forms.Label lblS1;
        private System.Windows.Forms.TextBox txtMinimalniIznos;
        private System.Windows.Forms.Label lblS2;
        private System.Windows.Forms.TextBox txtUsloviPodizanja;
        private System.Windows.Forms.Label lblS3;
        private System.Windows.Forms.TextBox txtFrekvencija;
        private System.Windows.Forms.Label lblS4;
        private System.Windows.Forms.TextBox txtBonusi;
        private System.Windows.Forms.Label lblD1;
        private System.Windows.Forms.TextBox txtDozvoljeneValute;
        private System.Windows.Forms.Label lblD2;
        private System.Windows.Forms.TextBox txtNamenaDevizni;
        private System.Windows.Forms.Label lblD3;
        private System.Windows.Forms.TextBox txtKursnaRazlika;
        private System.Windows.Forms.Label lblD4;
        private System.Windows.Forms.TextBox txtOgranicenja;
        private System.Windows.Forms.Label lblZ1;
        private System.Windows.Forms.TextBox txtNamenaZiro;
        private System.Windows.Forms.CheckBox chkEBankarstvo;
        private System.Windows.Forms.Label lblZ2;
        private System.Windows.Forms.TextBox txtLimitMasovnih;
        private System.Windows.Forms.Label lblZ3;
        private System.Windows.Forms.TextBox txtIntegracija;
        private System.Windows.Forms.Button btnNovi;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojRacuna;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipRacuna;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusRacuna;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valuta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Klijent;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtKlijent;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtValuta;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
    }
}
