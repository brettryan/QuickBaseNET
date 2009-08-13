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

        private void Log(String str, params object[] args) {
            Log(str, true, args);
        }

        private void Log(String str, bool newLine, params object[] args) {
            if (args.Length == 0) {
                txtOutput.AppendText(str);
            } else {
                txtOutput.AppendText(String.Format(str, args));
            }
            if (newLine)
                txtOutput.AppendText("\n");
        }

        private void DoPerformQuery(object sender, EventArgs args) {
            try {
                QuickBaseService client = new QuickBaseService(
                    txtUserName.Text, txtPassword.Text, txtUrl.Text);
                if (chkWriteDebug.Checked) {
                    client.DebugLocation = txtDebugLocation.Text;
                    client.IsDebugEnabled = true;
                }

                int qry = 0;
                if (!String.IsNullOrEmpty(txtQueryNum.Text) && !Int32.TryParse(txtQueryNum.Text, out qry)) {
                    MessageBox.Show(this, "You must enter a query number",
                        "Invalid Query", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtOutput.Clear();

                QueryResult res;
                if (qry > 0)
                    res = client.Query(txtDBID.Text, qry);
                else
                    res = client.Query(txtDBID.Text);

                StringBuilder sb;

                foreach (QueryRow r in res.Rows) {
                    sb = new StringBuilder();
                    foreach (int key in r.Data.Keys) {
                        if (sb.Length > 0)
                            sb.Append(',');
                        sb.Append(key).Append("='").Append(r.Data[key]).Append('\'');
                    }
                    Log(sb.ToString());
                    // Start- test query.
                    //var q = from n in r.Data
                    //        where n.Key == "6"
                    //           && n.Value.StartsWith("D44")
                    //           && n.Value.Contains("7")
                    //        select n.Value;
                    //foreach (var b in q) {
                    //    Log(b);
                    //}
                    // END- test query.
                }
                Log(res.Rows.Count + " rows retrieved!");
            } catch (Exception ex) {
                HandleException(ex);
            }
        }

        private void DoGetSchemas(object sender, EventArgs e) {
            QuickBaseService svc = new QuickBaseService(
                txtUserName.Text, txtPassword.Text, txtUrl.Text);
            if (chkWriteDebug.Checked) {
                svc.DebugLocation = txtDebugLocation.Text;
                svc.IsDebugEnabled = true;
            }
            try {
                txtOutput.Clear();

                Schema schema = svc.GetSchema(txtDBID.Text);
                Log("Got Schema:       " + schema.Name);
                Log("- ID:             " + schema.ID);
                Log("- Created:        " + schema.CreateDate);
                Log("- Description:    " + schema.Description);
                Log("- Mod Date:       " + schema.ModDate);
                Log("- Next Field ID:  " + schema.NextFieldID);
                Log("- Next Query ID:  " + schema.NextQueryID);
                Log("- Next Record ID: " + schema.NextRecordID);
                Log("- Parent ID:      " + schema.ParentID);
                Log("- Sort Field:     " + schema.SortField);
                Log("- Sort Order:     " + schema.SortOrder);
                if (schema.Variables.Count > 0) {
                    Log("\n==== Variables ====");
                    foreach (string key in schema.Variables.Keys) {
                        Log(key + " = " + schema.Variables[key]);
                    }
                }
                if (schema.Fields.Count > 0) {
                    Log("\n==== Fields ====");
                    foreach (int key in schema.Fields.Keys) {
                        Field fld = schema.Fields[key];
                        Log(key + ": " + fld.ID);
                    }
                }
                if (schema.Queries.Count > 0) {
                    Log("\n==== Queries ====");
                    foreach (Query qry in schema.Queries.Values) {
                        Log("ID={0}, Name={1}", qry.ID, qry.Name);
                    }
                }
                if (schema.Children.Count > 0) {
                    Log("\n==== Children ====");
                    foreach (string key in schema.Children.Keys) {
                        Log(key + " = " + schema.Children[key]);
                    }
                }
            } catch (Exception ex) {
                HandleException(ex);
            }
        }

        private void HandleException(Exception ex) {
            QuickBaseException qbe = ex as QuickBaseException;
            if (qbe == null) {
                Log("Unknown Error: {0}: \n{1}", ex.Message, ex.StackTrace);
            } else {
                Log("Quickbase Error: {0}: {1}\n  Action: {2}\n  Error: {3}",
                    qbe.ErrorCode, qbe.ErrorText, qbe.Action, qbe.Message);
            }
        }

        private void DoLocationClicked(object sender, EventArgs e) {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Select log file directory.";
            dlg.ShowNewFolderButton = true;
            if (dlg.ShowDialog(this) == DialogResult.OK) {
                txtDebugLocation.Text = dlg.SelectedPath;
                chkWriteDebug.Checked = true;
            }
        }

    }

}
