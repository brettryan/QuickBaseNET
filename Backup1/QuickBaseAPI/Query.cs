/*
 * Query.cs    11 August 2009, 16:49
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


namespace DrunkenDev.QuickBase {

    /// <summary>
    /// Represents a query to be sent to QuickBase.
    /// </summary>
    public class Query {

        /// <summary>
        /// Creates a new <c>Query</c> instance.
        /// </summary>
        public Query() {
            ColumnList = new List<int>();
            SortList = new List<int>();
            Properties = new Dictionary<string, string>();
        }

        /// <summary>
        /// Query ID.
        /// </summary>
        public int ID {
            get;
            set;
        }

        /// <summary>
        /// Query Name.
        /// </summary>
        public string Name {
            get;
            set;
        }

        /// <summary>
        /// Query type.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Current known values are <c>newsummary</c> and <c>table</c>, there
        /// is no documentation on what this field represents.
        /// </para>
        /// <para>
        /// I have found that trying to run a query with a type of
        /// <c>newsummary</c> results in an error
        /// <c>'API_DoQuery only supports table-type queries'</c>.
        /// </para>
        /// </remarks>
        public string QueryType {
            get;
            set;
        }

        /// <summary>
        /// String set of options for Query.
        /// </summary>
        /// <remarks>
        /// This will eventually be obsoleted with a preference for a standard
        /// API mechanism, possibly.
        /// </remarks>
        public string Options {
            get;
            set;
        }

        /// <summary>
        /// List of columns to return.
        /// </summary>
        public IList<int> ColumnList {
            get;
            private set;
        }

        /// <summary>
        /// List of columns to sort by.
        /// </summary>
        public IList<int> SortList {
            get;
            private set;
        }

        /// <summary>
        /// Raw data properties.
        /// </summary>
        [Obsolete("This field is only available while we work out what properties can be assigned to a query, this should NOT be relied on")]
        public IDictionary<string, string> Properties {
            get;
            private set;
        }

        #region System.Object overrides.

        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <param name="obj">Object you wish to compare to.</param>
        /// <returns>true if this object is equal to <c>obj</c>.</returns>
        public override bool Equals(object obj) {
            //if (obj != null && obj.GetType().Equals(this.GetType())) {
            //    Query other = obj as Query;
            //    if ((object)other != null) {
            //        //TODO: Add Equals implementation
            //        // Uncomment the following only if an
            //        // Equals(Query) implementation is present.
            //        //return Equals(other);
            //    }
            //}
            //return false;
            return base.Equals(obj);
        }

        #region Equals(Query) implementation
        ///// <summary>
        ///// Returns true if this object is equal to <c>obj</c>.
        ///// </summary>
        ///// <remarks>
        ///// This is an overloaded Equals implementation taking a
        ///// Query object to improve performance as a cast is not
        ///// required.
        ///// </remarks>
        ///// <param name="other">
        ///// Query object to compare against.
        ///// </param>
        //public bool Equals(Query other) {
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

    }

}
