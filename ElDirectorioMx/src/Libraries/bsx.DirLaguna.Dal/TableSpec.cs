
using System.Collections.Generic;


namespace bsx.DirLaguna.Dal
{

    public partial class AccountConcept
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "AccountConcept" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "AccountConcept" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnAccountConceptId = new TableColumn();
                columnAccountConceptId.ColumnName = "AccountConceptId";
                columnAccountConceptId.MaxLength = 4;
                columnAccountConceptId.AutoIncrement = bool.Parse("True");
                columnAccountConceptId.IsNullable = bool.Parse("False");
                columnAccountConceptId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAccountConceptId);



                TableColumn columnConceptKey = new TableColumn();
                columnConceptKey.ColumnName = "ConceptKey";
                columnConceptKey.MaxLength = 150;
                columnConceptKey.AutoIncrement = bool.Parse("False");
                columnConceptKey.IsNullable = bool.Parse("False");
                columnConceptKey.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnConceptKey);



                TableColumn columnGorilaId = new TableColumn();
                columnGorilaId.ColumnName = "GorilaId";
                columnGorilaId.MaxLength = 4;
                columnGorilaId.AutoIncrement = bool.Parse("False");
                columnGorilaId.IsNullable = bool.Parse("True");
                columnGorilaId.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnGorilaId);



                TableColumn columnTotalMax = new TableColumn();
                columnTotalMax.ColumnName = "TotalMax";
                columnTotalMax.MaxLength = 4;
                columnTotalMax.AutoIncrement = bool.Parse("False");
                columnTotalMax.IsNullable = bool.Parse("False");
                columnTotalMax.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnTotalMax);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                TableColumn columnMinValue = new TableColumn();
                columnMinValue.ColumnName = "MinValue";
                columnMinValue.MaxLength = 4;
                columnMinValue.AutoIncrement = bool.Parse("False");
                columnMinValue.IsNullable = bool.Parse("False");
                columnMinValue.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnMinValue);



                TableColumn columnDescription = new TableColumn();
                columnDescription.ColumnName = "Description";
                columnDescription.MaxLength = 500;
                columnDescription.AutoIncrement = bool.Parse("False");
                columnDescription.IsNullable = bool.Parse("True");
                columnDescription.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnDescription);



                return columnSpecs;

            }

            public static TableColumn AccountConceptIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn ConceptKeyColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn GorilaIdColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn TotalMaxColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn MinValueColumn
            {
                get
                {
                    return columns[5];
                }
            }

            public static TableColumn DescriptionColumn
            {
                get
                {
                    return columns[6];
                }
            }



        }

        public struct ColumnNames
        {
            public static string AccountConceptId = @"AccountConceptId";
            public static string ConceptKey = @"ConceptKey";
            public static string GorilaId = @"GorilaId";
            public static string TotalMax = @"TotalMax";
            public static string Deleted = @"Deleted";
            public static string MinValue = @"MinValue";
            public static string Description = @"Description";

        }

    }



    public partial class AccountDetail
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "AccountDetail" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "AccountDetail" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnAccountDetailId = new TableColumn();
                columnAccountDetailId.ColumnName = "AccountDetailId";
                columnAccountDetailId.MaxLength = 4;
                columnAccountDetailId.AutoIncrement = bool.Parse("True");
                columnAccountDetailId.IsNullable = bool.Parse("False");
                columnAccountDetailId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAccountDetailId);



                TableColumn columnContractId = new TableColumn();
                columnContractId.ColumnName = "ContractId";
                columnContractId.MaxLength = 4;
                columnContractId.AutoIncrement = bool.Parse("False");
                columnContractId.IsNullable = bool.Parse("False");
                columnContractId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnContractId);



                TableColumn columnAccountConceptId = new TableColumn();
                columnAccountConceptId.ColumnName = "AccountConceptId";
                columnAccountConceptId.MaxLength = 4;
                columnAccountConceptId.AutoIncrement = bool.Parse("False");
                columnAccountConceptId.IsNullable = bool.Parse("False");
                columnAccountConceptId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAccountConceptId);



                TableColumn columnQuantity = new TableColumn();
                columnQuantity.ColumnName = "Quantity";
                columnQuantity.MaxLength = 4;
                columnQuantity.AutoIncrement = bool.Parse("False");
                columnQuantity.IsNullable = bool.Parse("False");
                columnQuantity.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnQuantity);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                TableColumn columnAdvertiserId = new TableColumn();
                columnAdvertiserId.ColumnName = "AdvertiserId";
                columnAdvertiserId.MaxLength = 4;
                columnAdvertiserId.AutoIncrement = bool.Parse("False");
                columnAdvertiserId.IsNullable = bool.Parse("False");
                columnAdvertiserId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAdvertiserId);



                return columnSpecs;

            }

            public static TableColumn AccountDetailIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn ContractIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn AccountConceptIdColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn QuantityColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn AdvertiserIdColumn
            {
                get
                {
                    return columns[5];
                }
            }



        }

        public struct ColumnNames
        {
            public static string AccountDetailId = @"AccountDetailId";
            public static string ContractId = @"ContractId";
            public static string AccountConceptId = @"AccountConceptId";
            public static string Quantity = @"Quantity";
            public static string Deleted = @"Deleted";
            public static string AdvertiserId = @"AdvertiserId";

        }

    }



    public partial class Advertiser
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Advertiser" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Advertiser" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnAdvertiserId = new TableColumn();
                columnAdvertiserId.ColumnName = "AdvertiserId";
                columnAdvertiserId.MaxLength = 4;
                columnAdvertiserId.AutoIncrement = bool.Parse("True");
                columnAdvertiserId.IsNullable = bool.Parse("False");
                columnAdvertiserId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAdvertiserId);



                TableColumn columnUserId = new TableColumn();
                columnUserId.ColumnName = "UserId";
                columnUserId.MaxLength = 16;
                columnUserId.AutoIncrement = bool.Parse("False");
                columnUserId.IsNullable = bool.Parse("False");
                columnUserId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnUserId);



                TableColumn columnCityId = new TableColumn();
                columnCityId.ColumnName = "CityId";
                columnCityId.MaxLength = 4;
                columnCityId.AutoIncrement = bool.Parse("False");
                columnCityId.IsNullable = bool.Parse("False");
                columnCityId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCityId);



                TableColumn columnName = new TableColumn();
                columnName.ColumnName = "Name";
                columnName.MaxLength = 100;
                columnName.AutoIncrement = bool.Parse("False");
                columnName.IsNullable = bool.Parse("False");
                columnName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnName);



                TableColumn columnDescription = new TableColumn();
                columnDescription.ColumnName = "Description";
                columnDescription.MaxLength = 200;
                columnDescription.AutoIncrement = bool.Parse("False");
                columnDescription.IsNullable = bool.Parse("False");
                columnDescription.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDescription);



                TableColumn columnAddress = new TableColumn();
                columnAddress.ColumnName = "Address";
                columnAddress.MaxLength = 200;
                columnAddress.AutoIncrement = bool.Parse("False");
                columnAddress.IsNullable = bool.Parse("False");
                columnAddress.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAddress);



                TableColumn columnContact = new TableColumn();
                columnContact.ColumnName = "Contact";
                columnContact.MaxLength = 50;
                columnContact.AutoIncrement = bool.Parse("False");
                columnContact.IsNullable = bool.Parse("True");
                columnContact.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnContact);



                TableColumn columnWebPage = new TableColumn();
                columnWebPage.ColumnName = "WebPage";
                columnWebPage.MaxLength = 100;
                columnWebPage.AutoIncrement = bool.Parse("False");
                columnWebPage.IsNullable = bool.Parse("True");
                columnWebPage.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnWebPage);



                TableColumn columnTags = new TableColumn();
                columnTags.ColumnName = "Tags";
                columnTags.MaxLength = 500;
                columnTags.AutoIncrement = bool.Parse("False");
                columnTags.IsNullable = bool.Parse("True");
                columnTags.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnTags);



                TableColumn columnFacebook = new TableColumn();
                columnFacebook.ColumnName = "Facebook";
                columnFacebook.MaxLength = 100;
                columnFacebook.AutoIncrement = bool.Parse("False");
                columnFacebook.IsNullable = bool.Parse("True");
                columnFacebook.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnFacebook);



                TableColumn columnTwitter = new TableColumn();
                columnTwitter.ColumnName = "Twitter";
                columnTwitter.MaxLength = 40;
                columnTwitter.AutoIncrement = bool.Parse("False");
                columnTwitter.IsNullable = bool.Parse("True");
                columnTwitter.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnTwitter);



                TableColumn columnMapReferenceX = new TableColumn();
                columnMapReferenceX.ColumnName = "MapReferenceX";
                columnMapReferenceX.MaxLength = 8;
                columnMapReferenceX.AutoIncrement = bool.Parse("False");
                columnMapReferenceX.IsNullable = bool.Parse("True");
                columnMapReferenceX.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnMapReferenceX);



                TableColumn columnMapReferenceY = new TableColumn();
                columnMapReferenceY.ColumnName = "MapReferenceY";
                columnMapReferenceY.MaxLength = 8;
                columnMapReferenceY.AutoIncrement = bool.Parse("False");
                columnMapReferenceY.IsNullable = bool.Parse("True");
                columnMapReferenceY.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnMapReferenceY);



                TableColumn columnCreatedOn = new TableColumn();
                columnCreatedOn.ColumnName = "CreatedOn";
                columnCreatedOn.MaxLength = 8;
                columnCreatedOn.AutoIncrement = bool.Parse("False");
                columnCreatedOn.IsNullable = bool.Parse("False");
                columnCreatedOn.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCreatedOn);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                TableColumn columnModifiedOn = new TableColumn();
                columnModifiedOn.ColumnName = "ModifiedOn";
                columnModifiedOn.MaxLength = 8;
                columnModifiedOn.AutoIncrement = bool.Parse("False");
                columnModifiedOn.IsNullable = bool.Parse("True");
                columnModifiedOn.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnModifiedOn);



                TableColumn columnPriority = new TableColumn();
                columnPriority.ColumnName = "Priority";
                columnPriority.MaxLength = 4;
                columnPriority.AutoIncrement = bool.Parse("False");
                columnPriority.IsNullable = bool.Parse("False");
                columnPriority.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPriority);



                TableColumn columnAditionalInfo = new TableColumn();
                columnAditionalInfo.ColumnName = "AditionalInfo";
                columnAditionalInfo.MaxLength = 2147483647;
                columnAditionalInfo.AutoIncrement = bool.Parse("False");
                columnAditionalInfo.IsNullable = bool.Parse("True");
                columnAditionalInfo.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnAditionalInfo);



                TableColumn columnFranchiseeId = new TableColumn();
                columnFranchiseeId.ColumnName = "FranchiseeId";
                columnFranchiseeId.MaxLength = 4;
                columnFranchiseeId.AutoIncrement = bool.Parse("False");
                columnFranchiseeId.IsNullable = bool.Parse("False");
                columnFranchiseeId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFranchiseeId);



                TableColumn columnPersonalId = new TableColumn();
                columnPersonalId.ColumnName = "PersonalId";
                columnPersonalId.MaxLength = 4;
                columnPersonalId.AutoIncrement = bool.Parse("False");
                columnPersonalId.IsNullable = bool.Parse("False");
                columnPersonalId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPersonalId);



                TableColumn columnUserCreatedOn = new TableColumn();
                columnUserCreatedOn.ColumnName = "UserCreatedOn";
                columnUserCreatedOn.MaxLength = 4;
                columnUserCreatedOn.AutoIncrement = bool.Parse("False");
                columnUserCreatedOn.IsNullable = bool.Parse("True");
                columnUserCreatedOn.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnUserCreatedOn);



                TableColumn columnUserModifiedOn = new TableColumn();
                columnUserModifiedOn.ColumnName = "UserModifiedOn";
                columnUserModifiedOn.MaxLength = 4;
                columnUserModifiedOn.AutoIncrement = bool.Parse("False");
                columnUserModifiedOn.IsNullable = bool.Parse("True");
                columnUserModifiedOn.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnUserModifiedOn);



                TableColumn columnFiscalDetailId = new TableColumn();
                columnFiscalDetailId.ColumnName = "FiscalDetailId";
                columnFiscalDetailId.MaxLength = 4;
                columnFiscalDetailId.AutoIncrement = bool.Parse("False");
                columnFiscalDetailId.IsNullable = bool.Parse("True");
                columnFiscalDetailId.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnFiscalDetailId);



                TableColumn columnEndDate = new TableColumn();
                columnEndDate.ColumnName = "EndDate";
                columnEndDate.MaxLength = 8;
                columnEndDate.AutoIncrement = bool.Parse("False");
                columnEndDate.IsNullable = bool.Parse("True");
                columnEndDate.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnEndDate);



                TableColumn columnStartDate = new TableColumn();
                columnStartDate.ColumnName = "StartDate";
                columnStartDate.MaxLength = 8;
                columnStartDate.AutoIncrement = bool.Parse("False");
                columnStartDate.IsNullable = bool.Parse("True");
                columnStartDate.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnStartDate);



                TableColumn columnEstadoId = new TableColumn();
                columnEstadoId.ColumnName = "EstadoId";
                columnEstadoId.MaxLength = 4;
                columnEstadoId.AutoIncrement = bool.Parse("False");
                columnEstadoId.IsNullable = bool.Parse("False");
                columnEstadoId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnEstadoId);



                TableColumn columnMunicipioId = new TableColumn();
                columnMunicipioId.ColumnName = "MunicipioId";
                columnMunicipioId.MaxLength = 4;
                columnMunicipioId.AutoIncrement = bool.Parse("False");
                columnMunicipioId.IsNullable = bool.Parse("False");
                columnMunicipioId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnMunicipioId);



                TableColumn columnExternalKey = new TableColumn();
                columnExternalKey.ColumnName = "ExternalKey";
                columnExternalKey.MaxLength = 4;
                columnExternalKey.AutoIncrement = bool.Parse("False");
                columnExternalKey.IsNullable = bool.Parse("True");
                columnExternalKey.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnExternalKey);



                TableColumn columnNumberKey = new TableColumn();
                columnNumberKey.ColumnName = "NumberKey";
                columnNumberKey.MaxLength = 10;
                columnNumberKey.AutoIncrement = bool.Parse("False");
                columnNumberKey.IsNullable = bool.Parse("True");
                columnNumberKey.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnNumberKey);



                TableColumn columnDV = new TableColumn();
                columnDV.ColumnName = "DV";
                columnDV.MaxLength = 5;
                columnDV.AutoIncrement = bool.Parse("False");
                columnDV.IsNullable = bool.Parse("True");
                columnDV.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnDV);



                TableColumn columnYoutubeVideo = new TableColumn();
                columnYoutubeVideo.ColumnName = "YoutubeVideo";
                columnYoutubeVideo.MaxLength = 1024;
                columnYoutubeVideo.AutoIncrement = bool.Parse("False");
                columnYoutubeVideo.IsNullable = bool.Parse("True");
                columnYoutubeVideo.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnYoutubeVideo);



                return columnSpecs;

            }

            public static TableColumn AdvertiserIdColumn
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

            public static TableColumn CityIdColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn NameColumn
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

            public static TableColumn AddressColumn
            {
                get
                {
                    return columns[5];
                }
            }

            public static TableColumn ContactColumn
            {
                get
                {
                    return columns[6];
                }
            }

            public static TableColumn WebPageColumn
            {
                get
                {
                    return columns[7];
                }
            }

            public static TableColumn TagsColumn
            {
                get
                {
                    return columns[8];
                }
            }

            public static TableColumn FacebookColumn
            {
                get
                {
                    return columns[9];
                }
            }

            public static TableColumn TwitterColumn
            {
                get
                {
                    return columns[10];
                }
            }

            public static TableColumn MapReferenceXColumn
            {
                get
                {
                    return columns[11];
                }
            }

            public static TableColumn MapReferenceYColumn
            {
                get
                {
                    return columns[12];
                }
            }

            public static TableColumn CreatedOnColumn
            {
                get
                {
                    return columns[13];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[14];
                }
            }

            public static TableColumn ModifiedOnColumn
            {
                get
                {
                    return columns[15];
                }
            }

            public static TableColumn PriorityColumn
            {
                get
                {
                    return columns[16];
                }
            }

            public static TableColumn AditionalInfoColumn
            {
                get
                {
                    return columns[17];
                }
            }

            public static TableColumn FranchiseeIdColumn
            {
                get
                {
                    return columns[18];
                }
            }

            public static TableColumn PersonalIdColumn
            {
                get
                {
                    return columns[19];
                }
            }

            public static TableColumn UserCreatedOnColumn
            {
                get
                {
                    return columns[20];
                }
            }

            public static TableColumn UserModifiedOnColumn
            {
                get
                {
                    return columns[21];
                }
            }

            public static TableColumn FiscalDetailIdColumn
            {
                get
                {
                    return columns[22];
                }
            }

            public static TableColumn EndDateColumn
            {
                get
                {
                    return columns[23];
                }
            }

            public static TableColumn StartDateColumn
            {
                get
                {
                    return columns[24];
                }
            }

            public static TableColumn EstadoIdColumn
            {
                get
                {
                    return columns[25];
                }
            }

            public static TableColumn MunicipioIdColumn
            {
                get
                {
                    return columns[26];
                }
            }

            public static TableColumn ExternalKeyColumn
            {
                get
                {
                    return columns[27];
                }
            }

            public static TableColumn NumberKeyColumn
            {
                get
                {
                    return columns[28];
                }
            }

            public static TableColumn DVColumn
            {
                get
                {
                    return columns[29];
                }
            }

            public static TableColumn YoutubeVideoColumn
            {
                get
                {
                    return columns[30];
                }
            }



        }

        public struct ColumnNames
        {
            public static string AdvertiserId = @"AdvertiserId";
            public static string UserId = @"UserId";
            public static string CityId = @"CityId";
            public static string Name = @"Name";
            public static string Description = @"Description";
            public static string Address = @"Address";
            public static string Contact = @"Contact";
            public static string WebPage = @"WebPage";
            public static string Tags = @"Tags";
            public static string Facebook = @"Facebook";
            public static string Twitter = @"Twitter";
            public static string MapReferenceX = @"MapReferenceX";
            public static string MapReferenceY = @"MapReferenceY";
            public static string CreatedOn = @"CreatedOn";
            public static string Deleted = @"Deleted";
            public static string ModifiedOn = @"ModifiedOn";
            public static string Priority = @"Priority";
            public static string AditionalInfo = @"AditionalInfo";
            public static string FranchiseeId = @"FranchiseeId";
            public static string PersonalId = @"PersonalId";
            public static string UserCreatedOn = @"UserCreatedOn";
            public static string UserModifiedOn = @"UserModifiedOn";
            public static string FiscalDetailId = @"FiscalDetailId";
            public static string EndDate = @"EndDate";
            public static string StartDate = @"StartDate";
            public static string EstadoId = @"EstadoId";
            public static string MunicipioId = @"MunicipioId";
            public static string ExternalKey = @"ExternalKey";
            public static string NumberKey = @"NumberKey";
            public static string DV = @"DV";
            public static string YoutubeVideo = @"YoutubeVideo";

        }

    }



    public partial class AdvertiserCategory
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "AdvertiserCategory" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "AdvertiserCategory" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnAdvertiserCategoryId = new TableColumn();
                columnAdvertiserCategoryId.ColumnName = "AdvertiserCategoryId";
                columnAdvertiserCategoryId.MaxLength = 4;
                columnAdvertiserCategoryId.AutoIncrement = bool.Parse("True");
                columnAdvertiserCategoryId.IsNullable = bool.Parse("False");
                columnAdvertiserCategoryId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAdvertiserCategoryId);



                TableColumn columnCategoryId = new TableColumn();
                columnCategoryId.ColumnName = "CategoryId";
                columnCategoryId.MaxLength = 4;
                columnCategoryId.AutoIncrement = bool.Parse("False");
                columnCategoryId.IsNullable = bool.Parse("False");
                columnCategoryId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCategoryId);



                TableColumn columnAdvertiserId = new TableColumn();
                columnAdvertiserId.ColumnName = "AdvertiserId";
                columnAdvertiserId.MaxLength = 4;
                columnAdvertiserId.AutoIncrement = bool.Parse("False");
                columnAdvertiserId.IsNullable = bool.Parse("False");
                columnAdvertiserId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAdvertiserId);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                TableColumn columnFranchiseeId = new TableColumn();
                columnFranchiseeId.ColumnName = "FranchiseeId";
                columnFranchiseeId.MaxLength = 4;
                columnFranchiseeId.AutoIncrement = bool.Parse("False");
                columnFranchiseeId.IsNullable = bool.Parse("False");
                columnFranchiseeId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFranchiseeId);



                TableColumn columnCreatedOn = new TableColumn();
                columnCreatedOn.ColumnName = "CreatedOn";
                columnCreatedOn.MaxLength = 8;
                columnCreatedOn.AutoIncrement = bool.Parse("False");
                columnCreatedOn.IsNullable = bool.Parse("False");
                columnCreatedOn.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCreatedOn);



                return columnSpecs;

            }

            public static TableColumn AdvertiserCategoryIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn CategoryIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn AdvertiserIdColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn FranchiseeIdColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn CreatedOnColumn
            {
                get
                {
                    return columns[5];
                }
            }



        }

        public struct ColumnNames
        {
            public static string AdvertiserCategoryId = @"AdvertiserCategoryId";
            public static string CategoryId = @"CategoryId";
            public static string AdvertiserId = @"AdvertiserId";
            public static string Deleted = @"Deleted";
            public static string FranchiseeId = @"FranchiseeId";
            public static string CreatedOn = @"CreatedOn";

        }

    }



    public partial class Announce
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Announce" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Announce" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnAnnounceId = new TableColumn();
                columnAnnounceId.ColumnName = "AnnounceId";
                columnAnnounceId.MaxLength = 4;
                columnAnnounceId.AutoIncrement = bool.Parse("True");
                columnAnnounceId.IsNullable = bool.Parse("False");
                columnAnnounceId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAnnounceId);



                TableColumn columnAdvertiserId = new TableColumn();
                columnAdvertiserId.ColumnName = "AdvertiserId";
                columnAdvertiserId.MaxLength = 4;
                columnAdvertiserId.AutoIncrement = bool.Parse("False");
                columnAdvertiserId.IsNullable = bool.Parse("False");
                columnAdvertiserId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAdvertiserId);



                TableColumn columnPageId = new TableColumn();
                columnPageId.ColumnName = "PageId";
                columnPageId.MaxLength = 4;
                columnPageId.AutoIncrement = bool.Parse("False");
                columnPageId.IsNullable = bool.Parse("False");
                columnPageId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPageId);



                TableColumn columnCreatedOn = new TableColumn();
                columnCreatedOn.ColumnName = "CreatedOn";
                columnCreatedOn.MaxLength = 8;
                columnCreatedOn.AutoIncrement = bool.Parse("False");
                columnCreatedOn.IsNullable = bool.Parse("False");
                columnCreatedOn.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCreatedOn);



                TableColumn columnModifiedOn = new TableColumn();
                columnModifiedOn.ColumnName = "ModifiedOn";
                columnModifiedOn.MaxLength = 8;
                columnModifiedOn.AutoIncrement = bool.Parse("False");
                columnModifiedOn.IsNullable = bool.Parse("True");
                columnModifiedOn.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnModifiedOn);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                TableColumn columnFranchiseeId = new TableColumn();
                columnFranchiseeId.ColumnName = "FranchiseeId";
                columnFranchiseeId.MaxLength = 4;
                columnFranchiseeId.AutoIncrement = bool.Parse("False");
                columnFranchiseeId.IsNullable = bool.Parse("False");
                columnFranchiseeId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFranchiseeId);



                return columnSpecs;

            }

            public static TableColumn AnnounceIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn AdvertiserIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn PageIdColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn CreatedOnColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn ModifiedOnColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[5];
                }
            }

            public static TableColumn FranchiseeIdColumn
            {
                get
                {
                    return columns[6];
                }
            }



        }

        public struct ColumnNames
        {
            public static string AnnounceId = @"AnnounceId";
            public static string AdvertiserId = @"AdvertiserId";
            public static string PageId = @"PageId";
            public static string CreatedOn = @"CreatedOn";
            public static string ModifiedOn = @"ModifiedOn";
            public static string Deleted = @"Deleted";
            public static string FranchiseeId = @"FranchiseeId";

        }

    }



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



    public partial class Banner
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Banner" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Banner" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnBannerId = new TableColumn();
                columnBannerId.ColumnName = "BannerId";
                columnBannerId.MaxLength = 4;
                columnBannerId.AutoIncrement = bool.Parse("True");
                columnBannerId.IsNullable = bool.Parse("False");
                columnBannerId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnBannerId);



                TableColumn columnPicture = new TableColumn();
                columnPicture.ColumnName = "Picture";
                columnPicture.MaxLength = 512;
                columnPicture.AutoIncrement = bool.Parse("False");
                columnPicture.IsNullable = bool.Parse("True");
                columnPicture.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnPicture);



                TableColumn columnLink = new TableColumn();
                columnLink.ColumnName = "Link";
                columnLink.MaxLength = 512;
                columnLink.AutoIncrement = bool.Parse("False");
                columnLink.IsNullable = bool.Parse("True");
                columnLink.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnLink);



                TableColumn columnPriority = new TableColumn();
                columnPriority.ColumnName = "Priority";
                columnPriority.MaxLength = 4;
                columnPriority.AutoIncrement = bool.Parse("False");
                columnPriority.IsNullable = bool.Parse("False");
                columnPriority.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPriority);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                return columnSpecs;

            }

            public static TableColumn BannerIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn PictureColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn LinkColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn PriorityColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[4];
                }
            }



        }

        public struct ColumnNames
        {
            public static string BannerId = @"BannerId";
            public static string Picture = @"Picture";
            public static string Link = @"Link";
            public static string Priority = @"Priority";
            public static string Deleted = @"Deleted";

        }

    }



    public partial class Category
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Category" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Category" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnCategoryId = new TableColumn();
                columnCategoryId.ColumnName = "CategoryId";
                columnCategoryId.MaxLength = 4;
                columnCategoryId.AutoIncrement = bool.Parse("True");
                columnCategoryId.IsNullable = bool.Parse("False");
                columnCategoryId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCategoryId);



                TableColumn columnName = new TableColumn();
                columnName.ColumnName = "Name";
                columnName.MaxLength = 50;
                columnName.AutoIncrement = bool.Parse("False");
                columnName.IsNullable = bool.Parse("False");
                columnName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnName);



                TableColumn columnLetter = new TableColumn();
                columnLetter.ColumnName = "Letter";
                columnLetter.MaxLength = 1;
                columnLetter.AutoIncrement = bool.Parse("False");
                columnLetter.IsNullable = bool.Parse("False");
                columnLetter.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnLetter);



                TableColumn columnFeatured = new TableColumn();
                columnFeatured.ColumnName = "Featured";
                columnFeatured.MaxLength = 1;
                columnFeatured.AutoIncrement = bool.Parse("False");
                columnFeatured.IsNullable = bool.Parse("False");
                columnFeatured.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFeatured);



                TableColumn columnWeight = new TableColumn();
                columnWeight.ColumnName = "Weight";
                columnWeight.MaxLength = 4;
                columnWeight.AutoIncrement = bool.Parse("False");
                columnWeight.IsNullable = bool.Parse("False");
                columnWeight.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnWeight);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                return columnSpecs;

            }

            public static TableColumn CategoryIdColumn
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

            public static TableColumn LetterColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn FeaturedColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn WeightColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[5];
                }
            }



        }

        public struct ColumnNames
        {
            public static string CategoryId = @"CategoryId";
            public static string Name = @"Name";
            public static string Letter = @"Letter";
            public static string Featured = @"Featured";
            public static string Weight = @"Weight";
            public static string Deleted = @"Deleted";

        }

    }



    public partial class CatPublicity
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "CatPublicity" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "CatPublicity" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnCatPublicityId = new TableColumn();
                columnCatPublicityId.ColumnName = "CatPublicityId";
                columnCatPublicityId.MaxLength = 4;
                columnCatPublicityId.AutoIncrement = bool.Parse("True");
                columnCatPublicityId.IsNullable = bool.Parse("False");
                columnCatPublicityId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCatPublicityId);



                TableColumn columnCategoryId = new TableColumn();
                columnCategoryId.ColumnName = "CategoryId";
                columnCategoryId.MaxLength = 4;
                columnCategoryId.AutoIncrement = bool.Parse("False");
                columnCategoryId.IsNullable = bool.Parse("False");
                columnCategoryId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCategoryId);



                TableColumn columnName = new TableColumn();
                columnName.ColumnName = "Name";
                columnName.MaxLength = 50;
                columnName.AutoIncrement = bool.Parse("False");
                columnName.IsNullable = bool.Parse("False");
                columnName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnName);



                TableColumn columnDescription = new TableColumn();
                columnDescription.ColumnName = "Description";
                columnDescription.MaxLength = 150;
                columnDescription.AutoIncrement = bool.Parse("False");
                columnDescription.IsNullable = bool.Parse("False");
                columnDescription.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDescription);



                TableColumn columnPublicityFile = new TableColumn();
                columnPublicityFile.ColumnName = "PublicityFile";
                columnPublicityFile.MaxLength = 256;
                columnPublicityFile.AutoIncrement = bool.Parse("False");
                columnPublicityFile.IsNullable = bool.Parse("False");
                columnPublicityFile.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPublicityFile);



                TableColumn columnAvailable = new TableColumn();
                columnAvailable.ColumnName = "Available";
                columnAvailable.MaxLength = 1;
                columnAvailable.AutoIncrement = bool.Parse("False");
                columnAvailable.IsNullable = bool.Parse("False");
                columnAvailable.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAvailable);



                TableColumn columnFromDate = new TableColumn();
                columnFromDate.ColumnName = "FromDate";
                columnFromDate.MaxLength = 8;
                columnFromDate.AutoIncrement = bool.Parse("False");
                columnFromDate.IsNullable = bool.Parse("False");
                columnFromDate.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFromDate);



                TableColumn columnToDate = new TableColumn();
                columnToDate.ColumnName = "ToDate";
                columnToDate.MaxLength = 8;
                columnToDate.AutoIncrement = bool.Parse("False");
                columnToDate.IsNullable = bool.Parse("True");
                columnToDate.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnToDate);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                return columnSpecs;

            }

            public static TableColumn CatPublicityIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn CategoryIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn NameColumn
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

            public static TableColumn PublicityFileColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn AvailableColumn
            {
                get
                {
                    return columns[5];
                }
            }

            public static TableColumn FromDateColumn
            {
                get
                {
                    return columns[6];
                }
            }

            public static TableColumn ToDateColumn
            {
                get
                {
                    return columns[7];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[8];
                }
            }



        }

        public struct ColumnNames
        {
            public static string CatPublicityId = @"CatPublicityId";
            public static string CategoryId = @"CategoryId";
            public static string Name = @"Name";
            public static string Description = @"Description";
            public static string PublicityFile = @"PublicityFile";
            public static string Available = @"Available";
            public static string FromDate = @"FromDate";
            public static string ToDate = @"ToDate";
            public static string Deleted = @"Deleted";

        }

    }



    public partial class City
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "City" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "City" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnCityId = new TableColumn();
                columnCityId.ColumnName = "CityId";
                columnCityId.MaxLength = 4;
                columnCityId.AutoIncrement = bool.Parse("True");
                columnCityId.IsNullable = bool.Parse("False");
                columnCityId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCityId);



                TableColumn columnName = new TableColumn();
                columnName.ColumnName = "Name";
                columnName.MaxLength = 50;
                columnName.AutoIncrement = bool.Parse("False");
                columnName.IsNullable = bool.Parse("False");
                columnName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnName);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                return columnSpecs;

            }

            public static TableColumn CityIdColumn
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

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[2];
                }
            }



        }

        public struct ColumnNames
        {
            public static string CityId = @"CityId";
            public static string Name = @"Name";
            public static string Deleted = @"Deleted";

        }

    }



    public partial class Contract
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Contract" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Contract" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnContractId = new TableColumn();
                columnContractId.ColumnName = "ContractId";
                columnContractId.MaxLength = 4;
                columnContractId.AutoIncrement = bool.Parse("True");
                columnContractId.IsNullable = bool.Parse("False");
                columnContractId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnContractId);



                TableColumn columnAdvertiserId = new TableColumn();
                columnAdvertiserId.ColumnName = "AdvertiserId";
                columnAdvertiserId.MaxLength = 4;
                columnAdvertiserId.AutoIncrement = bool.Parse("False");
                columnAdvertiserId.IsNullable = bool.Parse("False");
                columnAdvertiserId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAdvertiserId);



                TableColumn columnContractDate = new TableColumn();
                columnContractDate.ColumnName = "ContractDate";
                columnContractDate.MaxLength = 8;
                columnContractDate.AutoIncrement = bool.Parse("False");
                columnContractDate.IsNullable = bool.Parse("False");
                columnContractDate.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnContractDate);



                TableColumn columnMonths = new TableColumn();
                columnMonths.ColumnName = "Months";
                columnMonths.MaxLength = 4;
                columnMonths.AutoIncrement = bool.Parse("False");
                columnMonths.IsNullable = bool.Parse("False");
                columnMonths.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnMonths);



                TableColumn columnEndDate = new TableColumn();
                columnEndDate.ColumnName = "EndDate";
                columnEndDate.MaxLength = 8;
                columnEndDate.AutoIncrement = bool.Parse("False");
                columnEndDate.IsNullable = bool.Parse("False");
                columnEndDate.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnEndDate);



                TableColumn columnPersonalId = new TableColumn();
                columnPersonalId.ColumnName = "PersonalId";
                columnPersonalId.MaxLength = 4;
                columnPersonalId.AutoIncrement = bool.Parse("False");
                columnPersonalId.IsNullable = bool.Parse("False");
                columnPersonalId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPersonalId);



                TableColumn columnCreationDate = new TableColumn();
                columnCreationDate.ColumnName = "CreationDate";
                columnCreationDate.MaxLength = 8;
                columnCreationDate.AutoIncrement = bool.Parse("False");
                columnCreationDate.IsNullable = bool.Parse("False");
                columnCreationDate.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCreationDate);



                TableColumn columnIsPaid = new TableColumn();
                columnIsPaid.ColumnName = "IsPaid";
                columnIsPaid.MaxLength = 1;
                columnIsPaid.AutoIncrement = bool.Parse("False");
                columnIsPaid.IsNullable = bool.Parse("False");
                columnIsPaid.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnIsPaid);



                TableColumn columnInvoiceId = new TableColumn();
                columnInvoiceId.ColumnName = "InvoiceId";
                columnInvoiceId.MaxLength = 4;
                columnInvoiceId.AutoIncrement = bool.Parse("False");
                columnInvoiceId.IsNullable = bool.Parse("True");
                columnInvoiceId.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnInvoiceId);



                TableColumn columnPayPalTransactionId = new TableColumn();
                columnPayPalTransactionId.ColumnName = "PayPalTransactionId";
                columnPayPalTransactionId.MaxLength = 100;
                columnPayPalTransactionId.AutoIncrement = bool.Parse("False");
                columnPayPalTransactionId.IsNullable = bool.Parse("True");
                columnPayPalTransactionId.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnPayPalTransactionId);



                TableColumn columnIsActive = new TableColumn();
                columnIsActive.ColumnName = "IsActive";
                columnIsActive.MaxLength = 1;
                columnIsActive.AutoIncrement = bool.Parse("False");
                columnIsActive.IsNullable = bool.Parse("False");
                columnIsActive.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnIsActive);



                TableColumn columnPaymentAmount = new TableColumn();
                columnPaymentAmount.ColumnName = "PaymentAmount";
                columnPaymentAmount.MaxLength = 17;
                columnPaymentAmount.AutoIncrement = bool.Parse("False");
                columnPaymentAmount.IsNullable = bool.Parse("True");
                columnPaymentAmount.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnPaymentAmount);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                TableColumn columnUsedReference = new TableColumn();
                columnUsedReference.ColumnName = "UsedReference";
                columnUsedReference.MaxLength = 100;
                columnUsedReference.AutoIncrement = bool.Parse("False");
                columnUsedReference.IsNullable = bool.Parse("True");
                columnUsedReference.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnUsedReference);



                TableColumn columnWebSite = new TableColumn();
                columnWebSite.ColumnName = "WebSite";
                columnWebSite.MaxLength = 1;
                columnWebSite.AutoIncrement = bool.Parse("False");
                columnWebSite.IsNullable = bool.Parse("False");
                columnWebSite.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnWebSite);



                TableColumn columniOs = new TableColumn();
                columniOs.ColumnName = "iOs";
                columniOs.MaxLength = 1;
                columniOs.AutoIncrement = bool.Parse("False");
                columniOs.IsNullable = bool.Parse("False");
                columniOs.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columniOs);



                TableColumn columnAndroid = new TableColumn();
                columnAndroid.ColumnName = "Android";
                columnAndroid.MaxLength = 1;
                columnAndroid.AutoIncrement = bool.Parse("False");
                columnAndroid.IsNullable = bool.Parse("False");
                columnAndroid.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAndroid);



                TableColumn columnFeatured = new TableColumn();
                columnFeatured.ColumnName = "Featured";
                columnFeatured.MaxLength = 1;
                columnFeatured.AutoIncrement = bool.Parse("False");
                columnFeatured.IsNullable = bool.Parse("False");
                columnFeatured.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFeatured);



                TableColumn columnPromiseDate = new TableColumn();
                columnPromiseDate.ColumnName = "PromiseDate";
                columnPromiseDate.MaxLength = 8;
                columnPromiseDate.AutoIncrement = bool.Parse("False");
                columnPromiseDate.IsNullable = bool.Parse("True");
                columnPromiseDate.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnPromiseDate);



                TableColumn columnFolio = new TableColumn();
                columnFolio.ColumnName = "Folio";
                columnFolio.MaxLength = 10;
                columnFolio.AutoIncrement = bool.Parse("False");
                columnFolio.IsNullable = bool.Parse("True");
                columnFolio.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnFolio);



                TableColumn columnInvoiceCreator = new TableColumn();
                columnInvoiceCreator.ColumnName = "InvoiceCreator";
                columnInvoiceCreator.MaxLength = 4;
                columnInvoiceCreator.AutoIncrement = bool.Parse("False");
                columnInvoiceCreator.IsNullable = bool.Parse("True");
                columnInvoiceCreator.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnInvoiceCreator);



                TableColumn columnInvoiceCreation = new TableColumn();
                columnInvoiceCreation.ColumnName = "InvoiceCreation";
                columnInvoiceCreation.MaxLength = 8;
                columnInvoiceCreation.AutoIncrement = bool.Parse("False");
                columnInvoiceCreation.IsNullable = bool.Parse("True");
                columnInvoiceCreation.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnInvoiceCreation);



                TableColumn columnPaymentUser = new TableColumn();
                columnPaymentUser.ColumnName = "PaymentUser";
                columnPaymentUser.MaxLength = 4;
                columnPaymentUser.AutoIncrement = bool.Parse("False");
                columnPaymentUser.IsNullable = bool.Parse("True");
                columnPaymentUser.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnPaymentUser);



                TableColumn columnPaymentDate = new TableColumn();
                columnPaymentDate.ColumnName = "PaymentDate";
                columnPaymentDate.MaxLength = 8;
                columnPaymentDate.AutoIncrement = bool.Parse("False");
                columnPaymentDate.IsNullable = bool.Parse("True");
                columnPaymentDate.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnPaymentDate);



                return columnSpecs;

            }

            public static TableColumn ContractIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn AdvertiserIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn ContractDateColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn MonthsColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn EndDateColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn PersonalIdColumn
            {
                get
                {
                    return columns[5];
                }
            }

            public static TableColumn CreationDateColumn
            {
                get
                {
                    return columns[6];
                }
            }

            public static TableColumn IsPaidColumn
            {
                get
                {
                    return columns[7];
                }
            }

            public static TableColumn InvoiceIdColumn
            {
                get
                {
                    return columns[8];
                }
            }

            public static TableColumn PayPalTransactionIdColumn
            {
                get
                {
                    return columns[9];
                }
            }

            public static TableColumn IsActiveColumn
            {
                get
                {
                    return columns[10];
                }
            }

            public static TableColumn PaymentAmountColumn
            {
                get
                {
                    return columns[11];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[12];
                }
            }

            public static TableColumn UsedReferenceColumn
            {
                get
                {
                    return columns[13];
                }
            }

            public static TableColumn WebSiteColumn
            {
                get
                {
                    return columns[14];
                }
            }

            public static TableColumn iOsColumn
            {
                get
                {
                    return columns[15];
                }
            }

            public static TableColumn AndroidColumn
            {
                get
                {
                    return columns[16];
                }
            }

            public static TableColumn FeaturedColumn
            {
                get
                {
                    return columns[17];
                }
            }

            public static TableColumn PromiseDateColumn
            {
                get
                {
                    return columns[18];
                }
            }

            public static TableColumn FolioColumn
            {
                get
                {
                    return columns[19];
                }
            }

            public static TableColumn InvoiceCreatorColumn
            {
                get
                {
                    return columns[20];
                }
            }

            public static TableColumn InvoiceCreationColumn
            {
                get
                {
                    return columns[21];
                }
            }

            public static TableColumn PaymentUserColumn
            {
                get
                {
                    return columns[22];
                }
            }

            public static TableColumn PaymentDateColumn
            {
                get
                {
                    return columns[23];
                }
            }



        }

        public struct ColumnNames
        {
            public static string ContractId = @"ContractId";
            public static string AdvertiserId = @"AdvertiserId";
            public static string ContractDate = @"ContractDate";
            public static string Months = @"Months";
            public static string EndDate = @"EndDate";
            public static string PersonalId = @"PersonalId";
            public static string CreationDate = @"CreationDate";
            public static string IsPaid = @"IsPaid";
            public static string InvoiceId = @"InvoiceId";
            public static string PayPalTransactionId = @"PayPalTransactionId";
            public static string IsActive = @"IsActive";
            public static string PaymentAmount = @"PaymentAmount";
            public static string Deleted = @"Deleted";
            public static string UsedReference = @"UsedReference";
            public static string WebSite = @"WebSite";
            public static string iOs = @"iOs";
            public static string Android = @"Android";
            public static string Featured = @"Featured";
            public static string PromiseDate = @"PromiseDate";
            public static string Folio = @"Folio";
            public static string InvoiceCreator = @"InvoiceCreator";
            public static string InvoiceCreation = @"InvoiceCreation";
            public static string PaymentUser = @"PaymentUser";
            public static string PaymentDate = @"PaymentDate";

        }

    }



    public partial class Coupon
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Coupon" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Coupon" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnCouponId = new TableColumn();
                columnCouponId.ColumnName = "CouponId";
                columnCouponId.MaxLength = 4;
                columnCouponId.AutoIncrement = bool.Parse("True");
                columnCouponId.IsNullable = bool.Parse("False");
                columnCouponId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCouponId);



                TableColumn columnFranchiseeId = new TableColumn();
                columnFranchiseeId.ColumnName = "FranchiseeId";
                columnFranchiseeId.MaxLength = 4;
                columnFranchiseeId.AutoIncrement = bool.Parse("False");
                columnFranchiseeId.IsNullable = bool.Parse("False");
                columnFranchiseeId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFranchiseeId);



                TableColumn columnAdvertiserId = new TableColumn();
                columnAdvertiserId.ColumnName = "AdvertiserId";
                columnAdvertiserId.MaxLength = 4;
                columnAdvertiserId.AutoIncrement = bool.Parse("False");
                columnAdvertiserId.IsNullable = bool.Parse("False");
                columnAdvertiserId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAdvertiserId);



                TableColumn columnCouponSetId = new TableColumn();
                columnCouponSetId.ColumnName = "CouponSetId";
                columnCouponSetId.MaxLength = 4;
                columnCouponSetId.AutoIncrement = bool.Parse("False");
                columnCouponSetId.IsNullable = bool.Parse("False");
                columnCouponSetId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCouponSetId);



                TableColumn columnCouponStatusId = new TableColumn();
                columnCouponStatusId.ColumnName = "CouponStatusId";
                columnCouponStatusId.MaxLength = 4;
                columnCouponStatusId.AutoIncrement = bool.Parse("False");
                columnCouponStatusId.IsNullable = bool.Parse("False");
                columnCouponStatusId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCouponStatusId);



                TableColumn columnName = new TableColumn();
                columnName.ColumnName = "Name";
                columnName.MaxLength = 50;
                columnName.AutoIncrement = bool.Parse("False");
                columnName.IsNullable = bool.Parse("False");
                columnName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnName);



                TableColumn columnDescription = new TableColumn();
                columnDescription.ColumnName = "Description";
                columnDescription.MaxLength = 500;
                columnDescription.AutoIncrement = bool.Parse("False");
                columnDescription.IsNullable = bool.Parse("True");
                columnDescription.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnDescription);



                TableColumn columnConditions = new TableColumn();
                columnConditions.ColumnName = "Conditions";
                columnConditions.MaxLength = 500;
                columnConditions.AutoIncrement = bool.Parse("False");
                columnConditions.IsNullable = bool.Parse("True");
                columnConditions.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnConditions);



                TableColumn columnHowToCash = new TableColumn();
                columnHowToCash.ColumnName = "HowToCash";
                columnHowToCash.MaxLength = 500;
                columnHowToCash.AutoIncrement = bool.Parse("False");
                columnHowToCash.IsNullable = bool.Parse("True");
                columnHowToCash.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnHowToCash);



                TableColumn columnStartDate = new TableColumn();
                columnStartDate.ColumnName = "StartDate";
                columnStartDate.MaxLength = 8;
                columnStartDate.AutoIncrement = bool.Parse("False");
                columnStartDate.IsNullable = bool.Parse("False");
                columnStartDate.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnStartDate);



                TableColumn columnEndDate = new TableColumn();
                columnEndDate.ColumnName = "EndDate";
                columnEndDate.MaxLength = 8;
                columnEndDate.AutoIncrement = bool.Parse("False");
                columnEndDate.IsNullable = bool.Parse("False");
                columnEndDate.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnEndDate);



                TableColumn columnHasPicture = new TableColumn();
                columnHasPicture.ColumnName = "HasPicture";
                columnHasPicture.MaxLength = 1;
                columnHasPicture.AutoIncrement = bool.Parse("False");
                columnHasPicture.IsNullable = bool.Parse("False");
                columnHasPicture.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnHasPicture);



                TableColumn columnIsExpirable = new TableColumn();
                columnIsExpirable.ColumnName = "IsExpirable";
                columnIsExpirable.MaxLength = 1;
                columnIsExpirable.AutoIncrement = bool.Parse("False");
                columnIsExpirable.IsNullable = bool.Parse("False");
                columnIsExpirable.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnIsExpirable);



                TableColumn columnCreatedBy = new TableColumn();
                columnCreatedBy.ColumnName = "CreatedBy";
                columnCreatedBy.MaxLength = 4;
                columnCreatedBy.AutoIncrement = bool.Parse("False");
                columnCreatedBy.IsNullable = bool.Parse("False");
                columnCreatedBy.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCreatedBy);



                TableColumn columnCreatedOn = new TableColumn();
                columnCreatedOn.ColumnName = "CreatedOn";
                columnCreatedOn.MaxLength = 8;
                columnCreatedOn.AutoIncrement = bool.Parse("False");
                columnCreatedOn.IsNullable = bool.Parse("False");
                columnCreatedOn.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCreatedOn);



                TableColumn columnModifiedBy = new TableColumn();
                columnModifiedBy.ColumnName = "ModifiedBy";
                columnModifiedBy.MaxLength = 4;
                columnModifiedBy.AutoIncrement = bool.Parse("False");
                columnModifiedBy.IsNullable = bool.Parse("True");
                columnModifiedBy.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnModifiedBy);



                TableColumn columnModifiedOn = new TableColumn();
                columnModifiedOn.ColumnName = "ModifiedOn";
                columnModifiedOn.MaxLength = 8;
                columnModifiedOn.AutoIncrement = bool.Parse("False");
                columnModifiedOn.IsNullable = bool.Parse("True");
                columnModifiedOn.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnModifiedOn);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                TableColumn columnIsNationale = new TableColumn();
                columnIsNationale.ColumnName = "IsNationale";
                columnIsNationale.MaxLength = 1;
                columnIsNationale.AutoIncrement = bool.Parse("False");
                columnIsNationale.IsNullable = bool.Parse("False");
                columnIsNationale.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnIsNationale);



                return columnSpecs;

            }

            public static TableColumn CouponIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn FranchiseeIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn AdvertiserIdColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn CouponSetIdColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn CouponStatusIdColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn NameColumn
            {
                get
                {
                    return columns[5];
                }
            }

            public static TableColumn DescriptionColumn
            {
                get
                {
                    return columns[6];
                }
            }

            public static TableColumn ConditionsColumn
            {
                get
                {
                    return columns[7];
                }
            }

            public static TableColumn HowToCashColumn
            {
                get
                {
                    return columns[8];
                }
            }

            public static TableColumn StartDateColumn
            {
                get
                {
                    return columns[9];
                }
            }

            public static TableColumn EndDateColumn
            {
                get
                {
                    return columns[10];
                }
            }

            public static TableColumn HasPictureColumn
            {
                get
                {
                    return columns[11];
                }
            }

            public static TableColumn IsExpirableColumn
            {
                get
                {
                    return columns[12];
                }
            }

            public static TableColumn CreatedByColumn
            {
                get
                {
                    return columns[13];
                }
            }

            public static TableColumn CreatedOnColumn
            {
                get
                {
                    return columns[14];
                }
            }

            public static TableColumn ModifiedByColumn
            {
                get
                {
                    return columns[15];
                }
            }

            public static TableColumn ModifiedOnColumn
            {
                get
                {
                    return columns[16];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[17];
                }
            }

            public static TableColumn IsNationaleColumn
            {
                get
                {
                    return columns[18];
                }
            }



        }

        public struct ColumnNames
        {
            public static string CouponId = @"CouponId";
            public static string FranchiseeId = @"FranchiseeId";
            public static string AdvertiserId = @"AdvertiserId";
            public static string CouponSetId = @"CouponSetId";
            public static string CouponStatusId = @"CouponStatusId";
            public static string Name = @"Name";
            public static string Description = @"Description";
            public static string Conditions = @"Conditions";
            public static string HowToCash = @"HowToCash";
            public static string StartDate = @"StartDate";
            public static string EndDate = @"EndDate";
            public static string HasPicture = @"HasPicture";
            public static string IsExpirable = @"IsExpirable";
            public static string CreatedBy = @"CreatedBy";
            public static string CreatedOn = @"CreatedOn";
            public static string ModifiedBy = @"ModifiedBy";
            public static string ModifiedOn = @"ModifiedOn";
            public static string Deleted = @"Deleted";
            public static string IsNationale = @"IsNationale";

        }

    }



    public partial class CouponCategory
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "CouponCategory" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "CouponCategory" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnCouponCategoryId = new TableColumn();
                columnCouponCategoryId.ColumnName = "CouponCategoryId";
                columnCouponCategoryId.MaxLength = 4;
                columnCouponCategoryId.AutoIncrement = bool.Parse("True");
                columnCouponCategoryId.IsNullable = bool.Parse("False");
                columnCouponCategoryId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCouponCategoryId);



                TableColumn columnCouponId = new TableColumn();
                columnCouponId.ColumnName = "CouponId";
                columnCouponId.MaxLength = 4;
                columnCouponId.AutoIncrement = bool.Parse("False");
                columnCouponId.IsNullable = bool.Parse("False");
                columnCouponId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCouponId);



                TableColumn columnCategoryId = new TableColumn();
                columnCategoryId.ColumnName = "CategoryId";
                columnCategoryId.MaxLength = 4;
                columnCategoryId.AutoIncrement = bool.Parse("False");
                columnCategoryId.IsNullable = bool.Parse("False");
                columnCategoryId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCategoryId);



                TableColumn columnCreatedBy = new TableColumn();
                columnCreatedBy.ColumnName = "CreatedBy";
                columnCreatedBy.MaxLength = 4;
                columnCreatedBy.AutoIncrement = bool.Parse("False");
                columnCreatedBy.IsNullable = bool.Parse("False");
                columnCreatedBy.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCreatedBy);



                TableColumn columnCreatedOn = new TableColumn();
                columnCreatedOn.ColumnName = "CreatedOn";
                columnCreatedOn.MaxLength = 8;
                columnCreatedOn.AutoIncrement = bool.Parse("False");
                columnCreatedOn.IsNullable = bool.Parse("False");
                columnCreatedOn.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCreatedOn);



                TableColumn columnModifiedBy = new TableColumn();
                columnModifiedBy.ColumnName = "ModifiedBy";
                columnModifiedBy.MaxLength = 4;
                columnModifiedBy.AutoIncrement = bool.Parse("False");
                columnModifiedBy.IsNullable = bool.Parse("False");
                columnModifiedBy.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnModifiedBy);



                TableColumn columnModifiedOn = new TableColumn();
                columnModifiedOn.ColumnName = "ModifiedOn";
                columnModifiedOn.MaxLength = 8;
                columnModifiedOn.AutoIncrement = bool.Parse("False");
                columnModifiedOn.IsNullable = bool.Parse("False");
                columnModifiedOn.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnModifiedOn);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                return columnSpecs;

            }

            public static TableColumn CouponCategoryIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn CouponIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn CategoryIdColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn CreatedByColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn CreatedOnColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn ModifiedByColumn
            {
                get
                {
                    return columns[5];
                }
            }

            public static TableColumn ModifiedOnColumn
            {
                get
                {
                    return columns[6];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[7];
                }
            }



        }

        public struct ColumnNames
        {
            public static string CouponCategoryId = @"CouponCategoryId";
            public static string CouponId = @"CouponId";
            public static string CategoryId = @"CategoryId";
            public static string CreatedBy = @"CreatedBy";
            public static string CreatedOn = @"CreatedOn";
            public static string ModifiedBy = @"ModifiedBy";
            public static string ModifiedOn = @"ModifiedOn";
            public static string Deleted = @"Deleted";

        }

    }



    public partial class CouponSet
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "CouponSet" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "CouponSet" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnCouponSetId = new TableColumn();
                columnCouponSetId.ColumnName = "CouponSetId";
                columnCouponSetId.MaxLength = 4;
                columnCouponSetId.AutoIncrement = bool.Parse("True");
                columnCouponSetId.IsNullable = bool.Parse("False");
                columnCouponSetId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCouponSetId);



                TableColumn columnFranchiseeId = new TableColumn();
                columnFranchiseeId.ColumnName = "FranchiseeId";
                columnFranchiseeId.MaxLength = 4;
                columnFranchiseeId.AutoIncrement = bool.Parse("False");
                columnFranchiseeId.IsNullable = bool.Parse("False");
                columnFranchiseeId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFranchiseeId);



                TableColumn columnAdvertiserId = new TableColumn();
                columnAdvertiserId.ColumnName = "AdvertiserId";
                columnAdvertiserId.MaxLength = 4;
                columnAdvertiserId.AutoIncrement = bool.Parse("False");
                columnAdvertiserId.IsNullable = bool.Parse("False");
                columnAdvertiserId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAdvertiserId);



                TableColumn columnName = new TableColumn();
                columnName.ColumnName = "Name";
                columnName.MaxLength = 50;
                columnName.AutoIncrement = bool.Parse("False");
                columnName.IsNullable = bool.Parse("False");
                columnName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnName);



                TableColumn columnDescription = new TableColumn();
                columnDescription.ColumnName = "Description";
                columnDescription.MaxLength = 500;
                columnDescription.AutoIncrement = bool.Parse("False");
                columnDescription.IsNullable = bool.Parse("True");
                columnDescription.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnDescription);



                TableColumn columnCreatedBy = new TableColumn();
                columnCreatedBy.ColumnName = "CreatedBy";
                columnCreatedBy.MaxLength = 4;
                columnCreatedBy.AutoIncrement = bool.Parse("False");
                columnCreatedBy.IsNullable = bool.Parse("False");
                columnCreatedBy.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCreatedBy);



                TableColumn columnCreatedOn = new TableColumn();
                columnCreatedOn.ColumnName = "CreatedOn";
                columnCreatedOn.MaxLength = 8;
                columnCreatedOn.AutoIncrement = bool.Parse("False");
                columnCreatedOn.IsNullable = bool.Parse("False");
                columnCreatedOn.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCreatedOn);



                TableColumn columnModifiedBy = new TableColumn();
                columnModifiedBy.ColumnName = "ModifiedBy";
                columnModifiedBy.MaxLength = 4;
                columnModifiedBy.AutoIncrement = bool.Parse("False");
                columnModifiedBy.IsNullable = bool.Parse("True");
                columnModifiedBy.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnModifiedBy);



                TableColumn columnModifiedOn = new TableColumn();
                columnModifiedOn.ColumnName = "ModifiedOn";
                columnModifiedOn.MaxLength = 8;
                columnModifiedOn.AutoIncrement = bool.Parse("False");
                columnModifiedOn.IsNullable = bool.Parse("True");
                columnModifiedOn.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnModifiedOn);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                return columnSpecs;

            }

            public static TableColumn CouponSetIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn FranchiseeIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn AdvertiserIdColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn NameColumn
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

            public static TableColumn CreatedByColumn
            {
                get
                {
                    return columns[5];
                }
            }

            public static TableColumn CreatedOnColumn
            {
                get
                {
                    return columns[6];
                }
            }

            public static TableColumn ModifiedByColumn
            {
                get
                {
                    return columns[7];
                }
            }

            public static TableColumn ModifiedOnColumn
            {
                get
                {
                    return columns[8];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[9];
                }
            }



        }

        public struct ColumnNames
        {
            public static string CouponSetId = @"CouponSetId";
            public static string FranchiseeId = @"FranchiseeId";
            public static string AdvertiserId = @"AdvertiserId";
            public static string Name = @"Name";
            public static string Description = @"Description";
            public static string CreatedBy = @"CreatedBy";
            public static string CreatedOn = @"CreatedOn";
            public static string ModifiedBy = @"ModifiedBy";
            public static string ModifiedOn = @"ModifiedOn";
            public static string Deleted = @"Deleted";

        }

    }



    public partial class CouponStatus
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "CouponStatus" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "CouponStatus" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnCouponStatusId = new TableColumn();
                columnCouponStatusId.ColumnName = "CouponStatusId";
                columnCouponStatusId.MaxLength = 4;
                columnCouponStatusId.AutoIncrement = bool.Parse("True");
                columnCouponStatusId.IsNullable = bool.Parse("False");
                columnCouponStatusId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCouponStatusId);



                TableColumn columnDescription = new TableColumn();
                columnDescription.ColumnName = "Description";
                columnDescription.MaxLength = 20;
                columnDescription.AutoIncrement = bool.Parse("False");
                columnDescription.IsNullable = bool.Parse("False");
                columnDescription.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDescription);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                return columnSpecs;

            }

            public static TableColumn CouponStatusIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn DescriptionColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[2];
                }
            }



        }

        public struct ColumnNames
        {
            public static string CouponStatusId = @"CouponStatusId";
            public static string Description = @"Description";
            public static string Deleted = @"Deleted";

        }

    }



    public partial class Email
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Email" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Email" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnEmailId = new TableColumn();
                columnEmailId.ColumnName = "EmailId";
                columnEmailId.MaxLength = 4;
                columnEmailId.AutoIncrement = bool.Parse("True");
                columnEmailId.IsNullable = bool.Parse("False");
                columnEmailId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnEmailId);



                TableColumn columnAdvertiserId = new TableColumn();
                columnAdvertiserId.ColumnName = "AdvertiserId";
                columnAdvertiserId.MaxLength = 4;
                columnAdvertiserId.AutoIncrement = bool.Parse("False");
                columnAdvertiserId.IsNullable = bool.Parse("False");
                columnAdvertiserId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAdvertiserId);



                TableColumn columnAddress = new TableColumn();
                columnAddress.ColumnName = "Address";
                columnAddress.MaxLength = 100;
                columnAddress.AutoIncrement = bool.Parse("False");
                columnAddress.IsNullable = bool.Parse("False");
                columnAddress.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAddress);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                return columnSpecs;

            }

            public static TableColumn EmailIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn AdvertiserIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn AddressColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[3];
                }
            }



        }

        public struct ColumnNames
        {
            public static string EmailId = @"EmailId";
            public static string AdvertiserId = @"AdvertiserId";
            public static string Address = @"Address";
            public static string Deleted = @"Deleted";

        }

    }



    public partial class Estado
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Estado" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Estado" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnEstadoId = new TableColumn();
                columnEstadoId.ColumnName = "EstadoId";
                columnEstadoId.MaxLength = 4;
                columnEstadoId.AutoIncrement = bool.Parse("True");
                columnEstadoId.IsNullable = bool.Parse("False");
                columnEstadoId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnEstadoId);



                TableColumn columnName = new TableColumn();
                columnName.ColumnName = "Name";
                columnName.MaxLength = 20;
                columnName.AutoIncrement = bool.Parse("False");
                columnName.IsNullable = bool.Parse("False");
                columnName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnName);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                return columnSpecs;

            }

            public static TableColumn EstadoIdColumn
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

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[2];
                }
            }



        }

        public struct ColumnNames
        {
            public static string EstadoId = @"EstadoId";
            public static string Name = @"Name";
            public static string Deleted = @"Deleted";

        }

    }



    public partial class FiscalDetail
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "FiscalDetail" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "FiscalDetail" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnFiscalDetailId = new TableColumn();
                columnFiscalDetailId.ColumnName = "FiscalDetailId";
                columnFiscalDetailId.MaxLength = 4;
                columnFiscalDetailId.AutoIncrement = bool.Parse("True");
                columnFiscalDetailId.IsNullable = bool.Parse("False");
                columnFiscalDetailId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFiscalDetailId);



                TableColumn columnId = new TableColumn();
                columnId.ColumnName = "Id";
                columnId.MaxLength = 4;
                columnId.AutoIncrement = bool.Parse("False");
                columnId.IsNullable = bool.Parse("False");
                columnId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnId);



                TableColumn columnName = new TableColumn();
                columnName.ColumnName = "Name";
                columnName.MaxLength = 50;
                columnName.AutoIncrement = bool.Parse("False");
                columnName.IsNullable = bool.Parse("False");
                columnName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnName);



                TableColumn columnRFC = new TableColumn();
                columnRFC.ColumnName = "RFC";
                columnRFC.MaxLength = 13;
                columnRFC.AutoIncrement = bool.Parse("False");
                columnRFC.IsNullable = bool.Parse("False");
                columnRFC.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnRFC);



                TableColumn columnIsMoralPerson = new TableColumn();
                columnIsMoralPerson.ColumnName = "IsMoralPerson";
                columnIsMoralPerson.MaxLength = 1;
                columnIsMoralPerson.AutoIncrement = bool.Parse("False");
                columnIsMoralPerson.IsNullable = bool.Parse("False");
                columnIsMoralPerson.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnIsMoralPerson);



                TableColumn columnEstadoId = new TableColumn();
                columnEstadoId.ColumnName = "EstadoId";
                columnEstadoId.MaxLength = 4;
                columnEstadoId.AutoIncrement = bool.Parse("False");
                columnEstadoId.IsNullable = bool.Parse("False");
                columnEstadoId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnEstadoId);



                TableColumn columnMunicipioId = new TableColumn();
                columnMunicipioId.ColumnName = "MunicipioId";
                columnMunicipioId.MaxLength = 4;
                columnMunicipioId.AutoIncrement = bool.Parse("False");
                columnMunicipioId.IsNullable = bool.Parse("False");
                columnMunicipioId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnMunicipioId);



                TableColumn columnPoblacion = new TableColumn();
                columnPoblacion.ColumnName = "Poblacion";
                columnPoblacion.MaxLength = 50;
                columnPoblacion.AutoIncrement = bool.Parse("False");
                columnPoblacion.IsNullable = bool.Parse("True");
                columnPoblacion.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnPoblacion);



                TableColumn columnStreet = new TableColumn();
                columnStreet.ColumnName = "Street";
                columnStreet.MaxLength = 50;
                columnStreet.AutoIncrement = bool.Parse("False");
                columnStreet.IsNullable = bool.Parse("False");
                columnStreet.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnStreet);



                TableColumn columnExteriorNumber = new TableColumn();
                columnExteriorNumber.ColumnName = "ExteriorNumber";
                columnExteriorNumber.MaxLength = 50;
                columnExteriorNumber.AutoIncrement = bool.Parse("False");
                columnExteriorNumber.IsNullable = bool.Parse("False");
                columnExteriorNumber.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnExteriorNumber);



                TableColumn columnInteriorNumber = new TableColumn();
                columnInteriorNumber.ColumnName = "InteriorNumber";
                columnInteriorNumber.MaxLength = 50;
                columnInteriorNumber.AutoIncrement = bool.Parse("False");
                columnInteriorNumber.IsNullable = bool.Parse("True");
                columnInteriorNumber.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnInteriorNumber);



                TableColumn columnColony = new TableColumn();
                columnColony.ColumnName = "Colony";
                columnColony.MaxLength = 50;
                columnColony.AutoIncrement = bool.Parse("False");
                columnColony.IsNullable = bool.Parse("False");
                columnColony.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnColony);



                TableColumn columnZipCode = new TableColumn();
                columnZipCode.ColumnName = "ZipCode";
                columnZipCode.MaxLength = 10;
                columnZipCode.AutoIncrement = bool.Parse("False");
                columnZipCode.IsNullable = bool.Parse("False");
                columnZipCode.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnZipCode);



                TableColumn columnContactEmail = new TableColumn();
                columnContactEmail.ColumnName = "ContactEmail";
                columnContactEmail.MaxLength = 50;
                columnContactEmail.AutoIncrement = bool.Parse("False");
                columnContactEmail.IsNullable = bool.Parse("True");
                columnContactEmail.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnContactEmail);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                return columnSpecs;

            }

            public static TableColumn FiscalDetailIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn IdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn NameColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn RFCColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn IsMoralPersonColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn EstadoIdColumn
            {
                get
                {
                    return columns[5];
                }
            }

            public static TableColumn MunicipioIdColumn
            {
                get
                {
                    return columns[6];
                }
            }

            public static TableColumn PoblacionColumn
            {
                get
                {
                    return columns[7];
                }
            }

            public static TableColumn StreetColumn
            {
                get
                {
                    return columns[8];
                }
            }

            public static TableColumn ExteriorNumberColumn
            {
                get
                {
                    return columns[9];
                }
            }

            public static TableColumn InteriorNumberColumn
            {
                get
                {
                    return columns[10];
                }
            }

            public static TableColumn ColonyColumn
            {
                get
                {
                    return columns[11];
                }
            }

            public static TableColumn ZipCodeColumn
            {
                get
                {
                    return columns[12];
                }
            }

            public static TableColumn ContactEmailColumn
            {
                get
                {
                    return columns[13];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[14];
                }
            }



        }

        public struct ColumnNames
        {
            public static string FiscalDetailId = @"FiscalDetailId";
            public static string Id = @"Id";
            public static string Name = @"Name";
            public static string RFC = @"RFC";
            public static string IsMoralPerson = @"IsMoralPerson";
            public static string EstadoId = @"EstadoId";
            public static string MunicipioId = @"MunicipioId";
            public static string Poblacion = @"Poblacion";
            public static string Street = @"Street";
            public static string ExteriorNumber = @"ExteriorNumber";
            public static string InteriorNumber = @"InteriorNumber";
            public static string Colony = @"Colony";
            public static string ZipCode = @"ZipCode";
            public static string ContactEmail = @"ContactEmail";
            public static string Deleted = @"Deleted";

        }

    }



    public partial class Franchisee
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Franchisee" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Franchisee" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnFranchiseeId = new TableColumn();
                columnFranchiseeId.ColumnName = "FranchiseeId";
                columnFranchiseeId.MaxLength = 4;
                columnFranchiseeId.AutoIncrement = bool.Parse("True");
                columnFranchiseeId.IsNullable = bool.Parse("False");
                columnFranchiseeId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFranchiseeId);



                TableColumn columnFiscalDetailId = new TableColumn();
                columnFiscalDetailId.ColumnName = "FiscalDetailId";
                columnFiscalDetailId.MaxLength = 4;
                columnFiscalDetailId.AutoIncrement = bool.Parse("False");
                columnFiscalDetailId.IsNullable = bool.Parse("True");
                columnFiscalDetailId.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnFiscalDetailId);



                TableColumn columnName = new TableColumn();
                columnName.ColumnName = "Name";
                columnName.MaxLength = 30;
                columnName.AutoIncrement = bool.Parse("False");
                columnName.IsNullable = bool.Parse("False");
                columnName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnName);



                TableColumn columnIsPrimary = new TableColumn();
                columnIsPrimary.ColumnName = "IsPrimary";
                columnIsPrimary.MaxLength = 1;
                columnIsPrimary.AutoIncrement = bool.Parse("False");
                columnIsPrimary.IsNullable = bool.Parse("False");
                columnIsPrimary.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnIsPrimary);



                TableColumn columnRfc = new TableColumn();
                columnRfc.ColumnName = "Rfc";
                columnRfc.MaxLength = 13;
                columnRfc.AutoIncrement = bool.Parse("False");
                columnRfc.IsNullable = bool.Parse("True");
                columnRfc.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnRfc);



                TableColumn columnGorilaKey = new TableColumn();
                columnGorilaKey.ColumnName = "GorilaKey";
                columnGorilaKey.MaxLength = 100;
                columnGorilaKey.AutoIncrement = bool.Parse("False");
                columnGorilaKey.IsNullable = bool.Parse("True");
                columnGorilaKey.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnGorilaKey);



                TableColumn columnAddress = new TableColumn();
                columnAddress.ColumnName = "Address";
                columnAddress.MaxLength = 150;
                columnAddress.AutoIncrement = bool.Parse("False");
                columnAddress.IsNullable = bool.Parse("False");
                columnAddress.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAddress);



                TableColumn columnPhone = new TableColumn();
                columnPhone.ColumnName = "Phone";
                columnPhone.MaxLength = 50;
                columnPhone.AutoIncrement = bool.Parse("False");
                columnPhone.IsNullable = bool.Parse("True");
                columnPhone.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnPhone);



                TableColumn columnCellPhone = new TableColumn();
                columnCellPhone.ColumnName = "CellPhone";
                columnCellPhone.MaxLength = 50;
                columnCellPhone.AutoIncrement = bool.Parse("False");
                columnCellPhone.IsNullable = bool.Parse("True");
                columnCellPhone.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnCellPhone);



                TableColumn columnEmail = new TableColumn();
                columnEmail.ColumnName = "Email";
                columnEmail.MaxLength = 50;
                columnEmail.AutoIncrement = bool.Parse("False");
                columnEmail.IsNullable = bool.Parse("True");
                columnEmail.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnEmail);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                TableColumn columnShareLevelId = new TableColumn();
                columnShareLevelId.ColumnName = "ShareLevelId";
                columnShareLevelId.MaxLength = 4;
                columnShareLevelId.AutoIncrement = bool.Parse("False");
                columnShareLevelId.IsNullable = bool.Parse("False");
                columnShareLevelId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnShareLevelId);



                TableColumn columnMunicipioId = new TableColumn();
                columnMunicipioId.ColumnName = "MunicipioId";
                columnMunicipioId.MaxLength = 4;
                columnMunicipioId.AutoIncrement = bool.Parse("False");
                columnMunicipioId.IsNullable = bool.Parse("False");
                columnMunicipioId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnMunicipioId);



                TableColumn columnExternalKey = new TableColumn();
                columnExternalKey.ColumnName = "ExternalKey";
                columnExternalKey.MaxLength = 4;
                columnExternalKey.AutoIncrement = bool.Parse("False");
                columnExternalKey.IsNullable = bool.Parse("True");
                columnExternalKey.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnExternalKey);



                TableColumn columnBankReference = new TableColumn();
                columnBankReference.ColumnName = "BankReference";
                columnBankReference.MaxLength = 50;
                columnBankReference.AutoIncrement = bool.Parse("False");
                columnBankReference.IsNullable = bool.Parse("True");
                columnBankReference.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnBankReference);



                TableColumn columnDV = new TableColumn();
                columnDV.ColumnName = "DV";
                columnDV.MaxLength = 5;
                columnDV.AutoIncrement = bool.Parse("False");
                columnDV.IsNullable = bool.Parse("True");
                columnDV.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnDV);



                TableColumn columnGorilaOfficeId = new TableColumn();
                columnGorilaOfficeId.ColumnName = "GorilaOfficeId";
                columnGorilaOfficeId.MaxLength = 4;
                columnGorilaOfficeId.AutoIncrement = bool.Parse("False");
                columnGorilaOfficeId.IsNullable = bool.Parse("True");
                columnGorilaOfficeId.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnGorilaOfficeId);



                TableColumn columnGorilaBankId = new TableColumn();
                columnGorilaBankId.ColumnName = "GorilaBankId";
                columnGorilaBankId.MaxLength = 4;
                columnGorilaBankId.AutoIncrement = bool.Parse("False");
                columnGorilaBankId.IsNullable = bool.Parse("True");
                columnGorilaBankId.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnGorilaBankId);



                return columnSpecs;

            }

            public static TableColumn FranchiseeIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn FiscalDetailIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn NameColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn IsPrimaryColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn RfcColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn GorilaKeyColumn
            {
                get
                {
                    return columns[5];
                }
            }

            public static TableColumn AddressColumn
            {
                get
                {
                    return columns[6];
                }
            }

            public static TableColumn PhoneColumn
            {
                get
                {
                    return columns[7];
                }
            }

            public static TableColumn CellPhoneColumn
            {
                get
                {
                    return columns[8];
                }
            }

            public static TableColumn EmailColumn
            {
                get
                {
                    return columns[9];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[10];
                }
            }

            public static TableColumn ShareLevelIdColumn
            {
                get
                {
                    return columns[11];
                }
            }

            public static TableColumn MunicipioIdColumn
            {
                get
                {
                    return columns[12];
                }
            }

            public static TableColumn ExternalKeyColumn
            {
                get
                {
                    return columns[13];
                }
            }

            public static TableColumn BankReferenceColumn
            {
                get
                {
                    return columns[14];
                }
            }

            public static TableColumn DVColumn
            {
                get
                {
                    return columns[15];
                }
            }

            public static TableColumn GorilaOfficeIdColumn
            {
                get
                {
                    return columns[16];
                }
            }

            public static TableColumn GorilaBankIdColumn
            {
                get
                {
                    return columns[17];
                }
            }



        }

        public struct ColumnNames
        {
            public static string FranchiseeId = @"FranchiseeId";
            public static string FiscalDetailId = @"FiscalDetailId";
            public static string Name = @"Name";
            public static string IsPrimary = @"IsPrimary";
            public static string Rfc = @"Rfc";
            public static string GorilaKey = @"GorilaKey";
            public static string Address = @"Address";
            public static string Phone = @"Phone";
            public static string CellPhone = @"CellPhone";
            public static string Email = @"Email";
            public static string Deleted = @"Deleted";
            public static string ShareLevelId = @"ShareLevelId";
            public static string MunicipioId = @"MunicipioId";
            public static string ExternalKey = @"ExternalKey";
            public static string BankReference = @"BankReference";
            public static string DV = @"DV";
            public static string GorilaOfficeId = @"GorilaOfficeId";
            public static string GorilaBankId = @"GorilaBankId";

        }

    }



    public partial class Gallery
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Gallery" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Gallery" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnGalleryId = new TableColumn();
                columnGalleryId.ColumnName = "GalleryId";
                columnGalleryId.MaxLength = 4;
                columnGalleryId.AutoIncrement = bool.Parse("True");
                columnGalleryId.IsNullable = bool.Parse("False");
                columnGalleryId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnGalleryId);



                TableColumn columnAdvertiserId = new TableColumn();
                columnAdvertiserId.ColumnName = "AdvertiserId";
                columnAdvertiserId.MaxLength = 4;
                columnAdvertiserId.AutoIncrement = bool.Parse("False");
                columnAdvertiserId.IsNullable = bool.Parse("False");
                columnAdvertiserId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAdvertiserId);



                TableColumn columnName = new TableColumn();
                columnName.ColumnName = "Name";
                columnName.MaxLength = 200;
                columnName.AutoIncrement = bool.Parse("False");
                columnName.IsNullable = bool.Parse("False");
                columnName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnName);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                TableColumn columnFranchiseeId = new TableColumn();
                columnFranchiseeId.ColumnName = "FranchiseeId";
                columnFranchiseeId.MaxLength = 4;
                columnFranchiseeId.AutoIncrement = bool.Parse("False");
                columnFranchiseeId.IsNullable = bool.Parse("False");
                columnFranchiseeId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFranchiseeId);



                return columnSpecs;

            }

            public static TableColumn GalleryIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn AdvertiserIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn NameColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn FranchiseeIdColumn
            {
                get
                {
                    return columns[4];
                }
            }



        }

        public struct ColumnNames
        {
            public static string GalleryId = @"GalleryId";
            public static string AdvertiserId = @"AdvertiserId";
            public static string Name = @"Name";
            public static string Deleted = @"Deleted";
            public static string FranchiseeId = @"FranchiseeId";

        }

    }



    public partial class GeneralSetUp
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "GeneralSetUp" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "GeneralSetUp" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnGeneralSetUpId = new TableColumn();
                columnGeneralSetUpId.ColumnName = "GeneralSetUpId";
                columnGeneralSetUpId.MaxLength = 4;
                columnGeneralSetUpId.AutoIncrement = bool.Parse("True");
                columnGeneralSetUpId.IsNullable = bool.Parse("False");
                columnGeneralSetUpId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnGeneralSetUpId);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                TableColumn columnFrontPageMarkup = new TableColumn();
                columnFrontPageMarkup.ColumnName = "FrontPageMarkup";
                columnFrontPageMarkup.MaxLength = 2147483647;
                columnFrontPageMarkup.AutoIncrement = bool.Parse("False");
                columnFrontPageMarkup.IsNullable = bool.Parse("True");
                columnFrontPageMarkup.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnFrontPageMarkup);



                TableColumn columnFrontPageMarkupIphone = new TableColumn();
                columnFrontPageMarkupIphone.ColumnName = "FrontPageMarkupIphone";
                columnFrontPageMarkupIphone.MaxLength = 2147483647;
                columnFrontPageMarkupIphone.AutoIncrement = bool.Parse("False");
                columnFrontPageMarkupIphone.IsNullable = bool.Parse("True");
                columnFrontPageMarkupIphone.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnFrontPageMarkupIphone);



                TableColumn columnFranchiseeMarkup = new TableColumn();
                columnFranchiseeMarkup.ColumnName = "FranchiseeMarkup";
                columnFranchiseeMarkup.MaxLength = 2147483647;
                columnFranchiseeMarkup.AutoIncrement = bool.Parse("False");
                columnFranchiseeMarkup.IsNullable = bool.Parse("True");
                columnFranchiseeMarkup.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnFranchiseeMarkup);



                TableColumn columnAdvertiserMarkup = new TableColumn();
                columnAdvertiserMarkup.ColumnName = "AdvertiserMarkup";
                columnAdvertiserMarkup.MaxLength = 2147483647;
                columnAdvertiserMarkup.AutoIncrement = bool.Parse("False");
                columnAdvertiserMarkup.IsNullable = bool.Parse("True");
                columnAdvertiserMarkup.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnAdvertiserMarkup);



                return columnSpecs;

            }

            public static TableColumn GeneralSetUpIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn FrontPageMarkupColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn FrontPageMarkupIphoneColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn FranchiseeMarkupColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn AdvertiserMarkupColumn
            {
                get
                {
                    return columns[5];
                }
            }



        }

        public struct ColumnNames
        {
            public static string GeneralSetUpId = @"GeneralSetUpId";
            public static string Deleted = @"Deleted";
            public static string FrontPageMarkup = @"FrontPageMarkup";
            public static string FrontPageMarkupIphone = @"FrontPageMarkupIphone";
            public static string FranchiseeMarkup = @"FranchiseeMarkup";
            public static string AdvertiserMarkup = @"AdvertiserMarkup";

        }

    }



    public partial class GenPublicity
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "GenPublicity" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "GenPublicity" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnGenPublicityId = new TableColumn();
                columnGenPublicityId.ColumnName = "GenPublicityId";
                columnGenPublicityId.MaxLength = 4;
                columnGenPublicityId.AutoIncrement = bool.Parse("True");
                columnGenPublicityId.IsNullable = bool.Parse("False");
                columnGenPublicityId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnGenPublicityId);



                TableColumn columnGeneralSetUpId = new TableColumn();
                columnGeneralSetUpId.ColumnName = "GeneralSetUpId";
                columnGeneralSetUpId.MaxLength = 4;
                columnGeneralSetUpId.AutoIncrement = bool.Parse("False");
                columnGeneralSetUpId.IsNullable = bool.Parse("False");
                columnGeneralSetUpId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnGeneralSetUpId);



                TableColumn columnName = new TableColumn();
                columnName.ColumnName = "Name";
                columnName.MaxLength = 50;
                columnName.AutoIncrement = bool.Parse("False");
                columnName.IsNullable = bool.Parse("False");
                columnName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnName);



                TableColumn columnDescription = new TableColumn();
                columnDescription.ColumnName = "Description";
                columnDescription.MaxLength = 150;
                columnDescription.AutoIncrement = bool.Parse("False");
                columnDescription.IsNullable = bool.Parse("False");
                columnDescription.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDescription);



                TableColumn columnPublicityFile = new TableColumn();
                columnPublicityFile.ColumnName = "PublicityFile";
                columnPublicityFile.MaxLength = 256;
                columnPublicityFile.AutoIncrement = bool.Parse("False");
                columnPublicityFile.IsNullable = bool.Parse("False");
                columnPublicityFile.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPublicityFile);



                TableColumn columnAvailable = new TableColumn();
                columnAvailable.ColumnName = "Available";
                columnAvailable.MaxLength = 1;
                columnAvailable.AutoIncrement = bool.Parse("False");
                columnAvailable.IsNullable = bool.Parse("False");
                columnAvailable.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAvailable);



                TableColumn columnFromDate = new TableColumn();
                columnFromDate.ColumnName = "FromDate";
                columnFromDate.MaxLength = 8;
                columnFromDate.AutoIncrement = bool.Parse("False");
                columnFromDate.IsNullable = bool.Parse("False");
                columnFromDate.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFromDate);



                TableColumn columnToDate = new TableColumn();
                columnToDate.ColumnName = "ToDate";
                columnToDate.MaxLength = 8;
                columnToDate.AutoIncrement = bool.Parse("False");
                columnToDate.IsNullable = bool.Parse("True");
                columnToDate.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnToDate);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                return columnSpecs;

            }

            public static TableColumn GenPublicityIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn GeneralSetUpIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn NameColumn
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

            public static TableColumn PublicityFileColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn AvailableColumn
            {
                get
                {
                    return columns[5];
                }
            }

            public static TableColumn FromDateColumn
            {
                get
                {
                    return columns[6];
                }
            }

            public static TableColumn ToDateColumn
            {
                get
                {
                    return columns[7];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[8];
                }
            }



        }

        public struct ColumnNames
        {
            public static string GenPublicityId = @"GenPublicityId";
            public static string GeneralSetUpId = @"GeneralSetUpId";
            public static string Name = @"Name";
            public static string Description = @"Description";
            public static string PublicityFile = @"PublicityFile";
            public static string Available = @"Available";
            public static string FromDate = @"FromDate";
            public static string ToDate = @"ToDate";
            public static string Deleted = @"Deleted";

        }

    }



    public partial class Municipio
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Municipio" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Municipio" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnMunicipioId = new TableColumn();
                columnMunicipioId.ColumnName = "MunicipioId";
                columnMunicipioId.MaxLength = 4;
                columnMunicipioId.AutoIncrement = bool.Parse("True");
                columnMunicipioId.IsNullable = bool.Parse("False");
                columnMunicipioId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnMunicipioId);



                TableColumn columnEstadoId = new TableColumn();
                columnEstadoId.ColumnName = "EstadoId";
                columnEstadoId.MaxLength = 4;
                columnEstadoId.AutoIncrement = bool.Parse("False");
                columnEstadoId.IsNullable = bool.Parse("False");
                columnEstadoId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnEstadoId);



                TableColumn columnName = new TableColumn();
                columnName.ColumnName = "Name";
                columnName.MaxLength = 500;
                columnName.AutoIncrement = bool.Parse("False");
                columnName.IsNullable = bool.Parse("False");
                columnName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnName);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                return columnSpecs;

            }

            public static TableColumn MunicipioIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn EstadoIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn NameColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[3];
                }
            }



        }

        public struct ColumnNames
        {
            public static string MunicipioId = @"MunicipioId";
            public static string EstadoId = @"EstadoId";
            public static string Name = @"Name";
            public static string Deleted = @"Deleted";

        }

    }



    public partial class Office
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Office" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Office" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnOfficeId = new TableColumn();
                columnOfficeId.ColumnName = "OfficeId";
                columnOfficeId.MaxLength = 4;
                columnOfficeId.AutoIncrement = bool.Parse("True");
                columnOfficeId.IsNullable = bool.Parse("False");
                columnOfficeId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnOfficeId);



                TableColumn columnAdvertiserId = new TableColumn();
                columnAdvertiserId.ColumnName = "AdvertiserId";
                columnAdvertiserId.MaxLength = 4;
                columnAdvertiserId.AutoIncrement = bool.Parse("False");
                columnAdvertiserId.IsNullable = bool.Parse("False");
                columnAdvertiserId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAdvertiserId);



                TableColumn columnCityId = new TableColumn();
                columnCityId.ColumnName = "CityId";
                columnCityId.MaxLength = 4;
                columnCityId.AutoIncrement = bool.Parse("False");
                columnCityId.IsNullable = bool.Parse("False");
                columnCityId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCityId);



                TableColumn columnName = new TableColumn();
                columnName.ColumnName = "Name";
                columnName.MaxLength = 50;
                columnName.AutoIncrement = bool.Parse("False");
                columnName.IsNullable = bool.Parse("False");
                columnName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnName);



                TableColumn columnAddress = new TableColumn();
                columnAddress.ColumnName = "Address";
                columnAddress.MaxLength = 200;
                columnAddress.AutoIncrement = bool.Parse("False");
                columnAddress.IsNullable = bool.Parse("False");
                columnAddress.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAddress);



                TableColumn columnMapReferenceX = new TableColumn();
                columnMapReferenceX.ColumnName = "MapReferenceX";
                columnMapReferenceX.MaxLength = 8;
                columnMapReferenceX.AutoIncrement = bool.Parse("False");
                columnMapReferenceX.IsNullable = bool.Parse("True");
                columnMapReferenceX.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnMapReferenceX);



                TableColumn columnMapReferenceY = new TableColumn();
                columnMapReferenceY.ColumnName = "MapReferenceY";
                columnMapReferenceY.MaxLength = 8;
                columnMapReferenceY.AutoIncrement = bool.Parse("False");
                columnMapReferenceY.IsNullable = bool.Parse("True");
                columnMapReferenceY.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnMapReferenceY);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                TableColumn columnFranchiseeId = new TableColumn();
                columnFranchiseeId.ColumnName = "FranchiseeId";
                columnFranchiseeId.MaxLength = 4;
                columnFranchiseeId.AutoIncrement = bool.Parse("False");
                columnFranchiseeId.IsNullable = bool.Parse("False");
                columnFranchiseeId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFranchiseeId);



                TableColumn columnMunicipioId = new TableColumn();
                columnMunicipioId.ColumnName = "MunicipioId";
                columnMunicipioId.MaxLength = 4;
                columnMunicipioId.AutoIncrement = bool.Parse("False");
                columnMunicipioId.IsNullable = bool.Parse("False");
                columnMunicipioId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnMunicipioId);



                TableColumn columnNumber = new TableColumn();
                columnNumber.ColumnName = "Number";
                columnNumber.MaxLength = 20;
                columnNumber.AutoIncrement = bool.Parse("False");
                columnNumber.IsNullable = bool.Parse("True");
                columnNumber.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnNumber);



                TableColumn columnZipCode = new TableColumn();
                columnZipCode.ColumnName = "ZipCode";
                columnZipCode.MaxLength = 10;
                columnZipCode.AutoIncrement = bool.Parse("False");
                columnZipCode.IsNullable = bool.Parse("True");
                columnZipCode.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnZipCode);



                TableColumn columnNeibornhod = new TableColumn();
                columnNeibornhod.ColumnName = "Neibornhod";
                columnNeibornhod.MaxLength = 50;
                columnNeibornhod.AutoIncrement = bool.Parse("False");
                columnNeibornhod.IsNullable = bool.Parse("True");
                columnNeibornhod.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnNeibornhod);



                TableColumn columnFeatured = new TableColumn();
                columnFeatured.ColumnName = "Featured";
                columnFeatured.MaxLength = 1;
                columnFeatured.AutoIncrement = bool.Parse("False");
                columnFeatured.IsNullable = bool.Parse("False");
                columnFeatured.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFeatured);



                return columnSpecs;

            }

            public static TableColumn OfficeIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn AdvertiserIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn CityIdColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn NameColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn AddressColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn MapReferenceXColumn
            {
                get
                {
                    return columns[5];
                }
            }

            public static TableColumn MapReferenceYColumn
            {
                get
                {
                    return columns[6];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[7];
                }
            }

            public static TableColumn FranchiseeIdColumn
            {
                get
                {
                    return columns[8];
                }
            }

            public static TableColumn MunicipioIdColumn
            {
                get
                {
                    return columns[9];
                }
            }

            public static TableColumn NumberColumn
            {
                get
                {
                    return columns[10];
                }
            }

            public static TableColumn ZipCodeColumn
            {
                get
                {
                    return columns[11];
                }
            }

            public static TableColumn NeibornhodColumn
            {
                get
                {
                    return columns[12];
                }
            }

            public static TableColumn FeaturedColumn
            {
                get
                {
                    return columns[13];
                }
            }



        }

        public struct ColumnNames
        {
            public static string OfficeId = @"OfficeId";
            public static string AdvertiserId = @"AdvertiserId";
            public static string CityId = @"CityId";
            public static string Name = @"Name";
            public static string Address = @"Address";
            public static string MapReferenceX = @"MapReferenceX";
            public static string MapReferenceY = @"MapReferenceY";
            public static string Deleted = @"Deleted";
            public static string FranchiseeId = @"FranchiseeId";
            public static string MunicipioId = @"MunicipioId";
            public static string Number = @"Number";
            public static string ZipCode = @"ZipCode";
            public static string Neibornhod = @"Neibornhod";
            public static string Featured = @"Featured";

        }

    }



    public partial class Page
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Page" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Page" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnPageId = new TableColumn();
                columnPageId.ColumnName = "PageId";
                columnPageId.MaxLength = 4;
                columnPageId.AutoIncrement = bool.Parse("True");
                columnPageId.IsNullable = bool.Parse("False");
                columnPageId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPageId);



                TableColumn columnNumber = new TableColumn();
                columnNumber.ColumnName = "Number";
                columnNumber.MaxLength = 4;
                columnNumber.AutoIncrement = bool.Parse("False");
                columnNumber.IsNullable = bool.Parse("False");
                columnNumber.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnNumber);



                TableColumn columnSyncNumber = new TableColumn();
                columnSyncNumber.ColumnName = "SyncNumber";
                columnSyncNumber.MaxLength = 4;
                columnSyncNumber.AutoIncrement = bool.Parse("False");
                columnSyncNumber.IsNullable = bool.Parse("False");
                columnSyncNumber.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnSyncNumber);



                TableColumn columnSyncDate = new TableColumn();
                columnSyncDate.ColumnName = "SyncDate";
                columnSyncDate.MaxLength = 8;
                columnSyncDate.AutoIncrement = bool.Parse("False");
                columnSyncDate.IsNullable = bool.Parse("True");
                columnSyncDate.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnSyncDate);



                TableColumn columnCreatedOn = new TableColumn();
                columnCreatedOn.ColumnName = "CreatedOn";
                columnCreatedOn.MaxLength = 8;
                columnCreatedOn.AutoIncrement = bool.Parse("False");
                columnCreatedOn.IsNullable = bool.Parse("False");
                columnCreatedOn.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnCreatedOn);



                TableColumn columnModiefiedOn = new TableColumn();
                columnModiefiedOn.ColumnName = "ModiefiedOn";
                columnModiefiedOn.MaxLength = 8;
                columnModiefiedOn.AutoIncrement = bool.Parse("False");
                columnModiefiedOn.IsNullable = bool.Parse("True");
                columnModiefiedOn.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnModiefiedOn);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                return columnSpecs;

            }

            public static TableColumn PageIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn NumberColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn SyncNumberColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn SyncDateColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn CreatedOnColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn ModiefiedOnColumn
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
            public static string PageId = @"PageId";
            public static string Number = @"Number";
            public static string SyncNumber = @"SyncNumber";
            public static string SyncDate = @"SyncDate";
            public static string CreatedOn = @"CreatedOn";
            public static string ModiefiedOn = @"ModiefiedOn";
            public static string Deleted = @"Deleted";

        }

    }



    public partial class Personal
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Personal" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Personal" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnPersonalId = new TableColumn();
                columnPersonalId.ColumnName = "PersonalId";
                columnPersonalId.MaxLength = 4;
                columnPersonalId.AutoIncrement = bool.Parse("True");
                columnPersonalId.IsNullable = bool.Parse("False");
                columnPersonalId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPersonalId);



                TableColumn columnName = new TableColumn();
                columnName.ColumnName = "Name";
                columnName.MaxLength = 30;
                columnName.AutoIncrement = bool.Parse("False");
                columnName.IsNullable = bool.Parse("False");
                columnName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnName);



                TableColumn columnFranchiseeId = new TableColumn();
                columnFranchiseeId.ColumnName = "FranchiseeId";
                columnFranchiseeId.MaxLength = 4;
                columnFranchiseeId.AutoIncrement = bool.Parse("False");
                columnFranchiseeId.IsNullable = bool.Parse("False");
                columnFranchiseeId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFranchiseeId);



                TableColumn columnUserId = new TableColumn();
                columnUserId.ColumnName = "UserId";
                columnUserId.MaxLength = 16;
                columnUserId.AutoIncrement = bool.Parse("False");
                columnUserId.IsNullable = bool.Parse("True");
                columnUserId.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnUserId);



                TableColumn columnPersonalTypeId = new TableColumn();
                columnPersonalTypeId.ColumnName = "PersonalTypeId";
                columnPersonalTypeId.MaxLength = 4;
                columnPersonalTypeId.AutoIncrement = bool.Parse("False");
                columnPersonalTypeId.IsNullable = bool.Parse("False");
                columnPersonalTypeId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPersonalTypeId);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                return columnSpecs;

            }

            public static TableColumn PersonalIdColumn
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

            public static TableColumn FranchiseeIdColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn UserIdColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn PersonalTypeIdColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[5];
                }
            }



        }

        public struct ColumnNames
        {
            public static string PersonalId = @"PersonalId";
            public static string Name = @"Name";
            public static string FranchiseeId = @"FranchiseeId";
            public static string UserId = @"UserId";
            public static string PersonalTypeId = @"PersonalTypeId";
            public static string Deleted = @"Deleted";

        }

    }



    public partial class PersonalType
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "PersonalType" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "PersonalType" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnPersonalTypeId = new TableColumn();
                columnPersonalTypeId.ColumnName = "PersonalTypeId";
                columnPersonalTypeId.MaxLength = 4;
                columnPersonalTypeId.AutoIncrement = bool.Parse("True");
                columnPersonalTypeId.IsNullable = bool.Parse("False");
                columnPersonalTypeId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPersonalTypeId);



                TableColumn columnDescription = new TableColumn();
                columnDescription.ColumnName = "Description";
                columnDescription.MaxLength = 30;
                columnDescription.AutoIncrement = bool.Parse("False");
                columnDescription.IsNullable = bool.Parse("False");
                columnDescription.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDescription);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                return columnSpecs;

            }

            public static TableColumn PersonalTypeIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn DescriptionColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[2];
                }
            }



        }

        public struct ColumnNames
        {
            public static string PersonalTypeId = @"PersonalTypeId";
            public static string Description = @"Description";
            public static string Deleted = @"Deleted";

        }

    }



    public partial class Phone
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Phone" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Phone" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnPhoneId = new TableColumn();
                columnPhoneId.ColumnName = "PhoneId";
                columnPhoneId.MaxLength = 4;
                columnPhoneId.AutoIncrement = bool.Parse("True");
                columnPhoneId.IsNullable = bool.Parse("False");
                columnPhoneId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPhoneId);



                TableColumn columnAdvertiserId = new TableColumn();
                columnAdvertiserId.ColumnName = "AdvertiserId";
                columnAdvertiserId.MaxLength = 4;
                columnAdvertiserId.AutoIncrement = bool.Parse("False");
                columnAdvertiserId.IsNullable = bool.Parse("False");
                columnAdvertiserId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAdvertiserId);



                TableColumn columnPhoneTypeId = new TableColumn();
                columnPhoneTypeId.ColumnName = "PhoneTypeId";
                columnPhoneTypeId.MaxLength = 4;
                columnPhoneTypeId.AutoIncrement = bool.Parse("False");
                columnPhoneTypeId.IsNullable = bool.Parse("False");
                columnPhoneTypeId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPhoneTypeId);



                TableColumn columnPhoneNumber = new TableColumn();
                columnPhoneNumber.ColumnName = "PhoneNumber";
                columnPhoneNumber.MaxLength = 50;
                columnPhoneNumber.AutoIncrement = bool.Parse("False");
                columnPhoneNumber.IsNullable = bool.Parse("False");
                columnPhoneNumber.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPhoneNumber);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                TableColumn columnFranchiseeId = new TableColumn();
                columnFranchiseeId.ColumnName = "FranchiseeId";
                columnFranchiseeId.MaxLength = 4;
                columnFranchiseeId.AutoIncrement = bool.Parse("False");
                columnFranchiseeId.IsNullable = bool.Parse("False");
                columnFranchiseeId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFranchiseeId);



                return columnSpecs;

            }

            public static TableColumn PhoneIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn AdvertiserIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn PhoneTypeIdColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn PhoneNumberColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[4];
                }
            }

            public static TableColumn FranchiseeIdColumn
            {
                get
                {
                    return columns[5];
                }
            }



        }

        public struct ColumnNames
        {
            public static string PhoneId = @"PhoneId";
            public static string AdvertiserId = @"AdvertiserId";
            public static string PhoneTypeId = @"PhoneTypeId";
            public static string PhoneNumber = @"PhoneNumber";
            public static string Deleted = @"Deleted";
            public static string FranchiseeId = @"FranchiseeId";

        }

    }



    public partial class PhoneType
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "PhoneType" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "PhoneType" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnPhoneTypeId = new TableColumn();
                columnPhoneTypeId.ColumnName = "PhoneTypeId";
                columnPhoneTypeId.MaxLength = 4;
                columnPhoneTypeId.AutoIncrement = bool.Parse("True");
                columnPhoneTypeId.IsNullable = bool.Parse("False");
                columnPhoneTypeId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPhoneTypeId);



                TableColumn columnName = new TableColumn();
                columnName.ColumnName = "Name";
                columnName.MaxLength = 20;
                columnName.AutoIncrement = bool.Parse("False");
                columnName.IsNullable = bool.Parse("True");
                columnName.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnName);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                return columnSpecs;

            }

            public static TableColumn PhoneTypeIdColumn
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

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[2];
                }
            }



        }

        public struct ColumnNames
        {
            public static string PhoneTypeId = @"PhoneTypeId";
            public static string Name = @"Name";
            public static string Deleted = @"Deleted";

        }

    }



    public partial class Picture
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Picture" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Picture" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnPictureId = new TableColumn();
                columnPictureId.ColumnName = "PictureId";
                columnPictureId.MaxLength = 4;
                columnPictureId.AutoIncrement = bool.Parse("True");
                columnPictureId.IsNullable = bool.Parse("False");
                columnPictureId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPictureId);



                TableColumn columnGalleryId = new TableColumn();
                columnGalleryId.ColumnName = "GalleryId";
                columnGalleryId.MaxLength = 4;
                columnGalleryId.AutoIncrement = bool.Parse("False");
                columnGalleryId.IsNullable = bool.Parse("False");
                columnGalleryId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnGalleryId);



                TableColumn columnDescription = new TableColumn();
                columnDescription.ColumnName = "Description";
                columnDescription.MaxLength = 200;
                columnDescription.AutoIncrement = bool.Parse("False");
                columnDescription.IsNullable = bool.Parse("True");
                columnDescription.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnDescription);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                TableColumn columnFranchiseeId = new TableColumn();
                columnFranchiseeId.ColumnName = "FranchiseeId";
                columnFranchiseeId.MaxLength = 4;
                columnFranchiseeId.AutoIncrement = bool.Parse("False");
                columnFranchiseeId.IsNullable = bool.Parse("False");
                columnFranchiseeId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFranchiseeId);



                return columnSpecs;

            }

            public static TableColumn PictureIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn GalleryIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn DescriptionColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn FranchiseeIdColumn
            {
                get
                {
                    return columns[4];
                }
            }



        }

        public struct ColumnNames
        {
            public static string PictureId = @"PictureId";
            public static string GalleryId = @"GalleryId";
            public static string Description = @"Description";
            public static string Deleted = @"Deleted";
            public static string FranchiseeId = @"FranchiseeId";

        }

    }



    public partial class ShareLevel
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "ShareLevel" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "ShareLevel" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnShareLevelId = new TableColumn();
                columnShareLevelId.ColumnName = "ShareLevelId";
                columnShareLevelId.MaxLength = 4;
                columnShareLevelId.AutoIncrement = bool.Parse("True");
                columnShareLevelId.IsNullable = bool.Parse("False");
                columnShareLevelId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnShareLevelId);



                TableColumn columnDescription = new TableColumn();
                columnDescription.ColumnName = "Description";
                columnDescription.MaxLength = 30;
                columnDescription.AutoIncrement = bool.Parse("False");
                columnDescription.IsNullable = bool.Parse("False");
                columnDescription.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDescription);



                TableColumn columnPercentage = new TableColumn();
                columnPercentage.ColumnName = "Percentage";
                columnPercentage.MaxLength = 4;
                columnPercentage.AutoIncrement = bool.Parse("False");
                columnPercentage.IsNullable = bool.Parse("False");
                columnPercentage.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnPercentage);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                return columnSpecs;

            }

            public static TableColumn ShareLevelIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn DescriptionColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn PercentageColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[3];
                }
            }



        }

        public struct ColumnNames
        {
            public static string ShareLevelId = @"ShareLevelId";
            public static string Description = @"Description";
            public static string Percentage = @"Percentage";
            public static string Deleted = @"Deleted";

        }

    }



    public partial class SqliteUpdate
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "SqliteUpdate" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "SqliteUpdate" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnSqliteUpdateId = new TableColumn();
                columnSqliteUpdateId.ColumnName = "SqliteUpdateId";
                columnSqliteUpdateId.MaxLength = 4;
                columnSqliteUpdateId.AutoIncrement = bool.Parse("True");
                columnSqliteUpdateId.IsNullable = bool.Parse("False");
                columnSqliteUpdateId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnSqliteUpdateId);



                TableColumn columnUpdateDate = new TableColumn();
                columnUpdateDate.ColumnName = "UpdateDate";
                columnUpdateDate.MaxLength = 8;
                columnUpdateDate.AutoIncrement = bool.Parse("False");
                columnUpdateDate.IsNullable = bool.Parse("False");
                columnUpdateDate.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnUpdateDate);



                TableColumn columnActiveRecords = new TableColumn();
                columnActiveRecords.ColumnName = "ActiveRecords";
                columnActiveRecords.MaxLength = 4;
                columnActiveRecords.AutoIncrement = bool.Parse("False");
                columnActiveRecords.IsNullable = bool.Parse("False");
                columnActiveRecords.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnActiveRecords);



                TableColumn columnAndroidRecords = new TableColumn();
                columnAndroidRecords.ColumnName = "AndroidRecords";
                columnAndroidRecords.MaxLength = 4;
                columnAndroidRecords.AutoIncrement = bool.Parse("False");
                columnAndroidRecords.IsNullable = bool.Parse("False");
                columnAndroidRecords.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAndroidRecords);



                return columnSpecs;

            }

            public static TableColumn SqliteUpdateIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn UpdateDateColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn ActiveRecordsColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn AndroidRecordsColumn
            {
                get
                {
                    return columns[3];
                }
            }



        }

        public struct ColumnNames
        {
            public static string SqliteUpdateId = @"SqliteUpdateId";
            public static string UpdateDate = @"UpdateDate";
            public static string ActiveRecords = @"ActiveRecords";
            public static string AndroidRecords = @"AndroidRecords";

        }

    }



    public partial class Status
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Status" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Status" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnStatusId = new TableColumn();
                columnStatusId.ColumnName = "StatusId";
                columnStatusId.MaxLength = 4;
                columnStatusId.AutoIncrement = bool.Parse("True");
                columnStatusId.IsNullable = bool.Parse("False");
                columnStatusId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnStatusId);



                TableColumn columnName = new TableColumn();
                columnName.ColumnName = "Name";
                columnName.MaxLength = 50;
                columnName.AutoIncrement = bool.Parse("False");
                columnName.IsNullable = bool.Parse("False");
                columnName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnName);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                TableColumn columnDisplayName = new TableColumn();
                columnDisplayName.ColumnName = "DisplayName";
                columnDisplayName.MaxLength = 50;
                columnDisplayName.AutoIncrement = bool.Parse("False");
                columnDisplayName.IsNullable = bool.Parse("False");
                columnDisplayName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDisplayName);



                return columnSpecs;

            }

            public static TableColumn StatusIdColumn
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

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn DisplayNameColumn
            {
                get
                {
                    return columns[3];
                }
            }



        }

        public struct ColumnNames
        {
            public static string StatusId = @"StatusId";
            public static string Name = @"Name";
            public static string Deleted = @"Deleted";
            public static string DisplayName = @"DisplayName";

        }

    }



    public partial class sysdiagrams
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "sysdiagrams" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "sysdiagrams" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnname = new TableColumn();
                columnname.ColumnName = "name";
                columnname.MaxLength = 128;
                columnname.AutoIncrement = bool.Parse("False");
                columnname.IsNullable = bool.Parse("False");
                columnname.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnname);



                TableColumn columnprincipal_id = new TableColumn();
                columnprincipal_id.ColumnName = "principal_id";
                columnprincipal_id.MaxLength = 4;
                columnprincipal_id.AutoIncrement = bool.Parse("False");
                columnprincipal_id.IsNullable = bool.Parse("False");
                columnprincipal_id.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnprincipal_id);



                TableColumn columndiagram_id = new TableColumn();
                columndiagram_id.ColumnName = "diagram_id";
                columndiagram_id.MaxLength = 4;
                columndiagram_id.AutoIncrement = bool.Parse("True");
                columndiagram_id.IsNullable = bool.Parse("False");
                columndiagram_id.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columndiagram_id);



                TableColumn columnversion = new TableColumn();
                columnversion.ColumnName = "version";
                columnversion.MaxLength = 4;
                columnversion.AutoIncrement = bool.Parse("False");
                columnversion.IsNullable = bool.Parse("True");
                columnversion.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columnversion);



                TableColumn columndefinition = new TableColumn();
                columndefinition.ColumnName = "definition";
                columndefinition.MaxLength = 2147483647;
                columndefinition.AutoIncrement = bool.Parse("False");
                columndefinition.IsNullable = bool.Parse("True");
                columndefinition.IsPrimaryKey = bool.Parse("True");
                columnSpecs.Add(columndefinition);



                return columnSpecs;

            }

            public static TableColumn nameColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn principal_idColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn diagram_idColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn versionColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn definitionColumn
            {
                get
                {
                    return columns[4];
                }
            }



        }

        public struct ColumnNames
        {
            public static string name = @"name";
            public static string principal_id = @"principal_id";
            public static string diagram_id = @"diagram_id";
            public static string version = @"version";
            public static string definition = @"definition";

        }

    }



    public partial class Tag
    {
        public static TableInfo SchemaInfo = new TableInfo() { TableName = "Tag" };

        public static class Columns
        {

            private static List<TableColumn> columns = GetSchema();

            private static TableInfo tableInfo;

            public static List<TableColumn> GetSchema()
            {
                Columns.tableInfo = new TableInfo() { TableName = "Tag" };

                List<TableColumn> columnSpecs = new List<TableColumn>();



                TableColumn columnTagId = new TableColumn();
                columnTagId.ColumnName = "TagId";
                columnTagId.MaxLength = 4;
                columnTagId.AutoIncrement = bool.Parse("True");
                columnTagId.IsNullable = bool.Parse("False");
                columnTagId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnTagId);



                TableColumn columnAdvertiserId = new TableColumn();
                columnAdvertiserId.ColumnName = "AdvertiserId";
                columnAdvertiserId.MaxLength = 4;
                columnAdvertiserId.AutoIncrement = bool.Parse("False");
                columnAdvertiserId.IsNullable = bool.Parse("False");
                columnAdvertiserId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnAdvertiserId);



                TableColumn columnName = new TableColumn();
                columnName.ColumnName = "Name";
                columnName.MaxLength = 50;
                columnName.AutoIncrement = bool.Parse("False");
                columnName.IsNullable = bool.Parse("False");
                columnName.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnName);



                TableColumn columnDeleted = new TableColumn();
                columnDeleted.ColumnName = "Deleted";
                columnDeleted.MaxLength = 1;
                columnDeleted.AutoIncrement = bool.Parse("False");
                columnDeleted.IsNullable = bool.Parse("False");
                columnDeleted.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnDeleted);



                TableColumn columnFranchiseeId = new TableColumn();
                columnFranchiseeId.ColumnName = "FranchiseeId";
                columnFranchiseeId.MaxLength = 4;
                columnFranchiseeId.AutoIncrement = bool.Parse("False");
                columnFranchiseeId.IsNullable = bool.Parse("False");
                columnFranchiseeId.IsPrimaryKey = bool.Parse("False");
                columnSpecs.Add(columnFranchiseeId);



                return columnSpecs;

            }

            public static TableColumn TagIdColumn
            {
                get
                {
                    return columns[0];
                }
            }

            public static TableColumn AdvertiserIdColumn
            {
                get
                {
                    return columns[1];
                }
            }

            public static TableColumn NameColumn
            {
                get
                {
                    return columns[2];
                }
            }

            public static TableColumn DeletedColumn
            {
                get
                {
                    return columns[3];
                }
            }

            public static TableColumn FranchiseeIdColumn
            {
                get
                {
                    return columns[4];
                }
            }



        }

        public struct ColumnNames
        {
            public static string TagId = @"TagId";
            public static string AdvertiserId = @"AdvertiserId";
            public static string Name = @"Name";
            public static string Deleted = @"Deleted";
            public static string FranchiseeId = @"FranchiseeId";

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
