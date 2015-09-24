#region Copyright Teference
// ************************************************************************************
// <copyright file="QueryStringBuilder.cs" company="Teference">
// Copyright © Teference 2015. All right reserved.
// </copyright>
// ************************************************************************************
// <author>Jaspalsinh Chauhan</author>
// <email>jachauhan@gmail.com</email>
// <project>Teference - Shopify API - C#.NET SDK</project>
// <remarks>Borrowed from Github OneDrive/onedrive-explorer-win - sample SDK [Commit from Ryan Gregg (github@rgregg)].</remarks>
// <link>https://github.com/OneDrive/onedrive-explorer-win/blob/master/OneDriveSDK/Utility/QueryStringBuilder.cs</link>
// ************************************************************************************
#endregion

namespace Teference.Shopify.Api
{
    #region Namespace

    using System;
    using System.Collections.Generic;
    using System.Text;
    
    #endregion

    internal sealed class QueryStringBuilder
    {
        #region Variable declaration

        private readonly IDictionary<string, string> paramValueCollection = new Dictionary<string, string>();

        #endregion

        #region Constructor

        internal QueryStringBuilder()
        {
            this.StartsWith = '?';
            this.SeperatesWith = '&';
            this.ParamValueJoinsWith = '=';
        }

        internal QueryStringBuilder(string param, string value)
        {
            this[param] = value;
        }

        #endregion

        #region Properties

        internal char? StartsWith { get; set; }

        internal char SeperatesWith { get; set; }

        internal char ParamValueJoinsWith { get; set; }

        internal string[] Keys
        {
            get
            {
                var keyArray = new string[this.paramValueCollection.Keys.Count];
                this.paramValueCollection.Keys.CopyTo(keyArray, 0);
                return keyArray;
            }
        }

        internal string this[string param]
        {
            get
            {
                return this.paramValueCollection.ContainsKey(param) ? this.paramValueCollection[param] : null;
            }

            set
            {
                this.paramValueCollection[param] = value;
            }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            var tempQueryStringBuilder = new StringBuilder();
            foreach (var paramValueItem in this.paramValueCollection)
            {
                //// Add start with character.
                if ((tempQueryStringBuilder.Length == 0) && (null != this.StartsWith))
                {
                    tempQueryStringBuilder.Append(this.StartsWith);
                }

                //// Add query string parameter / value seperator.
                if ((tempQueryStringBuilder.Length > 0) && (tempQueryStringBuilder[tempQueryStringBuilder.Length - 1] != this.StartsWith))
                {
                    tempQueryStringBuilder.Append(this.SeperatesWith);
                }

                //// Normal drill.
                tempQueryStringBuilder.Append(paramValueItem.Key);
                tempQueryStringBuilder.Append(this.ParamValueJoinsWith);
                tempQueryStringBuilder.Append(Uri.EscapeDataString(paramValueItem.Value));
            }

            return tempQueryStringBuilder.ToString();
        }

        internal bool ContainsParam(string paramName)
        {
            return this.paramValueCollection.ContainsKey(paramName);
        }

        internal void Add(string param, string value)
        {
            this.paramValueCollection[param] = value;
        }

        internal void Remove(string paramName)
        {
            this.paramValueCollection.Remove(paramName);
        }

        #endregion
    }
}