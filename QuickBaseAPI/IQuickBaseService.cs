/*
 * IQuickBaseService.cs    11 August 2009, 16:20
 *
 * Copyright 2009 Drunken Dev. All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;


namespace DrunkenDev.QuickBase {

    /// <summary>
    /// Service interface for the QuickBase HTTP API.
    /// </summary>
    /// <seealso cref="http://member.developer.intuit.com/MyIDN/technical_resources/quickbase/framework/httpapiref/HTML_API_Programmers_Guide.htm"/>
    public interface IQuickBaseService {

        /// <summary>
        /// Authenticate against the QuickBase service.
        /// </summary>
        /// <returns>True if authentication succeeded.</returns>
        bool Authenticate();

        /// <summary>
        /// Sign out fromt he QuickBase service.
        /// </summary>
        void SignOut();

        /// <summary>
        /// Returns a schema object encapsulating information about a
        /// database/table.
        /// </summary>
        /// <param name="dbid">
        /// Database or table ID to return results for.
        /// </param>
        /// <returns>
        /// Schema encapsulating information about the given database/table.
        /// </returns>
        /// <exception cref="DrunkenDev.QuickBase.QuickBaseException">
        /// If an implementation error occurs.
        /// </exception>
        Schema GetSchema(string dbid);

        /// <summary>
        /// Retrieve a list of granted databases.
        /// </summary>
        /// <remarks>
        /// Key is the DBID, valud is the database name.
        /// </remarks>
        /// <returns>Dictionary of available DB's</returns>
        IDictionary<string, string> GetGrantedDatabases();

        /// <summary>
        /// Retrieve a list of granted databases.
        /// </summary>
        /// <remarks>
        /// Key is the DBID, valud is the database name.
        /// </remarks>
        /// <param name="options">Retrieval options.</param>
        /// <returns>Dictionary of available DB's</returns>
        IDictionary<string, string> GetGrantedDatabases(GrantedDBOPtions options);
        
        /// <summary>
        /// Gets default fields for all records in a table.
        /// </summary>
        /// <remarks>
        /// Passing a DBID instead of a table ID will throw a
        /// <see cref="QuickBaseException"/>.
        /// </remarks>
        /// <param name="tableId">Table ID.</param>
        /// <returns>
        /// <see cref="QueryResult"/> object containing record data.
        /// </returns>
        QueryResult Query(string tableId);

        /// <summary>
        /// Runs a saved query against a table.
        /// </summary>
        /// <remarks>
        /// Passing a DBID instead of a table ID will throw a
        /// <see cref="QuickBaseException"/>.
        /// </remarks>
        /// <param name="tableId">Table ID</param>
        /// <param name="queryId">Query ID</param>
        /// <returns>
        /// <see cref="QueryResult"/> object containing record data.
        /// </returns>
        QueryResult Query(string tableId, int queryId);

        /// <summary>
        /// Performs a custom query against a given table.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Passing a DBID instead of a table ID will throw a
        /// <see cref="QuickBaseException"/>.
        /// </para>
        /// <para>
        /// Refer to the QuickBase documentation regarding the query format
        /// http://member.developer.intuit.com/MyIDN/technical_resources/quickbase/framework/httpapiref/HTML_API_Programmers_Guide.htm
        /// </para>
        /// </remarks>
        /// <param name="tableId">Table ID.</param>
        /// <param name="queryText">Query text.</param>
        /// <returns>
        /// <see cref="QueryResult"/> object containing record data.
        /// </returns>
        QueryResult Query(string tableId, string queryText);

        QueryResult Query(string dbid, Query query);

        QueryResult Query(string dbid, int queryId, string queryText, Query query);

        //int EditRecords(int record, IEnumerable<KeyValuePair<int, string>> fieldValues);
        int EditRecords(string dbid, int record, IEnumerable<KeyValuePair<int, string>> fieldValues);
        int EditRecords(string dbid, int record, IEnumerable<KeyValuePair<int, IFieldValue>> fieldValues);

        int AddRecords(string dbid, IEnumerable<KeyValuePair<int, string>> fieldValues);
        int DeleteRecords(string dbid, int record);

        /// <summary>
        /// Gets a file as a stream object.
        /// </summary>
        /// <remarks>
        /// You must remember to close this stream yourself.
        /// </remarks>
        /// <param name="file">QuickBase file to retrieve.</param>
        /// <returns>Stream for given file.</returns>
        Stream GetFile(QuickBaseFile file);

        /// <summary>
        /// Writes a file to a given stream.
        /// </summary>
        /// <remarks>
        /// The output stream will be closed for you.
        /// </remarks>
        /// <param name="file">QuickBase file to retrieve.</param>
        /// <param name="outputStream">Output stream.</param>
        void WriteFile(QuickBaseFile file, Stream outputStream);

        /// <summary>
        /// Start writing a file asynchronously.
        /// </summary>
        /// <param name="file">QuickBase file to retrieve.</param>
        /// <param name="outFile">Output file name</param>
        /// <param name="writeStarted">
        /// Method to call when the write starts, this may be null.
        /// </param>
        /// <param name="writeComplete">
        /// Method to call when the write completes, this may be null.
        /// </param>
        /// <param name="writeProgressChanged">
        /// Method to call when the write completes, this may be null.
        /// </param>
        /// <returns>Background worker object managing the task.</returns>
        BackgroundWorker WriteFileAsync(
            QuickBaseFile file,
            string outFile,
            WriteFileStartedDelegate writeStarted,
            WriteFileCompleteDelegate writeComplete,
            WriteFileProgressChangedDelegate writeProgressChanged
            );

    }

    /// <summary>
    /// Delegate called when an async file download starts.
    /// </summary>
    /// <param name="file">QuickBase file being downloaded.</param>
    /// <param name="length">File length in bytes.</param>
    /// <param name="contentType">MIME content type for the file.</param>
    /// <seealso cref="DrunkenDev.QuickBase.IQuickBaseService.WriteFileAsync"/>
    public delegate void WriteFileStartedDelegate(
            QuickBaseFile file, long length, string contentType);

    /// <summary>
    /// Delegate called when an async file download completes.
    /// </summary>
    /// <param name="file">QuickBase file being downloaded.</param>
    /// <param name="cancelled">True if the operation was cancelled.</param>
    /// <param name="error">Exception if an error was raised.</param>
    /// <seealso cref="DrunkenDev.QuickBase.IQuickBaseService.WriteFileAsync"/>
    public delegate void WriteFileCompleteDelegate(
            QuickBaseFile file, bool cancelled, Exception error);

    /// <summary>
    /// Delegate that reports progress of an async file download.
    /// </summary>
    /// <param name="file">QuickBase file being downloaded.</param>
    /// <param name="percent">Percentage of download.</param>
    /// <seealso cref="DrunkenDev.QuickBase.IQuickBaseService.WriteFileAsync"/>
    public delegate void WriteFileProgressChangedDelegate(
            QuickBaseFile file, int percent);

    /// <summary>
    /// Database Retrieval options.
    /// </summary>
    /// <seealso cref="DrunkenDev.QuickBase.IQuickBaseService.GetGrantedDatabases"/>
    [Flags]
    public enum GrantedDBOPtions {
        /// <summary>
        /// Parents.
        /// </summary>
        Parents,
        /// <summary>
        /// Child database tables.
        /// </summary>
        Children,
        /// <summary>
        /// Tables accessible to administrators only.
        /// </summary>
        AdminOnly,
    }

}
