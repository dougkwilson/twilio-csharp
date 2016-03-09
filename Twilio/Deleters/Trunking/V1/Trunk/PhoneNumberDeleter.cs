using Twilio.Clients;
using Twilio.Deleters.Deleter;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Trunking.V1.trunk.PhoneNumber;

namespace Twilio.Deleters.Trunking.V1.Trunk {

    public class PhoneNumberDeleter : Deleter<PhoneNumber> {
        private string trunkSid;
        private string sid;
    
        /**
         * Construct a new PhoneNumberDeleter
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         */
        public PhoneNumberDeleter(string trunkSid, string sid) {
            this.trunkSid = trunkSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the delete
         * 
         * @param client TwilioRestClient with which to make the request
         */
        [Override]
        public void execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.DELETE,
                TwilioRestClient.Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/PhoneNumbers/" + this.sid + "",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("PhoneNumber delete failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_NO_CONTENT) {
                RestException restException = RestException.fromJson(response.getStream(), client.getObjectMapper());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.getMessage(),
                    restException.getCode(),
                    restException.getMoreInfo(),
                    restException.getStatus(),
                    null
                );
            }
        }
    }
}