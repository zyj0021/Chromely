﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoutePath.cs" company="Chromely Projects">
//   Copyright (c) 2017-2018 Chromely Projects
// </copyright>
// <license>
//      See the LICENSE.md file in the project root for more information.
// </license>
// --------------------------------------------------------------------------------------------------------------------

namespace Chromely.Core.RestfulService
{
    /// <summary>
    /// The route path.
    /// </summary>
    public class RoutePath
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoutePath"/> class.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="path">
        /// The path.
        /// </param>
        public RoutePath(Method method, string path)
        {
            Method = method;
            var methodString = ConvertMethod(method);
            path = string.IsNullOrEmpty(path) ? string.Empty : path;
            var routeKey = $"{methodString}_{path}";
            Path = path;
            Key = routeKey.ToLower();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoutePath"/> class.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="path">
        /// The path.
        /// </param>
        public RoutePath(string method, string path)
        {
            var methodString = string.IsNullOrEmpty(method) ? "get" : method;
            path = string.IsNullOrEmpty(path) ? string.Empty : path;
            var routeKey = $"{methodString}_{path}";
            Path = path;
            Key = routeKey.ToLower();
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        public Method Method { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The valid method.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool ValidMethod(Method method)
        {
            switch (method)
            {
                case Method.GET:
                case Method.POST:
                case Method.PUT:
                case Method.DELETE:
                case Method.HEAD:
                case Method.OPTIONS:
                case Method.PATCH:
                case Method.MERGE:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// The valid method.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool ValidMethod(string method)
        {
            if (string.IsNullOrEmpty(method))
            {
                return false;
            }

            switch (method.ToUpper())
            {
                case "GET":
                case "POST":
                case "PUT":
                case "DELETE":
                case "HEAD":
                case "OPTIONS":
                case "PATCH":
                case "MERGE":
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// The convert method.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string ConvertMethod(Method method)
        {
            switch (method)
            {
                case Method.None:
                    return "None";
                case Method.GET:
                    return "GET";
                case Method.POST:
                    return "POST";
                case Method.PUT:
                    return "PUT";
                case Method.DELETE:
                    return "DELETE";
                case Method.HEAD:
                    return "HEAD";
                case Method.OPTIONS:
                    return "OPTIONS";
                case Method.PATCH:
                    return "PATCH";
                case Method.MERGE:
                    return "MERGE";
                default:
                    return "GET";
            }
        }
    }
}
