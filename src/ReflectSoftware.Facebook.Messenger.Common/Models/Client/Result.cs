// ReflectSoftware.Facebook
// Copyright (c) 2016 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

namespace ReflectSoftware.Facebook.Messenger.Common.Models.Client
{
    public class Result
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public ResultError Error { get; set; }
    }
}
