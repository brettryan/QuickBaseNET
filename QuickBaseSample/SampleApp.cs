/*
 * QuickBaseSampleApp.cs    11 August 2009, 17:38
 * 
 * Copyright 2009 Drunken Dev. All rights reserved.
 * Use is subject to license terms.
 * 
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace DrunkenDev.QuickBase.Sample {

    public static class SampleApp {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.Run(new SampleForm());

            Properties.Settings.Default.Save();
        }

    }

}
