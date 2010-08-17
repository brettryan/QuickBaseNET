/*
 * QueryRow.cs    11 August 2009, 16:32
 *
 * Copyright 2009 Drunken Dev. All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Commons.Collections;
using Commons.System;


namespace DrunkenDev.QuickBase {

    /// <summary>
    /// Represents a row returned from <c>QuickBase</c>.
    /// </summary>
    public class QueryRow : IEnumerable<KeyValuePair<int, string>> {

        private Dictionary<int, String> data;

        /// <summary>
        /// Creates a new <see cref="QueryRow"/> object.
        /// </summary>
        /// <param name="result">Parent query result.</param>
        public QueryRow(QueryResult result) {
            Data = new Dictionary<int, String>();
            this.Result = result;
        }

        /// <summary>
        /// Parent query result that this row is a part of.
        /// </summary>
        public QueryResult Result {
            get;
            private set;
        }

        /// <summary>
        /// Row data keyed by the row id and the string value for the row.
        /// </summary>
        public IDictionary<int, String> Data {
            get { return new ReadOnlyDictionary<int, string>(data); }
            private set { data = new Dictionary<int, string>(); }
        }

        /// <summary>
        /// Read-only field collection.
        /// </summary>
        public ICollection<int> Fields {
            get { return data.Keys; }
        }

        /// <summary>
        /// Sets the value for field <c>fid</c>.
        /// </summary>
        /// <remarks>
        /// This is here in an attempt to make <c>Data</c> imutable.
        /// </remarks>
        /// <param name="fid">Field ID.</param>
        /// <param name="val">Field value.</param>
        internal void SetData(int fid, string val) {
            if (this.data.ContainsKey(fid)) {
                data[fid] = val;
            } else {
                data.Add(fid, val);
            }
        }

        /// <summary>
        /// Gets the string value for the given field ID.
        /// </summary>
        /// <param name="fid">Field ID</param>
        /// <returns>Field value for <c>fid</c>.</returns>
        /// <exception cref="System.ArgumentException">
        /// If the field id does not exist.
        /// </exception>
        public string GetString(int fid) {
            if (Data.ContainsKey(fid)) {
                return Data[fid];
            }
            throw new ArgumentException(String.Format(
                "Field ID '{0}' does not exist in row.", fid), "fid");
        }

        /// <summary>
        /// Returns a <c>bool</c> value for a field.
        /// </summary>
        /// <param name="fid">Field ID</param>
        /// <returns>Field represented as a <c>bool</c> value.</returns>
        /// <exception cref="System.FormatException">
        /// If the value can not be converted.
        /// </exception>
        /// <exception cref="System.NullReferenceException">
        /// If the value is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// If the field id does not exist.
        /// </exception>
        public bool GetBool(int fid) {
            if (Data.ContainsKey(fid)) {
                string v = Data[fid];
                if (v == null)
                    throw new NullReferenceException();
                if ("1".Equals(v)) return true;
                if ("0".Equals(v)) return false;
                if (String.Empty.Equals(v) && Result.Schema.Fields[fid].BlankIsZero)
                    return false;
                throw new FormatException(String.Format(
                    "Value must be either '0' or '1' but was found to be '{0}'", v));
            }
            throw new ArgumentException(String.Format(
                "Field ID '{0}' does not exist in row.", fid), "fid");
        }

        /// <summary>
        /// Returns a <c>int</c> value for a field.
        /// </summary>
        /// <param name="fid">Field ID</param>
        /// <returns>Field represented as a <c>int</c> value.</returns>
        /// <exception cref="System.FormatException">
        /// If the value can not be converted.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// If the value is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// If the field id does not exist.
        /// </exception>
        public int? GetInt(int fid) {
            if (Data.ContainsKey(fid)) {
                string v = Data[fid];
                if (String.IsNullOrEmpty(v)) {
                    if (Result.Schema.Fields[fid].BlankIsZero)
                        return 0;
                    return null;
                }
                return Int32.Parse(v);
            }
            throw new ArgumentException(String.Format(
                "Field ID '{0}' does not exist in row.", fid), "fid");
        }

        /// <summary>
        /// Returns a <c>long</c> value for a field.
        /// </summary>
        /// <param name="fid">Field ID</param>
        /// <returns>Field represented as a <c>long</c> value.</returns>
        /// <exception cref="System.FormatException">
        /// If the value can not be converted.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// If the value is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// If the field id does not exist.
        /// </exception>
        public long? GetLong(int fid) {
            if (Data.ContainsKey(fid)) {
                string v = Data[fid];
                if (String.IsNullOrEmpty(v)) {
                    if (Result.Schema.Fields[fid].BlankIsZero)
                        return 0;
                    return null;
                }
                return long.Parse(v);
            }
            throw new ArgumentException(String.Format(
                "Field ID '{0}' does not exist in row.", fid), "fid");
        }

        /// <summary>
        /// Returns a <c>float</c> value for a field.
        /// </summary>
        /// <param name="fid">Field ID</param>
        /// <returns>Field represented as a <c>float</c> value.</returns>
        /// <exception cref="System.FormatException">
        /// If the value can not be converted.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// If the value is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// If the field id does not exist.
        /// </exception>
        public float? GetFloat(int fid) {
            if (Data.ContainsKey(fid)) {
                string v = Data[fid];
                if (String.IsNullOrEmpty(v)) {
                    if (Result.Schema.Fields[fid].BlankIsZero)
                        return 0;
                    return null;
                }
                return float.Parse(v);
            }
            throw new ArgumentException(String.Format(
                "Field ID '{0}' does not exist in row.", fid), "fid");
        }

        /// <summary>
        /// Returns a <c>double</c> value for a field.
        /// </summary>
        /// <param name="fid">Field ID</param>
        /// <returns>Field represented as a <c>double</c> value.</returns>
        /// <exception cref="System.FormatException">
        /// If the value can not be converted.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// If the value is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// If the field id does not exist.
        /// </exception>
        public double? GetDouble(int fid) {
            if (Data.ContainsKey(fid)) {
                string v = Data[fid];
                if (String.IsNullOrEmpty(v)) {
                    if (Result.Schema.Fields[fid].BlankIsZero)
                        return 0;
                    return null;
                }
                return double.Parse(v);
            }
            throw new ArgumentException(String.Format(
                "Field ID '{0}' does not exist in row.", fid), "fid");
        }

        /// <summary>
        /// Returns a <c>decimal</c> value for a field.
        /// </summary>
        /// <param name="fid">Field ID</param>
        /// <returns>Field represented as a <c>decimal</c> value.</returns>
        /// <exception cref="System.FormatException">
        /// If the value can not be converted.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// If the value is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// If the field id does not exist.
        /// </exception>
        public decimal? GetDecimal(int fid) {
            if (Data.ContainsKey(fid)) {
                string v = Data[fid];
                if (String.IsNullOrEmpty(v)) {
                    if (Result.Schema.Fields[fid].BlankIsZero)
                        return 0;
                    return null;
                }
                return decimal.Parse(v);
            }
            throw new ArgumentException(String.Format(
                "Field ID '{0}' does not exist in row.", fid), "fid");
        }

        /// <summary>
        /// Returns a <see cref="System.DateTime"/> value for a field.
        /// </summary>
        /// <param name="fid">Field ID</param>
        /// <returns>
        /// Field represented as a <see cref="System.DateTime"/> value.
        /// </returns>
        /// <exception cref="System.FormatException">
        /// If the value can not be converted.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// If the value is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// If the field id does not exist.
        /// </exception>
        public DateTime? GetDateTime(int fid) {
            if (Data.ContainsKey(fid)) {
                string v = Data[fid];
                if (String.IsNullOrEmpty(v)) {
                    return null;
                }
                return DateTimeUtils.FromUnixEpoch(long.Parse(v));
            }
            throw new ArgumentException(String.Format(
                "Field ID '{0}' does not exist in row.", fid), "fid");
        }

        /// <summary>
        /// Returns a nullable datetime field.
        /// </summary>
        /// <param name="fid">Field ID</param>
        /// <returns>
        /// Result as a <see cref="System.DateTime"/> instance.
        /// </returns>
        public DateTime? GetDate(int fid) {
            DateTime? dt = GetDateTime(fid);
            if (dt.HasValue)
                return dt.Value.Date;
            return dt;
        }

        /// <summary>
        /// Get a URL field.
        /// </summary>
        /// <param name="fid">Field ID</param>
        /// <returns>
        /// Result as a <see cref="System.Uri"/> instance.
        /// </returns>
        public Uri GetUri(int fid) {
            if (Data.ContainsKey(fid)) {
                string v = Data[fid];
                if (String.IsNullOrEmpty(v)) {
                    return null;
                }
                return new Uri(v);
            }
            throw new ArgumentException(String.Format(
                "Field ID '{0}' does not exist in row.", fid), "fid");
        }

        /// <summary>
        /// Get a quickbase file based field.
        /// </summary>
        /// <param name="fid">Field ID</param>
        /// <returns>
        /// Result as a <see cref="QuickBaseFile"/> instance.
        /// </returns>
        public QuickBaseFile GetFile(int fid) {
            if (Data.ContainsKey(fid)) {
                string v = Data[fid];
                if (String.IsNullOrEmpty(v)) {
                    return null;
                }
                return QuickBaseFile.GetFile(v);
            }
            throw new ArgumentException(String.Format(
                "Field ID '{0}' does not exist in row.", fid), "fid");
        }

        /// <summary>
        /// Returns an object field.
        /// </summary>
        /// <param name="fid">Field ID</param>
        /// <returns>
        /// Result as an object instance.
        /// </returns>
        public object GetObject(int fid) {
            if (Data.ContainsKey(fid)) {
                switch (Result.Schema.Fields[fid].FieldType) {
                    case FieldType.CheckBox:
                        return GetBool(fid);
                    case FieldType.Currency:
                        return GetDecimal(fid);
                    case FieldType.DatabaseLink:
                        break;
                    case FieldType.Date:
                        return GetDate(fid);
                    case FieldType.Duration:
                        break;
                    case FieldType.Email:
                        return GetString(fid);
                    case FieldType.File:
                        return GetFile(fid);
                    case FieldType.Float:
                        return GetFloat(fid);
                    case FieldType.Percent:
                        break;
                    case FieldType.Phone:
                        return GetString(fid);
                    case FieldType.Rating:
                        break;
                    case FieldType.RecordID:
                        break;
                    case FieldType.Text:
                        return GetString(fid);
                    case FieldType.TimeOfDay:
                        break;
                    case FieldType.TimeStamp:
                        return GetDateTime(fid);
                    case FieldType.Url:
                        return GetUri(fid);
                    case FieldType.UserID:
                        break;
                    default:
                        switch (Result.Schema.Fields[fid].BaseType) {
                            case "bool":
                                return GetBool(fid);
                            case "float":
                                return GetFloat(fid);
                            case "int32":
                                return GetInt(fid);
                            case "int64":
                                return GetLong(fid);
                            case "text":
                                return GetString(fid);
                        }
                        break;
                }
                return GetString(fid);
            }
            throw new ArgumentException(String.Format(
                "Field ID '{0}' does not exist in row.", fid), "fid");
        }


        #region System.Object overrides.

        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <param name="obj">Object you wish to compare to.</param>
        /// <returns>true if this object is equal to <c>obj</c>.</returns>
        public override bool Equals(object obj) {
            //if (obj != null && obj.GetType().Equals(this.GetType())) {
            //    QueryRow other = obj as QueryRow;
            //    if ((object)other != null) {
            //        //TODO: Add Equals implementation
            //        // Uncomment the following only if an
            //        // Equals(QueryRow) implementation is present.
            //        //return Equals(other);
            //    }
            //}
            //return false;
            return base.Equals(obj);
        }

        #region Equals(QueryRow) implementation
        ///// <summary>
        ///// Returns true if this object is equal to <c>obj</c>.
        ///// </summary>
        ///// <remarks>
        ///// This is an overloaded Equals implementation taking a
        ///// QueryRow object to improve performance as a cast is not
        ///// required.
        ///// </remarks>
        ///// <param name="other">
        ///// QueryRow object to compare against.
        ///// </param>
        //public bool Equals(QueryRow other) {
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


        #region IEnumerable<KeyValuePair<int,string>> Members

        public IEnumerator<KeyValuePair<int, string>> GetEnumerator() {
            return data.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable)data).GetEnumerator();
        }

        #endregion

    }

}
