using Newtonsoft.Json;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Deleters.Api.V2010.Account.Recording;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Recording;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Recording;
using Twilio.Resources;

namespace Twilio.Resources.Api.V2010.Account.Recording {

    public class Transcription : SidResource {
        public enum Status {
            IN_PROGRESS="in-progress",
            COMPLETED="completed",
            FAILED="failed"
        };
    
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param recordingSid The recording_sid
         * @param sid The sid
         * @return TranscriptionFetcher capable of executing the fetch
         */
        public static TranscriptionFetcher fetch(string accountSid, string recordingSid, string sid) {
            return new TranscriptionFetcher(accountSid, recordingSid, sid);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param recordingSid The recording_sid
         * @param sid The sid
         * @return TranscriptionDeleter capable of executing the delete
         */
        public static TranscriptionDeleter delete(string accountSid, string recordingSid, string sid) {
            return new TranscriptionDeleter(accountSid, recordingSid, sid);
        }
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param recordingSid The recording_sid
         * @return TranscriptionReader capable of executing the read
         */
        public static TranscriptionReader read(string accountSid, string recordingSid) {
            return new TranscriptionReader(accountSid, recordingSid);
        }
    
        /**
         * Converts a JSON string into a Transcription object
         * 
         * @param json Raw JSON string
         * @return Transcription object represented by the provided JSON
         */
        public static Transcription fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Transcription>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("duration")]
        private readonly string duration;
        [JsonProperty("price")]
        private readonly decimal price;
        [JsonProperty("price_unit")]
        private readonly decimal priceUnit;
        [JsonProperty("recording_sid")]
        private readonly string recordingSid;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("status")]
        private readonly Transcription.Status status;
        [JsonProperty("transcription_text")]
        private readonly string transcriptionText;
        [JsonProperty("type")]
        private readonly string type;
        [JsonProperty("uri")]
        private readonly string uri;
    
        private Transcription([JsonProperty("account_sid")]
                              string accountSid, 
                              [JsonProperty("api_version")]
                              string apiVersion, 
                              [JsonProperty("date_created")]
                              string dateCreated, 
                              [JsonProperty("date_updated")]
                              string dateUpdated, 
                              [JsonProperty("duration")]
                              string duration, 
                              [JsonProperty("price")]
                              decimal price, 
                              [JsonProperty("price_unit")]
                              decimal priceUnit, 
                              [JsonProperty("recording_sid")]
                              string recordingSid, 
                              [JsonProperty("sid")]
                              string sid, 
                              [JsonProperty("status")]
                              Transcription.Status status, 
                              [JsonProperty("transcription_text")]
                              string transcriptionText, 
                              [JsonProperty("type")]
                              string type, 
                              [JsonProperty("uri")]
                              string uri) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.duration = duration;
            this.price = price;
            this.priceUnit = priceUnit;
            this.recordingSid = recordingSid;
            this.sid = sid;
            this.status = status;
            this.transcriptionText = transcriptionText;
            this.type = type;
            this.uri = uri;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The api_version
         */
        public string GetApiVersion() {
            return this.apiVersion;
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
         * @return The duration
         */
        public string GetDuration() {
            return this.duration;
        }
    
        /**
         * @return The price
         */
        public decimal GetPrice() {
            return this.price;
        }
    
        /**
         * @return The price_unit
         */
        public decimal GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return The recording_sid
         */
        public string GetRecordingSid() {
            return this.recordingSid;
        }
    
        /**
         * @return The sid
         */
        public string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The status
         */
        public Transcription.Status GetStatus() {
            return this.status;
        }
    
        /**
         * @return The transcription_text
         */
        public string GetTranscriptionText() {
            return this.transcriptionText;
        }
    
        /**
         * @return The type
         */
        public string GetTranscriptionType() {
            return this.type;
        }
    
        /**
         * @return The uri
         */
        public string GetUri() {
            return this.uri;
        }
    }
}