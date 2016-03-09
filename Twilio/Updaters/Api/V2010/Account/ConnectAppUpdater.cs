using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters.Promoter;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.ConnectApp;
using com.twilio.sdk.updaters.Updater;

namespace Twilio.Updaters.Api.V2010.Account {

    public class ConnectAppUpdater : Updater<ConnectApp> {
        private string accountSid;
        private string sid;
        private Uri authorizeRedirectUrl;
        private string companyName;
        private HttpMethod deauthorizeCallbackMethod;
        private Uri deauthorizeCallbackUrl;
        private string description;
        private string friendlyName;
        private Uri homepageUrl;
        private List<ConnectApp.Permission> permissions;
    
        /**
         * Construct a new ConnectAppUpdater
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         */
        public ConnectAppUpdater(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * The URL the user's browser will redirect to after Twilio authenticates the
         * user and obtains authorization for this Connect App.
         * 
         * @param authorizeRedirectUrl URIL Twilio sends requests when users authorize
         * @return this
         */
        public ConnectAppUpdater setAuthorizeRedirectUrl(Uri authorizeRedirectUrl) {
            this.authorizeRedirectUrl = authorizeRedirectUrl;
            return this;
        }
    
        /**
         * The URL the user's browser will redirect to after Twilio authenticates the
         * user and obtains authorization for this Connect App.
         * 
         * @param authorizeRedirectUrl URIL Twilio sends requests when users authorize
         * @return this
         */
        public ConnectAppUpdater setAuthorizeRedirectUrl(string authorizeRedirectUrl) {
            return setAuthorizeRedirectUrl(Promoter.UriFromString(authorizeRedirectUrl));
        }
    
        /**
         * The company name set for this Connect App.
         * 
         * @param companyName The company name set for this Connect App.
         * @return this
         */
        public ConnectAppUpdater setCompanyName(string companyName) {
            this.companyName = companyName;
            return this;
        }
    
        /**
         * The HTTP method to be used when making a request to the
         * `DeauthorizeCallbackUrl`.
         * 
         * @param deauthorizeCallbackMethod HTTP method Twilio WIll use making requests
         *                                  to the url
         * @return this
         */
        public ConnectAppUpdater setDeauthorizeCallbackMethod(HttpMethod deauthorizeCallbackMethod) {
            this.deauthorizeCallbackMethod = deauthorizeCallbackMethod;
            return this;
        }
    
        /**
         * The URL to which Twilio will send a request when a user de-authorizes this
         * Connect App.
         * 
         * @param deauthorizeCallbackUrl URL Twilio will send a request when a user
         *                               de-authorizes this app
         * @return this
         */
        public ConnectAppUpdater setDeauthorizeCallbackUrl(Uri deauthorizeCallbackUrl) {
            this.deauthorizeCallbackUrl = deauthorizeCallbackUrl;
            return this;
        }
    
        /**
         * The URL to which Twilio will send a request when a user de-authorizes this
         * Connect App.
         * 
         * @param deauthorizeCallbackUrl URL Twilio will send a request when a user
         *                               de-authorizes this app
         * @return this
         */
        public ConnectAppUpdater setDeauthorizeCallbackUrl(string deauthorizeCallbackUrl) {
            return setDeauthorizeCallbackUrl(Promoter.UriFromString(deauthorizeCallbackUrl));
        }
    
        /**
         * A more detailed human readable description of the Connect App.
         * 
         * @param description A more detailed human readable description
         * @return this
         */
        public ConnectAppUpdater setDescription(string description) {
            this.description = description;
            return this;
        }
    
        /**
         * A human readable name for the Connect App.
         * 
         * @param friendlyName A human readable name for the Connect App.
         * @return this
         */
        public ConnectAppUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The public URL where users can obtain more information about this Connect
         * App.
         * 
         * @param homepageUrl The URL users can obtain more information
         * @return this
         */
        public ConnectAppUpdater setHomepageUrl(Uri homepageUrl) {
            this.homepageUrl = homepageUrl;
            return this;
        }
    
        /**
         * The public URL where users can obtain more information about this Connect
         * App.
         * 
         * @param homepageUrl The URL users can obtain more information
         * @return this
         */
        public ConnectAppUpdater setHomepageUrl(string homepageUrl) {
            return setHomepageUrl(Promoter.UriFromString(homepageUrl));
        }
    
        /**
         * The set of permissions that your ConnectApp requests.
         * 
         * @param permissions The set of permissions that your ConnectApp requests.
         * @return this
         */
        public ConnectAppUpdater setPermissions(List<ConnectApp.Permission> permissions) {
            this.permissions = permissions;
            return this;
        }
    
        /**
         * The set of permissions that your ConnectApp requests.
         * 
         * @param permissions The set of permissions that your ConnectApp requests.
         * @return this
         */
        public ConnectAppUpdater setPermissions(ConnectApp.Permission permissions) {
            return setPermissions(Promoter.listOfOne(permissions));
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated ConnectApp
         */
        [Override]
        public ConnectApp execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/ConnectApps/" + this.sid + ".json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ConnectApp update failed: Unable to connect to server");
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
            
            return ConnectApp.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (authorizeRedirectUrl != null) {
                request.addPostParam("AuthorizeRedirectUrl", authorizeRedirectUrl.ToString());
            }
            
            if (companyName != null) {
                request.addPostParam("CompanyName", companyName);
            }
            
            if (deauthorizeCallbackMethod != null) {
                request.addPostParam("DeauthorizeCallbackMethod", deauthorizeCallbackMethod.ToString());
            }
            
            if (deauthorizeCallbackUrl != null) {
                request.addPostParam("DeauthorizeCallbackUrl", deauthorizeCallbackUrl.ToString());
            }
            
            if (description != null) {
                request.addPostParam("Description", description);
            }
            
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (homepageUrl != null) {
                request.addPostParam("HomepageUrl", homepageUrl.ToString());
            }
            
            if (permissions != null) {
                request.addPostParam("Permissions", permissions.ToString());
            }
        }
    }
}