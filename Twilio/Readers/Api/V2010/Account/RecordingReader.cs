using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.Recording;
using com.twilio.sdk.readers.Reader;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Api.V2010.Account {

    public class RecordingReader : Reader<Recording> {
        private string accountSid;
        private string dateCreated;
    
        /**
         * Construct a new RecordingReader
         * 
         * @param accountSid The account_sid
         */
        public RecordingReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /**
         * Only show recordings on the given date. Should be formatted as YYYY-MM-DD.
         * You can also specify inequalities
         * 
         * @param dateCreated Filter by date created
         * @return this
         */
        public RecordingReader byDateCreated(string dateCreated) {
            this.dateCreated = dateCreated;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Recording ResourceSet
         */
        [Override]
        public ResourceSet<Recording> execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Recordings.json",
                client.getAccountSid()
            );
            
            addQueryParams(request);
            
            Page<Recording> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        [Override]
        public Page<Recording> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                nextPageUri,
                client.getAccountSid()
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of Recording Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<Recording> pageForRequest(final TwilioRestClient client, final Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Recording read failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
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
            
            Page<Recording> result = new Page<>();
            result.deserialize("recordings", response.getContent(), Recording.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(final Request request) {
            if (dateCreated != null) {
                request.addQueryParam("DateCreated", dateCreated);
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}