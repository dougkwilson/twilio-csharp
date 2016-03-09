using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account.Call;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Call;
using Twilio.Http;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account.Call;

namespace Twilio.Resources.Api.V2010.Account.Call {

    public class Feedback : Resource {
        public enum Issues {
            AUDIO_LATENCY="audio-latency",
            DIGITS_NOT_CAPTURED="digits-not-captured",
            DROPPED_CALL="dropped-call",
            IMPERFECT_AUDIO="imperfect-audio",
            INCORRECT_CALLER_ID="incorrect-caller-id",
            ONE_WAY_AUDIO="one-way-audio",
            POST_DIAL_DELAY="post-dial-delay",
            UNSOLICITED_CALL="unsolicited-call"
        };
    
        /**
         * create
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         * @param qualityScore The quality_score
         * @return FeedbackCreator capable of executing the create
         */
        public static FeedbackCreator create(string accountSid, string callSid, int qualityScore) {
            return new FeedbackCreator(accountSid, callSid, qualityScore);
        }
    
        /**
         * Fetch an instance of a feedback entry for a call
         * 
         * @param accountSid The account_sid
         * @param callSid The call sid that uniquely identifies the call
         * @return FeedbackFetcher capable of executing the fetch
         */
        public static FeedbackFetcher fetch(string accountSid, string callSid) {
            return new FeedbackFetcher(accountSid, callSid);
        }
    
        /**
         * Create or update a feedback entry for a call
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         * @param qualityScore An integer from 1 to 5
         * @return FeedbackUpdater capable of executing the update
         */
        public static FeedbackUpdater update(string accountSid, string callSid, int qualityScore) {
            return new FeedbackUpdater(accountSid, callSid, qualityScore);
        }
    
        /**
         * Converts a JSON string into a Feedback object
         * 
         * @param json Raw JSON string
         * @return Feedback object represented by the provided JSON
         */
        public static Feedback fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Feedback>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("issues")]
        private readonly List<Feedback.Issues> issues;
        [JsonProperty("quality_score")]
        private readonly int qualityScore;
        [JsonProperty("sid")]
        private readonly string sid;
    
        private Feedback([JsonProperty("account_sid")]
                         string accountSid, 
                         [JsonProperty("date_created")]
                         string dateCreated, 
                         [JsonProperty("date_updated")]
                         string dateUpdated, 
                         [JsonProperty("issues")]
                         List<Feedback.Issues> issues, 
                         [JsonProperty("quality_score")]
                         int qualityScore, 
                         [JsonProperty("sid")]
                         string sid) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.issues = issues;
            this.qualityScore = qualityScore;
            this.sid = sid;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
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
         * @return The issues
         */
        public List<Feedback.Issues> GetIssues() {
            return this.issues;
        }
    
        /**
         * @return 1 to 5 quality score
         */
        public int GetQualityScore() {
            return this.qualityScore;
        }
    
        /**
         * @return The sid
         */
        public string GetSid() {
            return this.sid;
        }
    }
}