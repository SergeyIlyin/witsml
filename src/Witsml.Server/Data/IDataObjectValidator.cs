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

using System.Xml.Linq;

namespace PDS.Witsml.Server.Data
{
    /// <summary>
    /// Defines a method that can be used to validate WITSML data objects.
    /// </summary>
    /// <typeparam name="T">The data object type.</typeparam>
    public interface IDataObjectValidator<T>
    {
        /// <summary>
        /// Gets the data object being validated.
        /// </summary>
        /// <value>The data object.</value>
        T DataObject { get; }

        /// <summary>
        /// Gets the input template parser.
        /// </summary>
        /// <value>The input template parser.</value>
        WitsmlQueryParser Parser { get; }

        /// <summary>
        /// Validates the specified data object while executing a WITSML API method.
        /// </summary>
        /// <param name="function">The WITSML API method.</param>
        /// <param name="parser">The input template parser.</param>
        /// <param name="dataObject">The data object.</param>
        void Validate(Functions function, WitsmlQueryParser parser, T dataObject);

        /// <summary>
        /// Parses the specified function.
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="parser">The input template parser.</param>
        /// <returns>A copy of the parsed element.</returns>
        XElement Parse(Functions function, WitsmlQueryParser parser);
    }
}
