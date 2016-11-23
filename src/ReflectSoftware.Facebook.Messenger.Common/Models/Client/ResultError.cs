// ReflectSoftware.Facebook
// Copyright (c) 2016 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

namespace ReflectSoftware.Facebook.Messenger.Common.Models.Client
{
    public class ResultError
    {
        public string Message { get; set; }

        public string Type { get; set; }

        public int Code { get; set; }

        public int ErrorSubcode { get; set; }

        public string FBTraceId { get; set; }
    }
}
