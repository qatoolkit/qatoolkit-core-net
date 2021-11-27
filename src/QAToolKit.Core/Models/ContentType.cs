using QAToolKit.Core.Exceptions;

namespace QAToolKit.Core.Models
{
    /// <summary>
    /// Built-in Http body Content Type
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
            OctetStream,
            /// <summary>
            /// multipart/form-data content type
            /// </summary>
            MultipartFormData,
            /// <summary>
            /// text/plain content type
            /// </summary>
            TextPlain,
            /// <summary>
            /// text/json content type
            /// </summary>
            TextJson,
            /// <summary>
            /// Text xml content type
            /// </summary>
            TextXml,
            /// <summary>
            /// Text CSV content type
            /// </summary>
            TextCsv,
            /// <summary>
            /// PDF content type
            /// </summary>
            Pdf
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
        /// multipart/form-data content type
        /// </summary>
        public static readonly ContentType MultipartFormData = new ContentType("multipart/form-data");
        /// <summary>
        /// text/plain content type
        /// </summary>
        public static readonly ContentType TextPlain = new ContentType("text/plain");
        /// <summary>
        /// text/json content type
        /// </summary>
        public static readonly ContentType TextJson = new ContentType("text/json");
        /// <summary>
        /// Text XML content type
        /// </summary>
        public static readonly ContentType TextXml = new ContentType("text/xml");
        /// <summary>
        /// Text CSV content type
        /// </summary>
        public static readonly ContentType TextCsv = new ContentType("text/csv");
        /// <summary>
        /// PDF content type
        /// </summary>
        public static readonly ContentType Pdf = new ContentType("application/pdf");
        
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
                throw new QAToolKitCoreException($"{value} is invalid content type. Check the documentation which types are supported.");
            }

            return (value.ToLower()) switch
            {
                "application/json" => Json,
                "application/xml" => Xml,
                "application/x-www-form-urlencoded" => FormUrlEncoded,
                "application/octet-stream" => OctetStream,
                "multipart/form-data" => MultipartFormData,
                "text/plain" => TextPlain,
                "text/json" => TextJson,
                "text/xml" => TextXml,
                "text/csv" => TextCsv,
                "application/pdf" => Pdf,
                _ => throw new QAToolKitCoreException($"{value} is invalid content type. Check the documentation which types are supported."),
            };
        }

        /// <summary>
        /// Convert to content type object from Enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ContentType From(Enumeration value)
        {
            return value switch
            {
                Enumeration.Json => Json,
                Enumeration.Xml => Xml,
                Enumeration.FormUrlEncoded => FormUrlEncoded,
                Enumeration.OctetStream => OctetStream,
                Enumeration.MultipartFormData => MultipartFormData,
                Enumeration.TextPlain => TextPlain,
                Enumeration.TextJson => TextJson,
                Enumeration.TextXml => TextXml,
                Enumeration.TextCsv => TextCsv,
                Enumeration.Pdf => Pdf,
                _ => throw new QAToolKitCoreException($"{value} is invalid content type. Check the documentation which types are supported."),
            };
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
                throw new QAToolKitCoreException($"{value} is invalid content type. Check the documentation which types are supported.");
            }

            return value._value switch
            {
                "application/json" => Enumeration.Json,
                "application/xml" => Enumeration.Xml,
                "application/x-www-form-urlencoded" => Enumeration.FormUrlEncoded,
                "application/octet-stream" => Enumeration.OctetStream,
                "multipart/form-data" => Enumeration.MultipartFormData,
                "text/plain" => Enumeration.TextPlain,
                "text/json" => Enumeration.TextJson,
                "text/xml" => Enumeration.TextXml,
                "text/csv" => Enumeration.TextCsv,
                "application/pdf" => Enumeration.Pdf,
                _ => throw new QAToolKitCoreException($"{value} is invalid content type. Check the documentation which types are supported."),
            };
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
                throw new QAToolKitCoreException($"{value} is invalid content type. Check the documentation which types are supported.");
            }

            return value switch
            {
                "application/json" => Enumeration.Json,
                "application/xml" => Enumeration.Xml,
                "application/x-www-form-urlencoded" => Enumeration.FormUrlEncoded,
                "application/octet-stream" => Enumeration.OctetStream,
                "multipart/form-data" => Enumeration.MultipartFormData,
                "text/plain" => Enumeration.TextPlain,
                "text/json" => Enumeration.TextJson,
                "text/xml" => Enumeration.TextXml,
                "text/csv" => Enumeration.TextCsv,
                "application/pdf" => Enumeration.Pdf,
                _ => throw new QAToolKitCoreException($"{value} is invalid content type. Check the documentation which types are supported."),
            };
        }
    }
}
