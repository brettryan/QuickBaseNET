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
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

using Commons.Windows.Forms;
using Commons.System;

using JohnSands.QuickBase;


namespace JohnSands.QuickBase.Sample {

    /// <summary>
    ///
    /// </summary>
    public partial class SampleForm : Form {

        private QuickBaseService svc;
        private BackgroundWorker wkr;
        private ToolStripButton cancelButton;

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
                try {
                    txtOutput.AppendText(String.Format(str, args));
                } catch (Exception ex) {
                    HandleException(ex);
                }
            }
            if (newLine)
                txtOutput.AppendText("\n");
        }

        private void PrintSchema(Schema schema) {
            Log("\n=== Schema Information ===");
            Log("Name:           {0}", schema.Name);
            Log("ID:             {0}", schema.ID);
            Log("Description:    {0}", schema.Description);
            Log("Created:        {0}", schema.CreateDate);
            Log("Mod Date:       {0}", schema.ModDate);
            Log("Next Field ID:  {0}", schema.NextFieldID);
            Log("Next Query ID:  {0}", schema.NextQueryID);
            Log("Next Record ID: {0}", schema.NextRecordID);
            Log("Parent ID:      {0}", schema.ParentID);
            if (schema.SortField != null)
                Log("Sort Field:     {0}", schema.SortField.Label);
            Log("Sort Order:     {0}", schema.SortOrder);
            if (schema.Variables.Count > 0) {
                Log("\n==== Variables ====");
                Log("Variable             Value");
                Log("-------------------- ------------------------------");
                foreach (KeyValuePair<string, string> ent in schema.Variables.OrderBy(en => en.Key)) {
                    Log("{0,-20} {1}", ent.Key, ent.Value);
                }
            }
            if (schema.Fields.Count > 0) {
                Log("\n==== Fields ====");
                Log("  ID Type         Mode    Width Label");
                Log("---- ------------ ------- ----- ------------------------------");

                foreach (KeyValuePair<int, Field> ent in schema.Fields) {
                    Log("{0,4} {1,-12} {2,-7} {3,-5} {4}",
                        ent.Key,
                        ent.Value.FieldType,
                        ent.Value.Mode == FieldMode.Normal ? String.Empty : ent.Value.Mode.ToString(),
                        ent.Value.Width,
                        ent.Value.Label
                        );
                }
            }
            if (schema.Queries.Count > 0) {
                Log("\n==== Queries ====");
                Log("  ID Type         Name");
                Log("---- ------------ ------------------------------");
                foreach (Query qry in schema.Queries.Values.OrderBy(q => q.Name)) {
                    Log("{0,4} {1,-12} {2}", qry.ID, qry.QueryType, qry.Name);
                }
            }
            if (schema.Children.Count > 0) {
                Log("\n==== Children ====");
                Log("DBID       Name");
                Log("---------- ------------------------------");
                foreach (KeyValuePair<String, String> ent in schema.Children) {
                    Log("{0,-10} {1}", ent.Key, ent.Value);
                }
            }
        }

        private void PrintQueryResult(QueryResult res) {
            string[] labels = new string[res.Schema.Fields.Count];
            int[] labelWidths = new int[res.Schema.Fields.Count];
            int i = 0;
            foreach (Field f in res.Schema.Fields.Values) {
                labels[i] = f.Label.TrimToEmpty();
                labelWidths[i] = Math.Max(f.Width, f.Label == null ? 0 : f.Label.Length);
                i++;
            }

            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            for (int x = 0; x < i; x++) {
                if (sb.Length > 0) {
                    sb.Append(' ');
                    sb2.Append(' ');
                }
                sb.Append(labels[x].PadRight(labelWidths[x]));
                sb2.Append("".PadRight(labelWidths[x], '-'));
            }
            Log(sb.ToString());
            Log(sb2.ToString());

            foreach (QueryRow r in res.Rows) {
                sb = new StringBuilder();
                i = 0;
                foreach (int key in r.Data.Keys) {
                    if (sb.Length > 0)
                        sb.Append(' ');
                    object v = r.GetObject(key);
                    sb.Append((v == null ? String.Empty : v.ToString()).PadRight(labelWidths[i]));
                    //sb.Append(key).Append("='").Append(r.GetObject(key)).Append('\'');
                    i++;
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
        }

        private string GetSelectedDBID() {
            GenericElement<string> ent = comboBox1.SelectedItem as GenericElement<string>;
            if (ent == null || ent.Tag == null)
                return String.Empty;
            return ent.Tag;
        }

        private void DoGetSchemas(object sender, EventArgs e) {
            try {
                txtOutput.Clear();
                Schema schema = svc.GetSchema(GetSelectedDBID());
                schemaInfoPanel1.Schema = schema;
                PrintSchema(schema);

                comboQuery.Items.Clear();
                foreach (Query q in schema.Queries.Values) {
                    comboQuery.Items.Add(new GenericElement<Query>(q.Name, q));
                }
            } catch (Exception ex) {
                HandleException(ex, true);
            }
        }

        private void DoPerformQuery(object sender, EventArgs args) {
            try {
                GenericElement<Query> elm = comboQuery.SelectedItem as GenericElement<Query>;
                if (elm == null) {
                    MessageBox.Show(this, "You must enter a query number",
                        "Invalid Query", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtOutput.Clear();

                QueryResult res;
                //if (qry > 0)
                //    res = svc.Query(GetSelectedDBID(), qry);
                //else
                //    res = svc.Query(GetSelectedDBID());
                queryResults.Result = res = svc.Query(GetSelectedDBID(), elm.Tag.ID);

                //PrintQueryResult(res);
                if (res.Schema != null) {
                    Log("\nResult also has a schema object available...");
                    PrintSchema(res.Schema);
                } else {
                    Log("No schema object returned.");
                }
            } catch (Exception ex) {
                HandleException(ex, true);
            }
        }

        private void HandleException(Exception ex) {
            QuickBaseException qbe = ex as QuickBaseException;
            if (qbe == null) {
                System.Net.WebException we = ex as System.Net.WebException;
                if (we == null) {
                    Log("Unknown Error: {0}: \n{1}", ex.Message, ex.StackTrace);
                } else {
                    Log("Web Error ({0}): {1}\n{2}", we.Status, we.Message, we.StackTrace);
                }
            } else {
                Log("Quickbase Error: {0}: {1}\n  Action: {2}\n  Error: {3}",
                    qbe.ErrorCode, qbe.ErrorText, qbe.Action, qbe.Message);
            }
        }

        private void HandleException(Exception ex, bool showDialog) {
            HandleException(ex);
            if (showDialog) {

                QuickBaseException qbe = ex as QuickBaseException;
                if (qbe != null) {
                    MessageBox.Show(this,
                        String.Format(
                            "QuickBase rased an error while getting schema information.\n\n" +
                            "Action: {0}\nError: {1} - {2}\nMessage: {3}",
                            qbe.Action,
                            qbe.ErrorCode,
                            qbe.ErrorText,
                            qbe.Message),
                        "QuickBase Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                WebException we = ex as WebException;
                if (we != null) {
                    MessageBox.Show(this,
                        String.Format(
                            "{0}: {1}",
                            we.Status, we.Message),
                        "Web Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                MessageBox.Show(this,
                    String.Format(
                        "{0} rased.\n{1}",
                        ex.Message,
                        ex.StackTrace),
                    "Unknown Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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

        private void DoFormLoaded(object sender, EventArgs e) {
            this.Size = Properties.Settings.Default.SampleFormSize;
            this.Location = Properties.Settings.Default.SampleFormLocation;
            if (Properties.Settings.Default.SampleFormMaximized) {
                this.WindowState = FormWindowState.Maximized;
            }
            queryResults.FileLinkSelected += new EventHandler<EventArgs<QuickBaseFile>>(queryResults_FileLinkSelected);

            cancelButton = new ToolStripButton("Cancel");
            cancelButton.Visible = false;
            cancelButton.Click += new EventHandler(DoCancel);
            //statusStrip1.Items.Add(cancelButton);
            statusStrip1.Items.Insert(1, cancelButton);
        }

        private void DoCancel(object sender, EventArgs e) {
            if (wkr != null && wkr.IsBusy && wkr.WorkerSupportsCancellation) {
                wkr.CancelAsync();
            }
        }

        private void queryResults_FileLinkSelected(object sender, EventArgs<QuickBaseFile> e) {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Save file to location.";
            dlg.AutoUpgradeEnabled = true;
            dlg.CheckPathExists = true;

            DirectoryInfo di = new DirectoryInfo(txtDebugLocation.Text);
            if (di.Exists)
                dlg.InitialDirectory = txtDebugLocation.Text;
            dlg.FileName = e.Data.DisplayText;

            if (dlg.ShowDialog(this) == DialogResult.OK) {
                progressStatus.Value = 0;
                progressStatus.Visible = true;
                labelStatus.Text = String.Empty;
                cancelButton.Visible = true;

                BackgroundWorkerDialog bgdlg = new BackgroundWorkerDialog(
                    String.Format("Downloading file '{0}'", e.Data.DisplayText),
                    "Downloading file from QuickBase...");
                wkr = svc.WriteFileAsync(e.Data, dlg.FileName,
                    DoWriteFileStarted,
                    DoWriteFileComplete,
                    DoWriteFileProgressChanged);
                bgdlg.SetWorker(wkr);
                bgdlg.ShowDialog(this);
            }
        }

        private void DoWriteFileStarted(QuickBaseFile file, long length, string contentType) {
            labelStatus.Text = String.Format(
                "File download started with length {0}, content type {1}", length, contentType);
            //Console.WriteLine("Write File Started: {0}, {1}", length, contentType);
        }
        private void DoWriteFileComplete(QuickBaseFile file, bool cancelled, Exception ex) {
            if (ex != null) {
                MessageBox.Show(this,
                    "There was a problem writing the output file!\n\n" + ex.Message,
                    "File download error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                labelStatus.Text = String.Format(
                    "Download of '{0}' raised error!", file.DisplayText);
            } else if (cancelled) {
                labelStatus.Text = String.Format(
                    "Download of '{0}' cancelled!", file.DisplayText);
            } else {
                labelStatus.Text = String.Format(
                    "Download of '{0}' completed successfully!", file.DisplayText);
            }
            progressStatus.Visible = false;
            cancelButton.Visible = false;
            wkr = null;
        }
        private void DoWriteFileProgressChanged(QuickBaseFile file, int percent) {
            progressStatus.Value = percent;
        }

        private void DoFormClosing(object sender, FormClosingEventArgs e) {
            if (WindowState == FormWindowState.Normal) {
                Properties.Settings.Default.SampleFormSize = Size;
                Properties.Settings.Default.SampleFormLocation = Location;
            }
            Properties.Settings.Default.SampleFormMaximized =
                WindowState == FormWindowState.Maximized;
            if (svc != null && svc.IsAuthenticated) {
                try {
                    svc.SignOut();
                } catch (Exception) { }
            }
        }

        private void UpdateEnabled() {
            bool authenticated = svc != null && svc.IsAuthenticated;
            btnSignIn.Enabled = !authenticated;
            txtPassword.Enabled = !authenticated;
            txtUserName.Enabled = !authenticated;
            textAppToken.Enabled = !authenticated;

            btnGetSchemas.Enabled = authenticated && !String.IsNullOrEmpty(GetSelectedDBID());
            btnRefreshSchemas.Enabled = authenticated;
            btnRunQuery.Enabled = authenticated;
            btnSignOut.Enabled = authenticated;
            comboBox1.Enabled = authenticated;
            //txtQueryNum.Enabled = authenticated;
            comboQuery.Enabled = authenticated;
            txtUrl.Enabled = !authenticated;
        }

        private void DoSignIn(object sender, EventArgs e) {
            if (svc != null && svc.IsAuthenticated) {
                MessageBox.Show(
                    this,
                    "You still have a session open, you must call 'SignOut' first.",
                    "Still signed in.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            try {
                string appToken = textAppToken.Text.TrimToEmpty();
                if (String.IsNullOrEmpty(appToken)) {
                    svc = new QuickBaseService(
                       txtUserName.Text, txtPassword.Text, txtUrl.Text);
                } else {
                    svc = new QuickBaseService(
                       txtUserName.Text, txtPassword.Text, txtUrl.Text, appToken);
                }
                if (chkWriteDebug.Checked) {
                    svc.DebugLocation = txtDebugLocation.Text;
                    svc.IsDebugEnabled = true;
                }
                if (svc.Authenticate()) {
                    DoRefreshSchemas(sender, e);
                } else {
                    MessageBox.Show(
                        this,
                        "The Authentication did not pass but produced no error.",
                        "Authentication did not pass.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                UpdateEnabled();
            } catch (Exception ex) {
                HandleException(ex, true);
            }
        }

        private void DoSignOut(object sender, EventArgs e) {
            if (svc == null || !svc.IsAuthenticated) {
                MessageBox.Show(
                    this,
                    "You are not signed into the QuickBase service.",
                    "Not signed in.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            try {
                svc.SignOut();
                UpdateEnabled();
            } catch (Exception ex) {
                HandleException(ex, true);
            }
        }

        private void DoRefreshSchemas(object sender, EventArgs e) {
            IDictionary<string, string> res = svc.GetGrantedDatabases();
            comboBox1.Items.Clear();
            foreach (KeyValuePair<string, string> ent in res) {
                GenericElement<string> elm = new GenericElement<string>(ent.Value, ent.Key);
                comboBox1.Items.Add(elm);
            }
        }

        private void DoSelectedDbChanged(object sender, EventArgs e) {
            comboQuery.Items.Clear();
            string dbid = GetSelectedDBID();
            btnGetSchemas.Enabled = !String.IsNullOrEmpty(dbid) && svc != null && svc.IsAuthenticated;
            if (!String.IsNullOrEmpty(dbid)) {
                DoGetSchemas(sender, e);
            }
        }

    }

}
