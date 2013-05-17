using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bsx.DirLaguna.CommonWeb.Enum;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.CommonWeb.Session
{
    public class SessionValues
    {
        private static SessionProperty<Guid> userId;

        public static Guid UserId
        {
            get
            {
                if (userId == null)
                    userId = new SessionProperty<Guid>("UserId", Guid.NewGuid());

                return userId.Value;
            }
            set
            {
                if (userId == null)
                    userId = new SessionProperty<Guid>("UserId", Guid.NewGuid());

                userId.Value = value;
            }
        }

        private static SessionProperty<string> userName;

        public static string UserName
        {
            get
            {
                if (userName == null)
                    userName = new SessionProperty<string>(string.Empty, null);
                return userName.Value;
            }
            set
            {
                if (userName == null)
                    userName = new SessionProperty<string>(string.Empty, null);
                userName.Value = value;
            }
        }

        private static SessionProperty<IList<string>> lastMessages;

        public static IList<string> LastMessages
        {
            get
            {
                if (lastMessages == null || lastMessages.Value == null)
                    lastMessages = new SessionProperty<IList<string>>("LastError", new List<string>());

                return lastMessages.Value;
            }
            set
            {
                if (lastMessages == null)
                    lastMessages = new SessionProperty<IList<string>>("LastError", new List<string>());

                lastMessages.Value = value;
            }
        }

        private static SessionProperty<MessageTypes> lastMessageType;

        public static MessageTypes LastMessageType
        {
            get
            {
                if (lastMessageType == null)
                    lastMessageType = new SessionProperty<MessageTypes>("LastMessageType", MessageTypes.Error);

                return lastMessageType.Value;
            }
            set
            {
                if (lastMessageType == null)
                    lastMessageType = new SessionProperty<MessageTypes>("LastMessageType", MessageTypes.Error);

                lastMessageType.Value = value;
            }
        }

        private static SessionProperty<int> franchiseeId;

        public static int FranchiseeId
        {
            get
            {
                if (franchiseeId == null)
                    franchiseeId = new SessionProperty<int>("FranchiseeId", -1);

                return franchiseeId.Value;
            }
            set
            {
                if (franchiseeId == null)
                    franchiseeId = new SessionProperty<int>("FranchiseeId", -1);

                franchiseeId.Value = value;
            }
        }

        private static SessionProperty<int> personalId;

        public static int PersonalId
        {
            get
            {
                if (personalId == null)
                    personalId = new SessionProperty<int>("PersonalId", -1);

                return personalId.Value;
            }
            set
            {
                if (personalId == null)
                    personalId = new SessionProperty<int>("PersonalId", -1);

                personalId.Value = value;
            }
        }

        private static SessionProperty<bool> isPrimary;

        public static bool IsPrimary
        {
            get
            {
                if (isPrimary == null)
                    isPrimary = new SessionProperty<bool>("IsPrimary", false);

                return isPrimary.Value;
            }
            set
            {
                if (isPrimary == null)
                    isPrimary = new SessionProperty<bool>("IsPrimary", false);

                isPrimary.Value = value;
            }
        }

        private static SessionProperty<PersonalTypeEnum> personalTypeId;

        public static PersonalTypeEnum PersonalTypeId
        {
            get
            {
                if (personalTypeId == null)
                    personalTypeId = new SessionProperty<PersonalTypeEnum>("PersonalTypeId", PersonalTypeEnum.UserNormal);

                return personalTypeId.Value;
            }
            set
            {
                if (personalTypeId == null)
                    personalTypeId = new SessionProperty<PersonalTypeEnum>("PersonalTypeId", PersonalTypeEnum.UserNormal);

                personalTypeId.Value = value;
            }
        }

        private static SessionProperty<int> advertiserId;

        public static int AdvertiserId
        {
            get
            {
                if (advertiserId == null)
                    advertiserId = new SessionProperty<int>("AdvertiserId", -1);

                return advertiserId.Value;
            }
            set
            {
                if (advertiserId == null)
                    advertiserId = new SessionProperty<int>("AdvertiserId", -1);

                advertiserId.Value = value;
            }
        }
    }
}
