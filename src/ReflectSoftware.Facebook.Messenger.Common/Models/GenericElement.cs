// ReflectSoftware.Facebook
// Copyright (c) 2019 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class GenericElement
    {
        /// <summary>
        /// Bubble title
        /// has a 80 character limit
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>
        /// Bubble subtitle
        /// has a 80 character limit
        /// </summary>
        [JsonProperty("subtitle", NullValueHandling = NullValueHandling.Ignore)]
        public string Subtitle { get; set; }

        /// <summary>
        /// URL that is opened when bubble is tapped
        /// </summary>
        [JsonProperty("item_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemUrl { get; set; }

        /// <summary>
        /// Bubble image
        /// </summary>
        [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the default action.
        /// </summary>
        /// <value>
        /// The default action.
        /// </value>
        [JsonProperty("default_action", NullValueHandling = NullValueHandling.Ignore)]
        public DefaultAction DefaultAction { get; set; }

        /// <summary>
        /// Set of buttons that appear as call-to-actions
        /// Call-to-action items: 3 buttons
        /// </summary>
        [JsonProperty("buttons", NullValueHandling = NullValueHandling.Ignore)]
        public List<Button> Buttons { get; set; }
    }
}
