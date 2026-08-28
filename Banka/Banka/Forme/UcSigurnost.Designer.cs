namespace Banka.Forme
{
    partial class UcSigurnost
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNaslov = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lblFilter1 = new System.Windows.Forms.Label();
            this.cmbKlijentFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter2 = new System.Windows.Forms.Label();
            this.cmbRacunFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter3 = new System.Windows.Forms.Label();
            this.cmbTipFilter = new System.Windows.Forms.ComboBox();
            this.dgvSigurnost = new System.Windows.Forms.DataGridView();
            this.grpPodaci = new System.Windows.Forms.GroupBox();
            this.lblC0_0 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblC0_1 = new System.Windows.Forms.Label();
            this.cmbKlijent = new System.Windows.Forms.ComboBox();
            this.lblC0_2 = new System.Windows.Forms.Label();
            this.cmbRacun = new System.Windows.Forms.ComboBox();
            this.lblC0_3 = new System.Windows.Forms.Label();
            this.cmbTipDogadjaja = new System.Windows.Forms.ComboBox();
            this.lblC1_0 = new System.Windows.Forms.Label();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.lblC1_1 = new System.Windows.Forms.Label();
            this.txtVreme = new System.Windows.Forms.TextBox();
            this.lblC1_2 = new System.Windows.Forms.Label();
            this.txtIpAdresa = new System.Windows.Forms.TextBox();
            this.lblC1_3 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblC2_0 = new System.Windows.Forms.Label();
            this.txtUredjaj = new System.Windows.Forms.TextBox();
            this.lblC2_1 = new System.Windows.Forms.Label();
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.btnNovi = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKlijent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRacun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipDogadjaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVreme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIpAdresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSigurnost)).BeginInit();
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
            this.lblNaslov.Size = new System.Drawing.Size(441, 47);
            this.lblNaslov.TabIndex = 0;
            this.lblNaslov.Text = "SIGURNOSNE KONTROLE";
            // 
            // panelFilter
            // 
            this.panelFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilter.Controls.Add(this.lblFilter1);
            this.panelFilter.Controls.Add(this.cmbKlijentFilter);
            this.panelFilter.Controls.Add(this.lblFilter2);
            this.panelFilter.Controls.Add(this.cmbRacunFilter);
            this.panelFilter.Controls.Add(this.lblFilter3);
            this.panelFilter.Controls.Add(this.cmbTipFilter);
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
            this.cmbKlijentFilter.Size = new System.Drawing.Size(150, 31);
            this.cmbKlijentFilter.TabIndex = 1;
            this.cmbKlijentFilter.SelectedIndexChanged += new System.EventHandler(this.cmbKlijentFilter_SelectedIndexChanged);
            // 
            // lblFilter2
            // 
            this.lblFilter2.AutoSize = true;
            this.lblFilter2.Location = new System.Drawing.Point(264, 18);
            this.lblFilter2.Name = "lblFilter2";
            this.lblFilter2.Size = new System.Drawing.Size(57, 23);
            this.lblFilter2.TabIndex = 2;
            this.lblFilter2.Text = "Račun";
            // 
            // cmbRacunFilter
            // 
            this.cmbRacunFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRacunFilter.FormattingEnabled = true;
            this.cmbRacunFilter.Location = new System.Drawing.Point(334, 14);
            this.cmbRacunFilter.Name = "cmbRacunFilter";
            this.cmbRacunFilter.Size = new System.Drawing.Size(150, 31);
            this.cmbRacunFilter.TabIndex = 3;
            this.cmbRacunFilter.SelectedIndexChanged += new System.EventHandler(this.cmbRacunFilter_SelectedIndexChanged);
            // 
            // lblFilter3
            // 
            this.lblFilter3.AutoSize = true;
            this.lblFilter3.Location = new System.Drawing.Point(510, 18);
            this.lblFilter3.Name = "lblFilter3";
            this.lblFilter3.Size = new System.Drawing.Size(109, 23);
            this.lblFilter3.TabIndex = 4;
            this.lblFilter3.Text = "Tip događaja";
            // 
            // cmbTipFilter
            // 
            this.cmbTipFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipFilter.FormattingEnabled = true;
            this.cmbTipFilter.Location = new System.Drawing.Point(624, 14);
            this.cmbTipFilter.Name = "cmbTipFilter";
            this.cmbTipFilter.Size = new System.Drawing.Size(190, 31);
            this.cmbTipFilter.TabIndex = 5;
            this.cmbTipFilter.SelectedIndexChanged += new System.EventHandler(this.cmbTipFilter_SelectedIndexChanged);
            // 
            // dgvSigurnost
            // 
            this.dgvSigurnost.AllowUserToAddRows = false;
            this.dgvSigurnost.AllowUserToDeleteRows = false;
            this.dgvSigurnost.AllowUserToResizeColumns = false;
            this.dgvSigurnost.AllowUserToResizeRows = false;
            this.dgvSigurnost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSigurnost.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSigurnost.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(72)))), ((int)(((byte)(106)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSigurnost.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSigurnost.ColumnHeadersHeight = 32;
            this.dgvSigurnost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colKlijent,
            this.colRacun,
            this.colTipDogadjaja,
            this.colDatum,
            this.colVreme,
            this.colIpAdresa,
            this.colStatus});
            this.dgvSigurnost.EnableHeadersVisualStyles = false;
            this.dgvSigurnost.Location = new System.Drawing.Point(25, 135);
            this.dgvSigurnost.Name = "dgvSigurnost";
            this.dgvSigurnost.ReadOnly = true;
            this.dgvSigurnost.RowHeadersVisible = false;
            this.dgvSigurnost.RowHeadersWidth = 57;
            this.dgvSigurnost.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSigurnost.Size = new System.Drawing.Size(1050, 210);
            this.dgvSigurnost.TabIndex = 2;
            this.dgvSigurnost.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSigurnost_CellClick);
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
            this.grpPodaci.Controls.Add(this.cmbTipDogadjaja);
            this.grpPodaci.Controls.Add(this.lblC1_0);
            this.grpPodaci.Controls.Add(this.dtpDatum);
            this.grpPodaci.Controls.Add(this.lblC1_1);
            this.grpPodaci.Controls.Add(this.txtVreme);
            this.grpPodaci.Controls.Add(this.lblC1_2);
            this.grpPodaci.Controls.Add(this.txtIpAdresa);
            this.grpPodaci.Controls.Add(this.lblC1_3);
            this.grpPodaci.Controls.Add(this.cmbStatus);
            this.grpPodaci.Controls.Add(this.lblC2_0);
            this.grpPodaci.Controls.Add(this.txtUredjaj);
            this.grpPodaci.Controls.Add(this.lblC2_1);
            this.grpPodaci.Controls.Add(this.txtOpis);
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
            this.grpPodaci.Text = "Podaci o sigurnosnom događaju";
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
            this.txtId.ReadOnly = true;
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
            this.cmbKlijent.SelectedIndexChanged += new System.EventHandler(this.cmbKlijent_SelectedIndexChanged);
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
            this.lblC0_3.Size = new System.Drawing.Size(109, 23);
            this.lblC0_3.TabIndex = 6;
            this.lblC0_3.Text = "Tip događaja";
            // 
            // cmbTipDogadjaja
            // 
            this.cmbTipDogadjaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipDogadjaja.FormattingEnabled = true;
            this.cmbTipDogadjaja.Items.AddRange(new object[] {
            "Login",
            "Neuspela autentifikacija",
            "Promena PIN-a",
            "Blokada računa",
            "Sumnjiva transakcija"});
            this.cmbTipDogadjaja.Location = new System.Drawing.Point(160, 142);
            this.cmbTipDogadjaja.Name = "cmbTipDogadjaja";
            this.cmbTipDogadjaja.Size = new System.Drawing.Size(165, 31);
            this.cmbTipDogadjaja.TabIndex = 7;
            // 
            // lblC1_0
            // 
            this.lblC1_0.AutoSize = true;
            this.lblC1_0.Location = new System.Drawing.Point(355, 38);
            this.lblC1_0.Name = "lblC1_0";
            this.lblC1_0.Size = new System.Drawing.Size(62, 23);
            this.lblC1_0.TabIndex = 8;
            this.lblC1_0.Text = "Datum";
            // 
            // dtpDatum
            // 
            this.dtpDatum.CustomFormat = "dd.MM.yyyy.";
            this.dtpDatum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatum.Location = new System.Drawing.Point(500, 34);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(155, 30);
            this.dtpDatum.TabIndex = 9;
            // 
            // lblC1_1
            // 
            this.lblC1_1.AutoSize = true;
            this.lblC1_1.Location = new System.Drawing.Point(355, 74);
            this.lblC1_1.Name = "lblC1_1";
            this.lblC1_1.Size = new System.Drawing.Size(59, 23);
            this.lblC1_1.TabIndex = 10;
            this.lblC1_1.Text = "Vreme";
            // 
            // txtVreme
            // 
            this.txtVreme.Location = new System.Drawing.Point(500, 70);
            this.txtVreme.Name = "txtVreme";
            this.txtVreme.Size = new System.Drawing.Size(155, 30);
            this.txtVreme.TabIndex = 11;
            // 
            // lblC1_2
            // 
            this.lblC1_2.AutoSize = true;
            this.lblC1_2.Location = new System.Drawing.Point(355, 110);
            this.lblC1_2.Name = "lblC1_2";
            this.lblC1_2.Size = new System.Drawing.Size(80, 23);
            this.lblC1_2.TabIndex = 12;
            this.lblC1_2.Text = "IP adresa";
            // 
            // txtIpAdresa
            // 
            this.txtIpAdresa.Location = new System.Drawing.Point(500, 106);
            this.txtIpAdresa.Name = "txtIpAdresa";
            this.txtIpAdresa.Size = new System.Drawing.Size(155, 30);
            this.txtIpAdresa.TabIndex = 13;
            // 
            // lblC1_3
            // 
            this.lblC1_3.AutoSize = true;
            this.lblC1_3.Location = new System.Drawing.Point(355, 146);
            this.lblC1_3.Name = "lblC1_3";
            this.lblC1_3.Size = new System.Drawing.Size(132, 23);
            this.lblC1_3.TabIndex = 14;
            this.lblC1_3.Text = "Status događaja";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Evidentiran",
            "U obradi",
            "Rešen"});
            this.cmbStatus.Location = new System.Drawing.Point(500, 142);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(155, 31);
            this.cmbStatus.TabIndex = 15;
            // 
            // lblC2_0
            // 
            this.lblC2_0.AutoSize = true;
            this.lblC2_0.Location = new System.Drawing.Point(690, 38);
            this.lblC2_0.Name = "lblC2_0";
            this.lblC2_0.Size = new System.Drawing.Size(138, 23);
            this.lblC2_0.TabIndex = 16;
            this.lblC2_0.Text = "Podaci o uređaju";
            // 
            // txtUredjaj
            // 
            this.txtUredjaj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUredjaj.Location = new System.Drawing.Point(850, 34);
            this.txtUredjaj.Multiline = true;
            this.txtUredjaj.Name = "txtUredjaj";
            this.txtUredjaj.Size = new System.Drawing.Size(175, 54);
            this.txtUredjaj.TabIndex = 17;
            // 
            // lblC2_1
            // 
            this.lblC2_1.AutoSize = true;
            this.lblC2_1.Location = new System.Drawing.Point(690, 100);
            this.lblC2_1.Name = "lblC2_1";
            this.lblC2_1.Size = new System.Drawing.Size(44, 23);
            this.lblC2_1.TabIndex = 18;
            this.lblC2_1.Text = "Opis";
            // 
            // txtOpis
            // 
            this.txtOpis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOpis.Location = new System.Drawing.Point(850, 96);
            this.txtOpis.Multiline = true;
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(175, 70);
            this.txtOpis.TabIndex = 19;
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
            this.btnNovi.TabIndex = 20;
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
            this.btnIzmeni.TabIndex = 21;
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
            this.btnObrisi.TabIndex = 22;
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
            this.btnSacuvaj.Location = new System.Drawing.Point(835, 255);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(90, 32);
            this.btnSacuvaj.TabIndex = 23;
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
            this.btnOdustani.Location = new System.Drawing.Point(935, 255);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(90, 32);
            this.btnOdustani.TabIndex = 24;
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
            // colKlijent
            // 
            this.colKlijent.FillWeight = 76.40096F;
            this.colKlijent.HeaderText = "Klijent";
            this.colKlijent.MinimumWidth = 7;
            this.colKlijent.Name = "colKlijent";
            this.colKlijent.ReadOnly = true;
            // 
            // colRacun
            // 
            this.colRacun.FillWeight = 76.40096F;
            this.colRacun.HeaderText = "Račun";
            this.colRacun.MinimumWidth = 7;
            this.colRacun.Name = "colRacun";
            this.colRacun.ReadOnly = true;
            // 
            // colTipDogadjaja
            // 
            this.colTipDogadjaja.FillWeight = 76.40096F;
            this.colTipDogadjaja.HeaderText = "Tip događaja";
            this.colTipDogadjaja.MinimumWidth = 7;
            this.colTipDogadjaja.Name = "colTipDogadjaja";
            this.colTipDogadjaja.ReadOnly = true;
            // 
            // colDatum
            // 
            this.colDatum.FillWeight = 76.40096F;
            this.colDatum.HeaderText = "Datum";
            this.colDatum.MinimumWidth = 7;
            this.colDatum.Name = "colDatum";
            this.colDatum.ReadOnly = true;
            // 
            // colVreme
            // 
            this.colVreme.FillWeight = 76.40096F;
            this.colVreme.HeaderText = "Vreme";
            this.colVreme.MinimumWidth = 7;
            this.colVreme.Name = "colVreme";
            this.colVreme.ReadOnly = true;
            // 
            // colIpAdresa
            // 
            this.colIpAdresa.FillWeight = 76.40096F;
            this.colIpAdresa.HeaderText = "IP adresa";
            this.colIpAdresa.MinimumWidth = 7;
            this.colIpAdresa.Name = "colIpAdresa";
            this.colIpAdresa.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.FillWeight = 76.40096F;
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 7;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // UcSigurnost
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblNaslov);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.dgvSigurnost);
            this.Controls.Add(this.grpPodaci);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UcSigurnost";
            this.Size = new System.Drawing.Size(1100, 700);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSigurnost)).EndInit();
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
        private System.Windows.Forms.ComboBox cmbRacunFilter;
        private System.Windows.Forms.Label lblFilter3;
        private System.Windows.Forms.ComboBox cmbTipFilter;
        private System.Windows.Forms.DataGridView dgvSigurnost;
        private System.Windows.Forms.GroupBox grpPodaci;
        private System.Windows.Forms.Label lblC0_0;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblC0_1;
        private System.Windows.Forms.ComboBox cmbKlijent;
        private System.Windows.Forms.Label lblC0_2;
        private System.Windows.Forms.ComboBox cmbRacun;
        private System.Windows.Forms.Label lblC0_3;
        private System.Windows.Forms.ComboBox cmbTipDogadjaja;
        private System.Windows.Forms.Label lblC1_0;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.Label lblC1_1;
        private System.Windows.Forms.TextBox txtVreme;
        private System.Windows.Forms.Label lblC1_2;
        private System.Windows.Forms.TextBox txtIpAdresa;
        private System.Windows.Forms.Label lblC1_3;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblC2_0;
        private System.Windows.Forms.TextBox txtUredjaj;
        private System.Windows.Forms.Label lblC2_1;
        private System.Windows.Forms.TextBox txtOpis;
        private System.Windows.Forms.Button btnNovi;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKlijent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRacun;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipDogadjaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVreme;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIpAdresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}
