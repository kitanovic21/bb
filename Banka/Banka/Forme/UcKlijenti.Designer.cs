namespace Banka.Forme
{
    partial class UcKlijenti
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNaslov = new System.Windows.Forms.Label();
            this.panelPretraga = new System.Windows.Forms.Panel();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.lblTipFilter = new System.Windows.Forms.Label();
            this.cmbTipFilter = new System.Windows.Forms.ComboBox();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.lblPretraga = new System.Windows.Forms.Label();
            this.dgvKlijenti = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImeNaziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJMBGPIB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpPodaciKlijenta = new System.Windows.Forms.GroupBox();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnNovi = new System.Windows.Forms.Button();
            this.txtKomentar = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtGrad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelPravno = new System.Windows.Forms.Panel();
            this.txtPIB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNazivFirme = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelFizicko = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblDR = new System.Windows.Forms.Label();
            this.txtBrojLicneKarte = new System.Windows.Forms.TextBox();
            this.lblBLK = new System.Windows.Forms.Label();
            this.txtJMBG = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.lblJMBG = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.lblIme = new System.Windows.Forms.Label();
            this.cmbTipKlijenta = new System.Windows.Forms.ComboBox();
            this.lblTipKlijenta = new System.Windows.Forms.Label();
            this.panelPretraga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).BeginInit();
            this.grpPodaciKlijenta.SuspendLayout();
            this.panelPravno.SuspendLayout();
            this.panelFizicko.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNaslov
            // 
            this.lblNaslov.AutoSize = true;
            this.lblNaslov.Font = new System.Drawing.Font("Segoe UI", 18.26866F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNaslov.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(72)))), ((int)(((byte)(106)))));
            this.lblNaslov.Location = new System.Drawing.Point(25, 18);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.Size = new System.Drawing.Size(147, 42);
            this.lblNaslov.TabIndex = 0;
            this.lblNaslov.Text = "KLIJENTI";
            // 
            // panelPretraga
            // 
            this.panelPretraga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPretraga.BackColor = System.Drawing.Color.White;
            this.panelPretraga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPretraga.Controls.Add(this.cmbStatusFilter);
            this.panelPretraga.Controls.Add(this.lblStatusFilter);
            this.panelPretraga.Controls.Add(this.lblTipFilter);
            this.panelPretraga.Controls.Add(this.cmbTipFilter);
            this.panelPretraga.Controls.Add(this.txtPretraga);
            this.panelPretraga.Controls.Add(this.lblPretraga);
            this.panelPretraga.Location = new System.Drawing.Point(25, 68);
            this.panelPretraga.Name = "panelPretraga";
            this.panelPretraga.Size = new System.Drawing.Size(1050, 55);
            this.panelPretraga.TabIndex = 1;
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
            // 
            // lblStatusFilter
            // 
            this.lblStatusFilter.AutoSize = true;
            this.lblStatusFilter.Location = new System.Drawing.Point(645, 18);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(49, 20);
            this.lblStatusFilter.TabIndex = 4;
            this.lblStatusFilter.Text = "Status";
            // 
            // lblTipFilter
            // 
            this.lblTipFilter.AutoSize = true;
            this.lblTipFilter.Location = new System.Drawing.Point(350, 18);
            this.lblTipFilter.Name = "lblTipFilter";
            this.lblTipFilter.Size = new System.Drawing.Size(30, 20);
            this.lblTipFilter.TabIndex = 3;
            this.lblTipFilter.Text = "Tip";
            // 
            // cmbTipFilter
            // 
            this.cmbTipFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipFilter.FormattingEnabled = true;
            this.cmbTipFilter.Items.AddRange(new object[] {
            "Svi",
            "Fizičko lice",
            "Pravno lice"});
            this.cmbTipFilter.Location = new System.Drawing.Point(435, 14);
            this.cmbTipFilter.Name = "cmbTipFilter";
            this.cmbTipFilter.Size = new System.Drawing.Size(180, 28);
            this.cmbTipFilter.TabIndex = 2;
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(90, 14);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(230, 27);
            this.txtPretraga.TabIndex = 1;
            // 
            // lblPretraga
            // 
            this.lblPretraga.AutoSize = true;
            this.lblPretraga.Location = new System.Drawing.Point(14, 18);
            this.lblPretraga.Name = "lblPretraga";
            this.lblPretraga.Size = new System.Drawing.Size(65, 20);
            this.lblPretraga.TabIndex = 0;
            this.lblPretraga.Text = "Pretraga";
            // 
            // dgvKlijenti
            // 
            this.dgvKlijenti.AllowUserToAddRows = false;
            this.dgvKlijenti.AllowUserToDeleteRows = false;
            this.dgvKlijenti.AllowUserToResizeColumns = false;
            this.dgvKlijenti.AllowUserToResizeRows = false;
            this.dgvKlijenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKlijenti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKlijenti.BackgroundColor = System.Drawing.Color.White;
            this.dgvKlijenti.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvKlijenti.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(72)))), ((int)(((byte)(106)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKlijenti.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKlijenti.ColumnHeadersHeight = 34;
            this.dgvKlijenti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colTip,
            this.colImeNaziv,
            this.colJMBGPIB,
            this.colGrad,
            this.colTelefon,
            this.colStatus});
            this.dgvKlijenti.EnableHeadersVisualStyles = false;
            this.dgvKlijenti.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvKlijenti.Location = new System.Drawing.Point(25, 135);
            this.dgvKlijenti.MultiSelect = false;
            this.dgvKlijenti.Name = "dgvKlijenti";
            this.dgvKlijenti.ReadOnly = true;
            this.dgvKlijenti.RowHeadersVisible = false;
            this.dgvKlijenti.RowHeadersWidth = 57;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(234)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvKlijenti.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKlijenti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKlijenti.Size = new System.Drawing.Size(1050, 205);
            this.dgvKlijenti.TabIndex = 2;
            this.dgvKlijenti.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKlijenti_CellClick);
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 7;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 60;
            // 
            // colTip
            // 
            this.colTip.HeaderText = "Tip klijenta";
            this.colTip.MinimumWidth = 7;
            this.colTip.Name = "colTip";
            this.colTip.ReadOnly = true;
            // 
            // colImeNaziv
            // 
            this.colImeNaziv.HeaderText = "Ime / naziv";
            this.colImeNaziv.MinimumWidth = 7;
            this.colImeNaziv.Name = "colImeNaziv";
            this.colImeNaziv.ReadOnly = true;
            // 
            // colJMBGPIB
            // 
            this.colJMBGPIB.HeaderText = "JMBG / PIB";
            this.colJMBGPIB.MinimumWidth = 7;
            this.colJMBGPIB.Name = "colJMBGPIB";
            this.colJMBGPIB.ReadOnly = true;
            // 
            // colGrad
            // 
            this.colGrad.HeaderText = "Grad";
            this.colGrad.MinimumWidth = 7;
            this.colGrad.Name = "colGrad";
            this.colGrad.ReadOnly = true;
            // 
            // colTelefon
            // 
            this.colTelefon.HeaderText = "Telefon";
            this.colTelefon.MinimumWidth = 7;
            this.colTelefon.Name = "colTelefon";
            this.colTelefon.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 7;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // grpPodaciKlijenta
            // 
            this.grpPodaciKlijenta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPodaciKlijenta.BackColor = System.Drawing.Color.White;
            this.grpPodaciKlijenta.Controls.Add(this.btnOdustani);
            this.grpPodaciKlijenta.Controls.Add(this.btnSacuvaj);
            this.grpPodaciKlijenta.Controls.Add(this.btnObrisi);
            this.grpPodaciKlijenta.Controls.Add(this.btnIzmeni);
            this.grpPodaciKlijenta.Controls.Add(this.btnNovi);
            this.grpPodaciKlijenta.Controls.Add(this.txtKomentar);
            this.grpPodaciKlijenta.Controls.Add(this.label8);
            this.grpPodaciKlijenta.Controls.Add(this.cmbStatus);
            this.grpPodaciKlijenta.Controls.Add(this.txtEmail);
            this.grpPodaciKlijenta.Controls.Add(this.label7);
            this.grpPodaciKlijenta.Controls.Add(this.label6);
            this.grpPodaciKlijenta.Controls.Add(this.txtTelefon);
            this.grpPodaciKlijenta.Controls.Add(this.txtGrad);
            this.grpPodaciKlijenta.Controls.Add(this.label5);
            this.grpPodaciKlijenta.Controls.Add(this.label4);
            this.grpPodaciKlijenta.Controls.Add(this.txtAdresa);
            this.grpPodaciKlijenta.Controls.Add(this.label3);
            this.grpPodaciKlijenta.Controls.Add(this.panelPravno);
            this.grpPodaciKlijenta.Controls.Add(this.panelFizicko);
            this.grpPodaciKlijenta.Controls.Add(this.cmbTipKlijenta);
            this.grpPodaciKlijenta.Controls.Add(this.lblTipKlijenta);
            this.grpPodaciKlijenta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPodaciKlijenta.Location = new System.Drawing.Point(25, 355);
            this.grpPodaciKlijenta.Name = "grpPodaciKlijenta";
            this.grpPodaciKlijenta.Size = new System.Drawing.Size(1050, 310);
            this.grpPodaciKlijenta.TabIndex = 3;
            this.grpPodaciKlijenta.TabStop = false;
            this.grpPodaciKlijenta.Text = "Podaci o klijentu";
            // 
            // btnOdustani
            // 
            this.btnOdustani.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOdustani.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOdustani.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnOdustani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdustani.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdustani.Location = new System.Drawing.Point(920, 255);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(90, 32);
            this.btnOdustani.TabIndex = 22;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSacuvaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(72)))), ((int)(((byte)(106)))));
            this.btnSacuvaj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSacuvaj.FlatAppearance.BorderSize = 0;
            this.btnSacuvaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSacuvaj.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSacuvaj.ForeColor = System.Drawing.Color.White;
            this.btnSacuvaj.Location = new System.Drawing.Point(820, 255);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(90, 32);
            this.btnSacuvaj.TabIndex = 21;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = false;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnObrisi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObrisi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnObrisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObrisi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnObrisi.Location = new System.Drawing.Point(220, 255);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(90, 32);
            this.btnObrisi.TabIndex = 20;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIzmeni.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIzmeni.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnIzmeni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzmeni.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzmeni.Location = new System.Drawing.Point(120, 255);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(90, 32);
            this.btnIzmeni.TabIndex = 19;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // btnNovi
            // 
            this.btnNovi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNovi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovi.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnNovi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovi.Location = new System.Drawing.Point(20, 255);
            this.btnNovi.Name = "btnNovi";
            this.btnNovi.Size = new System.Drawing.Size(90, 32);
            this.btnNovi.TabIndex = 18;
            this.btnNovi.Text = "Novi";
            this.btnNovi.UseVisualStyleBackColor = true;
            this.btnNovi.Click += new System.EventHandler(this.btnNovi_Click);
            // 
            // txtKomentar
            // 
            this.txtKomentar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKomentar.Location = new System.Drawing.Point(145, 202);
            this.txtKomentar.Multiline = true;
            this.txtKomentar.Name = "txtKomentar";
            this.txtKomentar.Size = new System.Drawing.Size(485, 40);
            this.txtKomentar.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Komentar";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Aktivan",
            "Neaktivan",
            "Blokiran"});
            this.cmbStatus.Location = new System.Drawing.Point(835, 170);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(175, 28);
            this.cmbStatus.TabIndex = 15;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(835, 136);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(175, 27);
            this.txtEmail.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(690, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(690, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Email";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefon.Location = new System.Drawing.Point(835, 102);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(175, 27);
            this.txtTelefon.TabIndex = 10;
            // 
            // txtGrad
            // 
            this.txtGrad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrad.Location = new System.Drawing.Point(835, 68);
            this.txtGrad.Name = "txtGrad";
            this.txtGrad.Size = new System.Drawing.Size(175, 27);
            this.txtGrad.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(690, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Telefon";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(690, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Grad";
            // 
            // txtAdresa
            // 
            this.txtAdresa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdresa.Location = new System.Drawing.Point(835, 34);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(175, 27);
            this.txtAdresa.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(690, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Adresa";
            // 
            // panelPravno
            // 
            this.panelPravno.Controls.Add(this.txtPIB);
            this.panelPravno.Controls.Add(this.label2);
            this.panelPravno.Controls.Add(this.txtNazivFirme);
            this.panelPravno.Controls.Add(this.label1);
            this.panelPravno.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelPravno.Location = new System.Drawing.Point(20, 70);
            this.panelPravno.Name = "panelPravno";
            this.panelPravno.Size = new System.Drawing.Size(610, 122);
            this.panelPravno.TabIndex = 4;
            this.panelPravno.Visible = false;
            // 
            // txtPIB
            // 
            this.txtPIB.Location = new System.Drawing.Point(125, 45);
            this.txtPIB.Name = "txtPIB";
            this.txtPIB.Size = new System.Drawing.Size(190, 27);
            this.txtPIB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "PIB";
            // 
            // txtNazivFirme
            // 
            this.txtNazivFirme.Location = new System.Drawing.Point(125, 9);
            this.txtNazivFirme.Name = "txtNazivFirme";
            this.txtNazivFirme.Size = new System.Drawing.Size(300, 27);
            this.txtNazivFirme.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv firme";
            // 
            // panelFizicko
            // 
            this.panelFizicko.Controls.Add(this.dateTimePicker1);
            this.panelFizicko.Controls.Add(this.lblDR);
            this.panelFizicko.Controls.Add(this.txtBrojLicneKarte);
            this.panelFizicko.Controls.Add(this.lblBLK);
            this.panelFizicko.Controls.Add(this.txtJMBG);
            this.panelFizicko.Controls.Add(this.txtPrezime);
            this.panelFizicko.Controls.Add(this.lblJMBG);
            this.panelFizicko.Controls.Add(this.lblPrezime);
            this.panelFizicko.Controls.Add(this.txtIme);
            this.panelFizicko.Controls.Add(this.lblIme);
            this.panelFizicko.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelFizicko.Location = new System.Drawing.Point(20, 70);
            this.panelFizicko.Name = "panelFizicko";
            this.panelFizicko.Size = new System.Drawing.Size(610, 122);
            this.panelFizicko.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy.";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(125, 81);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(180, 27);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // lblDR
            // 
            this.lblDR.AutoSize = true;
            this.lblDR.Location = new System.Drawing.Point(0, 85);
            this.lblDR.Name = "lblDR";
            this.lblDR.Size = new System.Drawing.Size(109, 20);
            this.lblDR.TabIndex = 8;
            this.lblDR.Text = "Datum rođenja";
            // 
            // txtBrojLicneKarte
            // 
            this.txtBrojLicneKarte.Location = new System.Drawing.Point(445, 45);
            this.txtBrojLicneKarte.Name = "txtBrojLicneKarte";
            this.txtBrojLicneKarte.Size = new System.Drawing.Size(160, 27);
            this.txtBrojLicneKarte.TabIndex = 7;
            // 
            // lblBLK
            // 
            this.lblBLK.AutoSize = true;
            this.lblBLK.Location = new System.Drawing.Point(335, 49);
            this.lblBLK.Name = "lblBLK";
            this.lblBLK.Size = new System.Drawing.Size(108, 20);
            this.lblBLK.TabIndex = 6;
            this.lblBLK.Text = "Broj lične karte";
            // 
            // txtJMBG
            // 
            this.txtJMBG.Location = new System.Drawing.Point(125, 45);
            this.txtJMBG.Name = "txtJMBG";
            this.txtJMBG.Size = new System.Drawing.Size(180, 27);
            this.txtJMBG.TabIndex = 5;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(445, 9);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(200, 27);
            this.txtPrezime.TabIndex = 4;
            // 
            // lblJMBG
            // 
            this.lblJMBG.AutoSize = true;
            this.lblJMBG.Location = new System.Drawing.Point(0, 49);
            this.lblJMBG.Name = "lblJMBG";
            this.lblJMBG.Size = new System.Drawing.Size(46, 20);
            this.lblJMBG.TabIndex = 3;
            this.lblJMBG.Text = "JMBG";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Location = new System.Drawing.Point(335, 13);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(62, 20);
            this.lblPrezime.TabIndex = 2;
            this.lblPrezime.Text = "Prezime";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(125, 9);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(180, 27);
            this.txtIme.TabIndex = 1;
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Location = new System.Drawing.Point(0, 13);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(34, 20);
            this.lblIme.TabIndex = 0;
            this.lblIme.Text = "Ime";
            // 
            // cmbTipKlijenta
            // 
            this.cmbTipKlijenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipKlijenta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipKlijenta.FormattingEnabled = true;
            this.cmbTipKlijenta.Items.AddRange(new object[] {
            "Fizičko lice",
            "Pravno lice"});
            this.cmbTipKlijenta.Location = new System.Drawing.Point(145, 34);
            this.cmbTipKlijenta.Name = "cmbTipKlijenta";
            this.cmbTipKlijenta.Size = new System.Drawing.Size(180, 28);
            this.cmbTipKlijenta.TabIndex = 1;
            this.cmbTipKlijenta.SelectedIndexChanged += new System.EventHandler(this.cmbTipKlijenta_SelectedIndexChanged);
            // 
            // lblTipKlijenta
            // 
            this.lblTipKlijenta.AutoSize = true;
            this.lblTipKlijenta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipKlijenta.Location = new System.Drawing.Point(20, 38);
            this.lblTipKlijenta.Name = "lblTipKlijenta";
            this.lblTipKlijenta.Size = new System.Drawing.Size(82, 20);
            this.lblTipKlijenta.TabIndex = 0;
            this.lblTipKlijenta.Text = "Tip klijenta";
            // 
            // UcKlijenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.grpPodaciKlijenta);
            this.Controls.Add(this.dgvKlijenti);
            this.Controls.Add(this.panelPretraga);
            this.Controls.Add(this.lblNaslov);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UcKlijenti";
            this.Size = new System.Drawing.Size(1100, 700);
            this.Load += new System.EventHandler(this.UcKlijenti_Load);
            this.panelPretraga.ResumeLayout(false);
            this.panelPretraga.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).EndInit();
            this.grpPodaciKlijenta.ResumeLayout(false);
            this.grpPodaciKlijenta.PerformLayout();
            this.panelPravno.ResumeLayout(false);
            this.panelPravno.PerformLayout();
            this.panelFizicko.ResumeLayout(false);
            this.panelFizicko.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.Panel panelPretraga;
        private System.Windows.Forms.ComboBox cmbTipFilter;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.Label lblPretraga;
        private System.Windows.Forms.DataGridView dgvKlijenti;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.Label lblTipFilter;
        private System.Windows.Forms.GroupBox grpPodaciKlijenta;
        private System.Windows.Forms.ComboBox cmbTipKlijenta;
        private System.Windows.Forms.Label lblTipKlijenta;
        private System.Windows.Forms.Panel panelFizicko;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label lblJMBG;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblDR;
        private System.Windows.Forms.TextBox txtBrojLicneKarte;
        private System.Windows.Forms.Label lblBLK;
        private System.Windows.Forms.TextBox txtJMBG;
        private System.Windows.Forms.Panel panelPravno;
        private System.Windows.Forms.TextBox txtPIB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNazivFirme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtGrad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnNovi;
        private System.Windows.Forms.TextBox txtKomentar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImeNaziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJMBGPIB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}
