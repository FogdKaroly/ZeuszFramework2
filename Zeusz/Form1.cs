using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeusz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DesignBeallitas();
            /*
            BejelentkezesFrm bejelentkezesFrm = new BejelentkezesFrm();
            bejelentkezesFrm.ShowDialog();

            CegvalasztoFrm cegvalasztoFrm = new CegvalasztoFrm();
            cegvalasztoFrm.ShowDialog();
            */
            megnyitasFoablakban(new KezdokepernyoFrm());

            this.Text = "Felhasználó: " + BejelentkezesFrm.Felhasznalo.Felhasznalonev + " | Kiválasztott cég: " + AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis;

            JogosultsagEllenorzes();
            
        }
        public static void JogosultsagEllenorzes()
        {
            foreach (var jog in BejelentkezesFrm.Felhasznalo.Jogosultsagok)
            {
                foreach (Control panelGomb in oldalMenuPanel.Controls)
                {
                    if ((panelGomb.Name == jog.Key) && (jog.Value == 0))
                    {
                        //MessageBox.Show(panelGomb.Name, panelGomb.Text);
                        panelGomb.Enabled = false;
                    }
                }
                foreach (Control panelGomb in konyvelesAlmenuPanel.Controls)
                {
                    if ((panelGomb.Name == jog.Key) && (jog.Value == 0))
                    {
                        //MessageBox.Show(panelGomb.Name, panelGomb.Text);
                        panelGomb.Enabled = false;
                    }
                }
                foreach (Control panelGomb in lekerdezesekAlmenuPanel.Controls)
                {
                    if ((panelGomb.Name == jog.Key) && (jog.Value == 0))
                    {
                        //MessageBox.Show(panelGomb.Name, panelGomb.Text);
                        panelGomb.Enabled = false;
                    }
                }
                foreach (Control panelGomb in beallitasokAlmenuPanel.Controls)
                {
                    if ((panelGomb.Name == jog.Key) && (jog.Value == 0))
                    {
                        //MessageBox.Show(panelGomb.Name, panelGomb.Text);
                        panelGomb.Enabled = false;
                    }
                }
                foreach (Control panelGomb in sugoAlmenuPanel.Controls)
                {
                    if ((panelGomb.Name == jog.Key) && (jog.Value == 0))
                    {
                        //MessageBox.Show(panelGomb.Name, panelGomb.Text);
                        panelGomb.Enabled = false;
                    }
                }
            }
        }
        private void DesignBeallitas()
        {
            konyvelesAlmenuPanel.Visible = false;
            lekerdezesekAlmenuPanel.Visible = false;
            beallitasokAlmenuPanel.Visible = false;
            sugoAlmenuPanel.Visible = false;
        }

        private void AlmenuElrejtes()
        {
            if (konyvelesAlmenuPanel.Visible == true)
            {
                konyvelesAlmenuPanel.Visible = false;
            }
            if (lekerdezesekAlmenuPanel.Visible == true)
            {
                lekerdezesekAlmenuPanel.Visible = false;
            }
            if (beallitasokAlmenuPanel.Visible == true)
            {
                beallitasokAlmenuPanel.Visible = false;
            }
            if (sugoAlmenuPanel.Visible == true)
            {
                sugoAlmenuPanel.Visible = false;
            }
        }

        private void AlmenuMegjelenites(Panel almenu)
        {
            if (almenu.Visible == false)
            {
                AlmenuElrejtes();
                almenu.Visible = true;
            }
            else
            {
                almenu.Visible = false;
            }
        }

        private void konyvelesBtn_Click(object sender, EventArgs e)
        {
            AlmenuMegjelenites(konyvelesAlmenuPanel);
        }

        private void ujVevoKonyveleseBtn_Click(object sender, EventArgs e)
        {
            // Új vevő tétel könyvelése, ha nincs lezárva az év
            if (!AdatbazisMuveletek.Lekerdezesek.LezartE(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis))
            {
                megnyitasFoablakban(new Konyveles.UjVevoKonyveleseFrm());
            }
            else
            {
                MessageBox.Show("Erre az évre a kiválasztott partnernél már nem lehet könyvelni, mert lezárt!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            AlmenuElrejtes();
        }

        private void ujSzallitoKonyveleseBtn_Click(object sender, EventArgs e)
        {
            // Új szállítói tétel könyvelése, ha nincs lezárva az év
            if (!AdatbazisMuveletek.Lekerdezesek.LezartE(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis))
            {
                megnyitasFoablakban(new Konyveles.UjSzallitoKonyveleseFrm());
            }
            else
            {
                MessageBox.Show("Erre az évre a kiválasztott partnernél már nem lehet könyvelni, mert lezárt!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            AlmenuElrejtes();
        }

        private void ujVegyesKonyveleseBtn_Click(object sender, EventArgs e)
        {
            // Új vegyes tétel könyvelése
            if (!AdatbazisMuveletek.Lekerdezesek.LezartE(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis))
            {
                megnyitasFoablakban(new Konyveles.UjVegyesKonyveleseFrm());
            }
            else
            {
                MessageBox.Show("Erre az évre a kiválasztott partnernél már nem lehet könyvelni, mert lezárt!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            AlmenuElrejtes();
        }

        private void merlegKesziteseBtn_Click(object sender, EventArgs e)
        {
            // Mérleg készítése
            megnyitasFoablakban(new Konyveles.MerlegFrm());

            AlmenuElrejtes();
        }

        private void eredmenyKesziteseBtn_Click(object sender, EventArgs e)
        {
            // Eredmény készítése
            megnyitasFoablakban(new Konyveles.EredmenyFrm());

            AlmenuElrejtes();
        }

        private void evNyitasBtn_Click(object sender, EventArgs e)
        {
            // Évnyitás, ha már le van zárva
            if (AdatbazisMuveletek.Lekerdezesek.LezartE(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis))
            {
                megnyitasFoablakban(new Konyveles.NyitasFrm());
            }
            else
            {
                MessageBox.Show("Az év még nincs lezárva, nem lehet újat nyitni!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            AlmenuElrejtes();
        }

        private void evZarasBtn_Click(object sender, EventArgs e)
        {
            // Évzárás, ha még nincs lezárva
            if (!AdatbazisMuveletek.Lekerdezesek.LezartE(AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis))
            {
                megnyitasFoablakban(new Konyveles.ZarasFrm());
            }
            else
            {
                MessageBox.Show("Az év már le van zárva ennél a cégnél!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            AlmenuElrejtes();
        }

        private void lekerdezesekBtn_Click(object sender, EventArgs e)
        {
            AlmenuMegjelenites(lekerdezesekAlmenuPanel);
        }

        private void kivonatBtn_Click(object sender, EventArgs e)
        {
            // Kivonat
            megnyitasFoablakban(new Lekerdezesek.FokonyviKivonatFrm());

            AlmenuElrejtes();
        }

        private void kartonBtn_Click(object sender, EventArgs e)
        {
            // Karton
            megnyitasFoablakban(new Lekerdezesek.FokonyviKartonFrm());

            AlmenuElrejtes();
        }

        private void nyitottVevoBtn_Click(object sender, EventArgs e)
        {
            // Nyitott vevők
            megnyitasFoablakban(new Lekerdezesek.NyitottVevoFrm());

            AlmenuElrejtes();
        }

        private void nyitottSzallitoBtn_Click(object sender, EventArgs e)
        {
            // Nyitott szállítók
            megnyitasFoablakban(new Lekerdezesek.NyitottSzallitoFrm());

            AlmenuElrejtes();
        }

        private void afaAnalitikaBtn_Click(object sender, EventArgs e)
        {
            // ÁFA analitika
            megnyitasFoablakban(new Lekerdezesek.AfaAnalitikaFrm());

            AlmenuElrejtes();
        }

        private void vezetoiInfoBtn_Click(object sender, EventArgs e)
        {
            // Vezetői infók
            megnyitasFoablakban(new Lekerdezesek.VezetoiInfoFrm());

            AlmenuElrejtes();
        }

        private void beallitasokBtn_Click(object sender, EventArgs e)
        {
            AlmenuMegjelenites(beallitasokAlmenuPanel);
        }

        private void konyveloCegAdataiBtn_Click(object sender, EventArgs e)
        {
            // Könyvelőcég adatai
            megnyitasFoablakban(new KonyvelocegAdataiFrm());

            AlmenuElrejtes();
        }

        private void felhasznalokKezeleseBtn_Click(object sender, EventArgs e)
        {
            // Felhasználók kezelése
            megnyitasFoablakban(new FelhasznalokKezeleseFrm());

            AlmenuElrejtes();
        }

        private void jogosultsagKezelesBtn_Click(object sender, EventArgs e)
        {
            // Jogosultságok kezelése
            megnyitasFoablakban(new JogosultsagKezelesFrm());

            AlmenuElrejtes();
        }

        private void konyveltCegAdataiBtn_Click(object sender, EventArgs e)
        {
            // Könyvelt cégek adatai
            megnyitasFoablakban(new KonyveltCegAdataiFrm());

            AlmenuElrejtes();
        }

        private void cegvaltasBtn_Click(object sender, EventArgs e)
        {
            // Másik cég választása

            CegvalasztoFrm cegvalasztoFrm = new CegvalasztoFrm();
            if (cegvalasztoFrm.ShowDialog() == DialogResult.OK)
            {
                megnyitasFoablakban(new KezdokepernyoFrm());
                this.Text = "Felhasználó: " + BejelentkezesFrm.Felhasznalo.Felhasznalonev + " | Kiválasztott cég: " + AdatbazisMuveletek.AktualisAdatbazis.KivalasztottAdatbazis;
            }

            AlmenuElrejtes();
        }

        private void partnerKarbantartasBtn_Click(object sender, EventArgs e)
        {
            // Partnerek karbantartása
            megnyitasFoablakban(new PartenrtorzsFrm());

            AlmenuElrejtes();
        }

        private void szamlatukorKarbantartasBtn_Click(object sender, EventArgs e)
        {
            //Számlatükör karbantartása
            megnyitasFoablakban(new Beallitasok.SzamlatukorKarbantartasFrm());

            AlmenuElrejtes();
        }

        private void sugoBtn_Click(object sender, EventArgs e)
        {
            AlmenuMegjelenites(sugoAlmenuPanel);
        }

        private void kezikonyvBtn_Click(object sender, EventArgs e)
        {
            // Kézikönyv
            megnyitasFoablakban(new Sugo.KezikonyvFrm());

            AlmenuElrejtes();
        }

        private void nevjegyBtn_Click(object sender, EventArgs e)
        {
            // Névjegy

            megnyitasFoablakban(new Nevjegy());

            AlmenuElrejtes();
        }

        private static Form aktivForm = null;
        public static void megnyitasFoablakban(Form megnyitandoForm)
        {
            if (aktivForm != null)
            {
                aktivForm.Close();
            }
            aktivForm = megnyitandoForm;
            megnyitandoForm.TopLevel = false;
            megnyitandoForm.FormBorderStyle = FormBorderStyle.None;
            megnyitandoForm.Dock = DockStyle.Fill;
            foAblakPanel.Controls.Add(megnyitandoForm);
            foAblakPanel.Tag = megnyitandoForm;
            megnyitandoForm.BringToFront();
            megnyitandoForm.Show();
        }
    }
}
