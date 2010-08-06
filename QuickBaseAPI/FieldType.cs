/*
 * FieldType.cs    11 August 2009, 16:51
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
    ///
    /// </summary>
    public enum FieldType {
        /// <summary>
        /// Type is not known.
        /// </summary>
        /// <remarks>
        /// If a type is not known then it should be treated as string.
        /// </remarks>
        Unknown,
        /// <summary>
        /// CheckBox
        /// </summary>
        CheckBox, // "checkbox"
        /// <summary>
        /// Numeric-Currency
        /// </summary>
        Currency, // "currency"
        /// <summary>
        /// Database Link
        /// </summary>
        DatabaseLink, // "dblink"
        /// <summary>
        /// Date
        /// </summary>
        Date, // "date"
        /// <summary>
        /// Duration
        /// </summary>
        Duration, // "duration"
        /// <summary>
        /// Email Address
        /// </summary>
        Email, // "email"
        /// <summary>
        /// File Attachment
        /// </summary>
        File, // "file"
        /// <summary>
        /// Numeric
        /// </summary>
        Float, // "float"
        Percent,
        /// <summary>
        /// Phone Number
        /// </summary>
        Phone, // "phone"
        /// <summary>
        /// Numeric-Rating
        /// </summary>
        Rating, // "rating"
        RecordID,
        /// <summary>
        /// Text
        /// </summary>
        Text, // "text"
        /// <summary>
        /// Time Of Day
        /// </summary>
        TimeOfDay, // "timeofday"
        TimeStamp, // "timestamp"
        /// <summary>
        /// URL-Link
        /// </summary>
        Url, // "url"
        UserID,
    }

}
