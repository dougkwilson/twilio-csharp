using Newtonsoft.Json;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account.Sip.CredentialList;
using Twilio.Deleters.Api.V2010.Account.Sip.CredentialList;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sip.CredentialList;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sip.CredentialList;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account.Sip.CredentialList;

namespace Twilio.Resources.Api.V2010.Account.Sip.Credentiallist {

    public class Credential : SidResource {
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param credentialListSid The credential_list_sid
         * @return CredentialReader capable of executing the read
         */
        public static CredentialReader read(string accountSid, string credentialListSid) {
            return new CredentialReader(accountSid, credentialListSid);
        }
    
        /**
         * create
         * 
         * @param accountSid The account_sid
         * @param credentialListSid The credential_list_sid
         * @param username The username
         * @param password The password
         * @return CredentialCreator capable of executing the create
         */
        public static CredentialCreator create(string accountSid, string credentialListSid, string username, string password) {
            return new CredentialCreator(accountSid, credentialListSid, username, password);
        }
    
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param credentialListSid The credential_list_sid
         * @param sid The sid
         * @return CredentialFetcher capable of executing the fetch
         */
        public static CredentialFetcher fetch(string accountSid, string credentialListSid, string sid) {
            return new CredentialFetcher(accountSid, credentialListSid, sid);
        }
    
        /**
         * update
         * 
         * @param accountSid The account_sid
         * @param credentialListSid The credential_list_sid
         * @param sid The sid
         * @param username The username
         * @param password The password
         * @return CredentialUpdater capable of executing the update
         */
        public static CredentialUpdater update(string accountSid, string credentialListSid, string sid, string username, string password) {
            return new CredentialUpdater(accountSid, credentialListSid, sid, username, password);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param credentialListSid The credential_list_sid
         * @param sid The sid
         * @return CredentialDeleter capable of executing the delete
         */
        public static CredentialDeleter delete(string accountSid, string credentialListSid, string sid) {
            return new CredentialDeleter(accountSid, credentialListSid, sid);
        }
    
        /**
         * Converts a JSON string into a Credential object
         * 
         * @param json Raw JSON string
         * @return Credential object represented by the provided JSON
         */
        public static Credential fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Credential>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("credential_list_sid")]
        private readonly string credentialListSid;
        [JsonProperty("username")]
        private readonly string username;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("uri")]
        private readonly string uri;
    
        private Credential([JsonProperty("sid")]
                           string sid, 
                           [JsonProperty("account_sid")]
                           string accountSid, 
                           [JsonProperty("credential_list_sid")]
                           string credentialListSid, 
                           [JsonProperty("username")]
                           string username, 
                           [JsonProperty("date_created")]
                           string dateCreated, 
                           [JsonProperty("date_updated")]
                           string dateUpdated, 
                           [JsonProperty("uri")]
                           string uri) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.credentialListSid = credentialListSid;
            this.username = username;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.uri = uri;
        }
    
        /**
         * @return The sid
         */
        public string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The credential_list_sid
         */
        public string GetCredentialListSid() {
            return this.credentialListSid;
        }
    
        /**
         * @return The username
         */
        public string GetUsername() {
            return this.username;
        }
    
        /**
         * @return The date_created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The uri
         */
        public string GetUri() {
            return this.uri;
        }
    }
}