using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeusz.Sugo
{
    public partial class KezikonyvFrm : Form
    {
        public KezikonyvFrm()
        {
            InitializeComponent();

            // segítség: https://www.c-sharpcorner.com/UploadFile/hirendra_singh/how-to-show-pdf-file-in-C-Sharp/
            kezikonyvPdf.LoadFile("felhasznaloi_kezikonyv.pdf");
        }
    }
}
