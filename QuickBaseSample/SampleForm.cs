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
            QuickBaseService client = new QuickBaseService(
                txtUserName.Text, txtPassword.Text, txtUrl.Text);
            QueryResult res = client.Query("begy9tmr3", 29);
            StringBuilder sb;
            foreach (QueryRow r in res.Rows) {
                sb = new StringBuilder();
                foreach (string key in r.Data.Keys) {
                    if (sb.Length > 0)
                        sb.Append(',');
                    sb.Append(key).Append("='").Append(r.Data[key]).Append('\'');
                }
                Log(sb.ToString());
            }
            Log(res.Rows.Count + " rows retrieved!");
        }

        private void DoGetSchemas(object sender, EventArgs e) {
            QuickBaseService svc = new QuickBaseService(
                txtUserName.Text, txtPassword.Text, txtUrl.Text);
            try {
                txtOutput.Clear();

                Schema schema = svc.GetSchema(txtDBID.Text);
                Log("Got Schema:       " + schema.Name);
                Log("\n- ID:             " + schema.ID);
                Log("\n- Created:        " + schema.CreateDate);
                Log("\n- Description:    " + schema.Description);
                Log("\n- Mod Date:       " + schema.ModDate);
                Log("\n- Next Field ID:  " + schema.NextFieldID);
                Log("\n- Next Query ID:  " + schema.NextQueryID);
                Log("\n- Next Record ID: " + schema.NextRecordID);
                Log("\n- Parent ID:      " + schema.ParentID);
                Log("\n- Sort Field:     " + schema.SortField);
                Log("\n- Sort Order:     " + schema.SortOrder);
                if (schema.Variables.Count > 0) {
                    Log("\n\n==== Variables ====");
                    foreach (string key in schema.Variables.Keys) {
                        Log("\n" + key + " = " + schema.Variables[key]);
                    }
                }
                if (schema.Fields.Count > 0) {
                    Log("\n\n==== Fields ====");
                    foreach (int key in schema.Fields.Keys) {
                        Field fld = schema.Fields[key];
                        Log("\n" + key + ": " + fld.ID);
                    }
                }
                if (schema.Queries.Count > 0) {
                    txtOutput.AppendText("\n\n==== Queries ====");
                    foreach (Query qry in schema.Queries.Values) {
                        Log("\nID={0}, Name={1}", qry.ID, qry.Name);
                    }
                }
                if (schema.Children.Count > 0) {
                    txtOutput.AppendText("\n\n==== Children ====");
                    foreach (string key in schema.Children.Keys) {
                        Log("\n" + key + " = " + schema.Children[key]);
                    }
                }
            } catch (QuickBaseException qbe) {
                Log(
                    "\nQuickbase Error: {0}: {1}\n  Action: {2}\n  Error: {3}",
                    qbe.ErrorCode, qbe.ErrorText, qbe.Action, qbe.Message);
            } catch (Exception ex) {
                Log("\nUnknown Error: {0}: \n{1}", ex.Message, ex.StackTrace);
            }
        }

    }

}
