/*
 * QuickBaseException.cs    11 August 2009, 16:29
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
    /// Exception raised by a <see cref="IQuickBaseService"/> service call.
    /// </summary>
    public class QuickBaseException : Exception {

        /// <summary>
        /// Creates a new instance of <c>QuickBaseException</c>.
        /// </summary>
        /// <param name="errCode">Error Code</param>
        /// <param name="errText">Error text.</param>
        /// <param name="errDetail">Error detail.</param>
        /// <param name="action">Action that raised the error.</param>
        public QuickBaseException(
                string errCode,
                string errText,
                string errDetail,
                string action)
            : base(errDetail) {
            this.ErrorCode = errCode;
            this.ErrorText = errText;
            this.Action = action;
        }

        /// <summary>
        /// Creates a new instance of <c>QuickBaseException</c>.
        /// </summary>
        public QuickBaseException() : base() {
        }

        /// <summary>
        /// Creates a new instance of <c>QuickBaseException</c>.
        /// </summary>
        /// <param name="message">Message text for exception.</param>
        public QuickBaseException(string message)
            : base(message) {
        }

        /// <summary>
        /// Creates a new instance of <c>QuickBaseException</c>.
        /// </summary>
        /// <param name="message">Message text for exception.</param>
        /// <param name="innerException">Inner exception.</param>
        public QuickBaseException(string message, Exception innerException)
            : base(message, innerException) {
        }

        /// <summary>
        /// Action that caused the error.
        /// </summary>
        public string Action {
            get;
            private set;
        }

        /// <summary>
        /// QuickBase Error code.
        /// </summary>
        public string ErrorCode {
            get;
            private set;
        }

        /// <summary>
        /// Error text.
        /// </summary>
        public string ErrorText {
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
            //    QuickBaseException other = obj as QuickBaseException;
            //    if ((object)other != null) {
            //        //TODO: Add Equals implementation
            //        // Uncomment the following only if an
            //        // Equals(QuickBaseException) implementation is present.
            //        //return Equals(other);
            //    }
            //}
            //return false;
            return base.Equals(obj);
        }

        #region Equals(QuickBaseException) implementation
        ///// <summary>
        ///// Returns true if this object is equal to <c>obj</c>.
        ///// </summary>
        ///// <remarks>
        ///// This is an overloaded Equals implementation taking a
        ///// QuickBaseException object to improve performance as a cast is not
        ///// required.
        ///// </remarks>
        ///// <param name="other">
        ///// QuickBaseException object to compare against.
        ///// </param>
        //public bool Equals(QuickBaseException other) {
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
