/*
 * Schema.cs    11 August 2009, 16:35
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
    /// Represents a quick-base database or table schema.
    /// </summary>
    public class Schema {

        /// <summary>
        /// Creates a new instance of <c>Schema</c>.
        /// </summary>
        public Schema() {
            Variables = new Dictionary<String, String>();
            Children = new Dictionary<String, String>();
            Fields = new Dictionary<int, Field>();
            Queries = new Dictionary<int, Query>();
        }

        public String Name {
            get;
            set;
        }

        public String Description {
            get;
            set;
        }

        public String ID {
            get;
            set;
        }

        public String ParentID {
            get;
            set;
        }

        public DateTime CreateDate {
            get;
            set;
        }

        public DateTime ModDate {
            get;
            set;
        }

        public long NextRecordID {
            get;
            set;
        }

        public int NextFieldID {
            get;
            set;
        }

        public int NextQueryID {
            get;
            set;
        }

        public int SortFieldID {
            get;
            set;
        }

        public int SortOrder {
            get;
            set;
        }

        public int KeyField {
            get;
            set;
        }

        public IDictionary<String, String> Variables {
            get;
            private set;
        }

        public IDictionary<String, String> Children {
            get;
            private set;
        }

        public IDictionary<int, Field> Fields {
            get;
            private set;
        }

        public IDictionary<int, Query> Queries {
            get;
            private set;
        }

        public Field SortField {
            get {
                if (Fields.ContainsKey(SortFieldID))
                    return Fields[SortFieldID];
                return null;
            }
        }

        #region System.Object overrides.

        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <param name="obj">Object you wish to compare to.</param>
        /// <returns>true if this object is equal to <c>obj</c>.</returns>
        public override bool Equals(object obj) {
            //if (obj != null && obj.GetType().Equals(this.GetType())) {
            //    Schema other = obj as Schema;
            //    if ((object)other != null) {
            //        //TODO: Add Equals implementation
            //        // Uncomment the following only if an
            //        // Equals(Schema) implementation is present.
            //        //return Equals(other);
            //    }
            //}
            //return false;
            return base.Equals(obj);
        }

        #region Equals(Schema) implementation
        ///// <summary>
        ///// Returns true if this object is equal to <c>obj</c>.
        ///// </summary>
        ///// <remarks>
        ///// This is an overloaded Equals implementation taking a
        ///// Schema object to improve performance as a cast is not
        ///// required.
        ///// </remarks>
        ///// <param name="other">
        ///// Schema object to compare against.
        ///// </param>
        //public bool Equals(Schema other) {
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
            return String.Format("{0}[ID={1},Name={2},ParentID={3},CreateDate={4},ModDate={5}]",
                GetType().Name, ID, Name, ParentID, CreateDate, ModDate
                );
        }

        #endregion

    }

}
