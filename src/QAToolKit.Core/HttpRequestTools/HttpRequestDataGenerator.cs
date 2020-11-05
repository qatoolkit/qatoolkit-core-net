using QAToolKit.Core.Models;
using System.Collections.Generic;

namespace QAToolKit.Core.HttpRequestTools
{
    /// <summary>
    /// Data generator for HttpRequest objects that will generate the data for the models or URLs.
    /// </summary>
    public class HttpRequestDataGenerator
    {
        private readonly IList<HttpRequest> _requests;

        /// <summary>
        /// Swagger data generator
        /// </summary>
        /// <param name="requests"></param>
        public HttpRequestDataGenerator(IList<HttpRequest> requests)
        {
            _requests = requests;
        }

        /// <summary>
        /// Generate HTTP request model data
        /// </summary>
        /// <returns></returns>
        public IList<HttpRequest> GenerateModelValues()
        {
            foreach (var request in _requests)
            {
                foreach (var body in request.RequestBodies)
                {
                    if (body.ContentType == ContentType.Enumeration.Json)
                    {
                        var propsTemp = new List<Property>();
                        foreach (var property in body.Properties)
                        {
                            propsTemp.Add(GeneratePropertyValue(property));
                        }

                        body.Properties = propsTemp;
                    }
                }
            }

            return _requests;
        }

        private Property GeneratePropertyValue(Property property)
        {
            var type = property.Value.GetType();

            switch (property.Type)
            {
                case "integer":
                    if (type.Equals(typeof(long)) || type.Equals(typeof(int)))
                    {
                        //property.Value = Faker.RandomNumber.Next(0, 1).ToString();
                    }

                    break;
                case "string":
                    if (type.Equals(typeof(string)))
                    {
                        //property.Value = Faker.Lorem.Sentence(1);
                    }

                    break;
                case "object":
                    if (type.Equals(typeof(string)))
                    {
                        // if (property.Value != null)
                        //    property.Value = Faker.Lorem.Sentence(1);
                    }

                    break;
                case "array":
                    foreach (var prop in property.Properties)
                    {
                        // prop.Value = Faker.Lorem.Sentence(1);
                    }
                    break;
                default:
                    break;
            }

            return property;
        }
    }
}
