/*
 * QueryResultPanel.cs    16 August 2009, 1:05
 * 
 * Copyright 2009 John Sands (Australia) Ltd. All rights reserved.
 * Use is subject to license terms.
 * 
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Commons.System;


namespace JohnSands.QuickBase.Sample {

    public partial class QueryResultPanel : UserControl {

        private const string StatusText = "Returned Rows: {0}";
        private QueryResult result;

        public event EventHandler<EventArgs<QuickBaseFile>> FileLinkSelected;

        public QueryResultPanel() {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public QueryResult Result {
            get { return result; }
            set {
                result = value;
                BindResult();
            }
        }

        private void BindResult() {
            grdResults.Rows.Clear();
            grdResults.Columns.Clear();
            if (result == null) {
                label1.Text = String.Format(StatusText, 0);
            } else {
                label1.Text = String.Format(StatusText, result.Rows.Count);
                foreach (Field f in result.Schema.Fields.Values) {
                    DataGridViewColumn col = new DataGridViewColumn();
                    //col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    col.HeaderText = f.Label;
                    col.MinimumWidth = 100;
                    grdResults.Columns.Add(col);
                }
                foreach (QueryRow rr in result.Rows) {
                    DataGridViewRow r = new DataGridViewRow();
                    foreach (int fid in rr.Fields) {
                        DataGridViewCell cell;
                        switch (rr.Result.Schema.Fields[fid].FieldType) {
                            case FieldType.CheckBox:
                                cell = new DataGridViewCheckBoxCell();
                                cell.Value = rr.GetBool(fid);
                                break;
                            case FieldType.Date:
                                cell = new DataGridViewTextBoxCell();
                                DateTime? dt = rr.GetDate(fid);
                                if (dt.HasValue)
                                    cell.Value = dt.Value.ToShortDateString();
                                break;
                            case FieldType.File:
                                cell = new DataGridViewLinkCell();
                                QuickBaseFile f = rr.GetFile(fid);
                                if (f != null) {
                                    cell.Tag = f;
                                    cell.ToolTipText = f.Uri.ToString();
                                    if (String.IsNullOrEmpty(f.DisplayText))
                                        cell.Value = f.Uri;
                                    else
                                        cell.Value = f.DisplayText;
                                }
                                break;
                            case FieldType.Url:
                                cell = new DataGridViewLinkCell();
                                cell.Value = rr.GetUri(fid);
                                break;
                            default:
                                cell = new DataGridViewTextBoxCell();
                                object v = rr.GetObject(fid);
                                if (v == null)
                                    cell.Value = String.Empty;
                                else
                                    cell.Value = v.ToString();
                                break;
                        }
                        cell.Tag = rr.GetObject(fid);
                        r.Cells.Add(cell);
                    }
                    grdResults.Rows.Add(r);
                }
                grdResults.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                foreach (DataGridViewColumn col in grdResults.Columns) {
                    if (col.Width > 400)
                        col.Width = 400;
                }
            }
        }

        private void DoCellContentClick(object sender, DataGridViewCellEventArgs e) {
            QuickBaseFile file = grdResults[e.ColumnIndex, e.RowIndex].Tag
                as QuickBaseFile;
            if (file != null && FileLinkSelected != null) {
                FileLinkSelected(this, new EventArgs<QuickBaseFile>(file));
            }
        }

    }

}
