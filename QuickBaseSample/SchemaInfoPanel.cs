/*
 * SchemaInfoPanel.cs    16 August 2009, 20:18
 * 
 * Copyright 2009 Drunken Dev. All rights reserved.
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


namespace DrunkenDev.QuickBase.Sample {

    public partial class SchemaInfoPanel : UserControl {

        private Schema schema;

        public SchemaInfoPanel() {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Schema Schema {
            get { return schema; }
            set {
                schema = value;
                BindSchema();
            }
        }

        private void BindSchema() {
            if (schema == null) {
                textCreated.Text = String.Empty;
                textDBID.Text = String.Empty;
                textDescription.Text = String.Empty;
                textModified.Text = String.Empty;
                textName.Text = String.Empty;
                textNextFieldID.Text = String.Empty;
                textNextQueryID.Text = String.Empty;
                textNextRecordID.Text = String.Empty;
                textParentDBID.Text = String.Empty;
                textSortField.Text = String.Empty;
                textSortOrder.Text = String.Empty;
            } else {
                textCreated.Text = schema.CreateDate.ToString();
                textDBID.Text = schema.ID;
                textDescription.Text = schema.Description;
                textModified.Text = schema.ModDate.ToString();
                textName.Text = schema.Name;
                textNextFieldID.Text = schema.NextFieldID.ToString();
                textNextQueryID.Text = schema.NextQueryID.ToString();
                textNextRecordID.Text = schema.NextRecordID.ToString();
                textParentDBID.Text = schema.ParentID;
                Field sortField = schema.SortField;
                if (sortField == null)
                    textSortField.Text = String.Empty;
                else
                    textSortField.Text = sortField.Label;
                textSortOrder.Text = schema.SortOrder.ToString();
            }
        }

    }

}
