/*
 * QuickBaseCommands.cs    11 August 2009, 16:21
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
    /// Commands known from quick-base API documentation.
    /// </summary>
    public static class QuickBaseCommands {

        //
        // Application and table metadata
        //
        public const string FindDBByName = "API_FindDBByName";
        public const string GetAppDTMInfo = "API_GetAppDTMInfo";
        public const string GetDBInfo = "API_GetDBInfo";
        public const string GetSchema = "API_GetSchema";
        public const string GrantedDBs = "API_GrantedDBs";

        //
        // Application life cycle
        //
        public const string CloneDatabase = "API_CloneDatabase";
        public const string CreateDatabase = "API_CreateDatabase";
        public const string DeleteDatabase = "API_DeleteDatabase";
        public const string RenameApp = "API_RenameApp";

        //
        // File upload and download
        //
        public const string AddRecord = "API_AddRecord";
        //public const string EditRecord = "API_EditRecord";
        public const string UploadFile = "API_UploadFile";

        //
        // Misc
        //
        public const string AddReplaceDBPage = "API_AddReplaceDBPage";
        public const string GetDBPage = "API_GetDBPage";
        public const string GetDBvar = "API_GetDBvar";
        public const string SetDBvar = "API_SetDBvar";

        //
        // Secure access to QuickBase applications
        // requires https communication
        // requires ticket and developer key
        //
        public const string Authenticate = "API_Authenticate";
        //public const string GetOneTimeTicket = "API_GetOneTimeTicket";
        public const string SignOut = "API_SignOut";

        //
        // Table and field management
        //
        public const string AddField = "API_AddField";
        public const string CreateTable = "API_CreateTable";
        public const string DeleteField = "API_DeleteField";
        public const string FieldAddChoices = "API_FieldAddChoices";
        public const string FieldRemoveChoices = "API_FieldRemoveChoices";
        public const string SetFieldProperties = "API_SetFieldProperties";

        //
        // Table record management
        //
        //public const string AddRecord = "API_AddRecord";
        public const string ChangeRecordOwner = "API_ChangeRecordOwner";
        public const string DeleteRecord = "API_DeleteRecord";
        public const string DoQuery = "API_DoQuery";
        public const string EditRecord = "API_EditRecord";
        public const string GenAddRecordForm = "API_GenAddRecordForm";
        public const string GenResultsTable = "API_GenResultsTable";
        public const string GetNumRecords = "API_GetNumRecords";
        public const string GetRecordAsHTML = "API_GetRecordAsHTML";
        public const string GetRecordInfo = "API_GetRecordInfo";
        public const string ImportFromCSV = "API_ImportFromCSV";
        public const string PurgeRecords = "API_PurgeRecords";
        public const string RunImport = "API_RunImport";

        //
        // User access management
        //
        public const string AddUserToRole = "API_AddUserToRole";
        public const string ChangeUserRole = "API_ChangeUserRole";
        //public const string ChangeRecordOwner = "API_ChangeRecordOwner";
        public const string GetRoleInfo = "API_GetRoleInfo";
        public const string GetUserInfo = "API_GetUserInfo";
        public const string GetUserRole = "API_GetUserRole";
        public const string ProvisionUser = "API_ProvisionUser";
        public const string RemoveUserFromRole = "API_RemoveUserFromRole";
        public const string SendInvitation = "API_SendInvitation";
        public const string UserRoles = "API_UserRoles";

        //
        // Not found in new API documentation.
        //
        [Obsolete]
        public const string ChangePermission = "API_ChangePermission";
        [Obsolete]
        public const string OneTimeTicket = "API_OneTimeTicket";

    }

}
