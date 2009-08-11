/*
 * SampleForm.cs    8/11/2009 5:40:37 PM
 *
 * Copyright 2009  All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using JohnSands.QuickBase;


namespace JohnSands.QuickBase.Sample {

    /// <summary>
    ///
    /// </summary>
    public partial class SampleForm : Form {

        /// <summary>
        /// Creates a new instance of <c>SampleForm</c>.
        /// </summary>
        public SampleForm() {
            InitializeComponent();
        }

        private void DoGetSchemas(object sender, EventArgs e) {
            QuickBaseService svc = new QuickBaseService(
                txtUserName.Text, txtPassword.Text, txtUrl.Text);
            try {
                svc.GetSchema(txtDBID.Text);
            } catch (QuickBaseException qbe) {
                Console.WriteLine("Quickbase Error: {0}: {1}\n  Action: {2}\n  Error: {3}",
                    qbe.ErrorCode, qbe.ErrorText, qbe.Action, qbe.Message);
            } catch (Exception ex) {
            }
        }

    }

}
