using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeusz.Konyveles
{
    public partial class MerlegFrm : Form
    {
        public MerlegFrm()
        {
            InitializeComponent();
            MerlegKeszites();
            lekerDatumLbl.Text = DateTime.Now.ToShortDateString();
        }

        private void kilepesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.megnyitasFoablakban(new KezdokepernyoFrm());
        }

        private void MerlegKeszites()
        {
            merlegDgv.Rows.Clear();

            

            merlegDgv.Rows.Add(new object[] { "", "ESZKÖZÖK", "", "", "" });

            merlegDgv.Rows.Add(new object[] { "A.", "Befektetett eszközök", Math.Round(AdatbazisMuveletek.Merleg.ElozoMA() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MA() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "  I.", "  Immateriális javak", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAI() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAI() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Alapítás átszervezés aktivált értéke", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAI1() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAI1() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Kísérleti fejlesztés aktivált értéke", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAI2() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAI2() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Vagyoni értékű jogok", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAI3() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAI3() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    4.", "    Szellemi termékek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAI4() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAI4() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    5.", "    Üzleti vagy cégérték", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAI5() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAI5() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    6.", "    Immateriális javakra adott előlegek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAI6() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAI6() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    7.", "    Immateriális javak értékhelyesbítése", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAI7() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAI7() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "  II.", "  Tárgyi eszközök", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAII() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAII() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Ingatlanok és kapcsolódó vagyoni értékű jogok", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAII1() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAII1() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Műszaki berendezések, gépek, járművek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAII2() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAII2() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Egyéb berendezések, felszerelések, járművek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAII3() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAII3() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    4.", "    Tenyészállatok", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAII4() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAII4() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    5.", "    Beruházások, felújítások", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAII5() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAII5() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    6.", "    Beruházásokra adott előlegek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAII6() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAII6() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    7.", "    Tárgyi eszkökök értékhelyesbítése", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAII7() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAII7() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "  III.", "  Befektetett pénzügyi eszközök", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAIII() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAIII() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Tartós részesedés kapcsolt vállalkozásban", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAIII1() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAIII1() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Tartósan adott kölcsön kapcsolt vállalkozásban", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAIII2() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAIII2() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Tartós jelentős tulajdoni részesedés", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAIII3() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAIII3() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    4.", "    Tartósan adott kölcsön jelentős tulajdoni részesedési viszonyban álló vállalkozásban", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAIII4() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAIII4() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    5.", "    Egyéb tartós részesedés", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAIII5() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAIII5() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    6.", "    Tartósan adott kölcsön egyéb részesedési viszonyban álló vállalkozásban", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAIII6() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAIII6() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    7.", "    Egyéb tartósan adott kölcsön", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAIII7() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAIII7() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    8.", "    Tartós hitelviszonyt megtestesítő értékpapír", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAIII8() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAIII8() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    9.", "    Befektetett pénzügyi eszközök értékhelyesbítése", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAIII9() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAIII9() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    10.", "    Befektetett pénzügyi eszközök értékelési különbözete", Math.Round(AdatbazisMuveletek.Merleg.ElozoMAIII10() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MAIII10() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "B.", "Forgóeszközök", Math.Round(AdatbazisMuveletek.Merleg.ElozoMB() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MB() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "  I.", "  Készletek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBI() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBI() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Anyagok", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBI1() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBI1() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Befejezetlen és félkész termékek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBI2() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBI2() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Növendék-, hízó- és egyéb állatok", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBI3() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBI3() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    4.", "    Késztermékek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBI4() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBI4() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    5.", "    Áruk", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBI5() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBI5() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    6.", "    Készletekre adott előlegek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBI6() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBI6() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "  II.", "  Követelések", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBII() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBII() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Követelések áruszállításból és szolgáltatásból (vevők)", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBII1() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBII1() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Követelések kapcsolt vállalkozással szemben", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBII2() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBII2() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Követelések jelentős tulajdoni részesedési viszonyban lévő vállalkozással szemben", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBII3() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBII3() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    4.", "    Követelések egyéb részesedési viszonyban lévő vállalkozással szemben", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBII4() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBII4() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    5.", "    Váltókövetelések", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBII5() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBII5() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    6.", "    Egyéb követelések", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBII6() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBII6() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    7.", "    Követelések értékelési különbözete", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBII7() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBII7() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    8.", "    Származékos ügyletek pozitív értékelési különbözete", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBII8() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBII8() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "  III.", "  Értékpapírok", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBIII() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBIII() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Részesedés kapcsolt vállalkozásban", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBIII1() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBIII1() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Jelentős tulajdoni részesedés", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBIII2() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBIII2() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Egyéb részesedés", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBIII3() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBIII3() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    4.", "    Saját részvények, saját üzletrészek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBIII4() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBIII4() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    5.", "    Forgatási célú hitelviszonyt megtestesítő értékpapírok", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBIII5() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBIII5() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    6.", "    Értékpapírok értékelési különbözete", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBIII6() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBIII6() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "  IV.", "  Pénzeszközök", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBIV() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBIV() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Pénztár, csekkek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBIV1() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBIV1() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Bankbetétek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMBIV2() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MBIV2() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "C.", "Aktív időbeli elhatárolások", Math.Round(AdatbazisMuveletek.Merleg.ElozoMC() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MC() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Bevételek aktív időbeli elhatárolása", Math.Round(AdatbazisMuveletek.Merleg.ElozoMC1() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MC1() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Költségek, ráfordítások aktív időbeli elhatárolása", Math.Round(AdatbazisMuveletek.Merleg.ElozoMC2() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MC2() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Halasztott ráfordítások", Math.Round(AdatbazisMuveletek.Merleg.ElozoMC3() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MC3() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "", "ESZKÖZÖK ÖSSZESEN", Math.Round(AdatbazisMuveletek.Merleg.ElozoMOsszesEszkoz() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MOsszesEszkoz() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "", "", "", "", "" });

            merlegDgv.Rows.Add(new object[] { "", "FORRÁSOK", "", "", "" });

            merlegDgv.Rows.Add(new object[] { "D.", "Saját tőke", Math.Round(AdatbazisMuveletek.Merleg.ElozoMD() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MD() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "  I.", "  Jegyzett tőke", Math.Round(AdatbazisMuveletek.Merleg.ElozoMDI() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MDI() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "  II.", "  Jegyzett, de még be nem fizetett tőke", Math.Round(AdatbazisMuveletek.Merleg.ElozoMDII() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MDII() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "  III.", "  Tőketartalék", Math.Round(AdatbazisMuveletek.Merleg.ElozoMDIII() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MDIII() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "  IV.", "  Eredménytartalék", Math.Round(AdatbazisMuveletek.Merleg.ElozoMDIV() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MDIV() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "  V.", "  Lekötött tartalék", Math.Round(AdatbazisMuveletek.Merleg.ElozoMDV() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MDV() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "  VI.", "  Értékelési tartalék", Math.Round(AdatbazisMuveletek.Merleg.ElozoMDVI() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MDVI() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "  VII.", "  Adózott eredmény", Math.Round(AdatbazisMuveletek.Merleg.ElozoMDVII() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MDVII() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "E.", "Céltartalékok", Math.Round(AdatbazisMuveletek.Merleg.ElozoME() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.ME() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Céltartalék a várható kötelezettségekre", Math.Round(AdatbazisMuveletek.Merleg.ElozoME1() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.ME1() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Céltartalék a jövőbeni költségekre", Math.Round(AdatbazisMuveletek.Merleg.ElozoME2() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.ME2() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Egyéb céltartalék", Math.Round(AdatbazisMuveletek.Merleg.ElozoME3() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.ME3() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "F.", "Kötelezettségek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMF() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MF() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "  I.", "  Hátrasorolt kötelezettségek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFI() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFI() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Hátrasorolt kötelezettségek kapcsolt vállalkozással szemben", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFI1() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFI1() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Hátrasorolt kötelezettségek jelentős tulajdoni részesedési viszonyban lévő vállalkozással szemben", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFI2() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFI2() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Hátrasorolt kötelezettségek egyéb részesedési viszonyban lévő vállalkozással szemben", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFI3() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFI3() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    4.", "    Hátrasorolt kötelezettségek egyéb gazdálkodóval szemben", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFI4() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFI4() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "  II.", "  Hosszú lejáratú kötelezettségek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFII() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFII() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Hosszú lejáratra kapott kölcsönök", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFII1() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFII1() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Átváltoztatható és átváltozó kötvények", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFII2() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFII2() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Tartozások kötvénykibocsátásból", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFII3() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFII3() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    4.", "    Beruházási és fejlesztési hitelek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFII4() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFII4() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    5.", "    Egyéb hosszú lejáratú hitelek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFII5() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFII5() / 1000f) });
            
            merlegDgv.Rows.Add(new Object[] { "    6.", "    Tartós kötelezettségek kapcsolt vállalkozással szemben", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFII6() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFII6() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    7.", "    Tartós kötelezettségek jelentős tulajdoni részesedési viszonyban lévő vállalkozással szemben", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFII7() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFII7() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    8.", "    Tartós kötelezettségek egyéb részesedési viszonyban lévő vállalkozással szemben", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFII8() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFII8() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    9.", "    Egyéb hosszú lejáratú kötelezettségek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFII9() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFII9() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "  III.", "  Rövid lejáratú kötelezettségek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFIII() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFIII() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Rövid lejáratú kölcsönök", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFIII1() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFIII1() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Rövid lejáratú hitelek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFIII2() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFIII2() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Vevőktől kapott előlegek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFIII3() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFIII3() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    4.", "    Kötelezettségek áruszállításból és szolgáltatásból (szállítók)", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFIII4() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFIII4() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    5.", "    Váltótartozások", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFIII5() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFIII5() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    6.", "    Rövid lejáratú kötelezettségek kapcsolt vállalkozással szemben", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFIII6() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFIII6() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    7.", "    Rövid lejáratú kötelezettségek jelentős tulajdoni részesedési viszonyban lévő vállalkozással szemben", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFIII7() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFIII7() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    8.", "    Rövid lejáratú kötelezettségek egyéb részesedési viszonyban lévő vállalkozással szemben", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFIII8() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFIII8() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    9.", "    Egyéb rövid lejáratú kötelezettségek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFIII9() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFIII9() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    10.", "    Kötelezettségek értékelési különbözette", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFIII10() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFIII10() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    11.", "    Származékos ügyletek negatív értékelési különbözete", Math.Round(AdatbazisMuveletek.Merleg.ElozoMFIII11() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MFIII11() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "G.", "Passzív időbeli elhatárolások", Math.Round(AdatbazisMuveletek.Merleg.ElozoMG() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MG() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Bevételek passzív időbeli elhatárolása", Math.Round(AdatbazisMuveletek.Merleg.ElozoMG1() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MG1() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Költségek, ráfordítások passzív időbeli elhatárolása", Math.Round(AdatbazisMuveletek.Merleg.ElozoMG2() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MG2() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Halasztott bevételek", Math.Round(AdatbazisMuveletek.Merleg.ElozoMG3() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MG3() / 1000f) });

            merlegDgv.Rows.Add(new Object[] { "", "FORRÁSOK ÖSSZESEN", Math.Round(AdatbazisMuveletek.Merleg.ElozoMOsszesForras() / 1000f), "", Math.Round(AdatbazisMuveletek.Merleg.MOsszesForras() / 1000f) });

            merlegDgv.Rows.Add(new object[] { "", "", "", "", "" });

            merlegDgv.Rows.Add(new object[] { "", "", "", DateTime.Now.ToShortDateString(), "" });
        }

        private void excelExportBtn_Click(object sender, EventArgs e)
        {
            if (merlegDgv.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < merlegDgv.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = merlegDgv.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < merlegDgv.Rows.Count; i++)
                {
                    for (int j = 0; j < merlegDgv.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = merlegDgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
                excelApp.Columns.AutoFit();
                excelApp.Visible = true;
            }
        }

        private void csvExportBtn_Click(object sender, EventArgs e)
        {
            if (merlegDgv.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV (*.csv)|*.csv|Minden fájl (*.*)|*.*";
                saveFileDialog.FileName = "merleg.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        File.Delete(saveFileDialog.FileName);
                    }

                    int sorokSzama = merlegDgv.Columns.Count;
                    string sorNevek = "";
                    string[] exportAdatok = new string[merlegDgv.Rows.Count + 1];

                    for (int i = 0; i < sorokSzama; i++)
                    {
                        sorNevek += merlegDgv.Columns[i].HeaderText.ToString();
                    }
                    exportAdatok[0] += sorNevek;

                    for (int i = 1; (i - 1) < merlegDgv.Rows.Count; i++)
                    {
                        for (int j = 0; j < sorokSzama; j++)
                        {
                            exportAdatok[i] += merlegDgv.Rows[i - 1].Cells[j].Value.ToString() + ";";
                        }
                    }

                    File.WriteAllLines(saveFileDialog.FileName, exportAdatok, Encoding.UTF8);

                    MessageBox.Show("A mérleg exportálása CSV-be sikeres!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
