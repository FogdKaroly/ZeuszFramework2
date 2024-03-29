﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeusz.Lekerdezesek
{
    public partial class MutatoszamokFrm : Form
    {
        public MutatoszamokFrm(int ev)
        {
            InitializeComponent();
            Megjelenites(ev);
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Megjelenites(int ev)
        {
            adossagallomanyAranyaLbl.Text = Math.Round(AdatbazisMuveletek.Lekerdezesek.AdossagallomanyAranyaLekerdezes(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, ev), 2).ToString() + "%";

            likviditasiMutatoLbl.Text = Math.Round(AdatbazisMuveletek.Lekerdezesek.LikviditasiMutatoLekeres(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, ev), 2).ToString();

            likviditasiGyorsrataLbl.Text = Math.Round(AdatbazisMuveletek.Lekerdezesek.LikviditasiGyorsrataLekerdezes(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, ev), 2).ToString();

            nettoMukodoTokeLbl.Text = Math.Round(AdatbazisMuveletek.Lekerdezesek.NettoMukodoTokeLekerdezes(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, ev), 2).ToString();

            tokeszerkezetiMutatoLbl.Text = Math.Round(AdatbazisMuveletek.Lekerdezesek.TokeszerkezetiMutatoLekerdezes(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, ev), 2).ToString() + "%";

            befektetettEszkozFedezettsegLbl.Text = Math.Round(AdatbazisMuveletek.Lekerdezesek.BefektetettEszkozFedezetettsegLekerdezes(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, ev), 2).ToString() + "%";

            vagyonszerkezetLbl.Text = Math.Round(AdatbazisMuveletek.Lekerdezesek.VagyonszerkezetLekeres(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, ev), 2).ToString() + "%";

            befektetettEszkozAranyLbl.Text = Math.Round(AdatbazisMuveletek.Lekerdezesek.BefektetettEszkozokAranyaLekerdezes(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis, ev), 2).ToString() + "%";
        }
    }
}
