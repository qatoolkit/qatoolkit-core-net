using System;

namespace QAToolKit.Core.Models
{
    /// <summary>
    /// Http body Content Type
    /// </summary>
    public class ContentType
    {
        /// <summary>
        /// Content type enumeration representation
        /// </summary>
        public enum Enumeration
        {
            /// <summary>
            /// Json content type
            /// </summary>
            Json,
            /// <summary>
            /// Xml content type
            /// </summary>
            Xml,
            /// <summary>
            /// Form url encoded content type
            /// </summary>
            FormUrlEncoded,
            /// <summary>
            /// Binary content type for uploading files for example
            /// </summary>
            OctetStream
        }

        private readonly string _value;

        /// <summary>
        /// application/json content type
        /// </summary>
        public static readonly ContentType Json = new ContentType("application/json");
        /// <summary>
        /// application/xml content type
        /// </summary>
        public static readonly ContentType Xml = new ContentType("application/xml");
        /// <summary>
        /// application/x-www-form-urlencoded
        /// </summary>
        public static readonly ContentType FormUrlEncoded = new ContentType("application/x-www-form-urlencoded");
        /// <summary>
        /// application/octet-stream content type
        /// </summary>
        public static readonly ContentType OctetStream = new ContentType("application/octet-stream");

        /// <summary>
        /// Content type constructor
        /// </summary>
        /// <param name="value"></param>
        public ContentType(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Return code as integer
        /// </summary>
        /// <returns></returns>
        public string Value()
        {
            return _value;
        }

        /// <summary>
        /// Convert to content type from string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ContentType From(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception($"{value} is invalid content type. Check the documentation which types are supported.");
            }

            switch (value.ToLower())
            {
                case "application/json":
                    return Json;
                case "application/xml":
                    return Xml;
                case "application/x-www-form-urlencoded":
                    return FormUrlEncoded;
                case "application/octet-stream":
                    return OctetStream;
                default:
                    throw new Exception($"{value} is invalid content type. Check the documentation which types are supported.");
            }
        }

        /// <summary>
        /// Convert to content type object from Enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ContentType From(Enumeration value)
        {
            switch (value)
            {
                case Enumeration.Json:
                    return Json;
                case Enumeration.Xml:
                    return Xml;
                case Enumeration.FormUrlEncoded:
                    return FormUrlEncoded;
                case Enumeration.OctetStream:
                    return OctetStream;
                default:
                    throw new Exception($"{value} is invalid content type. Check the documentation which types are supported.");
            }
        }

        /// <summary>
        /// Convert content type object to enumeration
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Enumeration ToEnum(ContentType value)
        {
            if (value == null)
            {
                throw new Exception($"{value} is invalid content type. Check the documentation which types are supported.");
            }

            switch (value._value)
            {
                case "application/json":
                    return Enumeration.Json;
                case "application/xml":
                    return Enumeration.Xml;
                case "application/x-www-form-urlencoded":
                    return Enumeration.FormUrlEncoded;
                case "application/octet-stream":
                    return Enumeration.OctetStream;
                default:
                    throw new Exception($"{value} is invalid content type. Check the documentation which types are supported.");
            }
        }

        /// <summary>
        /// Convert string content type to enumeration
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Enumeration ToEnum(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception($"{value} is invalid content type. Check the documentation which types are supported.");
            }

            switch (value)
            {
                case "application/json":
                    return Enumeration.Json;
                case "application/xml":
                    return Enumeration.Xml;
                case "application/x-www-form-urlencoded":
                    return Enumeration.FormUrlEncoded;
                case "application/octet-stream":
                    return Enumeration.OctetStream;
                default:
                    throw new Exception($"{value} is invalid content type. Check the documentation which types are supported.");
            }
        }
    }
}
