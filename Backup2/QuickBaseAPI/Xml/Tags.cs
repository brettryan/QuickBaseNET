/*
 * Tags.cs    14 August 2009, 16:23
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


namespace DrunkenDev.QuickBase.Xml {

    /// <summary>
    ///
    /// </summary>
    internal static class Tags {

        internal const string DocRoot = "qdbapi";

        internal const string ErrorCode = "errcode";
        internal const string ErrorText = "errtext";
        internal const string ErrorDetail = "errdetail";

        internal const string Username = "username";
        internal const string Password = "password";

        internal const string Ticket = "ticket";
        internal const string UserID = "userid";

        internal const string Action = "action";

        internal const string QueryFormat = "fmt";
        internal const string Record = "record";
        internal const string RecordField = "f";

        internal const string AttributeID = "id";

        internal const string AppToken = "apptoken";

    }

}
