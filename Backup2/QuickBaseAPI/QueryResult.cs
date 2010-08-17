/*
 * QueryResult.cs    11 August 2009, 16:31
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
    /// Result for a <see cref="Query"/> call.
    /// </summary>
    public class QueryResult {

        /// <summary>
        /// Creates a new <c>QueryResult</c> instance.
        /// </summary>
        public QueryResult() {
            Rows = new List<QueryRow>();
        }

        /// <summary>
        /// List of rows returned by the query.
        /// </summary>
        public IList<QueryRow> Rows {
            get;
            private set;
        }

        /// <summary>
        /// Shema returned from QuickBase
        /// </summary>
        public Schema Schema {
            get;
            internal set;
        }

        #region System.Object overrides.

        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <param name="obj">Object you wish to compare to.</param>
        /// <returns>true if this object is equal to <c>obj</c>.</returns>
        public override bool Equals(object obj) {
            //if (obj != null && obj.GetType().Equals(this.GetType())) {
            //    QueryResult other = obj as QueryResult;
            //    if ((object)other != null) {
            //        //TODO: Add Equals implementation
            //        // Uncomment the following only if an
            //        // Equals(QueryResult) implementation is present.
            //        //return Equals(other);
            //    }
            //}
            //return false;
            return base.Equals(obj);
        }

        #region Equals(QueryResult) implementation
        ///// <summary>
        ///// Returns true if this object is equal to <c>obj</c>.
        ///// </summary>
        ///// <remarks>
        ///// This is an overloaded Equals implementation taking a
        ///// QueryResult object to improve performance as a cast is not
        ///// required.
        ///// </remarks>
        ///// <param name="other">
        ///// QueryResult object to compare against.
        ///// </param>
        //public bool Equals(QueryResult other) {
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
