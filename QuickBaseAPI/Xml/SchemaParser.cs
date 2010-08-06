/*
 * SchemaParser.cs    14 August 2009, 16:15
 *
 * Copyright 2009 Drunken Dev. All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Commons.System;


namespace DrunkenDev.QuickBase.Xml {

    /// <summary>
    /// 
    /// </summary>
    internal static class SchemaParser {

        /// <summary>
        /// Parent tag for quieries.
        /// </summary>
        internal const string TagQueries = "queries";
        /// <summary>
        /// Query tag.
        /// </summary>
        private const string TagQuery = "query";
        /// <summary>
        /// Query column list tag.
        /// </summary>
        private const string TagQueryColumnList = "qyclst";
        /// <summary>
        /// Query name tag.
        /// </summary>
        private const string TagQueryName = "qyname";
        /// <summary>
        /// Query options tag.
        /// </summary>
        private const string TagQueryOptions = "qyopts";
        /// <summary>
        /// Query sort list tag.
        /// </summary>
        private const string TagQuerySortList = "qyslst";
        /// <summary>
        /// Query type tag.
        /// </summary>
        private const string TagQueryType = "qytype";
        /// <summary>
        /// Query ID attribute.
        /// </summary>
        private const string AttributeQueryID = "id";

        internal const string TagFields = "fields";
        private const string TagField = "field";
        private const string TagFieldAbbreviate = "abbreviate";
        private const string TagFieldAllowHtml = "allowHTML";
        private const string TagFieldAllowNewChoices = "allow_new_choices";
        private const string TagFieldAppearsAs = "appears_as";
        private const string TagFieldAppearsByDefault = "appears_by_default";
        private const string TagFieldAutoSave = "auto_save";
        private const string TagFieldAppendOnly = "append_only";
        private const string TagFieldBlankIsZero = "blank_is_zero";
        private const string TagFieldBold = "bold";
        private const string TagFieldCarryChoices = "carrychoices";
        private const string TagFieldChoice = "choice";
        private const string TagFieldChoices = "choices";
        private const string TagFieldCommaStart = "comma_start";
        private const string TagFieldCoverText = "cover_text";
        private const string TagFieldCurrencyFormat = "currency_format";
        private const string TagFieldCurrencySymbol = "currency_symbol";
        private const string TagFieldDecimalPlaces = "decimal_places";
        private const string TagFieldDefaultKind = "default_kind";
        private const string TagFieldDefaultToday = "default_today";
        private const string TagFieldDisplayDayOfWeek = "display_dow";
        private const string TagFieldDisplayGraphic = "display_graphic";
        private const string TagFieldDisplayMonth = "display_month";
        private const string TagFieldDisplayRelative = "display_relative";
        private const string TagFieldDisplayTime = "display_time";
        private const string TagFieldDisplayUser = "display_user";
        private const string TagFieldDisplayZone = "display_zone";
        private const string TagFieldDoesAverage = "does_average";
        private const string TagFieldDoesDataCopy = "doesdatacopy";
        private const string TagFieldDoesTotal = "does_total";
        private const string TagFieldExact = "exact";
        private const string TagFieldFindEnabled = "find_enabled";
        private const string TagFieldForeignKey = "foreignkey";
        private const string TagFieldFormula = "formula";
        private const string TagFieldHelp = "fieldhelp";
        private const string TagFieldLabel = "label";
        private const string TagFieldMaximumLength = "maxlength";
        private const string TagFieldMaximumVersions = "max_versions";
        private const string TagFieldNoWrap = "nowrap";
        private const string TagFieldNumberOfLines = "num_lines";
        private const string TagFieldSeeVersions = "see_versions";
        private const string TagFieldRequired = "required";
        private const string TagFieldSortAsGiven = "sort_as_given";
        private const string TagFieldSourceFieldID = "source_fid";
        private const string TagFieldTargetDBID = "target_dbid";
        private const string TagFieldTargetFieldID = "target_fid";
        private const string TagFieldUnique = "unique";
        private const string TagFieldUseNewWindow = "use_new_window";
        private const string TagFieldWidth = "width";
        private const string AttributeFieldBaseType = "base_type";
        private const string AttributeFieldID = "id";
        private const string AttributeFieldMode = "mode";
        private const string AttributeFieldModeVirtual = "virtual";
        private const string AttributeFieldModeLookup = "lookup";
        private const string AttributeFieldType = "field_type";

        internal const string TagTable = "table";
        internal const string TagTableName = "name";
        internal const string TagTableProperties = "original";
        private const string TagTablePropertyApplicationID = "app_id";
        private const string TagTablePropertyChildDBID = "chdbid";
        private const string TagTablePropertyCreateDate = "cre_date";
        private const string TagTablePropertyDescription = "desc";
        private const string TagTablePropertyDefaultSortFieldID = "def_sort_fid";
        private const string TagTablePropertyDefaultSortOrder = "def_sort_order";
        private const string TagTablePropertyKeyFieldID = "key_fid";
        private const string TagTablePropertyModDate = "mod_date";
        private const string TagTablePropertyNextFieldID = "next_field_id";
        private const string TagTablePropertyNextQueryID = "next_query_id";
        private const string TagTablePropertyNextRecordID = "next_record_id";
        private const string TagTablePropertyTableID = "table_id";

        private const string TagVariable = "var";
        internal const string TagVariables = "variables";
        private const string AttributeVariableName = "name";

        internal const string TagChildDatabases = "chdbids";
        private const string TagChildDBID = "chdbid";
        private const string AttributeChildDBIDName = "name";

#if DEBUG
        private static bool showDebugMessages = true;
        public static bool ShowDebugMessages {
            get { return showDebugMessages; }
            set { showDebugMessages = value; }
        }
#endif

        private static Query GetQuery(XmlReader rdr) {
            Query qry = new Query();
            bool c = rdr.Read();
            qry.ID = Int32.Parse(rdr.GetAttribute(AttributeQueryID));
            while (c) {
                c = false;
                if (rdr.IsStartElement()) {
                    switch (rdr.Name) {
                        case TagQuery:
                            break;
                        case TagQueryName:
                            qry.Name = rdr.ReadString();
                            break;
                        case TagQueryType:
                            qry.QueryType = rdr.ReadString();
                            //switch (rdr.ReadString()) {
                            //    case "newsummary":
                            //        break;
                            //    case "table":
                            //        break;
                            //}
                            break;
                        case TagQueryColumnList:
                            foreach (string col in rdr.ReadString().Split('.')) {
                                qry.ColumnList.Add(Int32.Parse(col));
                            }
                            break;
                        case TagQuerySortList:
                            foreach (string col in rdr.ReadString().Split('.')) {
                                qry.SortList.Add(Int32.Parse(col));
                            }
                            break;
                        case TagQueryOptions:
                            qry.Options = rdr.ReadString();
                            break;
                        case "qycalst":
                            qry.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case "qyform": // Ignore this.
                            rdr.ReadInnerXml();
                            c = true;
                            break;
                        case "qyftyp":
                            qry.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case "qycrit":
                            qry.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
#if DEBUG
                        default:
                            if (ShowDebugMessages)
                                Console.WriteLine("Unknown Query Property: '{0}'", rdr.Name);
                            break;
#endif
                    }
                }
                if (!c) c = rdr.Read();
            }
            return qry;
        }

        internal static ICollection<Query> GetQueries(XmlReader rdr) {
            ICollection<Query> queries = new List<Query>();
            bool c = rdr.Read();

            while (c) {
                c = false;
                if (rdr.IsStartElement()) {
                    if (TagQuery.Equals(rdr.Name)) {
                        queries.Add(GetQuery(rdr.ReadSubtree()));
                        c = true;
                    }
                }
                if (!c) c = rdr.Read();
            }
            return queries;
        }

        private static IList<string> GetChoices(XmlReader rdr) {
            List<String> choices = new List<string>();
            bool c = rdr.Read();
            while (c) {
                c = false;
                if (rdr.IsStartElement()) {
                    if (TagFieldChoice.Equals(rdr.Name)) {
                        choices.Add(rdr.ReadString());
                        c = true;
                    }
                }
                if (!c) c = rdr.Read();
            }
            return choices;
        }

        private static Field GetField(XmlReader rdr) {
            Field f = new Field();
            bool c = rdr.Read();
            f.ID = Int32.Parse(rdr.GetAttribute(AttributeFieldID));
            switch (rdr.GetAttribute(AttributeFieldType)) {
                case "checkbox":
                    f.FieldType = FieldType.CheckBox;
                    break;
                case "currency":
                    f.FieldType = FieldType.Currency;
                    break;
                case "dblink":
                    f.FieldType = FieldType.DatabaseLink;
                    break;
                case "date":
                    f.FieldType = FieldType.Date;
                    break;
                case "duration":
                    f.FieldType = FieldType.Duration;
                    break;
                case "email":
                    f.FieldType = FieldType.Email;
                    break;
                case "file":
                    f.FieldType = FieldType.File;
                    break;
                case "float":
                    f.FieldType = FieldType.Float;
                    break;
                case "percent":
                    f.FieldType = FieldType.Percent;
                    break;
                case "phone":
                    f.FieldType = FieldType.Phone;
                    break;
                case "rating":
                    f.FieldType = FieldType.Rating;
                    break;
                case "recordid":
                    f.FieldType = FieldType.RecordID;
                    break;
                case "text":
                    f.FieldType = FieldType.Text;
                    break;
                case "timeofday":
                    f.FieldType = FieldType.TimeOfDay;
                    break;
                case "timestamp":
                    f.FieldType = FieldType.TimeStamp;
                    break;
                case "url":
                    f.FieldType = FieldType.Url;
                    break;
                case "userid":
                    f.FieldType = FieldType.UserID;
                    break;
            }
            f.BaseType = rdr.GetAttribute(AttributeFieldBaseType);
            switch (rdr.GetAttribute(AttributeFieldMode)) {
                case AttributeFieldModeVirtual:
                    f.Mode = FieldMode.Virtual;
                    break;
                case AttributeFieldModeLookup:
                    f.Mode = FieldMode.Lookup;
                    break;
            }
            while (c) {
                c = false;

                if (rdr.IsStartElement()) {
                    switch (rdr.Name) {
                        case TagField:
                            break;
                        case TagFieldLabel:
                            f.Label = rdr.ReadString();
                            break;
                        case TagFieldNoWrap:
                            f.NoWrap = "1".Equals(rdr.ReadString());
                            break;
                        case TagFieldBold:
                            f.Bold = "1".Equals(rdr.ReadString());
                            break;
                        case TagFieldRequired:
                            f.Required = "1".Equals(rdr.ReadString());
                            break;
                        case TagFieldAppearsByDefault:
                            f.AppearsByDefault = "1".Equals(rdr.ReadString());
                            break;
                        case TagFieldFindEnabled:
                            f.FindEnabled = "1".Equals(rdr.ReadString());
                            break;
                        case TagFieldAllowNewChoices:
                            f.AllowNewChoices = "1".Equals(rdr.ReadString());
                            break;
                        case TagFieldSortAsGiven:
                            f.SortAsGiven = "1".Equals(rdr.ReadString());
                            break;
                        case TagFieldWidth:
                            f.Width = Int32.Parse(rdr.ReadString());
                            break;
                        case TagFieldCarryChoices:
                            f.CarryChoices = "1".Equals(rdr.ReadString());
                            break;
                        case TagFieldForeignKey:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldUnique:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldDoesDataCopy:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldHelp:
                            f.FieldHelp = rdr.ReadInnerXml();
                            c = true;
                            break;
                        case TagFieldNumberOfLines:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldMaximumLength:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldAppendOnly:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldAllowHtml:
                            f.AllowHtml = "1".Equals(rdr.ReadString());
                            break;
                        case "mcdbid":
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case "mcfid":
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case "lutfid":
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case "lusfid":
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldChoices:
                            foreach (string choice in GetChoices(rdr.ReadSubtree())) {
                                f.Choices.Add(choice);
                            }
                            c = true;
                            break;
                        case TagFieldDecimalPlaces:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldCommaStart:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldDoesAverage:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldDoesTotal:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldBlankIsZero:
                            f.BlankIsZero = "1".Equals(rdr.ReadString());
                            break;
                        case TagFieldCurrencySymbol:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldCurrencyFormat:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldFormula:
                            f.Properties.Add(rdr.Name, rdr.ReadInnerXml());
                            c = true;
                            break;
                        case TagFieldAppearsAs:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldAbbreviate:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldUseNewWindow:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldAutoSave:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldMaximumVersions:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldSeeVersions:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldDisplayGraphic:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldDisplayTime:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldDisplayRelative:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldDisplayMonth:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldDefaultToday:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldDisplayDayOfWeek:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldDisplayZone:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldTargetDBID:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldTargetFieldID:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldSourceFieldID:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldCoverText:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldExact:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case "mastag":
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldDisplayUser:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        case TagFieldDefaultKind:
                            f.Properties.Add(rdr.Name, rdr.ReadString());
                            break;
                        default:
                            string prop = rdr.Name;
                            string val = rdr.ReadInnerXml();
                            c = true;
#if DEBUG
                            if (ShowDebugMessages)
                                Console.WriteLine(
                                    "Unknown Field Property: '{0}' = {1}",
                                    prop, val);
#endif
                            if (f.Properties.ContainsKey(prop)) {
                                Console.Error.WriteLine(
                                    "Key already added '{0}' = '{1}'\n                Currently: '{2}'",
                                    prop, f.Properties[prop], val);
                            } else {
                                f.Properties.Add(prop, val);
                            }
                            break;
                    }
                }
                if (!c) c = rdr.Read();
            }
            return f;
        }

        internal static ICollection<Field> GetFields(XmlReader rdr) {
            ICollection<Field> fields = new List<Field>();
            bool c = rdr.Read();
            while (c) {
                c = false;
                if (rdr.IsStartElement()) {
                    if (TagField.Equals(rdr.Name)) {
                        fields.Add(GetField(rdr.ReadSubtree()));
                        c = true;
                    }
                }
                if (!c) c = rdr.Read();
            }
            return fields;
        }

        internal static IDictionary<String, String> GetVariables(XmlReader rdr) {
            Dictionary<String, String> variables = new Dictionary<string, string>();
            while (rdr.Read()) {
                if (rdr.IsStartElement()) {
                    if (TagVariable.Equals(rdr.Name)) {
                        variables.Add(rdr.GetAttribute(AttributeVariableName), rdr.ReadString());
                    }
                }
            }
            return variables;
        }

        internal static IDictionary<String, String> GetChildTables(XmlReader rdr) {
            Dictionary<String, String> variables = new Dictionary<string, string>();
            string name;
            while (rdr.Read()) {
                if (rdr.IsStartElement()) {
                    if (TagChildDBID.Equals(rdr.Name)) {
                        name = rdr.GetAttribute(AttributeChildDBIDName);
                        variables.Add(rdr.ReadString(), name);
                    }
                }
            }
            return variables;
        }

        internal static void PopulateTableProperties(Schema schema, XmlReader rdr) {
            while (rdr.Read()) {
                if (rdr.IsStartElement()) {
                    switch (rdr.Name) {
                        case TagTableProperties:
                            break;
                        case TagTablePropertyTableID:
                            schema.ID = rdr.ReadString();
                            break;
                        case TagTablePropertyDescription:
                            schema.Description = rdr.ReadString();
                            break;
                        case TagTablePropertyApplicationID:
                            schema.ParentID = rdr.ReadString();
                            break;
                        case TagTablePropertyCreateDate:
                            schema.CreateDate = DateTimeUtils.FromUnixEpoch(
                                long.Parse(rdr.ReadString()));
                            break;
                        case TagTablePropertyModDate:
                            schema.ModDate = DateTimeUtils.FromUnixEpoch(
                                long.Parse(rdr.ReadString()));
                            break;
                        case TagTablePropertyNextRecordID:
                            schema.NextRecordID = long.Parse(rdr.ReadString());
                            break;
                        case TagTablePropertyNextFieldID:
                            schema.NextFieldID = Int32.Parse(rdr.ReadString());
                            break;
                        case TagTablePropertyNextQueryID:
                            schema.NextQueryID = Int32.Parse(rdr.ReadString());
                            break;
                        case TagTablePropertyDefaultSortFieldID:
                            schema.SortFieldID = Int32.Parse(rdr.ReadString());
                            break;
                        case TagTablePropertyDefaultSortOrder:
                            schema.SortOrder = Int32.Parse(rdr.ReadString());
                            break;
                        case TagTablePropertyKeyFieldID:
                            schema.KeyField = Int32.Parse(rdr.ReadString());
                            break;
#if DEBUG
                        default:
                            if (ShowDebugMessages)
                                Console.WriteLine("Unknown Table Property: '{0}'", rdr.Name);
                            break;
#endif
                    }
                }
            }
        }

        internal static KeyValuePair<string, string> GetDBInfo(XmlReader rdr) {
            string id = null;
            string name = null;
            while (rdr.Read()) {
                switch (rdr.Name) {
                    case "dbname":
                        name = rdr.ReadString();
                        break;
                    case "dbid":
                        id = rdr.ReadString();
                        break;
                }
            }
            return new KeyValuePair<string,string>(id, name);
        }

        internal static IDictionary<string, string> GetGrantedDatabases(XmlReader rdr) {
            Dictionary<string, string> result = new Dictionary<string, string>();

            // Use of ReadInnerXml will move the cursor.
            bool c = rdr.Read();

            while (c) {
                c = false;
                if (rdr.IsStartElement()) {
                    switch (rdr.Name) {
                        case "databases":
                            break;
                        case "dbinfo":
                            KeyValuePair<string, string> ent = GetDBInfo(rdr.ReadSubtree());
                            result.Add(ent.Key, ent.Value);
                            c = true;
                            break;
#if DEBUG
                        default:
                            if (ShowDebugMessages)
                                Console.WriteLine("Unknown Schema Property: '{0}'", rdr.Name);
                            break;
#endif
                    }
                }
                if (!c) c = rdr.Read();
            }

            return result;
        }

        internal static Schema GetSchema(XmlReader rdr) {
            Schema schema = new Schema();

            // Use of ReadInnerXml will move the cursor.
            bool c = rdr.Read();

            while (c) {
                c = false;
                if (rdr.IsStartElement()) {
                    switch (rdr.Name) {
                        case TagTable:
                            break;
                        case TagTableName:
                            schema.Name = rdr.ReadString();
                            break;
                        case TagTableProperties:
                            PopulateTableProperties(schema, rdr.ReadSubtree());
                            c = true;
                            break;
                        case TagQueries:
                            foreach (Query q in GetQueries(rdr.ReadSubtree())) {
                                schema.Queries.Add(q.ID, q);
                            }
                            c = true;
                            break;
                        case TagFields:
                            foreach (Field f in GetFields(rdr.ReadSubtree())) {
                                schema.Fields.Add(f.ID, f);
                            }
                            c = true;
                            break;
                        case TagVariables:
                            foreach (KeyValuePair<string, string> v in GetVariables(rdr.ReadSubtree())) {
                                schema.Variables.Add(v.Key, v.Value);
                            }
                            c = true;
                            break;
                        case TagChildDatabases:
                            foreach (KeyValuePair<string, string> v in GetChildTables(rdr.ReadSubtree())) {
                                schema.Children.Add(v.Key, v.Value);
                            }
                            c = true;
                            break;
#if DEBUG
                        default:
                            if (ShowDebugMessages)
                                Console.WriteLine("Unknown Schema Property: '{0}'", rdr.Name);
                            break;
#endif
                    }
                }
                if (!c) c = rdr.Read();
            }

            return schema;
        }

    }

}
