using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Selejtezés
{
    public class Ellenorzes
    {
        public int fsz;
        public void XMLEllenorzes()
        {
            ////fsz = 1;
           
            ////    for (int i = 0; i < fsz; ++i)
            ////    {
            ////    if (fsz != 0)
            ////    {
                   Kereses();
            //        Thread.Sleep(2000);
            //     //   MessageBox.Show(fsz.ToString());
            //    }
             
            //     }

        }
        private void Kereses()
        {
            string[] filePaths = Directory.GetFiles(@"\\fs\Mindenki\IT\Lacas\", "*.pdf",
                                            SearchOption.TopDirectoryOnly);
            fsz = 0;
            foreach (string file in filePaths)
            {
                fsz = fsz + 1;
            }
          //  MessageBox.Show(fsz.ToString());
        }

    }
}
