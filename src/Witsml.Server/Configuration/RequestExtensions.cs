﻿//----------------------------------------------------------------------- 
// PDS.Witsml.Server, 2016.1
//
// Copyright 2016 Petrotechnical Data Systems
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-----------------------------------------------------------------------

namespace PDS.Witsml.Server.Configuration
{
    /// <summary>
    /// Provides extension methods that can be used to process WITSML Store API method input paramters.
    /// </summary>
    public static class RequestExtensions
    {
        /// <summary>
        /// Converts a specific request object into a common structure.
        /// </summary>
        /// <param name="request">The GetFromStore request object.</param>
        /// <returns>The request context instance.</returns>
        public static RequestContext ToContext(this WMLS_GetFromStoreRequest request)
        {
            return new RequestContext(
                function: Functions.GetFromStore,
                objectType: request.WMLtypeIn,
                xml: request.QueryIn,
                options: request.OptionsIn,
                capabilities: request.CapabilitiesIn);
        }

        /// <summary>
        /// Converts a specific request object into a common structure.
        /// </summary>
        /// <param name="request">The AddToStore request object.</param>
        /// <returns>The request context instance.</returns>
        public static RequestContext ToContext(this WMLS_AddToStoreRequest request)
        {
            return new RequestContext(
                function: Functions.AddToStore,
                objectType: request.WMLtypeIn,
                xml: request.XMLin,
                options: request.OptionsIn,
                capabilities: request.CapabilitiesIn);
        }

        /// <summary>
        /// Converts a specific request object into a common structure.
        /// </summary>
        /// <param name="request">The UpdateInStore request object.</param>
        /// <returns>The request context instance.</returns>
        public static RequestContext ToContext(this WMLS_UpdateInStoreRequest request)
        {
            return new RequestContext(
                function: Functions.UpdateInStore,
                objectType: request.WMLtypeIn,
                xml: request.XMLin,
                options: request.OptionsIn,
                capabilities: request.CapabilitiesIn);
        }

        /// <summary>
        /// Converts a specific request object into a common structure.
        /// </summary>
        /// <param name="request">The DeleteFromStore request object.</param>
        /// <returns>The request context instance.</returns>
        public static RequestContext ToContext(this WMLS_DeleteFromStoreRequest request)
        {
            return new RequestContext(
                function: Functions.DeleteFromStore,
                objectType: request.WMLtypeIn,
                xml: request.QueryIn,
                options: request.OptionsIn,
                capabilities: request.CapabilitiesIn);
        }
    }
}
