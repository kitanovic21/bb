using Banka.DTOs;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Banka.Forme
{
    public partial class UcDepoziti : UserControl
    {
        private List<DepozitPregled> sviDepoziti = new List<DepozitPregled>();
        private int? selektovaniDepozit = null;
        public UcDepoziti()
        {
            InitializeComponent();
            cmbStatusFilter.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbKlijentFilter.SelectedIndex = 0;
        }

        private void PopulateInfos()
        {
            dgvDepoziti.Rows.Clear();

            foreach (DepozitPregled dp in sviDepoziti)
            {
                dgvDepoziti.Rows.Add(
                    dp.Id,
                    dp.Iznos,
                    dp.DatumPocetka,
                    dp.Valuta,
                    dp.Status,
                    dp.ImeNaziv
                );
            }

            dgvDepoziti.ClearSelection();
            selektovaniDepozit = null;
            dgvDepoziti.Refresh();
        }
    }
}
