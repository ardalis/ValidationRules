# ValidationRules

A collection of validation rules for VS Web Tests

Depends on Microsoft.VisualStudio.QualityTools.WebTestFramework.dll.

## Usage

After adding a reference to the package, you should see new validation rule(s) appear when you add a new Validation Rule to a web test in Visual Studio. The current list of validation rules is shown below.

### JsonPropertyValidationRule

The JSON Property validation rule lets you specify the path to a JSON property and its expected value. The rule passes if the response is a JSON response and it includes the specified property and it has the specified value.
