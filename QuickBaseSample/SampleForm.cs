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
                txtOutput.Clear();

                Schema schema = svc.GetSchema(txtDBID.Text);
                txtOutput.AppendText("Got Schema:       " + schema.Name);
                txtOutput.AppendText("\n- ID:             " + schema.ID);
                txtOutput.AppendText("\n- Created:        " + schema.CreateDate);
                txtOutput.AppendText("\n- Description:    " + schema.Description);
                txtOutput.AppendText("\n- Mod Date:       " + schema.ModDate);
                txtOutput.AppendText("\n- Next Field ID:  " + schema.NextFieldID);
                txtOutput.AppendText("\n- Next Query ID:  " + schema.NextQueryID);
                txtOutput.AppendText("\n- Next Record ID: " + schema.NextRecordID);
                txtOutput.AppendText("\n- Parent ID:      " + schema.ParentID);
                txtOutput.AppendText("\n- Sort Field:     " + schema.SortField);
                txtOutput.AppendText("\n- Sort Order:     " + schema.SortOrder);
                if (schema.Variables.Count > 0) {
                    txtOutput.AppendText("\n\n==== Variables ====");
                    foreach (string key in schema.Variables.Keys) {
                        txtOutput.AppendText("\n" + key + " = " + schema.Variables[key]);
                    }
                }
                if (schema.Fields.Count > 0) {
                    txtOutput.AppendText("\n\n==== Fields ====");
                    foreach (int key in schema.Fields.Keys) {
                        Field fld = schema.Fields[key];
                        txtOutput.AppendText("\n" + key + ": " + fld.ID);
                    }
                }
                if (schema.Queries.Count > 0) {
                    txtOutput.AppendText("\n\n==== Queries ====");
                    foreach (Query qry in schema.Queries.Values) {
                        txtOutput.AppendText(String.Format("\nID={0}, Name={1}", qry.ID, qry.Name));
                    }
                }
                if (schema.Children.Count > 0) {
                    txtOutput.AppendText("\n\n==== Children ====");
                    foreach (string key in schema.Children.Keys) {
                        txtOutput.AppendText("\n" + key + " = " + schema.Children[key]);
                    }
                }
            } catch (QuickBaseException qbe) {
                txtOutput.AppendText(String.Format(
                    "\nQuickbase Error: {0}: {1}\n  Action: {2}\n  Error: {3}",
                    qbe.ErrorCode, qbe.ErrorText, qbe.Action, qbe.Message));
            } catch (Exception ex) {
                txtOutput.AppendText(String.Format(
                    "\nUnknown Error: {0}: \n{1}",
                    ex.Message, ex.StackTrace));
            }
        }

    }

}
