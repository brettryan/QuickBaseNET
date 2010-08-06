/*
 * Field.cs    11 August 2009, 16:50
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
    /// Represents a <c>QuickBase</c> field.
    /// </summary>
    public class Field {

        /// <summary>
        /// Creates a new <c>Field</c> instance.
        /// </summary>
        public Field() {
            Choices = new List<string>();
            Properties = new Dictionary<string, string>();
        }

        /// <summary>
        /// <see cref="FieldType"/> for this field.
        /// </summary>
        public FieldType FieldType {
            get;
            set;
        }

        /// <summary>
        /// Base data type.
        /// </summary>
        public string BaseType {
            get;
            set;
        }

        /// <summary>
        /// Field ID.
        /// </summary>
        public int ID {
            get;
            set;
        }

        /// <summary>
        /// Field label.
        /// </summary>
        public string Label {
            get;
            set;
        }

        /// <summary>
        /// <see cref="FieldMode"/> for this field.
        /// </summary>
        public FieldMode Mode {
            get;
            set;
        }

        /// <summary>
        /// <c>True</c> if display wrapping is not allowed.
        /// </summary>
        public bool NoWrap {
            get;
            set;
        }

        /// <summary>
        /// <c>True</c> to show field value in bold text.
        /// </summary>
        public bool Bold {
            get;
            set;
        }

        /// <summary>
        /// <c>True</c> if this field is required.
        /// </summary>
        public bool Required {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        public bool AppearsByDefault {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool AllowNewChoices {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool SortAsGiven {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Commas {
            get;
            set;
        }

        public bool FindEnabled {
            get;
            set;
        }

        public int Width {
            get;
            set;
        }

        public bool CarryChoices {
            get;
            set;
        }

        public string FieldHelp {
            get;
            set;
        }

        public bool AllowHtml {
            get;
            set;
        }

        public bool BlankIsZero {
            get;
            set;
        }

        public IList<String> Choices {
            get;
            private set;
        }

        [Obsolete("This field is only available while we work out what properties can be assigned to a field, this should NOT be relied on")]
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
            //    Field other = obj as Field;
            //    if ((object)other != null) {
            //        //TODO: Add Equals implementation
            //        // Uncomment the following only if an
            //        // Equals(Field) implementation is present.
            //        //return Equals(other);
            //    }
            //}
            //return false;
            return base.Equals(obj);
        }

        #region Equals(Field) implementation
        ///// <summary>
        ///// Returns true if this object is equal to <c>obj</c>.
        ///// </summary>
        ///// <remarks>
        ///// This is an overloaded Equals implementation taking a
        ///// Field object to improve performance as a cast is not
        ///// required.
        ///// </remarks>
        ///// <param name="other">
        ///// Field object to compare against.
        ///// </param>
        //public bool Equals(Field other) {
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
