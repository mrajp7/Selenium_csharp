# Selenium_csharp

Selenium Automation Project written with,
 - xunit [Unit Test Framework]
 - .net core 3.1
 - design pattern - POM
 - multiple browser compatibilities [Chrome,Edge,Firefox]
 - can work on any environment (provided .net core is istalled
 
 Application under Test - Gmail.
 
 _Note: change the `username` `password` in /CrossMail.Tests/config.json and
 change browsers in `browser` supported values`chrome|edge|firefox`_
 
# Sections and its details:
 
## Dependencies (Reference and nuget packages):
- Analyzers 
  reference to codeanalysis, csharp and .net framework related items
- Frameworks
  reference to .netcoreapp [3.1] and Windowsforms [for keyboard actions]
  Note: Windowsforms library works only on windows, TODO to add support for other platform's keyboard actions
- Packages
  nuget packages to Selenium csharp
  fxcop analyzers [code analysis library]
  webdrivers - chrome,firefox, edge
  xunit

## Controls:
 - Wrapper on IWebElement to define each of the web elements behaviour.
 - The actions are defined on the element type
 - i.e., on Textbox SetText() and Clear() can be performed and not on Button.
 - Common type is defined in /CrossMail.Tests/Controls/Element.cs
 - Other types like Button | Textbox inherits Element.
 - Each webelement of page should be any of the Controls type.
 
## Driver:
  - /CrossMail.Tests/Driver/DriverFacory.cs implements the factory for creating a driver instance

## Enum:
  - defines all the enum types for the project
  
## Page:
  - represents each page of application under test
  - place to add selectors of each element to act upon.
  
## Tests:
  - Test section to add tests
  - One sample test is added [Send Email with label and attachment]
  - Testdata folder to hold data required for the test
  - Helper.cs has all the common/support methods to run the tests
  
## Testbase.cs:
  - Instantiates the web driver 
  - loads the config
  - disposes driver instance after all tests are completed
  
