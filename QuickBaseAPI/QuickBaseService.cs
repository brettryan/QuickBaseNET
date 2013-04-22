/*
 * QuickBaseService.cs    11 August 2009, 17:02
 *
 * Copyright 2009 Drunken Dev. All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

using Commons.System;
using Commons.System.IO;

using DrunkenDev.QuickBase.Xml;


namespace DrunkenDev.QuickBase {

    /// <summary>
    ///
    /// </summary>
    /// <remarks>
    /// TODO: Implement the ticket based authentication mechanism.
    /// </remarks>
    public class QuickBaseService : IQuickBaseService {

        private const string UserAgentName = "QuickBaseNETAPI/2.0";

        /// <summary>
        /// Creates a new instance of <c>QuickBaseService</c>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Please refer to the <a href="http://www.quickbase.com/">QuickBase
        /// home page</a> for more information on how to get a QuickBase
        /// account.
        /// </para>
        /// <para>
        /// QuickBase databases are by default not accessible via HTTP. To
        /// allow HTTP access to a QuickBase database go to its main page and
        /// click on "Administration" under "SHORTCUTS". Then click on "Basic
        /// Properties". Next to "Options" you'll see a checkbox labeled
        /// "Allow non-SSL access" (normally unchecked). You'll need to check
        /// this box to allow HTTP access to the database.
        /// </para>
        /// </remarks>
        /// <param name="username">
        /// Either a QuickBase screen name or email address of a registered
        /// QuickBase user.
        /// </param>
        /// <param name="password">
        /// The QuickBase password corresponding to the QuickBase username.
        /// </param>
        /// <param name="url">
        /// The URL prefix for all QuickBase calls. The default is
        /// https://www.quickbase.com/db/
        /// </param>
        /// <param name="appToken">
        /// The application token required for all API calls for a particular
        /// QuickBase application.
        /// </param>
        public QuickBaseService(string username,
                                string password,
                                string url,
                                string appToken)
                : this(username, password, url) {
            this.AppToken = appToken;
        }

        /// <summary>
        /// Creates a new instance of <c>QuickBaseService</c>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Please refer to the <a href="http://www.quickbase.com/">QuickBase
        /// home page</a> for more information on how to get a QuickBase
        /// account.
        /// </para>
        /// <para>
        /// QuickBase databases are by default not accessible via HTTP. To
        /// allow HTTP access to a QuickBase database go to its main page and
        /// click on "Administration" under "SHORTCUTS". Then click on "Basic
        /// Properties". Next to "Options" you'll see a checkbox labeled
        /// "Allow non-SSL access" (normally unchecked). You'll need to check
        /// this box to allow HTTP access to the database.
        /// </para>
        /// </remarks>
        /// <param name="username">
        /// Either a QuickBase screen name or email address of a registered
        /// QuickBase user.
        /// </param>
        /// <param name="password">
        /// The QuickBase password corresponding to the QuickBase username.
        /// </param>
        /// <param name="url">
        /// The URL prefix for all QuickBase calls. The default is
        /// https://www.quickbase.com/db/
        /// </param>
        public QuickBaseService(string username,
                                string password,
                                string url) : this() {
            this.Username = username;
            this.Password = password;
            this.Url = url;
        }

        private QuickBaseService() {
            // Something appears to be wrong with anything other than ASCII.
            this.Encoding = Encoding.ASCII;
        }

        /// <summary>
        /// Username used in QuickBase connections.
        /// </summary>
        public string Username {
            get;
            private set;
        }

        /// <summary>
        /// Password used in QuickBase connections.
        /// </summary>
        public string Password {
            get;
            private set;
        }

        /// <summary>
        /// Url for connecting to QuickBase.
        /// </summary>
        public string Url {
            get;
            private set;
        }

        /// <summary>
        /// Application token used to access QuickBase applications.
        /// </summary>
        /// <remarks>
        /// This is required for some QuickBase applications where configured.
        /// </remarks>
        public string AppToken {
            get;
            private set;
        }

        public Encoding Encoding {
            get;
            set;
        }

        public bool IsDebugEnabled {
            get;
            set;
        }

        public string DebugLocation {
            get;
            set;
        }

        public string Ticket {
            get;
            private set;
        }

        public string UserID {
            get;
            private set;
        }

#if DEBUG
        private static bool showDebugMessages = true;
        public static bool ShowDebugMessages {
            get { return showDebugMessages; }
            set {
                showDebugMessages = value;
                QueryParser.ShowDebugMessages = value;
                SchemaParser.ShowDebugMessages = value;
            }
        }
#endif

        /// <summary>
        /// True if a ticket has been returned for authentication.
        /// </summary>
        public bool IsAuthenticated {
            get { return !String.IsNullOrEmpty(Ticket); }
        }

        #region System.Object overrides.

        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <param name="obj">Object you wish to compare to.</param>
        /// <returns>true if this object is equal to <c>obj</c>.</returns>
        public override bool Equals(object obj) {
            //if (obj != null && obj.GetType().Equals(this.GetType())) {
            //    QuickBaseService other = obj as QuickBaseService;
            //    if ((object)other != null) {
            //        //TODO: Add Equals implementation
            //        // Uncomment the following only if an
            //        // Equals(QuickBaseService) implementation is present.
            //        //return Equals(other);
            //    }
            //}
            //return false;
            return base.Equals(obj);
        }

        #region Equals(QuickBaseService) implementation
        ///// <summary>
        ///// Returns true if this object is equal to <c>obj</c>.
        ///// </summary>
        ///// <remarks>
        ///// This is an overloaded Equals implementation taking a
        ///// QuickBaseService object to improve performance as a cast is not
        ///// required.
        ///// </remarks>
        ///// <param name="other">
        ///// QuickBaseService object to compare against.
        ///// </param>
        //public bool Equals(QuickBaseService other) {
        //    //TODO: Add Equals implementation
        //    return base.Equals(other);
        //}
        #endregion

        /// <summary>
        /// Returns a simple hash for this structure.
        /// </summary>
        /// <returns>The hash for this object.</returns>
        public override int GetHashCode() {
            //TODO: create real implementation for GetHashCode()
            // Implementations should at the least return an exclusive or of
            // all properties (prop1.GetHashCode() ^ prop2.GetHashCode()).
            // Improve this by performing binary shifts for values too large
            // for an integer eg. dbl ^ ((uint)dbl >> 32) where dbl is some
            // double.
            //
            // Sample (NetBeans 6.0 Implementation):
            // int hash = {Num};
            // hash = {Num} * hash + this.intProp;
            // hash = {Num} * hash + this.dblProp ^ ((uint)this.dblProp >> 32);
            // hash = {Num} * hash + this.strProp == null
            //                              ? 0 : this.strProp.GetHashCode();
            // return hash;
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a string representation of this object.
        /// </summary>
        /// <remarks>
        /// Returns a string representation of this object. This is
        /// formatted as a key property list proceeded by the fully qualified
        /// type name.
        /// </remarks>
        public override string ToString() {
            //return GetType().Name
            //    + "["
            ////  TODO: Add property list to output
            ////        Example: Property=value,Property2=value
            //    + "]"
            //    ;
            return base.ToString();
        }

        #endregion

        private void CheckError(string errCode, string errText, string errDetail, string action) {
            if ((!"0".Equals(errCode) && errCode != null) || errDetail != null) {
                throw new QuickBaseException(errCode, errText, errDetail, action);
            }
        }

        private XmlReaderSettings rdrSettings;
        private XmlReaderSettings GetReaderSettings() {
            if (rdrSettings == null) {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;
                settings.IgnoreProcessingInstructions = true;
                settings.IgnoreWhitespace = true;
                settings.ValidationType = ValidationType.None;
                
                rdrSettings = settings;
            }
            return rdrSettings;
        }

        private Stream GetResponseStream(Stream s, string action) {
            if (IsDebugEnabled) {
                MemoryStream input = new MemoryStream();
                s.CopyTo(input);
                input.Position = 0;
                try {
                    DirectoryInfo di = new DirectoryInfo(DebugLocation);
                    if (!di.Exists) {
                        di.Create();
                    }
                    using (FileStream fs = new FileStream(
                                String.Format("{0}\\{1}-res.xml",
                                di.FullName, action), FileMode.Create)) {
                        try {
                            input.WriteTo(fs);
                        } finally {
                            fs.Close();
                        }
                    }
                } catch (Exception ex) {
                    Console.Error.WriteLine(
                        "DEBUG: Exception occurred trying to write response: {0}.\n{1}",
                        ex.Message, ex.StackTrace);
                }
                input.Position = 0;
                return input;
            } else {
                return s;
            }
        }

        private void CreateRequestDoc(Stream stream,
                                      IEnumerable<KeyValuePair<string, string>> args,
                                      IEnumerable<Element> elements) {
            XmlWriterSettings outSettings = new XmlWriterSettings();
            outSettings.Encoding = Encoding;
            using (XmlWriter xmlOut = XmlWriter.Create(stream, outSettings)) {
                xmlOut.WriteStartDocument();
                xmlOut.WriteStartElement(Tags.DocRoot);

                //xmlOut.WriteElementString("encoding", Encoding.WebName);

                if (Ticket == null) {
                    xmlOut.WriteElementString(Tags.Username, Username);
                    xmlOut.WriteElementString(Tags.Password, Password);
                } else {
                    xmlOut.WriteElementString(Tags.Ticket, Ticket);
                }
                if (AppToken != null) {
                    xmlOut.WriteElementString(Tags.AppToken, AppToken);
                }
                if (elements != null) {
                    foreach (var el in elements) {
                        xmlOut.WriteStartElement(el.Name);
                        foreach (var attr in el.Attributes) {
                            xmlOut.WriteAttributeString(attr.Key, attr.Value);
                        }
                        xmlOut.WriteString(el.Content);
                        xmlOut.WriteEndElement();
                    }
                }
                if (args != null) {
                    foreach (KeyValuePair<string, string> arg in args) {
                        xmlOut.WriteElementString(arg.Key, arg.Value);
                    }
                }

                xmlOut.WriteEndElement();
                xmlOut.WriteEndDocument();
                xmlOut.Flush();
                xmlOut.Close();
            }
        }

        private WebResponse GetResponse(string dbid, string action) {
            return GetResponse(dbid, action, null, null);
        }

        private WebResponse GetResponse(string action) {
            return GetResponse(null, action);
        }

        private WebResponse GetResponse(string dbid,
                                        string action,
                                        IEnumerable<KeyValuePair<string, string>> args,
                                        IEnumerable<Element> elements) {
            HttpWebRequest req;
            if (String.IsNullOrEmpty(dbid)) {
                req = (HttpWebRequest)WebRequest.Create(Url);
            } else {
                req = (HttpWebRequest)WebRequest.Create(Url + dbid);
            }
            req.Method = "POST";
            req.UserAgent = UserAgentName;
            req.Accept = "text/html";
            req.ContentType = "text/xml";
            req.Headers.Add("QUICKBASE-ACTION", action);
            
            using (MemoryStream ms = new MemoryStream()) {
                CreateRequestDoc(ms, args, elements);
                //req.ContentLength = ms.Length;
                Stream outStream = req.GetRequestStream();
                
                if (IsDebugEnabled) {
                    try {
                        DirectoryInfo di = new DirectoryInfo(DebugLocation);
                        if (!di.Exists) {
                            di.Create();
                        }
                        using (FileStream fs = new FileStream(
                                    String.Format("{0}\\{1}-req.xml",
                                    di.FullName, action), FileMode.Create)) {
                            try {
                                ms.WriteTo(fs);
                            } finally {
                                fs.Close();
                            }
                        }
                    } catch (Exception ex) {
                        Console.Error.WriteLine(
                            "DEBUG: Exception occurred trying to write request: {0}.\n{1}",
                            ex.Message, ex.StackTrace);
                    }
                    ms.Position = 0;
                }

                ms.WriteTo(outStream);
                outStream.Close();
            }
            
            return req.GetResponse();
        }

        #region IQuickBaseService Members

        public bool Authenticate() {
            if (Ticket != null)
                throw new System.IO.IOException(
                    "A ticket is already present, you must call 'Close' first.");

            string errCode = null;
            string errText = null;
            string errDetail = null;
            string action = QuickBaseCommands.Authenticate;

            WebResponse res = GetResponse("main", action);
            using (XmlReader rdr = XmlReader.Create(
                        GetResponseStream(res.GetResponseStream(), action),
                        GetReaderSettings())) {
                rdr.MoveToContent();

                // Use of ReadInnerXml will move the cursor.
                bool c = rdr.Read();

                while (c) {
                    c = false;
                    if (rdr.IsStartElement()) {
                        switch (rdr.Name) {
                            case Tags.DocRoot:
                                break;
                            case Tags.Ticket:
                                this.Ticket = rdr.ReadString();
                                break;
                            case Tags.UserID:
                                this.UserID = rdr.ReadString();
                                break;
                            case Tags.Action:
                                action = rdr.ReadString();
                                break;
                            case Tags.ErrorCode:
                                errCode = rdr.ReadString();
                                break;
                            case Tags.ErrorText:
                                errText = rdr.ReadString();
                                break;
                            case Tags.ErrorDetail:
                                errDetail = rdr.ReadString();
                                break;
#if DEBUG
                            default:
                                if (ShowDebugMessages)
                                    Console.WriteLine("Unknown {0} Property: '{1}'", action, rdr.Name);
                                break;
#endif
                        }
                    }
                    if (!c) c = rdr.Read();
                }
            }
            CheckError(errCode, errText, errDetail, action);
            return IsAuthenticated;
        }

        public void SignOut() {
            if (Ticket == null)
                throw new System.IO.IOException(
                    "No ticket is available to sign out with.");

            string errCode = null;
            string errText = null;
            string errDetail = null;
            string action = QuickBaseCommands.SignOut;

            WebResponse res = GetResponse("main", action);
            using (XmlReader rdr = XmlReader.Create(
                        GetResponseStream(res.GetResponseStream(), action),
                        GetReaderSettings())) {
                rdr.MoveToContent();

                // Use of ReadInnerXml will move the cursor.
                bool c = rdr.Read();

                while (c) {
                    c = false;
                    if (rdr.IsStartElement()) {
                        switch (rdr.Name) {
                            case Tags.DocRoot:
                                break;
                            case Tags.Action:
                                action = rdr.ReadString();
                                break;
                            case Tags.ErrorCode:
                                errCode = rdr.ReadString();
                                break;
                            case Tags.ErrorText:
                                errText = rdr.ReadString();
                                break;
                            case Tags.ErrorDetail:
                                errDetail = rdr.ReadString();
                                break;
#if DEBUG
                            default:
                                if (ShowDebugMessages)
                                    Console.WriteLine("Unknown {0} Property: '{1}'", action, rdr.Name);
                                break;
#endif
                        }
                    }
                    if (!c) c = rdr.Read();
                }
            }
            CheckError(errCode, errText, errDetail, action);
            this.Ticket = null;
            this.UserID = null;
        }

        public IDictionary<string, string> GetGrantedDatabases() {
            return GetGrantedDatabases(GrantedDBOPtions.Parents | GrantedDBOPtions.Children);
        }

        public IDictionary<string, string> GetGrantedDatabases(GrantedDBOPtions options) {
            string errCode = null;
            string errText = null;
            string errDetail = null;
            string action = QuickBaseCommands.GrantedDBs;

            IDictionary<string, string> result = null;

            IDictionary<string, string> args = new Dictionary<string, string>();
            if ((options & GrantedDBOPtions.AdminOnly) == GrantedDBOPtions.AdminOnly) {
                args.Add("adminOnly", "1");
            }
            args.Add("withembeddedtables", ((options & GrantedDBOPtions.Children) == GrantedDBOPtions.Children) ? "1" : "0");
            args.Add("excludeparents", ((options & GrantedDBOPtions.Parents) == GrantedDBOPtions.Parents) ? "0" : "1");

            WebResponse res = GetResponse("main", action, args, null);
            using (XmlReader rdr = XmlReader.Create(
                        GetResponseStream(res.GetResponseStream(), action),
                        GetReaderSettings())) {
                rdr.MoveToContent();

                // Use of ReadInnerXml will move the cursor.
                bool c = rdr.Read();

                while (c) {
                    c = false;
                    if (rdr.IsStartElement()) {
                        switch (rdr.Name) {
                            case Tags.DocRoot:
                                break;
                            case "databases":
                                result = SchemaParser.GetGrantedDatabases(rdr.ReadSubtree());
                                break;
                            case Tags.Action:
                                action = rdr.ReadString();
                                break;
                            case Tags.ErrorCode:
                                errCode = rdr.ReadString();
                                break;
                            case Tags.ErrorText:
                                errText = rdr.ReadString();
                                break;
                            case Tags.ErrorDetail:
                                errDetail = rdr.ReadString();
                                break;
#if DEBUG
                            default:
                                if (ShowDebugMessages)
                                    Console.WriteLine("Unknown {0} Property: '{1}'", action, rdr.Name);
                                break;
#endif
                        }
                    }
                    if (!c) c = rdr.Read();
                }
            }
            CheckError(errCode, errText, errDetail, action);

            return result == null ? new Dictionary<string, string>() : result;
        }

        public Schema GetSchema(string dbid) {
            string errCode = null;
            string errText = null;
            string errDetail = null;
            string action = QuickBaseCommands.GetSchema;
            Schema schema = null;

            WebResponse res = GetResponse(dbid, action);

            using (XmlReader rdr = XmlReader.Create(
                        GetResponseStream(res.GetResponseStream(), action),
                        GetReaderSettings())) {
                rdr.MoveToContent();

                // Use of ReadInnerXml will move the cursor.
                bool c = rdr.Read();

                while (c) {
                    c = false;
                    if (rdr.IsStartElement()) {
                        switch (rdr.Name) {
                            case Tags.DocRoot:
                                break;
                            case SchemaParser.TagTable:
                                schema = SchemaParser.GetSchema(rdr.ReadSubtree());
                                c = true;
                                break;
                            case Tags.Action:
                                action = rdr.ReadString();
                                break;
                            case Tags.ErrorCode:
                                errCode = rdr.ReadString();
                                break;
                            case Tags.ErrorText:
                                errText = rdr.ReadString();
                                break;
                            case Tags.ErrorDetail:
                                errDetail = rdr.ReadString();
                                break;
#if DEBUG
                            default:
                                if (ShowDebugMessages)
                                    Console.WriteLine("Unknown {0} Property: '{1}'", action, rdr.Name);
                                break;
#endif
                        }
                    }
                    if (!c) c = rdr.Read();
                }
            }
            CheckError(errCode, errText, errDetail, action);
            return schema;
        }

        public QueryResult Query(string dbid) {
            return Query(dbid, 0, null, null);
        }

        public QueryResult Query(string dbid, int queryId) {
            return Query(dbid, queryId, null, null);
        }

        public QueryResult Query(string dbid, string queryText) {
            return Query(dbid, 0, queryText, null);
        }

        public QueryResult Query(string dbid, Query query) {
            return Query(dbid, 0, null, query);
        }
        
        public QueryResult Query(
                string dbid,
                int queryId,
                string queryText,
                Query query)
        {
            string errCode = null;
            string errText = null;
            string errDetail = null;
            string action = QuickBaseCommands.DoQuery;

            Dictionary<string, string> args = new Dictionary<string, string>();
            // Use this because the unstructured option while using 
            args.Add(Tags.QueryFormat, "structured");

            if (queryId > 0) {
                args.Add("qid", queryId.ToString());
            } else if (!String.IsNullOrEmpty(queryText)) {
                args.Add("query", queryText);
            }

            if (query != null) {
                StringBuilder sb = new StringBuilder();
                if (query.ColumnList.Count > 0) {
                    foreach (int col in query.ColumnList) {
                        if (sb.Length > 0)
                            sb.Append('.');
                        sb.Append(col);
                    }
                    args.Add("clist", sb.ToString());
                }
                sb = new StringBuilder();
                if (query.SortList.Count > 0) {
                    foreach (int col in query.SortList) {
                        if (sb.Length > 0)
                            sb.Append('.');
                        sb.Append(col);
                    }
                    args.Add("slist", sb.ToString());
                }
                // Options, query restriction and sorting behaviour.
                // - num-{n}: max of {n} records.
                // - onlynew: return only new records.
                // - skip-{n}: skip {n} records.
                // - sortorder-[A|D]: Sort [A]scending (default) or [D]escending.
                //   * sortorder may be plural with one for each clist entry.
                // <options>num-15.sortorder-A.skp-15</options>
            }

            WebResponse res = GetResponse(dbid, action, args, null);
            
            QueryResult result = new QueryResult();
            StringBuilder field = new StringBuilder();

            using (XmlReader rdr = XmlReader.Create(GetResponseStream(res.GetResponseStream(), action),
                                                    GetReaderSettings())) {
                rdr.MoveToContent();
                // Use of ReadInnerXml will move the cursor.
                bool c = rdr.Read();

                while (c) {
                    c = false;
                    if (rdr.IsStartElement()) {
                        switch (rdr.Name) {
                            case Tags.DocRoot:
                                break;
                            //case "table":
                            //    result.Schema = SchemaParser.GetSchema(rdr.ReadSubtree());
                            //    c = true;
                            //    break;
                            case SchemaParser.TagTable:
                                result = QueryParser.GetQueryResult(rdr.ReadSubtree());
                                c = true;
                                break;
                            case Tags.Action:
                                action = rdr.ReadString();
                                break;
                            case Tags.ErrorCode:
                                errCode = rdr.ReadString();
                                break;
                            case Tags.ErrorText:
                                errText = rdr.ReadString();
                                break;
                            case Tags.ErrorDetail:
                                errDetail = rdr.ReadString();
                                break;
#if DEBUG
                            default:
                                if (ShowDebugMessages)
                                    Console.WriteLine("Unknown {0} Property: '{1}'", action, rdr.Name);
                                break;
#endif
                        }
                    }
                    if (!c) c = rdr.Read();
                }
            }
            CheckError(errCode, errText, errDetail, action);
            return result;
        }


        //TODO: Use constants
        //TODO: Check this works :)
        public int EditRecords(string dbid, int record, IEnumerable<KeyValuePair<int, string>> fieldValues) {
            string errCode = null;
            string errText = null;
            string errDetail = null;
            string action = QuickBaseCommands.EditRecord;

            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add(Tags.RecordID, record.ToString());
            args.Add("msInUTC", "1");
            //<testc fid="32">f.Value</testc>
            List<Element> elements = new List<Element>();
            foreach (var f in fieldValues) {
                Element e = new Element("field", f.Value);
                e.Attributes.Add("fid", f.Key.ToString());
                e.Attributes.Add("filename", "");
                elements.Add(e);
            }

            WebResponse res = GetResponse(dbid, action, args, elements);
            string result = null;
            StringBuilder field = new StringBuilder();
            
            using (XmlReader rdr = XmlReader.Create(GetResponseStream(res.GetResponseStream(), action),
                                                    GetReaderSettings())) {
                rdr.MoveToContent();
                // Use of ReadInnerXml will move the cursor.
                bool c = rdr.Read();

                while (c) {
                    c = false;
                    if (rdr.IsStartElement()) {
                        switch (rdr.Name) {
                            case Tags.DocRoot:
                                break;
                            //case "table":
                            //    result.Schema = SchemaParser.GetSchema(rdr.ReadSubtree());
                            //    c = true;
                            //    break;
                            case SchemaParser.TagTable:
                            //    result = QueryParser.GetQueryResult(rdr.ReadSubtree());
                            //    c = true;
                                break;
                            case "num_fields_changed":
                                result = rdr.ReadString();
                                break;
                            case Tags.Action:
                                action = rdr.ReadString();
                                break;
                            case Tags.ErrorCode:
                                errCode = rdr.ReadString();
                                break;
                            case Tags.ErrorText:
                                errText = rdr.ReadString();
                                break;
                            case Tags.ErrorDetail:
                                errDetail = rdr.ReadString();
                                break;
#if DEBUG
                            default:
                                if (ShowDebugMessages)
                                    Console.WriteLine("Unknown {0} Property: '{1}'", action, rdr.Name);
                                break;
#endif
                        }
                    }
                    if (!c) c = rdr.Read();
                }
            }
            CheckError(errCode, errText, errDetail, action);
            return Int32.Parse(result);
        }

        /*
         * Edit Records in QuickBase
         */
         
        public int EditRecords(string dbid, int record, IEnumerable<KeyValuePair<int, IFieldValue>> fieldValues) {
            string errCode = null;
            string errText = null;
            string errDetail = null;
            string action = QuickBaseCommands.EditRecord;

            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add(Tags.RecordID, record.ToString());
            args.Add("msInUTC", "1");
            //<testc fid="32">f.Value</testc>
            List<Element> elements = new List<Element>();
            foreach (var f in fieldValues) {
                Element e = new Element("field", f.Value.GetDataAsString());
                e.Attributes.Add("fid", f.Key.ToString());
                foreach (var attr in f.Value.GetAttributes()) {
                    e.Attributes.Add(attr.Key, attr.Value);
                }
                elements.Add(e);
            }

            WebResponse res = GetResponse(dbid, action, args, elements);
            string result = null;
            StringBuilder field = new StringBuilder();

            using (XmlReader rdr = XmlReader.Create(GetResponseStream(res.GetResponseStream(), action),
                                                    GetReaderSettings())) {
                rdr.MoveToContent();
                // Use of ReadInnerXml will move the cursor.
                bool c = rdr.Read();

                while (c) {
                    c = false;
                    if (rdr.IsStartElement()) {
                        switch (rdr.Name) {
                            case Tags.DocRoot:
                                break;
                            //case "table":
                            //    result.Schema = SchemaParser.GetSchema(rdr.ReadSubtree());
                            //    c = true;
                            //    break;
                            case SchemaParser.TagTable:
                                //    result = QueryParser.GetQueryResult(rdr.ReadSubtree());
                                //    c = true;
                                break;
                            case "num_fields_changed":
                                result = rdr.ReadString();
                                break;
                            case Tags.Action:
                                action = rdr.ReadString();
                                break;
                            case Tags.ErrorCode:
                                errCode = rdr.ReadString();
                                break;
                            case Tags.ErrorText:
                                errText = rdr.ReadString();
                                break;
                            case Tags.ErrorDetail:
                                errDetail = rdr.ReadString();
                                break;
#if DEBUG
                            default:
                                if (ShowDebugMessages)
                                    Console.WriteLine("Unknown {0} Property: '{1}'", action, rdr.Name);
                                break;
#endif
                        }
                    }
                    if (!c) c = rdr.Read();
                }
            }
            CheckError(errCode, errText, errDetail, action);
            return Int32.Parse(result);
        }
        
        /*
         * Delete Records
         */

        public void DeleteRecords(string dbid, int record) {
            string errCode = null;
            string errText = null;
            string errDetail = null;
            string action = QuickBaseCommands.DeleteRecord;

            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add(Tags.RecordID, record.ToString());
            args.Add("msInUTC", "1");

            WebResponse res = GetResponse(dbid, action, args, null);
            string result = null;
            StringBuilder field = new StringBuilder();

            using (XmlReader rdr = XmlReader.Create(GetResponseStream(res.GetResponseStream(), action),
                                                    GetReaderSettings())) {
                rdr.MoveToContent();
                // Use of ReadInnerXml will move the cursor.
                bool c = rdr.Read();

                while (c) {
                    c = false;
                    if (rdr.IsStartElement()) {
                        switch (rdr.Name) {
                            case Tags.DocRoot:
                                break;
                            case SchemaParser.TagTable:
                                break;
                            case Tags.Action:
                                action = rdr.ReadString();
                                break;
                            case Tags.ErrorCode:
                                errCode = rdr.ReadString();
                                break;
                            case Tags.ErrorText:
                                errText = rdr.ReadString();
                                break;
                            case Tags.ErrorDetail:
                                errDetail = rdr.ReadString();
                                break;
#if DEBUG
                            default:
                                if (ShowDebugMessages)
                                    Console.WriteLine("Unknown {0} Property: '{1}'", action, rdr.Name);
                                break;
#endif
                        }
                    }
                    if (!c) c = rdr.Read();
                }
            }
        }

        /*
         * Add Records to QuickBase
         */

        public int AddRecords(string dbid, IEnumerable<KeyValuePair<int, string>> fieldValues) {
            string errCode = null;
            string errText = null;
            string errDetail = null;
            string action = QuickBaseCommands.AddRecord;

            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("msInUTC", "1");

            List<Element> elements = new List<Element>();
            foreach (var f in fieldValues) {
                Element e = new Element("field", f.Value);
                e.Attributes.Add("fid", f.Key.ToString());
                elements.Add(e);
            }

            WebResponse res = GetResponse(dbid, action, args, elements);
            string result = null;
            StringBuilder field = new StringBuilder();

            using (XmlReader rdr = XmlReader.Create(GetResponseStream(res.GetResponseStream(), action),
                                                    GetReaderSettings())) {
                rdr.MoveToContent();
                // Use of ReadInnerXml will move the cursor.
                bool c = rdr.Read();

                while (c) {
                    c = false;
                    if (rdr.IsStartElement()) {
                        switch (rdr.Name) {
                            case Tags.DocRoot:
                                break;
                            case SchemaParser.TagTable:
                                break;
                            case Tags.Action:
                                action = rdr.ReadString();
                                break;
                            case Tags.ErrorCode:
                                errCode = rdr.ReadString();
                                break;
                            case Tags.ErrorText:
                                errText = rdr.ReadString();
                                break;
                            case Tags.ErrorDetail:
                                errDetail = rdr.ReadString();
                                break;
                            case Tags.RecordID:
                                result = rdr.ReadString();
                                break;
#if DEBUG
                            default:
                                if (ShowDebugMessages)
                                    Console.WriteLine("Unknown {0} Property: '{1}'", action, rdr.Name);
                                break;
#endif
                        }
                    }
                    if (!c) c = rdr.Read();
                }
            }
            CheckError(errCode, errText, errDetail, action);
            return Int32.Parse(result);
        }

        

        private Uri GetFileUri(QuickBaseFile file) {
            UriBuilder bld = new UriBuilder(file.Uri);
            bld.Query = "ticket=" + Ticket;
            return bld.Uri;
        }

        public Stream GetFile(QuickBaseFile file) {
            if (Ticket == null)
                throw new System.IO.IOException(
                    "You must have a valid ticket for GetFile, call 'Authenticate'.");

            using (WebClient client = new WebClient()) {
                return new BufferedStream(client.OpenRead(GetFileUri(file)));
            }
        }

        public void WriteFile(QuickBaseFile file, Stream outStream) {
            if (Ticket == null)
                throw new System.IO.IOException(
                    "You must have a valid ticket for GetFile, call 'Authenticate'.");

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(GetFileUri(file));
            WebResponse res = req.GetResponse();

            using (Stream inStream = res.GetResponseStream()) {
                inStream.CopyTo(outStream);
                inStream.Close();
                outStream.Flush();
                outStream.Close();
            }
        }

        public BackgroundWorker WriteFileAsync(
            QuickBaseFile file,
            string outFile,
            WriteFileStartedDelegate writeStarted,
            WriteFileCompleteDelegate writeComplete,
            WriteFileProgressChangedDelegate writeProgressChanged
            ) {
            if (Ticket == null)
                throw new System.IO.IOException(
                    "You must have a valid ticket for GetFile, call 'Authenticate'.");

            BackgroundWorker wkr = new BackgroundWorker();
            wkr.DoWork += new DoWorkEventHandler(DoGetFileWork);
            wkr.ProgressChanged += new ProgressChangedEventHandler(DoGetFileProgressChanged);
            wkr.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DoGetFileComplete);
            wkr.WorkerReportsProgress = true;
            wkr.WorkerSupportsCancellation = true;
            wkr.RunWorkerAsync(new object[] {
                    file,
                    outFile,
                    writeStarted,
                    writeComplete,
                    writeProgressChanged,
                    null,
                    false
                });
            return wkr;
        }

        private void DoGetFileWork(object sender, DoWorkEventArgs e) {
            BackgroundWorker wkr = sender as BackgroundWorker;
            object[] args = e.Argument as object[];
            e.Result = e.Argument;

            try {
                QuickBaseFile file = args[0] as QuickBaseFile;
                string outFile = args[1] as string;
                WriteFileStartedDelegate writeStarted
                    = args[2] as WriteFileStartedDelegate;

                if (file == null)
                    throw new ArgumentException("File was not valid");

                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(GetFileUri(file));
                WebResponse res = req.GetResponse();

                long len = res.ContentLength;
                if (writeStarted != null) {
                    writeStarted(file, len, res.ContentType);
                }
                bool cancelled = false;
                using (Stream inStream = res.GetResponseStream()) {
                    using (FileStream outStream = new FileStream(outFile, FileMode.Create)) {
                        int buffSize = 4096;
                        byte[] buffer = new byte[buffSize];
                        int read;
                        int totRead = 0;
                        while ((read = inStream.Read(buffer, 0, buffer.Length)) > 0) {
                            totRead += read;
                            outStream.Write(buffer, 0, read);
                            if (wkr.WorkerReportsProgress) {
                                wkr.ReportProgress((int)Math.Round(100d * totRead / len), args);
                            }
                            if (wkr.CancellationPending) {
                                cancelled = true;
                                break;
                            }
                        }
                        inStream.Close();
                        outStream.Flush();
                        outStream.Close();
                    }
                }
                if (cancelled) {
                    args[6] = true;
                    FileInfo fi = new FileInfo(outFile);
                    fi.Delete();
                }
            } catch (Exception ex) {
                // If we use error process normally we won't be able to get the
                // requested delegate to fire on.
                args[5] = ex;
            }
        }

        private void DoGetFileComplete(object sender, RunWorkerCompletedEventArgs e) {
            BackgroundWorker wkr = sender as BackgroundWorker;
            object[] args = e.Result as object[];
            Exception ex = args[5] as Exception;
            WriteFileCompleteDelegate writeComplete =
                args[3] as WriteFileCompleteDelegate;
            bool cancelled = (bool) args[6];
            if (writeComplete != null)
                writeComplete(args[0] as QuickBaseFile, cancelled, ex);
        }

        private void DoGetFileProgressChanged(object sender, ProgressChangedEventArgs e) {
            BackgroundWorker wkr = sender as BackgroundWorker;
            object[] args = e.UserState as object[];
            WriteFileProgressChangedDelegate writeProgressChanged
                = args[4] as WriteFileProgressChangedDelegate;
            if (writeProgressChanged == null) return;
            writeProgressChanged(args[0] as QuickBaseFile, e.ProgressPercentage);
        }

        #endregion

    }

    internal class Element {

        internal Element(string name, string content) {
            this.Name = name;
            this.Content = content;
            this.Attributes = new Dictionary<string, string>();
        }

        internal string Name {
            get;
            private set;
        }

        internal Dictionary<string, string> Attributes {
            get;
            private set;
        }

        internal string Content {
            get;
            private set;
        }

    }


}
