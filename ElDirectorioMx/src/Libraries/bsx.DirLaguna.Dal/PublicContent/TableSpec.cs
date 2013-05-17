
using System.Collections.Generic;

namespace bsx.DirLaguna.Dal.PublicContent
{

    public partial class aspnet_Applications
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "aspnet_Applications" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "aspnet_Applications" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnApplicationName = new TableColumn();
                columnApplicationName.ColumnName = "ApplicationName";
                columnApplicationName.MaxLength = 256;
                columnApplicationName.AutoIncrement = bool.Parse("False");
                columnApplicationName.IsNullable = bool.Parse("False");
                columnApplicationName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnApplicationName);



                TableColumn columnLoweredApplicationName = new TableColumn();
                columnLoweredApplicationName.ColumnName = "LoweredApplicationName";
                columnLoweredApplicationName.MaxLength = 256;
                columnLoweredApplicationName.AutoIncrement = bool.Parse("False");
                columnLoweredApplicationName.IsNullable = bool.Parse("False");
                columnLoweredApplicationName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnLoweredApplicationName);



                TableColumn columnApplicationId = new TableColumn();
                columnApplicationId.ColumnName = "ApplicationId";
                columnApplicationId.MaxLength = 16;
                columnApplicationId.AutoIncrement = bool.Parse("False");
                columnApplicationId.IsNullable = bool.Parse("False");
                columnApplicationId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnApplicationId);



                TableColumn columnDescription = new TableColumn();
                columnDescription.ColumnName = "Description";
                columnDescription.MaxLength = 256;
                columnDescription.AutoIncrement = bool.Parse("False");
                columnDescription.IsNullable = bool.Parse("True");
                columnDescription.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnDescription);



                return columnSpecs;

            }

            public static TableColumn ApplicationNameColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn LoweredApplicationNameColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn ApplicationIdColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn DescriptionColumn
            {
                get
                {
                    return columns[3];
                }
            }



        }

        public struct ColumnNames
        {
            public static string ApplicationName = @"ApplicationName";
            public static string LoweredApplicationName = @"LoweredApplicationName";
            public static string ApplicationId = @"ApplicationId";
            public static string Description = @"Description";

        }

    }



    public partial class aspnet_Membership
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "aspnet_Membership" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "aspnet_Membership" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnApplicationId = new TableColumn();
                columnApplicationId.ColumnName = "ApplicationId";
                columnApplicationId.MaxLength = 16;
                columnApplicationId.AutoIncrement = bool.Parse("False");
                columnApplicationId.IsNullable = bool.Parse("False");
                columnApplicationId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnApplicationId);



                TableColumn columnUserId = new TableColumn();
                columnUserId.ColumnName = "UserId";
                columnUserId.MaxLength = 16;
                columnUserId.AutoIncrement = bool.Parse("False");
                columnUserId.IsNullable = bool.Parse("False");
                columnUserId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnUserId);



                TableColumn columnPassword = new TableColumn();
                columnPassword.ColumnName = "Password";
                columnPassword.MaxLength = 128;
                columnPassword.AutoIncrement = bool.Parse("False");
                columnPassword.IsNullable = bool.Parse("False");
                columnPassword.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPassword);



                TableColumn columnPasswordFormat = new TableColumn();
                columnPasswordFormat.ColumnName = "PasswordFormat";
                columnPasswordFormat.MaxLength = 4;
                columnPasswordFormat.AutoIncrement = bool.Parse("False");
                columnPasswordFormat.IsNullable = bool.Parse("False");
                columnPasswordFormat.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPasswordFormat);



                TableColumn columnPasswordSalt = new TableColumn();
                columnPasswordSalt.ColumnName = "PasswordSalt";
                columnPasswordSalt.MaxLength = 128;
                columnPasswordSalt.AutoIncrement = bool.Parse("False");
                columnPasswordSalt.IsNullable = bool.Parse("False");
                columnPasswordSalt.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPasswordSalt);



                TableColumn columnMobilePIN = new TableColumn();
                columnMobilePIN.ColumnName = "MobilePIN";
                columnMobilePIN.MaxLength = 16;
                columnMobilePIN.AutoIncrement = bool.Parse("False");
                columnMobilePIN.IsNullable = bool.Parse("True");
                columnMobilePIN.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnMobilePIN);



                TableColumn columnEmail = new TableColumn();
                columnEmail.ColumnName = "Email";
                columnEmail.MaxLength = 256;
                columnEmail.AutoIncrement = bool.Parse("False");
                columnEmail.IsNullable = bool.Parse("True");
                columnEmail.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnEmail);



                TableColumn columnLoweredEmail = new TableColumn();
                columnLoweredEmail.ColumnName = "LoweredEmail";
                columnLoweredEmail.MaxLength = 256;
                columnLoweredEmail.AutoIncrement = bool.Parse("False");
                columnLoweredEmail.IsNullable = bool.Parse("True");
                columnLoweredEmail.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnLoweredEmail);



                TableColumn columnPasswordQuestion = new TableColumn();
                columnPasswordQuestion.ColumnName = "PasswordQuestion";
                columnPasswordQuestion.MaxLength = 256;
                columnPasswordQuestion.AutoIncrement = bool.Parse("False");
                columnPasswordQuestion.IsNullable = bool.Parse("True");
                columnPasswordQuestion.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnPasswordQuestion);



                TableColumn columnPasswordAnswer = new TableColumn();
                columnPasswordAnswer.ColumnName = "PasswordAnswer";
                columnPasswordAnswer.MaxLength = 128;
                columnPasswordAnswer.AutoIncrement = bool.Parse("False");
                columnPasswordAnswer.IsNullable = bool.Parse("True");
                columnPasswordAnswer.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnPasswordAnswer);



                TableColumn columnIsApproved = new TableColumn();
                columnIsApproved.ColumnName = "IsApproved";
                columnIsApproved.MaxLength = 1;
                columnIsApproved.AutoIncrement = bool.Parse("False");
                columnIsApproved.IsNullable = bool.Parse("False");
                columnIsApproved.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnIsApproved);



                TableColumn columnIsLockedOut = new TableColumn();
                columnIsLockedOut.ColumnName = "IsLockedOut";
                columnIsLockedOut.MaxLength = 1;
                columnIsLockedOut.AutoIncrement = bool.Parse("False");
                columnIsLockedOut.IsNullable = bool.Parse("False");
                columnIsLockedOut.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnIsLockedOut);



                TableColumn columnCreateDate = new TableColumn();
                columnCreateDate.ColumnName = "CreateDate";
                columnCreateDate.MaxLength = 8;
                columnCreateDate.AutoIncrement = bool.Parse("False");
                columnCreateDate.IsNullable = bool.Parse("False");
                columnCreateDate.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCreateDate);



                TableColumn columnLastLoginDate = new TableColumn();
                columnLastLoginDate.ColumnName = "LastLoginDate";
                columnLastLoginDate.MaxLength = 8;
                columnLastLoginDate.AutoIncrement = bool.Parse("False");
                columnLastLoginDate.IsNullable = bool.Parse("False");
                columnLastLoginDate.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnLastLoginDate);



                TableColumn columnLastPasswordChangedDate = new TableColumn();
                columnLastPasswordChangedDate.ColumnName = "LastPasswordChangedDate";
                columnLastPasswordChangedDate.MaxLength = 8;
                columnLastPasswordChangedDate.AutoIncrement = bool.Parse("False");
                columnLastPasswordChangedDate.IsNullable = bool.Parse("False");
                columnLastPasswordChangedDate.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnLastPasswordChangedDate);



                TableColumn columnLastLockoutDate = new TableColumn();
                columnLastLockoutDate.ColumnName = "LastLockoutDate";
                columnLastLockoutDate.MaxLength = 8;
                columnLastLockoutDate.AutoIncrement = bool.Parse("False");
                columnLastLockoutDate.IsNullable = bool.Parse("False");
                columnLastLockoutDate.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnLastLockoutDate);



                TableColumn columnFailedPasswordAttemptCount = new TableColumn();
                columnFailedPasswordAttemptCount.ColumnName = "FailedPasswordAttemptCount";
                columnFailedPasswordAttemptCount.MaxLength = 4;
                columnFailedPasswordAttemptCount.AutoIncrement = bool.Parse("False");
                columnFailedPasswordAttemptCount.IsNullable = bool.Parse("False");
                columnFailedPasswordAttemptCount.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFailedPasswordAttemptCount);



                TableColumn columnFailedPasswordAttemptWindowStart = new TableColumn();
                columnFailedPasswordAttemptWindowStart.ColumnName = "FailedPasswordAttemptWindowStart";
                columnFailedPasswordAttemptWindowStart.MaxLength = 8;
                columnFailedPasswordAttemptWindowStart.AutoIncrement = bool.Parse("False");
                columnFailedPasswordAttemptWindowStart.IsNullable = bool.Parse("False");
                columnFailedPasswordAttemptWindowStart.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFailedPasswordAttemptWindowStart);



                TableColumn columnFailedPasswordAnswerAttemptCount = new TableColumn();
                columnFailedPasswordAnswerAttemptCount.ColumnName = "FailedPasswordAnswerAttemptCount";
                columnFailedPasswordAnswerAttemptCount.MaxLength = 4;
                columnFailedPasswordAnswerAttemptCount.AutoIncrement = bool.Parse("False");
                columnFailedPasswordAnswerAttemptCount.IsNullable = bool.Parse("False");
                columnFailedPasswordAnswerAttemptCount.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFailedPasswordAnswerAttemptCount);



                TableColumn columnFailedPasswordAnswerAttemptWindowStart = new TableColumn();
                columnFailedPasswordAnswerAttemptWindowStart.ColumnName = "FailedPasswordAnswerAttemptWindowStart";
                columnFailedPasswordAnswerAttemptWindowStart.MaxLength = 8;
                columnFailedPasswordAnswerAttemptWindowStart.AutoIncrement = bool.Parse("False");
                columnFailedPasswordAnswerAttemptWindowStart.IsNullable = bool.Parse("False");
                columnFailedPasswordAnswerAttemptWindowStart.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFailedPasswordAnswerAttemptWindowStart);



                TableColumn columnComment = new TableColumn();
                columnComment.ColumnName = "Comment";
                columnComment.MaxLength = 1073741823;
                columnComment.AutoIncrement = bool.Parse("False");
                columnComment.IsNullable = bool.Parse("True");
                columnComment.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnComment);



                return columnSpecs;

            }

            public static TableColumn ApplicationIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn UserIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn PasswordColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn PasswordFormatColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn PasswordSaltColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn MobilePINColumn
            {
                get
                {
                    return columns[5];
                }
            }

            public static TableColumn EmailColumn
            {
                get
                {
                    return columns[6];
                }
            }

            public static TableColumn LoweredEmailColumn
            {
                get
                {
                    return columns[7];
                }
            }

            public static TableColumn PasswordQuestionColumn
            {
                get
                {
                    return columns[8];
                }
            }

            public static TableColumn PasswordAnswerColumn
            {
                get
                {
                    return columns[9];
                }
            }

            public static TableColumn IsApprovedColumn
            {
                get
                {
                    return columns[10];
                }
            }

            public static TableColumn IsLockedOutColumn
            {
                get
                {
                    return columns[11];
                }
            }

            public static TableColumn CreateDateColumn
            {
                get
                {
                    return columns[12];
                }
            }

            public static TableColumn LastLoginDateColumn
            {
                get
                {
                    return columns[13];
                }
            }

            public static TableColumn LastPasswordChangedDateColumn
            {
                get
                {
                    return columns[14];
                }
            }

            public static TableColumn LastLockoutDateColumn
            {
                get
                {
                    return columns[15];
                }
            }

            public static TableColumn FailedPasswordAttemptCountColumn
            {
                get
                {
                    return columns[16];
                }
            }

            public static TableColumn FailedPasswordAttemptWindowStartColumn
            {
                get
                {
                    return columns[17];
                }
            }

            public static TableColumn FailedPasswordAnswerAttemptCountColumn
            {
                get
                {
                    return columns[18];
                }
            }

            public static TableColumn FailedPasswordAnswerAttemptWindowStartColumn
            {
                get
                {
                    return columns[19];
                }
            }

            public static TableColumn CommentColumn
            {
                get
                {
                    return columns[20];
                }
            }



        }

        public struct ColumnNames
        {
            public static string ApplicationId = @"ApplicationId";
            public static string UserId = @"UserId";
            public static string Password = @"Password";
            public static string PasswordFormat = @"PasswordFormat";
            public static string PasswordSalt = @"PasswordSalt";
            public static string MobilePIN = @"MobilePIN";
            public static string Email = @"Email";
            public static string LoweredEmail = @"LoweredEmail";
            public static string PasswordQuestion = @"PasswordQuestion";
            public static string PasswordAnswer = @"PasswordAnswer";
            public static string IsApproved = @"IsApproved";
            public static string IsLockedOut = @"IsLockedOut";
            public static string CreateDate = @"CreateDate";
            public static string LastLoginDate = @"LastLoginDate";
            public static string LastPasswordChangedDate = @"LastPasswordChangedDate";
            public static string LastLockoutDate = @"LastLockoutDate";
            public static string FailedPasswordAttemptCount = @"FailedPasswordAttemptCount";
            public static string FailedPasswordAttemptWindowStart = @"FailedPasswordAttemptWindowStart";
            public static string FailedPasswordAnswerAttemptCount = @"FailedPasswordAnswerAttemptCount";
            public static string FailedPasswordAnswerAttemptWindowStart = @"FailedPasswordAnswerAttemptWindowStart";
            public static string Comment = @"Comment";

        }

    }



    public partial class aspnet_Paths
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "aspnet_Paths" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "aspnet_Paths" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnApplicationId = new TableColumn();
                columnApplicationId.ColumnName = "ApplicationId";
                columnApplicationId.MaxLength = 16;
                columnApplicationId.AutoIncrement = bool.Parse("False");
                columnApplicationId.IsNullable = bool.Parse("False");
                columnApplicationId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnApplicationId);



                TableColumn columnPathId = new TableColumn();
                columnPathId.ColumnName = "PathId";
                columnPathId.MaxLength = 16;
                columnPathId.AutoIncrement = bool.Parse("False");
                columnPathId.IsNullable = bool.Parse("False");
                columnPathId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPathId);



                TableColumn columnPath = new TableColumn();
                columnPath.ColumnName = "Path";
                columnPath.MaxLength = 256;
                columnPath.AutoIncrement = bool.Parse("False");
                columnPath.IsNullable = bool.Parse("False");
                columnPath.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPath);



                TableColumn columnLoweredPath = new TableColumn();
                columnLoweredPath.ColumnName = "LoweredPath";
                columnLoweredPath.MaxLength = 256;
                columnLoweredPath.AutoIncrement = bool.Parse("False");
                columnLoweredPath.IsNullable = bool.Parse("False");
                columnLoweredPath.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnLoweredPath);



                return columnSpecs;

            }

            public static TableColumn ApplicationIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn PathIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn PathColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn LoweredPathColumn
            {
                get
                {
                    return columns[3];
                }
            }



        }

        public struct ColumnNames
        {
            public static string ApplicationId = @"ApplicationId";
            public static string PathId = @"PathId";
            public static string Path = @"Path";
            public static string LoweredPath = @"LoweredPath";

        }

    }



    public partial class aspnet_PersonalizationAllUsers
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "aspnet_PersonalizationAllUsers" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "aspnet_PersonalizationAllUsers" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnPathId = new TableColumn();
                columnPathId.ColumnName = "PathId";
                columnPathId.MaxLength = 16;
                columnPathId.AutoIncrement = bool.Parse("False");
                columnPathId.IsNullable = bool.Parse("False");
                columnPathId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPathId);



                TableColumn columnPageSettings = new TableColumn();
                columnPageSettings.ColumnName = "PageSettings";
                columnPageSettings.MaxLength = 2147483647;
                columnPageSettings.AutoIncrement = bool.Parse("False");
                columnPageSettings.IsNullable = bool.Parse("False");
                columnPageSettings.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPageSettings);



                TableColumn columnLastUpdatedDate = new TableColumn();
                columnLastUpdatedDate.ColumnName = "LastUpdatedDate";
                columnLastUpdatedDate.MaxLength = 8;
                columnLastUpdatedDate.AutoIncrement = bool.Parse("False");
                columnLastUpdatedDate.IsNullable = bool.Parse("False");
                columnLastUpdatedDate.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnLastUpdatedDate);



                return columnSpecs;

            }

            public static TableColumn PathIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn PageSettingsColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn LastUpdatedDateColumn
            {
                get
                {
                    return columns[2];
                }
            }



        }

        public struct ColumnNames
        {
            public static string PathId = @"PathId";
            public static string PageSettings = @"PageSettings";
            public static string LastUpdatedDate = @"LastUpdatedDate";

        }

    }



    public partial class aspnet_PersonalizationPerUser
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "aspnet_PersonalizationPerUser" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "aspnet_PersonalizationPerUser" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnId = new TableColumn();
                columnId.ColumnName = "Id";
                columnId.MaxLength = 16;
                columnId.AutoIncrement = bool.Parse("False");
                columnId.IsNullable = bool.Parse("False");
                columnId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnId);



                TableColumn columnPathId = new TableColumn();
                columnPathId.ColumnName = "PathId";
                columnPathId.MaxLength = 16;
                columnPathId.AutoIncrement = bool.Parse("False");
                columnPathId.IsNullable = bool.Parse("True");
                columnPathId.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnPathId);



                TableColumn columnUserId = new TableColumn();
                columnUserId.ColumnName = "UserId";
                columnUserId.MaxLength = 16;
                columnUserId.AutoIncrement = bool.Parse("False");
                columnUserId.IsNullable = bool.Parse("True");
                columnUserId.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnUserId);



                TableColumn columnPageSettings = new TableColumn();
                columnPageSettings.ColumnName = "PageSettings";
                columnPageSettings.MaxLength = 2147483647;
                columnPageSettings.AutoIncrement = bool.Parse("False");
                columnPageSettings.IsNullable = bool.Parse("False");
                columnPageSettings.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPageSettings);



                TableColumn columnLastUpdatedDate = new TableColumn();
                columnLastUpdatedDate.ColumnName = "LastUpdatedDate";
                columnLastUpdatedDate.MaxLength = 8;
                columnLastUpdatedDate.AutoIncrement = bool.Parse("False");
                columnLastUpdatedDate.IsNullable = bool.Parse("False");
                columnLastUpdatedDate.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnLastUpdatedDate);



                return columnSpecs;

            }

            public static TableColumn IdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn PathIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn UserIdColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn PageSettingsColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn LastUpdatedDateColumn
            {
                get
                {
                    return columns[4];
                }
            }



        }

        public struct ColumnNames
        {
            public static string Id = @"Id";
            public static string PathId = @"PathId";
            public static string UserId = @"UserId";
            public static string PageSettings = @"PageSettings";
            public static string LastUpdatedDate = @"LastUpdatedDate";

        }

    }



    public partial class aspnet_Profile
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "aspnet_Profile" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "aspnet_Profile" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnUserId = new TableColumn();
                columnUserId.ColumnName = "UserId";
                columnUserId.MaxLength = 16;
                columnUserId.AutoIncrement = bool.Parse("False");
                columnUserId.IsNullable = bool.Parse("False");
                columnUserId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnUserId);



                TableColumn columnPropertyNames = new TableColumn();
                columnPropertyNames.ColumnName = "PropertyNames";
                columnPropertyNames.MaxLength = 1073741823;
                columnPropertyNames.AutoIncrement = bool.Parse("False");
                columnPropertyNames.IsNullable = bool.Parse("False");
                columnPropertyNames.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPropertyNames);



                TableColumn columnPropertyValuesString = new TableColumn();
                columnPropertyValuesString.ColumnName = "PropertyValuesString";
                columnPropertyValuesString.MaxLength = 1073741823;
                columnPropertyValuesString.AutoIncrement = bool.Parse("False");
                columnPropertyValuesString.IsNullable = bool.Parse("False");
                columnPropertyValuesString.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPropertyValuesString);



                TableColumn columnPropertyValuesBinary = new TableColumn();
                columnPropertyValuesBinary.ColumnName = "PropertyValuesBinary";
                columnPropertyValuesBinary.MaxLength = 2147483647;
                columnPropertyValuesBinary.AutoIncrement = bool.Parse("False");
                columnPropertyValuesBinary.IsNullable = bool.Parse("False");
                columnPropertyValuesBinary.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPropertyValuesBinary);



                TableColumn columnLastUpdatedDate = new TableColumn();
                columnLastUpdatedDate.ColumnName = "LastUpdatedDate";
                columnLastUpdatedDate.MaxLength = 8;
                columnLastUpdatedDate.AutoIncrement = bool.Parse("False");
                columnLastUpdatedDate.IsNullable = bool.Parse("False");
                columnLastUpdatedDate.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnLastUpdatedDate);



                return columnSpecs;

            }

            public static TableColumn UserIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn PropertyNamesColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn PropertyValuesStringColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn PropertyValuesBinaryColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn LastUpdatedDateColumn
            {
                get
                {
                    return columns[4];
                }
            }



        }

        public struct ColumnNames
        {
            public static string UserId = @"UserId";
            public static string PropertyNames = @"PropertyNames";
            public static string PropertyValuesString = @"PropertyValuesString";
            public static string PropertyValuesBinary = @"PropertyValuesBinary";
            public static string LastUpdatedDate = @"LastUpdatedDate";

        }

    }



    public partial class aspnet_Roles
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "aspnet_Roles" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "aspnet_Roles" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnApplicationId = new TableColumn();
                columnApplicationId.ColumnName = "ApplicationId";
                columnApplicationId.MaxLength = 16;
                columnApplicationId.AutoIncrement = bool.Parse("False");
                columnApplicationId.IsNullable = bool.Parse("False");
                columnApplicationId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnApplicationId);



                TableColumn columnRoleId = new TableColumn();
                columnRoleId.ColumnName = "RoleId";
                columnRoleId.MaxLength = 16;
                columnRoleId.AutoIncrement = bool.Parse("False");
                columnRoleId.IsNullable = bool.Parse("False");
                columnRoleId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnRoleId);



                TableColumn columnRoleName = new TableColumn();
                columnRoleName.ColumnName = "RoleName";
                columnRoleName.MaxLength = 256;
                columnRoleName.AutoIncrement = bool.Parse("False");
                columnRoleName.IsNullable = bool.Parse("False");
                columnRoleName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnRoleName);



                TableColumn columnLoweredRoleName = new TableColumn();
                columnLoweredRoleName.ColumnName = "LoweredRoleName";
                columnLoweredRoleName.MaxLength = 256;
                columnLoweredRoleName.AutoIncrement = bool.Parse("False");
                columnLoweredRoleName.IsNullable = bool.Parse("False");
                columnLoweredRoleName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnLoweredRoleName);



                TableColumn columnDescription = new TableColumn();
                columnDescription.ColumnName = "Description";
                columnDescription.MaxLength = 256;
                columnDescription.AutoIncrement = bool.Parse("False");
                columnDescription.IsNullable = bool.Parse("True");
                columnDescription.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnDescription);



                return columnSpecs;

            }

            public static TableColumn ApplicationIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn RoleIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn RoleNameColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn LoweredRoleNameColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn DescriptionColumn
            {
                get
                {
                    return columns[4];
                }
            }



        }

        public struct ColumnNames
        {
            public static string ApplicationId = @"ApplicationId";
            public static string RoleId = @"RoleId";
            public static string RoleName = @"RoleName";
            public static string LoweredRoleName = @"LoweredRoleName";
            public static string Description = @"Description";

        }

    }



    public partial class aspnet_SchemaVersions
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "aspnet_SchemaVersions" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "aspnet_SchemaVersions" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnFeature = new TableColumn();
                columnFeature.ColumnName = "Feature";
                columnFeature.MaxLength = 128;
                columnFeature.AutoIncrement = bool.Parse("False");
                columnFeature.IsNullable = bool.Parse("False");
                columnFeature.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFeature);



                TableColumn columnCompatibleSchemaVersion = new TableColumn();
                columnCompatibleSchemaVersion.ColumnName = "CompatibleSchemaVersion";
                columnCompatibleSchemaVersion.MaxLength = 128;
                columnCompatibleSchemaVersion.AutoIncrement = bool.Parse("False");
                columnCompatibleSchemaVersion.IsNullable = bool.Parse("False");
                columnCompatibleSchemaVersion.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCompatibleSchemaVersion);



                TableColumn columnIsCurrentVersion = new TableColumn();
                columnIsCurrentVersion.ColumnName = "IsCurrentVersion";
                columnIsCurrentVersion.MaxLength = 1;
                columnIsCurrentVersion.AutoIncrement = bool.Parse("False");
                columnIsCurrentVersion.IsNullable = bool.Parse("False");
                columnIsCurrentVersion.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnIsCurrentVersion);



                return columnSpecs;

            }

            public static TableColumn FeatureColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn CompatibleSchemaVersionColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn IsCurrentVersionColumn
            {
                get
                {
                    return columns[2];
                }
            }



        }

        public struct ColumnNames
        {
            public static string Feature = @"Feature";
            public static string CompatibleSchemaVersion = @"CompatibleSchemaVersion";
            public static string IsCurrentVersion = @"IsCurrentVersion";

        }

    }



    public partial class aspnet_Users
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "aspnet_Users" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "aspnet_Users" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnApplicationId = new TableColumn();
                columnApplicationId.ColumnName = "ApplicationId";
                columnApplicationId.MaxLength = 16;
                columnApplicationId.AutoIncrement = bool.Parse("False");
                columnApplicationId.IsNullable = bool.Parse("False");
                columnApplicationId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnApplicationId);



                TableColumn columnUserId = new TableColumn();
                columnUserId.ColumnName = "UserId";
                columnUserId.MaxLength = 16;
                columnUserId.AutoIncrement = bool.Parse("False");
                columnUserId.IsNullable = bool.Parse("False");
                columnUserId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnUserId);



                TableColumn columnUserName = new TableColumn();
                columnUserName.ColumnName = "UserName";
                columnUserName.MaxLength = 256;
                columnUserName.AutoIncrement = bool.Parse("False");
                columnUserName.IsNullable = bool.Parse("False");
                columnUserName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnUserName);



                TableColumn columnLoweredUserName = new TableColumn();
                columnLoweredUserName.ColumnName = "LoweredUserName";
                columnLoweredUserName.MaxLength = 256;
                columnLoweredUserName.AutoIncrement = bool.Parse("False");
                columnLoweredUserName.IsNullable = bool.Parse("False");
                columnLoweredUserName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnLoweredUserName);



                TableColumn columnMobileAlias = new TableColumn();
                columnMobileAlias.ColumnName = "MobileAlias";
                columnMobileAlias.MaxLength = 16;
                columnMobileAlias.AutoIncrement = bool.Parse("False");
                columnMobileAlias.IsNullable = bool.Parse("True");
                columnMobileAlias.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnMobileAlias);



                TableColumn columnIsAnonymous = new TableColumn();
                columnIsAnonymous.ColumnName = "IsAnonymous";
                columnIsAnonymous.MaxLength = 1;
                columnIsAnonymous.AutoIncrement = bool.Parse("False");
                columnIsAnonymous.IsNullable = bool.Parse("False");
                columnIsAnonymous.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnIsAnonymous);



                TableColumn columnLastActivityDate = new TableColumn();
                columnLastActivityDate.ColumnName = "LastActivityDate";
                columnLastActivityDate.MaxLength = 8;
                columnLastActivityDate.AutoIncrement = bool.Parse("False");
                columnLastActivityDate.IsNullable = bool.Parse("False");
                columnLastActivityDate.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnLastActivityDate);



                return columnSpecs;

            }

            public static TableColumn ApplicationIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn UserIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn UserNameColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn LoweredUserNameColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn MobileAliasColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn IsAnonymousColumn
            {
                get
                {
                    return columns[5];
                }
            }

            public static TableColumn LastActivityDateColumn
            {
                get
                {
                    return columns[6];
                }
            }



        }

        public struct ColumnNames
        {
            public static string ApplicationId = @"ApplicationId";
            public static string UserId = @"UserId";
            public static string UserName = @"UserName";
            public static string LoweredUserName = @"LoweredUserName";
            public static string MobileAlias = @"MobileAlias";
            public static string IsAnonymous = @"IsAnonymous";
            public static string LastActivityDate = @"LastActivityDate";

        }

    }



    public partial class aspnet_UsersInRoles
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "aspnet_UsersInRoles" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "aspnet_UsersInRoles" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnUserId = new TableColumn();
                columnUserId.ColumnName = "UserId";
                columnUserId.MaxLength = 16;
                columnUserId.AutoIncrement = bool.Parse("False");
                columnUserId.IsNullable = bool.Parse("False");
                columnUserId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnUserId);



                TableColumn columnRoleId = new TableColumn();
                columnRoleId.ColumnName = "RoleId";
                columnRoleId.MaxLength = 16;
                columnRoleId.AutoIncrement = bool.Parse("False");
                columnRoleId.IsNullable = bool.Parse("False");
                columnRoleId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnRoleId);



                return columnSpecs;

            }

            public static TableColumn UserIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn RoleIdColumn
            {
                get
                {
                    return columns[1];
                }
            }



        }

        public struct ColumnNames
        {
            public static string UserId = @"UserId";
            public static string RoleId = @"RoleId";

        }

    }



    public partial class aspnet_WebEvent_Events
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "aspnet_WebEvent_Events" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "aspnet_WebEvent_Events" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnEventId = new TableColumn();
                columnEventId.ColumnName = "EventId";
                columnEventId.MaxLength = 32;
                columnEventId.AutoIncrement = bool.Parse("False");
                columnEventId.IsNullable = bool.Parse("False");
                columnEventId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnEventId);



                TableColumn columnEventTimeUtc = new TableColumn();
                columnEventTimeUtc.ColumnName = "EventTimeUtc";
                columnEventTimeUtc.MaxLength = 8;
                columnEventTimeUtc.AutoIncrement = bool.Parse("False");
                columnEventTimeUtc.IsNullable = bool.Parse("False");
                columnEventTimeUtc.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnEventTimeUtc);



                TableColumn columnEventTime = new TableColumn();
                columnEventTime.ColumnName = "EventTime";
                columnEventTime.MaxLength = 8;
                columnEventTime.AutoIncrement = bool.Parse("False");
                columnEventTime.IsNullable = bool.Parse("False");
                columnEventTime.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnEventTime);



                TableColumn columnEventType = new TableColumn();
                columnEventType.ColumnName = "EventType";
                columnEventType.MaxLength = 256;
                columnEventType.AutoIncrement = bool.Parse("False");
                columnEventType.IsNullable = bool.Parse("False");
                columnEventType.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnEventType);



                TableColumn columnEventSequence = new TableColumn();
                columnEventSequence.ColumnName = "EventSequence";
                columnEventSequence.MaxLength = 17;
                columnEventSequence.AutoIncrement = bool.Parse("False");
                columnEventSequence.IsNullable = bool.Parse("False");
                columnEventSequence.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnEventSequence);



                TableColumn columnEventOccurrence = new TableColumn();
                columnEventOccurrence.ColumnName = "EventOccurrence";
                columnEventOccurrence.MaxLength = 17;
                columnEventOccurrence.AutoIncrement = bool.Parse("False");
                columnEventOccurrence.IsNullable = bool.Parse("False");
                columnEventOccurrence.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnEventOccurrence);



                TableColumn columnEventCode = new TableColumn();
                columnEventCode.ColumnName = "EventCode";
                columnEventCode.MaxLength = 4;
                columnEventCode.AutoIncrement = bool.Parse("False");
                columnEventCode.IsNullable = bool.Parse("False");
                columnEventCode.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnEventCode);



                TableColumn columnEventDetailCode = new TableColumn();
                columnEventDetailCode.ColumnName = "EventDetailCode";
                columnEventDetailCode.MaxLength = 4;
                columnEventDetailCode.AutoIncrement = bool.Parse("False");
                columnEventDetailCode.IsNullable = bool.Parse("False");
                columnEventDetailCode.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnEventDetailCode);



                TableColumn columnMessage = new TableColumn();
                columnMessage.ColumnName = "Message";
                columnMessage.MaxLength = 1024;
                columnMessage.AutoIncrement = bool.Parse("False");
                columnMessage.IsNullable = bool.Parse("True");
                columnMessage.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnMessage);



                TableColumn columnApplicationPath = new TableColumn();
                columnApplicationPath.ColumnName = "ApplicationPath";
                columnApplicationPath.MaxLength = 256;
                columnApplicationPath.AutoIncrement = bool.Parse("False");
                columnApplicationPath.IsNullable = bool.Parse("True");
                columnApplicationPath.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnApplicationPath);



                TableColumn columnApplicationVirtualPath = new TableColumn();
                columnApplicationVirtualPath.ColumnName = "ApplicationVirtualPath";
                columnApplicationVirtualPath.MaxLength = 256;
                columnApplicationVirtualPath.AutoIncrement = bool.Parse("False");
                columnApplicationVirtualPath.IsNullable = bool.Parse("True");
                columnApplicationVirtualPath.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnApplicationVirtualPath);



                TableColumn columnMachineName = new TableColumn();
                columnMachineName.ColumnName = "MachineName";
                columnMachineName.MaxLength = 256;
                columnMachineName.AutoIncrement = bool.Parse("False");
                columnMachineName.IsNullable = bool.Parse("False");
                columnMachineName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnMachineName);



                TableColumn columnRequestUrl = new TableColumn();
                columnRequestUrl.ColumnName = "RequestUrl";
                columnRequestUrl.MaxLength = 1024;
                columnRequestUrl.AutoIncrement = bool.Parse("False");
                columnRequestUrl.IsNullable = bool.Parse("True");
                columnRequestUrl.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnRequestUrl);



                TableColumn columnExceptionType = new TableColumn();
                columnExceptionType.ColumnName = "ExceptionType";
                columnExceptionType.MaxLength = 256;
                columnExceptionType.AutoIncrement = bool.Parse("False");
                columnExceptionType.IsNullable = bool.Parse("True");
                columnExceptionType.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnExceptionType);



                TableColumn columnDetails = new TableColumn();
                columnDetails.ColumnName = "Details";
                columnDetails.MaxLength = 1073741823;
                columnDetails.AutoIncrement = bool.Parse("False");
                columnDetails.IsNullable = bool.Parse("True");
                columnDetails.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnDetails);



                return columnSpecs;

            }

            public static TableColumn EventIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn EventTimeUtcColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn EventTimeColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn EventTypeColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn EventSequenceColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn EventOccurrenceColumn
            {
                get
                {
                    return columns[5];
                }
            }

            public static TableColumn EventCodeColumn
            {
                get
                {
                    return columns[6];
                }
            }

            public static TableColumn EventDetailCodeColumn
            {
                get
                {
                    return columns[7];
                }
            }

            public static TableColumn MessageColumn
            {
                get
                {
                    return columns[8];
                }
            }

            public static TableColumn ApplicationPathColumn
            {
                get
                {
                    return columns[9];
                }
            }

            public static TableColumn ApplicationVirtualPathColumn
            {
                get
                {
                    return columns[10];
                }
            }

            public static TableColumn MachineNameColumn
            {
                get
                {
                    return columns[11];
                }
            }

            public static TableColumn RequestUrlColumn
            {
                get
                {
                    return columns[12];
                }
            }

            public static TableColumn ExceptionTypeColumn
            {
                get
                {
                    return columns[13];
                }
            }

            public static TableColumn DetailsColumn
            {
                get
                {
                    return columns[14];
                }
            }



        }

        public struct ColumnNames
        {
            public static string EventId = @"EventId";
            public static string EventTimeUtc = @"EventTimeUtc";
            public static string EventTime = @"EventTime";
            public static string EventType = @"EventType";
            public static string EventSequence = @"EventSequence";
            public static string EventOccurrence = @"EventOccurrence";
            public static string EventCode = @"EventCode";
            public static string EventDetailCode = @"EventDetailCode";
            public static string Message = @"Message";
            public static string ApplicationPath = @"ApplicationPath";
            public static string ApplicationVirtualPath = @"ApplicationVirtualPath";
            public static string MachineName = @"MachineName";
            public static string RequestUrl = @"RequestUrl";
            public static string ExceptionType = @"ExceptionType";
            public static string Details = @"Details";

        }

    }



    public partial class Guest
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Guest" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Guest" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnGuestId = new TableColumn();
                columnGuestId.ColumnName = "GuestId";
                columnGuestId.MaxLength = 4;
                columnGuestId.AutoIncrement = bool.Parse("True");
                columnGuestId.IsNullable = bool.Parse("False");
                columnGuestId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnGuestId);



                TableColumn columnName = new TableColumn();
                columnName.ColumnName = "Name";
                columnName.MaxLength = 100;
                columnName.AutoIncrement = bool.Parse("False");
                columnName.IsNullable = bool.Parse("False");
                columnName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnName);



                TableColumn columnUserId = new TableColumn();
                columnUserId.ColumnName = "UserId";
                columnUserId.MaxLength = 16;
                columnUserId.AutoIncrement = bool.Parse("False");
                columnUserId.IsNullable = bool.Parse("False");
                columnUserId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnUserId);



                TableColumn columnSendPublicity = new TableColumn();
                columnSendPublicity.ColumnName = "SendPublicity";
                columnSendPublicity.MaxLength = 1;
                columnSendPublicity.AutoIncrement = bool.Parse("False");
                columnSendPublicity.IsNullable = bool.Parse("False");
                columnSendPublicity.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnSendPublicity);



                TableColumn columnCity = new TableColumn();
                columnCity.ColumnName = "City";
                columnCity.MaxLength = 50;
                columnCity.AutoIncrement = bool.Parse("False");
                columnCity.IsNullable = bool.Parse("True");
                columnCity.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnCity);



                TableColumn columnAge = new TableColumn();
                columnAge.ColumnName = "Age";
                columnAge.MaxLength = 2;
                columnAge.AutoIncrement = bool.Parse("False");
                columnAge.IsNullable = bool.Parse("True");
                columnAge.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnAge);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                return columnSpecs;

            }

            public static TableColumn GuestIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn NameColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn UserIdColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn SendPublicityColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn CityColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn AgeColumn
            {
                get
                {
                    return columns[5];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[6];
                }
            }



        }

        public struct ColumnNames
        {
            public static string GuestId = @"GuestId";
            public static string Name = @"Name";
            public static string UserId = @"UserId";
            public static string SendPublicity = @"SendPublicity";
            public static string City = @"City";
            public static string Age = @"Age";
            public static string Deleted = @"Deleted";

        }

    }

    public class TableColumn
    {
        public string ColumnName { get; set; }

        public int MaxLength { get; set; }

        public bool AutoIncrement { get; set; }

        public bool IsNullable { get; set; }

        public bool IsPrimaryKey { get; set; }

        public bool IsForeignKey { get; set; }

        public string ForeignKeyTableName { get; set; }
    }

    public class TableInfo
    {
        public string TableName { get; set; }
    }


}
