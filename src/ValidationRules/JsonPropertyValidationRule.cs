using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace Ardalis.ValidationRules
{
    /// <summary>
    /// A JSON validation rule for Visual Studio webtest that validates a property of a JSON response.
    /// Source: https://gist.github.com/LockTar/1a90d92335d524f26604
    /// </summary>
    [DisplayName("JSON Property Validation Rule")]
    [Description("Validates the value from a JSON property in the response")]
    public class JsonPropertyValidationRule : ValidationRule
    {
        /// <summary>
        /// The name of the JSON property to validate in the JSON result.
        /// </summary>
        [DisplayName("Property name")]
        [Description("The name of the JSON property to validate in the JSON result")]
        public string JSonPropertyName { get; set; }

        /// <summary>
        /// The expected value of the property in the JSON result.
        /// </summary>
        [DisplayName("Expected value")]
        [Description("The expected value of the property in the JSON result")]
        public string ExpectedValue { get; set; }

        /// <summary>
        /// Validates if the property is available in the response and if it is the same as the expected value.
        /// </summary>
        public override void Validate(object sender, ValidationEventArgs e)
        {
            var jsonBody = JsonConvert.DeserializeObject(e.Response.BodyString);
            var o = JObject.FromObject(jsonBody);
            string value = (string)o.SelectToken(JSonPropertyName);

            if (!string.IsNullOrWhiteSpace(value))
            {
                if (value == ExpectedValue)
                {
                    e.Message = $"Property '{JSonPropertyName}' has the value '{value}' and is the same as the expected value '{ExpectedValue}'";
                    e.IsValid = true;
                }
                else
                {
                    e.Message = $"Property '{JSonPropertyName}' with value '{value}' is not the same as expected value '{ExpectedValue}'";
                    e.IsValid = false;
                }
            }
            else
            {
                e.Message = $"Property '{JSonPropertyName}' not found in response";
                e.IsValid = false;
            }
        }
    }
}