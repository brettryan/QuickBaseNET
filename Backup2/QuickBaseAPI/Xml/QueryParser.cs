/*
 * QueryParser.cs    15 August 2009, 3:08
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
using System.Web;
using System.Xml;


namespace DrunkenDev.QuickBase.Xml {

    /// <summary>
    ///
    /// </summary>
    internal static class QueryParser {

        /// <summary>
        /// Tag for a field.
        /// </summary>
        private const string TagField = "f";
        /// <summary>
        /// Tag for a record.
        /// </summary>
        private const string TagRecord = "record";
        /// <summary>
        /// Tag for a set of records.
        /// </summary>
        private const string TagRecords = "records";
        /// <summary>
        /// Field ID attribute.
        /// </summary>
        private const string AttributeFieldID = "id";


#if DEBUG

        /// <summary>
        /// In DEBUG mode default messages to be switched on.
        /// </summary>
        static QueryParser() {
            ShowDebugMessages = true;
        }

        /// <summary>
        /// In DEBUG mode we can print out messages to identify missing parts
        /// of the API.
        /// </summary>
        internal static bool ShowDebugMessages {
            get;
            set;
        }

#endif


        /// <summary>
        /// Fill out a <see cref="DrunkenDev.QuickBase.QueryRow"/> result from
        /// an XML reader part containing the row node.
        /// </summary>
        /// <param name="rdr">Reader containing query row.</param>
        /// <param name="row">Row to fill-in.</param>
        private static void FillRow(XmlReader rdr, QueryRow row) {
            bool c = rdr.Read();
            while (c) {
                c = false;
                if (rdr.IsStartElement()) {
                    if (TagField.Equals(rdr.Name)) {
                        // Replace breaks with new lines. This would be better
                        // handled as an RegEx, but I'm lazy and tired :)
                        // NOTE: QuickBase incorrectly uses upper case HTML.
                        row.SetData(
                            Int32.Parse(rdr.GetAttribute(AttributeFieldID)),
                            HttpUtility.HtmlDecode(rdr.ReadInnerXml())
                                .Replace("\n", "")
                                .Replace("<BR />", "\n"));
                        c = true;
                    }
                }
                if (!c) c = rdr.Read();
            }
        }

        /// <summary>
        /// Return a list of <see cref="DrunkenDev.QuickBase.QueryRow"/> rows
        /// from a row collection XML part element.
        /// </summary>
        /// <param name="rdr">XML Reader containing row set (record).</param>
        /// <param name="qr">Row to populate with result.</param>
        /// <returns></returns>
        private static IList<QueryRow> GetResultRows(XmlReader rdr, QueryResult qr) {
            IList<QueryRow> rows = new List<QueryRow>();
            
            while (rdr.Read()) {
                if (rdr.IsStartElement()) {
                    if (TagRecord.Equals(rdr.Name)) {
                        QueryRow row = new QueryRow(qr);
                        rows.Add(row);
                        FillRow(rdr.ReadSubtree(), row);
                    }
                }
            }
            return rows;
        }

        /// <summary>
        /// Retrieve a query result from an query.
        /// </summary>
        /// <param name="rdr">XML Reader for query.</param>
        /// <returns>Returned result.</returns>
        internal static QueryResult GetQueryResult(XmlReader rdr) {
            QueryResult result = new QueryResult();
            Schema schema = new Schema();
            result.Schema = schema;

            // Use of ReadInnerXml will move the cursor.
            bool c = rdr.Read();

            while (c) {
                c = false;
                if (rdr.IsStartElement()) {
                    switch (rdr.Name) {
                        case SchemaParser.TagTable:
                            break;
                        case SchemaParser.TagTableName:
                            schema.Name = rdr.ReadString();
                            break;
                        case SchemaParser.TagTableProperties:
                            SchemaParser.PopulateTableProperties(schema, rdr.ReadSubtree());
                            c = true;
                            break;
                        case SchemaParser.TagQueries:
                            foreach (Query q in SchemaParser.GetQueries(rdr.ReadSubtree())) {
                                schema.Queries.Add(q.ID, q);
                            }
                            c = true;
                            break;
                        case SchemaParser.TagFields:
                            foreach (Field f in SchemaParser.GetFields(rdr.ReadSubtree())) {
                                schema.Fields.Add(f.ID, f);
                            }
                            c = true;
                            break;
                        case SchemaParser.TagVariables:
                            foreach (KeyValuePair<string, string> v in SchemaParser.GetVariables(rdr.ReadSubtree())) {
                                schema.Variables.Add(v.Key, v.Value);
                            }
                            c = true;
                            break;
                        case SchemaParser.TagChildDatabases:
                            foreach (KeyValuePair<string, string> v in SchemaParser.GetChildTables(rdr.ReadSubtree())) {
                                schema.Children.Add(v.Key, v.Value);
                            }
                            c = true;
                            break;
                        case TagRecords:
                            foreach (QueryRow qr in GetResultRows(rdr.ReadSubtree(), result)) {
                                result.Rows.Add(qr);
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

            return result;
        }

    }

}
