/// -------  ToujoursEnBeta
/// Author & Copyright : Peter Luschny
/// License: Creative Commons Attribution-ShareAlike 3.0
/// Comments mail to: peter(at)luschny.de
/// Created: 2013-08-16

using System;
using System.Windows.Forms;

namespace Luschny.Tree
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PartitionForm());
        }
    }
}
