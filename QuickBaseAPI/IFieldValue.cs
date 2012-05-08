/*
 * IFieldValue.cs    8 May 2012, 14:38
 *
 * Copyright 2012 Drunken Dev. All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DrunkenDev.QuickBase {

    public interface IFieldValue {

        string GetDataAsString();

        Dictionary<String, String> GetAttributes();

    }

}
