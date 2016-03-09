using Twilio.Clients;
using Twilio.Deleters.Deleter;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.workspace.Worker;

namespace Twilio.Deleters.Taskrouter.V1.Workspace {

    public class WorkerDeleter : Deleter<Worker> {
        private string workspaceSid;
        private string sid;
    
        /**
         * Construct a new WorkerDeleter
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         */
        public WorkerDeleter(string workspaceSid, string sid) {
            this.workspaceSid = workspaceSid;
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
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers/" + this.sid + "",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Worker delete failed: Unable to connect to server");
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