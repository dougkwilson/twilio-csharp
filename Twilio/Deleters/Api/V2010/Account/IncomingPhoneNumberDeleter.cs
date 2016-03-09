using Twilio.Clients;
using Twilio.Deleters.Deleter;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.IncomingPhoneNumber;

namespace Twilio.Deleters.Api.V2010.Account {

    public class IncomingPhoneNumberDeleter : Deleter<IncomingPhoneNumber> {
        private string ownerAccountSid;
        private string sid;
    
        /**
         * Construct a new IncomingPhoneNumberDeleter
         * 
         * @param ownerAccountSid The owner_account_sid
         * @param sid Delete by unique phone-number Sid
         */
        public IncomingPhoneNumberDeleter(string ownerAccountSid, string sid) {
            this.ownerAccountSid = ownerAccountSid;
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
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.ownerAccountSid + "/IncomingPhoneNumbers/" + this.sid + ".json",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("IncomingPhoneNumber delete failed: Unable to connect to server");
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