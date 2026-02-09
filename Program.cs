using System;
using System.Windows.Forms;
using AppEscritorioUPT.Data;

namespace AppEscritorioUPT
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // 1. Asegurar que la BD y las tablas existen
            Database.EnsureCreated();

            // 2. Lanzar la UI
            Application.Run(new Form1());
        }
    }
}