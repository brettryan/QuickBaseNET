/*
 * FileFieldValue.cs    8 May 2012, 14:53
 *
 * Copyright 2012 Drunken Dev. All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace DrunkenDev.QuickBase {

    public class FileFieldValue : IFieldValue {

        private Stream fileStream;
        private string fileName;

        public FileFieldValue(Stream fileStream, string fileName) {
            this.fileName = fileName;
            this.fileStream = fileStream;
        }

        #region IFieldValue Members

        public string GetDataAsString() {
            byte[] data = new byte[fileStream.Length];
            int len = fileStream.Read(data, 0, Convert.ToInt32(fileStream.Length));
            return Convert.ToBase64String(data, 0, len, Base64FormattingOptions.None);
        }

        public Dictionary<string, string> GetAttributes() {
            var r = new Dictionary<string, string>();
            r.Add("filename", fileName);
            return r;
        }

        #endregion

    }

}
