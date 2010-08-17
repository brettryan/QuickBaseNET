/*
 * QuickBaseFile.cs    17 August 2009, 4:47
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
using System.Text.RegularExpressions;


namespace DrunkenDev.QuickBase {

    /// <summary>
    /// Represents a QuickBase file.
    /// </summary>
    public class QuickBaseFile {

        /// <summary>
        /// QuickBase URL.
        /// </summary>
        public static readonly Regex UrlRegex = new Regex(@"^(.+)?<url>(.+)</url>$");

        /// <summary>
        /// Retrieve a file object from a string matching <see cref="UrlRegex"/>.
        /// </summary>
        /// <param name="input">Text input.</param>
        /// <returns>file instance for input text.</returns>
        public static QuickBaseFile GetFile(string input) {
            Match m = UrlRegex.Match(input);
            if (m.Success) {
                Group tx = m.Groups[1];
                Group ur = m.Groups[2];
                if (ur.Captures.Count > 0) {
                    if (tx.Captures.Count > 0)
                        return new QuickBaseFile(new Uri(ur.Captures[0].Value), tx.Captures[0].Value);
                    return new QuickBaseFile(new Uri(ur.Captures[0].Value));
                }
            }
            throw new FormatException("Url not in correct format, must be name<url>url</url>.");
        }

        /// <summary>
        /// Creates a new instance of <c>QuickBaseFile</c>.
        /// </summary>
        public QuickBaseFile(Uri uri, string displayText) : this(uri) {
            this.DisplayText = displayText;
        }

        /// <summary>
        /// Creates a new file instance from the given <see cref="System.Uri"/>.
        /// </summary>
        /// <param name="uri">Uri to create instance for.</param>
        public QuickBaseFile(Uri uri) {
            this.Uri = uri;
        }

        /// <summary>
        /// <see cref="System.Uri"/> instance that this file represents.
        /// </summary>
        public Uri Uri {
            get;
            private set;
        }

        /// <summary>
        /// File display text.
        /// </summary>
        public string DisplayText {
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
            if (obj != null && obj.GetType().Equals(this.GetType())) {
                QuickBaseFile other = obj as QuickBaseFile;
                if ((object)other != null) {
                    return Equals(other);
                }
            }
            return false;
        }

        #region Equals(QuickBaseFile) implementation
        /// <summary>
        /// Returns true if this object is equal to <c>obj</c>.
        /// </summary>
        /// <remarks>
        /// This is an overloaded Equals implementation taking a
        /// QuickBaseFile object to improve performance as a cast is not
        /// required.
        /// </remarks>
        /// <param name="other">
        /// QuickBaseFile object to compare against.
        /// </param>
        public bool Equals(QuickBaseFile other) {
            return other != null && (
                Uri.Equals(this.Uri, other.Uri) &&
                String.Equals(this.DisplayText, other.DisplayText)
                );        }
        #endregion

        /// <summary>
        /// Returns a simple hash for this structure.
        /// </summary>
        /// <returns>The hash for this object.</returns>
        public override int GetHashCode() {
            int hash = 2;
            hash = 2 * hash + Uri.GetHashCode();
            hash = 2 * hash + DisplayText == null
                ? 0 : DisplayText.GetHashCode();
            return hash;
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
            return ToHtmlString();
        }

        public string ToHtmlString() {
            if (String.IsNullOrEmpty(DisplayText)) {
                return String.Format("<a href='{0}'>{0}</a>", Uri.ToString());
            } else {
                return String.Format(
                    "<a href='{0}'>{1}</a>",
                    Uri.ToString(),
                    DisplayText);
            }
        }

        #endregion

    }

}
