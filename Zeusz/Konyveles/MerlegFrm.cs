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
        }

        private void MerlegKeszites()
        {
            merlegDgv.Rows.Clear();

            merlegDgv.Rows.Add(new object[] { "", "ESZKÖZÖK", "", "", "" });

            merlegDgv.Rows.Add(new object[] { "A.", "Befektetett eszközök", AdatbazisMuveletek.Merleg.ElozoMA(), "", AdatbazisMuveletek.Merleg.MA() });

            merlegDgv.Rows.Add(new object[] { "  I.", "  Immateriális javak", AdatbazisMuveletek.Merleg.ElozoMAI(), "", AdatbazisMuveletek.Merleg.MAI() });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Alapítás átszervezés aktivált értéke", AdatbazisMuveletek.Merleg.ElozoMAI1(), "", AdatbazisMuveletek.Merleg.MAI1() });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Kísérleti fejlesztés aktivált értéke", AdatbazisMuveletek.Merleg.ElozoMAI2(), "", AdatbazisMuveletek.Merleg.MAI2() });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Vagyoni értékű jogok", AdatbazisMuveletek.Merleg.ElozoMAI3(), "", AdatbazisMuveletek.Merleg.MAI3() });

            merlegDgv.Rows.Add(new Object[] { "    4.", "    Szellemi termékek", AdatbazisMuveletek.Merleg.ElozoMAI4(), "", AdatbazisMuveletek.Merleg.MAI4() });

            merlegDgv.Rows.Add(new Object[] { "    5.", "    Üzleti vagy cégérték", AdatbazisMuveletek.Merleg.ElozoMAI5(), "", AdatbazisMuveletek.Merleg.MAI5() });

            merlegDgv.Rows.Add(new Object[] { "    6.", "    Immateriális javakra adott előlegek", AdatbazisMuveletek.Merleg.ElozoMAI6(), "", AdatbazisMuveletek.Merleg.MAI6() });

            merlegDgv.Rows.Add(new Object[] { "    7.", "    Immateriális javak értékhelyesbítése", AdatbazisMuveletek.Merleg.ElozoMAI7(), "", AdatbazisMuveletek.Merleg.MAI7() });

            merlegDgv.Rows.Add(new object[] { "  II.", "  Tárgyi eszközök", AdatbazisMuveletek.Merleg.ElozoMAII(), "", AdatbazisMuveletek.Merleg.MAII() });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Ingatlanok és kapcsolódó vagyoni értékű jogok", AdatbazisMuveletek.Merleg.ElozoMAII1(), "", AdatbazisMuveletek.Merleg.MAII1() });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Műszaki berendezések, gépek, járművek", AdatbazisMuveletek.Merleg.ElozoMAII2(), "", AdatbazisMuveletek.Merleg.MAII2() });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Egyéb berendezések, felszerelések, járművek", AdatbazisMuveletek.Merleg.ElozoMAII3(), "", AdatbazisMuveletek.Merleg.MAII3() });

            merlegDgv.Rows.Add(new Object[] { "    4.", "    Tenyészállatok", AdatbazisMuveletek.Merleg.ElozoMAII4(), "", AdatbazisMuveletek.Merleg.MAII4() });

            merlegDgv.Rows.Add(new Object[] { "    5.", "    Beruházások, felújítások", AdatbazisMuveletek.Merleg.ElozoMAII5(), "", AdatbazisMuveletek.Merleg.MAII5() });

            merlegDgv.Rows.Add(new Object[] { "    6.", "    Beruházásokra adott előlegek", AdatbazisMuveletek.Merleg.ElozoMAII6(), "", AdatbazisMuveletek.Merleg.MAII6() });

            merlegDgv.Rows.Add(new Object[] { "    7.", "    Tárgyi eszkökök értékhelyesbítése", AdatbazisMuveletek.Merleg.ElozoMAII7(), "", AdatbazisMuveletek.Merleg.MAII7() });

            merlegDgv.Rows.Add(new object[] { "  III.", "  Befektetett pénzügyi eszközök", AdatbazisMuveletek.Merleg.ElozoMAIII(), "", AdatbazisMuveletek.Merleg.MAIII() });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Tartós részesedés kapcsolt vállalkozásban", AdatbazisMuveletek.Merleg.ElozoMAIII1(), "", AdatbazisMuveletek.Merleg.MAIII1() });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Tartósan adott kölcsön kapcsolt vállalkozásban", AdatbazisMuveletek.Merleg.ElozoMAIII2(), "", AdatbazisMuveletek.Merleg.MAIII2() });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Tartós jelentős tulajdoni részesedés", AdatbazisMuveletek.Merleg.ElozoMAIII3(), "", AdatbazisMuveletek.Merleg.MAIII3() });

            merlegDgv.Rows.Add(new Object[] { "    4.", "    Tartósan adott kölcsön jelentős tulajdoni részesedési viszonyban álló vállalkozásban", AdatbazisMuveletek.Merleg.ElozoMAIII4(), "", AdatbazisMuveletek.Merleg.MAIII4() });

            merlegDgv.Rows.Add(new Object[] { "    5.", "    Egyéb tartós részesedés", AdatbazisMuveletek.Merleg.ElozoMAIII5(), "", AdatbazisMuveletek.Merleg.MAIII5() });

            merlegDgv.Rows.Add(new Object[] { "    6.", "    Tartósan adott kölcsön egyéb részesedési viszonyban álló vállalkozásban", AdatbazisMuveletek.Merleg.ElozoMAIII6(), "", AdatbazisMuveletek.Merleg.MAIII6() });

            merlegDgv.Rows.Add(new Object[] { "    7.", "    Egyéb tartósan adott kölcsön", AdatbazisMuveletek.Merleg.ElozoMAIII7(), "", AdatbazisMuveletek.Merleg.MAIII7() });

            merlegDgv.Rows.Add(new Object[] { "    8.", "    Tartós hitelviszonyt megtestesítő értékpapír", AdatbazisMuveletek.Merleg.ElozoMAIII8(), "", AdatbazisMuveletek.Merleg.MAIII8() });

            merlegDgv.Rows.Add(new Object[] { "    9.", "    Befektetett pénzügyi eszközök értékhelyesbítése", AdatbazisMuveletek.Merleg.ElozoMAIII9(), "", AdatbazisMuveletek.Merleg.MAIII9() });

            merlegDgv.Rows.Add(new Object[] { "    10.", "    Befektetett pénzügyi eszközök értékelési különbözete", AdatbazisMuveletek.Merleg.ElozoMAIII10(), "", AdatbazisMuveletek.Merleg.MAIII10() });

            merlegDgv.Rows.Add(new object[] { "B.", "Forgóeszközök", AdatbazisMuveletek.Merleg.ElozoMB(), "", AdatbazisMuveletek.Merleg.MB() });

            merlegDgv.Rows.Add(new object[] { "  I.", "  Készletek", AdatbazisMuveletek.Merleg.ElozoMBI(), "", AdatbazisMuveletek.Merleg.MBI() });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Anyagok", AdatbazisMuveletek.Merleg.ElozoMBI1(), "", AdatbazisMuveletek.Merleg.MBI1() });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Befejezetlen és félkész termékek", AdatbazisMuveletek.Merleg.ElozoMBI2(), "", AdatbazisMuveletek.Merleg.MBI2() });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Növendék-, hízó- és egyéb állatok", AdatbazisMuveletek.Merleg.ElozoMBI3(), "", AdatbazisMuveletek.Merleg.MBI3() });

            merlegDgv.Rows.Add(new Object[] { "    4.", "    Késztermékek", AdatbazisMuveletek.Merleg.ElozoMBI4(), "", AdatbazisMuveletek.Merleg.MBI4() });

            merlegDgv.Rows.Add(new Object[] { "    5.", "    Áruk", AdatbazisMuveletek.Merleg.ElozoMBI5(), "", AdatbazisMuveletek.Merleg.MBI5() });

            merlegDgv.Rows.Add(new Object[] { "    6.", "    Készletekre adott előlegek", AdatbazisMuveletek.Merleg.ElozoMBI6(), "", AdatbazisMuveletek.Merleg.MBI6() });

            merlegDgv.Rows.Add(new object[] { "  II.", "  Követelések", AdatbazisMuveletek.Merleg.ElozoMBII(), "", AdatbazisMuveletek.Merleg.MBII() });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Követelések áruszállításból és szolgáltatásból (vevők)", AdatbazisMuveletek.Merleg.ElozoMBII1(), "", AdatbazisMuveletek.Merleg.MBII1() });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Követelések kapcsolt vállalkozással szemben", AdatbazisMuveletek.Merleg.ElozoMBII2(), "", AdatbazisMuveletek.Merleg.MBII2() });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Követelések jelentős tulajdoni részesedési viszonyban lévő vállalkozással szemben", AdatbazisMuveletek.Merleg.ElozoMBII3(), "", AdatbazisMuveletek.Merleg.MBII3() });

            merlegDgv.Rows.Add(new Object[] { "    4.", "    Követelések egyéb részesedési viszonyban lévő vállalkozással szemben", AdatbazisMuveletek.Merleg.ElozoMBII4(), "", AdatbazisMuveletek.Merleg.MBII4() });

            merlegDgv.Rows.Add(new Object[] { "    5.", "    Váltókövetelések", AdatbazisMuveletek.Merleg.ElozoMBII5(), "", AdatbazisMuveletek.Merleg.MBII5() });

            merlegDgv.Rows.Add(new Object[] { "    6.", "    Egyéb követelések", AdatbazisMuveletek.Merleg.ElozoMBII6(), "", AdatbazisMuveletek.Merleg.MBII6() });

            merlegDgv.Rows.Add(new Object[] { "    7.", "    Követelések értékelési különbözete", AdatbazisMuveletek.Merleg.ElozoMBII7(), "", AdatbazisMuveletek.Merleg.MBII7() });

            merlegDgv.Rows.Add(new Object[] { "    8.", "    Származékos ügyletek pozitív értékelési különbözete", AdatbazisMuveletek.Merleg.ElozoMBII8(), "", AdatbazisMuveletek.Merleg.MBII8() });

            merlegDgv.Rows.Add(new object[] { "  III.", "  Értékpapírok", AdatbazisMuveletek.Merleg.ElozoMBIII(), "", AdatbazisMuveletek.Merleg.MBIII() });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Részesedés kapcsolt vállalkozásban", AdatbazisMuveletek.Merleg.ElozoMBIII1(), "", AdatbazisMuveletek.Merleg.MBIII1() });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Jelentős tulajdoni részesedés", AdatbazisMuveletek.Merleg.ElozoMBIII2(), "", AdatbazisMuveletek.Merleg.MBIII2() });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Egyéb részesedés", AdatbazisMuveletek.Merleg.ElozoMBIII3(), "", AdatbazisMuveletek.Merleg.MBIII3() });

            merlegDgv.Rows.Add(new Object[] { "    4.", "    Saját részvények, saját üzletrészek", AdatbazisMuveletek.Merleg.ElozoMBIII4(), "", AdatbazisMuveletek.Merleg.MBIII4() });

            merlegDgv.Rows.Add(new Object[] { "    5.", "    Forgatási célú hitelviszonyt megtestesítő értékpapírok", AdatbazisMuveletek.Merleg.ElozoMBIII5(), "", AdatbazisMuveletek.Merleg.MBIII5() });

            merlegDgv.Rows.Add(new Object[] { "    6.", "    Értékpapírok értékelési különbözete", AdatbazisMuveletek.Merleg.ElozoMBIII6(), "", AdatbazisMuveletek.Merleg.MBIII6() });

            merlegDgv.Rows.Add(new object[] { "  IV.", "  Pénzeszközök", AdatbazisMuveletek.Merleg.ElozoMBIV(), "", AdatbazisMuveletek.Merleg.MBIV() });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Pénztár, csekkek", AdatbazisMuveletek.Merleg.ElozoMBIV1(), "", AdatbazisMuveletek.Merleg.MBIV1() });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Bankbetétek", AdatbazisMuveletek.Merleg.ElozoMBIV2(), "", AdatbazisMuveletek.Merleg.MBIV2() });

            merlegDgv.Rows.Add(new object[] { "C.", "Aktív időbeli elhatárolások", AdatbazisMuveletek.Merleg.ElozoMC(), "", AdatbazisMuveletek.Merleg.MC() });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Bevételek aktív időbeli elhatárolása", AdatbazisMuveletek.Merleg.ElozoMC1(), "", AdatbazisMuveletek.Merleg.MC1() });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Költségek, ráfordítások aktív időbeli elhatárolása", AdatbazisMuveletek.Merleg.ElozoMC2(), "", AdatbazisMuveletek.Merleg.MC2() });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Halasztott ráfordítások", AdatbazisMuveletek.Merleg.ElozoMC3(), "", AdatbazisMuveletek.Merleg.MC3() });

            merlegDgv.Rows.Add(new Object[] { "", "ESZKÖZÖK ÖSSZESEN", AdatbazisMuveletek.Merleg.ElozoMOsszesEszkoz(), "", AdatbazisMuveletek.Merleg.MOsszesEszkoz() });

            merlegDgv.Rows.Add(new object[] { "", "", "", "", "" });

            merlegDgv.Rows.Add(new object[] { "", "FORRÁSOK", "", "", "" });

            merlegDgv.Rows.Add(new object[] { "D.", "Saját tőke", AdatbazisMuveletek.Merleg.ElozoMD(), "", AdatbazisMuveletek.Merleg.MD() });

            merlegDgv.Rows.Add(new object[] { "  I.", "  Jegyzett tőke", AdatbazisMuveletek.Merleg.ElozoMDI(), "", AdatbazisMuveletek.Merleg.MDI() });

            merlegDgv.Rows.Add(new object[] { "  II.", "  Jegyzett, de még be nem fizetett tőke", AdatbazisMuveletek.Merleg.ElozoMDII(), "", AdatbazisMuveletek.Merleg.MDII() });

            merlegDgv.Rows.Add(new object[] { "  III.", "  Tőketartalék", AdatbazisMuveletek.Merleg.ElozoMDIII(), "", AdatbazisMuveletek.Merleg.MDIII() });

            merlegDgv.Rows.Add(new object[] { "  IV.", "  Eredménytartalék", AdatbazisMuveletek.Merleg.ElozoMDIV(), "", AdatbazisMuveletek.Merleg.MDIV() });

            merlegDgv.Rows.Add(new object[] { "  V.", "  Lekötött tartalék", AdatbazisMuveletek.Merleg.ElozoMDV(), "", AdatbazisMuveletek.Merleg.MDV() });

            merlegDgv.Rows.Add(new object[] { "  VI.", "  Értékelési tartalék", AdatbazisMuveletek.Merleg.ElozoMDVI(), "", AdatbazisMuveletek.Merleg.MDVI() });

            merlegDgv.Rows.Add(new object[] { "  VII.", "  Adózott eredmény", AdatbazisMuveletek.Merleg.ElozoMDVII(), "", AdatbazisMuveletek.Merleg.MDVII() });

            merlegDgv.Rows.Add(new object[] { "E.", "Céltartalékok", AdatbazisMuveletek.Merleg.ElozoME(), "", AdatbazisMuveletek.Merleg.ME() });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Céltartalék a várható kötelezettségekre", AdatbazisMuveletek.Merleg.ElozoME1(), "", AdatbazisMuveletek.Merleg.ME1() });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Céltartalék a jövőbeni költségekre", AdatbazisMuveletek.Merleg.ElozoME2(), "", AdatbazisMuveletek.Merleg.ME2() });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Egyéb céltartalék", AdatbazisMuveletek.Merleg.ElozoME3(), "", AdatbazisMuveletek.Merleg.ME3() });

            merlegDgv.Rows.Add(new object[] { "F.", "Kötelezettségek", AdatbazisMuveletek.Merleg.ElozoMF(), "", AdatbazisMuveletek.Merleg.MF() });

            merlegDgv.Rows.Add(new object[] { "  I.", "  Hátrasorolt kötelezettségek", AdatbazisMuveletek.Merleg.ElozoMFI(), "", AdatbazisMuveletek.Merleg.MFI() });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Hátrasorolt kötelezettségek kapcsolt vállalkozással szemben", AdatbazisMuveletek.Merleg.ElozoMFI1(), "", AdatbazisMuveletek.Merleg.MFI1() });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Hátrasorolt kötelezettségek jelentős tulajdoni részesedési viszonyban lévő vállalkozással szemben", AdatbazisMuveletek.Merleg.ElozoMFI2(), "", AdatbazisMuveletek.Merleg.MFI2() });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Hátrasorolt kötelezettségek egyéb részesedési viszonyban lévő vállalkozással szemben", AdatbazisMuveletek.Merleg.ElozoMFI3(), "", AdatbazisMuveletek.Merleg.MFI3() });

            merlegDgv.Rows.Add(new Object[] { "    4.", "    Hátrasorolt kötelezettségek egyéb gazdálkodóval szemben", AdatbazisMuveletek.Merleg.ElozoMFI4(), "", AdatbazisMuveletek.Merleg.MFI4() });

            merlegDgv.Rows.Add(new object[] { "  II.", "  Hosszú lejáratú kötelezettségek", AdatbazisMuveletek.Merleg.ElozoMFII(), "", AdatbazisMuveletek.Merleg.MFII() });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Hosszú lejáratra kapott kölcsönök", AdatbazisMuveletek.Merleg.ElozoMFII1(), "", AdatbazisMuveletek.Merleg.MFII1() });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Átváltoztatható és átváltozó kötvények", AdatbazisMuveletek.Merleg.ElozoMFII2(), "", AdatbazisMuveletek.Merleg.MFII2() });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Tartozások kötvénykibocsátásból", AdatbazisMuveletek.Merleg.ElozoMFII3(), "", AdatbazisMuveletek.Merleg.MFII3() });

            merlegDgv.Rows.Add(new Object[] { "    4.", "    Beruházási és fejlesztési hitelek", AdatbazisMuveletek.Merleg.ElozoMFII4(), "", AdatbazisMuveletek.Merleg.MFII4() });

            merlegDgv.Rows.Add(new Object[] { "    5.", "    Egyéb hosszú lejáratú hitelek", AdatbazisMuveletek.Merleg.ElozoMFII5(), "", AdatbazisMuveletek.Merleg.MFII5() });
            
            merlegDgv.Rows.Add(new Object[] { "    6.", "    Tartós kötelezettségek kapcsolt vállalkozással szemben", AdatbazisMuveletek.Merleg.ElozoMFII6(), "", AdatbazisMuveletek.Merleg.MFII6() });

            merlegDgv.Rows.Add(new Object[] { "    7.", "    Tartós kötelezettségek jelentős tulajdoni részesedési viszonyban lévő vállalkozással szemben", AdatbazisMuveletek.Merleg.ElozoMFII7(), "", AdatbazisMuveletek.Merleg.MFII7() });

            merlegDgv.Rows.Add(new Object[] { "    8.", "    Tartós kötelezettségek egyéb részesedési viszonyban lévő vállalkozással szemben", AdatbazisMuveletek.Merleg.ElozoMFII8(), "", AdatbazisMuveletek.Merleg.MFII8() });

            merlegDgv.Rows.Add(new Object[] { "    9.", "    Egyéb hosszú lejáratú kötelezettségek", AdatbazisMuveletek.Merleg.ElozoMFII9(), "", AdatbazisMuveletek.Merleg.MFII9() });

            merlegDgv.Rows.Add(new object[] { "  III.", "  Rövid lejáratú kötelezettségek", AdatbazisMuveletek.Merleg.ElozoMFIII(), "", AdatbazisMuveletek.Merleg.MFIII() });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Rövid lejáratú kölcsönök", AdatbazisMuveletek.Merleg.ElozoMFIII1(), "", AdatbazisMuveletek.Merleg.MFIII1() });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Rövid lejáratú hitelek", AdatbazisMuveletek.Merleg.ElozoMFIII2(), "", AdatbazisMuveletek.Merleg.MFIII2() });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Vevőktől kapott előlegek", AdatbazisMuveletek.Merleg.ElozoMFIII3(), "", AdatbazisMuveletek.Merleg.MFIII3() });

            merlegDgv.Rows.Add(new Object[] { "    4.", "    Kötelezettségek áruszállításból és szolgáltatásból (szállítók)", AdatbazisMuveletek.Merleg.ElozoMFIII4(), "", AdatbazisMuveletek.Merleg.MFIII4() });

            merlegDgv.Rows.Add(new Object[] { "    5.", "    Váltótartozások", AdatbazisMuveletek.Merleg.ElozoMFIII5(), "", AdatbazisMuveletek.Merleg.MFIII5() });

            merlegDgv.Rows.Add(new Object[] { "    6.", "    Rövid lejáratú kötelezettségek kapcsolt vállalkozással szemben", AdatbazisMuveletek.Merleg.ElozoMFIII6(), "", AdatbazisMuveletek.Merleg.MFIII6() });

            merlegDgv.Rows.Add(new Object[] { "    7.", "    Rövid lejáratú kötelezettségek jelentős tulajdoni részesedési viszonyban lévő vállalkozással szemben", AdatbazisMuveletek.Merleg.ElozoMFIII7(), "", AdatbazisMuveletek.Merleg.MFIII7() });

            merlegDgv.Rows.Add(new Object[] { "    8.", "    Rövid lejáratú kötelezettségek egyéb részesedési viszonyban lévő vállalkozással szemben", AdatbazisMuveletek.Merleg.ElozoMFIII8(), "", AdatbazisMuveletek.Merleg.MFIII8() });

            merlegDgv.Rows.Add(new Object[] { "    9.", "    Egyéb rövid lejáratú kötelezettségek", AdatbazisMuveletek.Merleg.ElozoMFIII9(), "", AdatbazisMuveletek.Merleg.MFIII9() });

            merlegDgv.Rows.Add(new Object[] { "    10.", "    Kötelezettségek értékelési különbözette", AdatbazisMuveletek.Merleg.ElozoMFIII10(), "", AdatbazisMuveletek.Merleg.MFIII10() });

            merlegDgv.Rows.Add(new Object[] { "    11.", "    Származékos ügyletek negatív értékelési különbözete", AdatbazisMuveletek.Merleg.ElozoMFIII11(), "", AdatbazisMuveletek.Merleg.MFIII11() });

            merlegDgv.Rows.Add(new object[] { "G.", "Passzív időbeli elhatárolások", AdatbazisMuveletek.Merleg.ElozoMG(), "", AdatbazisMuveletek.Merleg.MG() });

            merlegDgv.Rows.Add(new Object[] { "    1.", "    Bevételek passzív időbeli elhatárolása", AdatbazisMuveletek.Merleg.ElozoMG1(), "", AdatbazisMuveletek.Merleg.MG1() });

            merlegDgv.Rows.Add(new Object[] { "    2.", "    Költségek, ráfordítások passzív időbeli elhatárolása", AdatbazisMuveletek.Merleg.ElozoMG2(), "", AdatbazisMuveletek.Merleg.MG2() });

            merlegDgv.Rows.Add(new Object[] { "    3.", "    Halasztott bevételek", AdatbazisMuveletek.Merleg.ElozoMG3(), "", AdatbazisMuveletek.Merleg.MG3() });

            merlegDgv.Rows.Add(new Object[] { "", "FORRÁSOK ÖSSZESEN", AdatbazisMuveletek.Merleg.ElozoMOsszesForras(), "", AdatbazisMuveletek.Merleg.MOsszesForras() });
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
